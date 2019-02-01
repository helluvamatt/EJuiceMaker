using EJuiceMaker.Controls;
using EJuiceMaker.Data;
using EJuiceMaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using R = EJuiceMaker.Properties.Resources;
using Settings = EJuiceMaker.Properties.Settings;

namespace EJuiceMaker
{
    // TODO Replace DataGridView(s) (need a custom ListControl)
    public partial class MainForm : Form
    {
        private readonly InventoryManager _InventoryManager;
        private readonly MixModel _MixModel;

        public MainForm()
        {
            InitializeComponent();

            _InventoryManager = new InventoryManager();
            _MixModel = new MixModel();

            Settings.Default.PropertyChanged += OnSettingsPropertyChanged;

            tabPageEntryBindingSource.DataSource = new List<TabPageEntry>
            {
                new TabPageEntry(R.mix, R.TabMix),
                new TabPageEntry(R.recipes, R.TabRecipes),
                new TabPageEntry(R.ingredients, R.TabIngredients)
            };

            _InventoryManager.PropertyChanged += OnInventoryManagerPropertyChanged;

            if (!string.IsNullOrEmpty(Settings.Default.LastInventoryFile)) _InventoryManager.Load(Settings.Default.LastInventoryFile);
            else _InventoryManager.New("new_inventory.xml");

            numMixVolume.DataBindings.Add(nameof(NumericUpDown.Value), _MixModel, nameof(MixModel.Volume), false, DataSourceUpdateMode.OnPropertyChanged);
            numMixNicotine.DataBindings.Add(nameof(NumericUpDown.Value), _MixModel, nameof(MixModel.NicotineDose), false, DataSourceUpdateMode.OnPropertyChanged);
            numMixVg.DataBindings.Add(nameof(NumericUpDown.Value), _MixModel, nameof(MixModel.VgPercentage), false, DataSourceUpdateMode.OnPropertyChanged);
            numMixPg.DataBindings.Add(nameof(NumericUpDown.Value), _MixModel, nameof(MixModel.PgPercentage), false, DataSourceUpdateMode.OnPropertyChanged);
            _MixModel.PropertyChanged += OnMixModelPropertyChanged;
            mixIngredientModelBindingSource.DataSource = _MixModel.Ingredients;
            SetErrors();

            cmbRecipeIngredientAdd.ComboBox.DataSource = ingredientBindingSource;

            SetTitle();
            saveInventoryToolStripMenuItem.Enabled = _InventoryManager.IsDirty;
        }

        #region Form event handlers

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_InventoryManager.IsDirty)
            {
                var result = MessageBox.Show(this, string.Format(R.UnsavedChanges, _InventoryManager.Inventory.Name), R.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    OnSaveInventoryToolStripMenuItemClick(this, e);
                }
                else if (result == DialogResult.Cancel) e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void OnSettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Settings.Default.Save();
        }

        private void OnNewInventoryToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_InventoryManager.IsDirty)
            {
                var result = MessageBox.Show(this, string.Format(R.UnsavedChanges, _InventoryManager.Inventory.Name), R.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    OnSaveInventoryToolStripMenuItemClick(sender, e);
                }
                else if (result == DialogResult.Cancel) return;
            }
            Settings.Default.LastInventoryFile = string.Empty;
            _InventoryManager.New("new_inventory.xml");
        }

        private void OnOpenInventoryToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (_InventoryManager.IsDirty)
            {
                var result = MessageBox.Show(this, string.Format(R.UnsavedChanges, _InventoryManager.Inventory.Name), R.AppTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    OnSaveInventoryToolStripMenuItemClick(sender, e);
                }
                else if (result == DialogResult.Cancel) return;
            }
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    Settings.Default.LastInventoryFile = openFileDialog.FileName;
                    _InventoryManager.Load(Settings.Default.LastInventoryFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, string.Format(R.ErrorFailedToLoadInventory, ex.Message), R.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnSaveInventoryToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Settings.Default.LastInventoryFile))
            {
                OnSaveInventoryAsToolStripMenuItemClick(sender, e);
            }
            else
            {
                try
                {
                    _InventoryManager.Save(Settings.Default.LastInventoryFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, string.Format(R.ErrorFailedToSaveInventory, ex.Message), R.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnSaveInventoryAsToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Settings.Default.LastInventoryFile)) saveFileDialog.InitialDirectory = Path.GetDirectoryName(Settings.Default.LastInventoryFile);
            saveFileDialog.FileName = _InventoryManager.Inventory.Name;
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    Settings.Default.LastInventoryFile = saveFileDialog.FileName;
                    _InventoryManager.Inventory.Name = Path.GetFileName(Settings.Default.LastInventoryFile);
                    _InventoryManager.Save(Settings.Default.LastInventoryFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, string.Format(R.ErrorFailedToSaveInventory, ex.Message), R.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void TabPageEntryBindingSource_PositionChanged(object sender, EventArgs e)
        {
            panelSwitcher.SelectedIndex = tabPageEntryBindingSource.Position;
        }

        private void DrawTabSwitcherItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index > -1 && e.Index < tabPageEntryBindingSource.Count)
            {
                var item = (TabPageEntry)tabPageEntryBindingSource[e.Index];
                var iconBounds = new Rectangle(e.Bounds.X + (e.Bounds.Height - 32) / 2, e.Bounds.Y + (e.Bounds.Height - 32) / 2, 32, 32);
                e.Graphics.DrawSvg(item.Icon, e.ForeColor, iconBounds);
                var textBounds = e.Graphics.MeasureString(item.Text, e.Font);
                e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.X + e.Bounds.Height, e.Bounds.Y + (e.Bounds.Height - textBounds.Height) / 2);
            }
            e.DrawFocusRectangle();
        }

        private void OnInventoryManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (nameof(InventoryManager.Inventory) == e.PropertyName)
            {
                ingredientBindingSource.DataSource = _InventoryManager.Inventory.IngredientList;
                recipeBindingSource.DataSource = _InventoryManager.Inventory.RecipeList;
                SetTitle();
            }
            if (nameof(InventoryManager.IsDirty) == e.PropertyName)
            {
                SetTitle();
                saveInventoryToolStripMenuItem.Enabled = _InventoryManager.IsDirty;
            }
        }

        private void SetTitle()
        {
            var sb = new StringBuilder(1024);
            sb.Append(R.AppTitle);
            sb.Append(" - ");
            sb.Append(_InventoryManager.Inventory.Name);
            if (_InventoryManager.IsDirty) sb.Append("*");
            Text = sb.ToString();
        }

        #endregion

        #region Mix tab event handlers
        
        private void OnMixEditRecipeClick(object sender, EventArgs e)
        {
            tabPageEntryBindingSource.Position = 1;
        }

        private void OnMixSaveDefaultsClick(object sender, EventArgs e)
        {
            _MixModel.Recipe.DefaultAmountMl = _MixModel.Volume;
            _MixModel.Recipe.DefaultNicotineDose = _MixModel.NicotineDose;
            _MixModel.Recipe.DefaultVg = _MixModel.VgPercentage;
            _MixModel.Recipe.DefaultPg = _MixModel.PgPercentage;
        }

        private void OnMixResetDefaultsClick(object sender, EventArgs e)
        {
            _MixModel.Volume = _MixModel.Recipe.DefaultAmountMl;
            _MixModel.NicotineDose = _MixModel.Recipe.DefaultNicotineDose;
            _MixModel.VgPercentage = _MixModel.Recipe.DefaultVg;
            _MixModel.PgPercentage = _MixModel.Recipe.DefaultPg;
        }

        private void OnMixModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (nameof(MixModel.Errors) == e.PropertyName)
            {
                SetErrors();
            }
            if (nameof(MixModel.Ingredients) == e.PropertyName)
            {
                gridMixResults.Invalidate();
            }
        }

        private void OnGridMixResultsCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridMixResults.Columns[e.ColumnIndex] == gridMixResultsIngredientTypeColumn)
            {
                var value = (IngredientType)e.Value;
                string str =  R.ResourceManager.GetString($"Description_{nameof(IngredientType)}_{value}") ?? value.ToString();
                if (value == IngredientType.NicotineBase && mixIngredientModelBindingSource[e.RowIndex] is MixIngredientModel ingredientModel)
                    str += string.Format(" ({0:0.0} {1})", ingredientModel.IngredientNicotineAmount, R.Unit_mgmL);
                e.Value = str;
            }
        }

        private void SetErrors()
        {
            if (_MixModel.Errors != null && _MixModel.Errors.Length > 0)
            {
                lblMixValid.Image = R.cross_shield;
                lblMixValidMessage.Text = string.Join("\r\n", _MixModel.Errors);
                lblMixValidMessage.ForeColor = Color.Red;
            }
            else
            {
                lblMixValid.Image = R.tick_shield;
                lblMixValidMessage.Text = R.MixValid;
                lblMixValidMessage.ForeColor = Color.FromArgb(0, 0x99, 0);
            }
        }

        #endregion

        #region Recipes tab event handlers

        private void OnRecipeBindingSourceCurrentChanged(object sender, EventArgs e)
        {
            if (recipeBindingSource.Current is Recipe recipe)
            {
                layoutRecipeDetails.Enabled = true;
                recipeIngredientBindingSource.DataSource = recipe.IngredientList;
                txtRecipeTags.DataSource = recipe.TagList;
                _MixModel.Recipe = recipe;
            }
            else
            {
                recipeIngredientBindingSource.DataSource = null;
                layoutRecipeDetails.Enabled = false;
                txtRecipeTags.DataSource = null;
                _MixModel.Recipe = null;
            }
        }

        private void OnRecipesAddClick(object sender, EventArgs e)
        {
            recipeBindingSource.Add(_InventoryManager.CreateNew<Recipe>(R.NewRecipeName));
            recipeBindingSource.Position = recipeBindingSource.Position - 1;
        }

        private void OnRecipesRemoveClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, R.AreYouSureDeleteRecipe, R.AreYouSure, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                recipeBindingSource.RemoveCurrent();
            }
        }

        private void OnRecipesClearClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, R.AreYouSureDeleteAllRecipes, R.AreYouSure, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                recipeBindingSource.Clear();
            }
        }

        private void OnRecipeIngredientAddClick(object sender, EventArgs e)
        {
            if (ingredientBindingSource.Current is Ingredient ingredient)
            {
                recipeIngredientBindingSource.Add(_InventoryManager.CreateNew(ingredient));
                recipeIngredientBindingSource.Position = recipeIngredientBindingSource.Count - 1;
            }
        }

        private void OnRecipeIngredientRemoveClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, R.AreYouSureDeleteRecipeIngredient, R.AreYouSure, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                recipeIngredientBindingSource.RemoveCurrent();
            }
        }

        private void OnRecipeIngredientClearClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, R.AreYouSureDeleteAllRecipeIngredients, R.AreYouSure, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                recipeIngredientBindingSource.Clear();
            }
        }

        private void OnGridRecipeIngredientsCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridRecipeIngredients.Columns[e.ColumnIndex] == gridRecipeIngredientsTypeColumn)
            {
                var value = (IngredientType)e.Value;
                e.Value = R.ResourceManager.GetString($"Description_{nameof(IngredientType)}_{value}") ?? value.ToString();
            }
            else if (gridRecipeIngredients.Columns[e.ColumnIndex] == gridRecipeIngredientsPercentageColumn)
            {
                var ingredientType = ((RecipeIngredient)recipeIngredientBindingSource[e.RowIndex]).Ingredient.Type;
                if (ingredientType != IngredientType.Flavor && ingredientType != IngredientType.Other)
                {
                    e.Value = R.NotAvailableAbbrv;
                    e.CellStyle.ForeColor = SystemColors.GrayText;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
                }
            }
        }

        private void OnGridRecipeIngredientsCellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (gridRecipeIngredients.Columns[e.ColumnIndex] == gridRecipeIngredientsPercentageColumn)
            {
                var ingredientType = ((RecipeIngredient)recipeIngredientBindingSource[e.RowIndex]).Ingredient.Type;
                e.Cancel = ingredientType != IngredientType.Flavor && ingredientType != IngredientType.Other;
            }
        }

        private void OnRecipeTagsAdding(object sender, TagAddingEventArgs e)
        {
            if (recipeBindingSource.Current is Recipe recipe)
            {
                var newTag = _InventoryManager.CreateNew<RecipeTag>();
                newTag.Tag = e.Value;
                recipe.TagList.Add(newTag);
            }
        }

        #endregion

        #region Ingredients tab event handlers

        private void OnIngredientBindingSourceCurrentChanged(object sender, EventArgs e)
        {
            if (ingredientBindingSource.Current is Ingredient current)
            {
                propertyGridIngredients.SelectedObject = new IngredientModel(current);
                propertyGridIngredients.Enabled = true;
            }
            else
            {
                propertyGridIngredients.SelectedObject = null;
                propertyGridIngredients.Enabled = false;
            }
        }

        private void OnIngredientsAddClick(object sender, EventArgs e)
        {
            ingredientBindingSource.Add(_InventoryManager.CreateNew<Ingredient>(R.NewIngredientName));
            ingredientBindingSource.Position = ingredientBindingSource.Count - 1;
        }

        private void OnIngredientsDeleteClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, R.AreYouSureDeleteIngredient, R.AreYouSure, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ingredientBindingSource.RemoveCurrent();
            }
        }

        private void OnIngredientsClearClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, R.AreYouSureDeleteAllIngredients, R.AreYouSure, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ingredientBindingSource.Clear();
            }
        }

        #endregion
    }
}
