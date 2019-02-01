namespace EJuiceMaker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lstTabs = new EJuiceMaker.Controls.ListBoxEx();
            this.tabPageEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveInventoryAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSwitcher = new EJuiceMaker.Controls.PanelSwitcher();
            this.tabPageMix = new System.Windows.Forms.TabPage();
            this.layoutMix = new System.Windows.Forms.TableLayoutPanel();
            this.lblMixVolume = new System.Windows.Forms.Label();
            this.lblMixNicotine = new System.Windows.Forms.Label();
            this.lblMixVg = new System.Windows.Forms.Label();
            this.lblMixPg = new System.Windows.Forms.Label();
            this.numMixVg = new EJuiceMaker.Controls.PercentNumericUpDown();
            this.numMixPg = new EJuiceMaker.Controls.PercentNumericUpDown();
            this.numMixNicotine = new EJuiceMaker.Controls.UnitNumericUpDown();
            this.numMixVolume = new EJuiceMaker.Controls.UnitNumericUpDown();
            this.lblMixValid = new System.Windows.Forms.Label();
            this.lblMixValidMessage = new System.Windows.Forms.Label();
            this.gridMixResults = new System.Windows.Forms.DataGridView();
            this.gridMixResultsIngredientNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMixResultsIngredientTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMixResultsComputedPercentageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMixResultsComputedVolumeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridMixResultsComputedMassColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mixIngredientModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbMixRecipe = new System.Windows.Forms.ComboBox();
            this.recipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMix = new System.Windows.Forms.ToolStrip();
            this.btnMixEditRecipe = new System.Windows.Forms.ToolStripButton();
            this.btnMixResetDefaults = new System.Windows.Forms.ToolStripButton();
            this.btnMixSaveDefaults = new System.Windows.Forms.ToolStripButton();
            this.tabPageRecipes = new System.Windows.Forms.TabPage();
            this.layoutRecipes = new System.Windows.Forms.SplitContainer();
            this.layoutRecipeDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.lblRecipeDefaultNicotineDose = new System.Windows.Forms.Label();
            this.lblDefaultAmountToMake = new System.Windows.Forms.Label();
            this.lblDaysToSteep = new System.Windows.Forms.Label();
            this.lblRecipeModified = new System.Windows.Forms.Label();
            this.lblRecipeCreated = new System.Windows.Forms.Label();
            this.lblRecipeModifiedValue = new System.Windows.Forms.Label();
            this.lblRecipeCreatedValue = new System.Windows.Forms.Label();
            this.lblRecipeNotes = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.txtRecipeNotes = new System.Windows.Forms.TextBox();
            this.numRecipeDefaultNicotineDose = new EJuiceMaker.Controls.UnitNumericUpDown();
            this.numRecipeDefaultAmountToMake = new EJuiceMaker.Controls.UnitNumericUpDown();
            this.numRecipeDaysToSteep = new System.Windows.Forms.NumericUpDown();
            this.numRecipeDefaultVG = new EJuiceMaker.Controls.PercentNumericUpDown();
            this.numRecipeDefaultPG = new EJuiceMaker.Controls.PercentNumericUpDown();
            this.lblRecipeDefaultVG = new System.Windows.Forms.Label();
            this.lblRecipeDefaultPG = new System.Windows.Forms.Label();
            this.lblRecipeTags = new System.Windows.Forms.Label();
            this.txtRecipeTags = new EJuiceMaker.Controls.TagsListBox();
            this.toolStripRecipeIngredients = new System.Windows.Forms.ToolStrip();
            this.cmbRecipeIngredientAdd = new System.Windows.Forms.ToolStripComboBox();
            this.btnRecipeIngredientAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRecipeIngredientRemove = new System.Windows.Forms.ToolStripButton();
            this.btnRecipeIngredientClear = new System.Windows.Forms.ToolStripButton();
            this.gridRecipeIngredients = new System.Windows.Forms.DataGridView();
            this.gridRecipeIngredientsIngredientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRecipeIngredientsPercentageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRecipeIngredientsTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeIngredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbRecipes = new System.Windows.Forms.ComboBox();
            this.toolStripRecipes = new System.Windows.Forms.ToolStrip();
            this.btnRecipesAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRecipesRemove = new System.Windows.Forms.ToolStripButton();
            this.btnRecipesClear = new System.Windows.Forms.ToolStripButton();
            this.tabPageIngredients = new System.Windows.Forms.TabPage();
            this.propertyGridIngredients = new System.Windows.Forms.PropertyGrid();
            this.comboBoxIngredients = new System.Windows.Forms.ComboBox();
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripIngredients = new System.Windows.Forms.ToolStrip();
            this.btnIngredientsAdd = new System.Windows.Forms.ToolStripButton();
            this.btnIngredientsClear = new System.Windows.Forms.ToolStripButton();
            this.btnIngredientsDelete = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.recipeTagBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageEntryBindingSource)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.panelSwitcher.SuspendLayout();
            this.tabPageMix.SuspendLayout();
            this.layoutMix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMixVg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMixPg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMixNicotine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMixVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMixResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixIngredientModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).BeginInit();
            this.toolStripMix.SuspendLayout();
            this.tabPageRecipes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutRecipes)).BeginInit();
            this.layoutRecipes.Panel1.SuspendLayout();
            this.layoutRecipes.Panel2.SuspendLayout();
            this.layoutRecipes.SuspendLayout();
            this.layoutRecipeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDefaultNicotineDose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDefaultAmountToMake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDaysToSteep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDefaultVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDefaultPG)).BeginInit();
            this.toolStripRecipeIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecipeIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeIngredientBindingSource)).BeginInit();
            this.toolStripRecipes.SuspendLayout();
            this.tabPageIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            this.toolStripIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipeTagBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lstTabs
            // 
            resources.ApplyResources(this.lstTabs, "lstTabs");
            this.lstTabs.DataSource = this.tabPageEntryBindingSource;
            this.lstTabs.DisplayMember = "Text";
            this.lstTabs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstTabs.FormattingEnabled = true;
            this.lstTabs.Name = "lstTabs";
            this.lstTabs.DrawItemEx += new System.EventHandler<System.Windows.Forms.DrawItemEventArgs>(this.DrawTabSwitcherItem);
            // 
            // tabPageEntryBindingSource
            // 
            this.tabPageEntryBindingSource.DataSource = typeof(EJuiceMaker.Controls.TabPageEntry);
            this.tabPageEntryBindingSource.PositionChanged += new System.EventHandler(this.TabPageEntryBindingSource_PositionChanged);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.mainMenuStrip, "mainMenuStrip");
            this.mainMenuStrip.Name = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newInventoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.openInventoryToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveInventoryToolStripMenuItem,
            this.saveInventoryAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newInventoryToolStripMenuItem
            // 
            this.newInventoryToolStripMenuItem.Image = global::EJuiceMaker.Properties.Resources.page_white;
            this.newInventoryToolStripMenuItem.Name = "newInventoryToolStripMenuItem";
            resources.ApplyResources(this.newInventoryToolStripMenuItem, "newInventoryToolStripMenuItem");
            this.newInventoryToolStripMenuItem.Click += new System.EventHandler(this.OnNewInventoryToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // openInventoryToolStripMenuItem
            // 
            this.openInventoryToolStripMenuItem.Image = global::EJuiceMaker.Properties.Resources.folder_vertical_open;
            this.openInventoryToolStripMenuItem.Name = "openInventoryToolStripMenuItem";
            resources.ApplyResources(this.openInventoryToolStripMenuItem, "openInventoryToolStripMenuItem");
            this.openInventoryToolStripMenuItem.Click += new System.EventHandler(this.OnOpenInventoryToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // saveInventoryToolStripMenuItem
            // 
            this.saveInventoryToolStripMenuItem.Image = global::EJuiceMaker.Properties.Resources.diskette;
            this.saveInventoryToolStripMenuItem.Name = "saveInventoryToolStripMenuItem";
            resources.ApplyResources(this.saveInventoryToolStripMenuItem, "saveInventoryToolStripMenuItem");
            this.saveInventoryToolStripMenuItem.Click += new System.EventHandler(this.OnSaveInventoryToolStripMenuItemClick);
            // 
            // saveInventoryAsToolStripMenuItem
            // 
            this.saveInventoryAsToolStripMenuItem.Image = global::EJuiceMaker.Properties.Resources.save_as;
            this.saveInventoryAsToolStripMenuItem.Name = "saveInventoryAsToolStripMenuItem";
            resources.ApplyResources(this.saveInventoryAsToolStripMenuItem, "saveInventoryAsToolStripMenuItem");
            this.saveInventoryAsToolStripMenuItem.Click += new System.EventHandler(this.OnSaveInventoryAsToolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
            // 
            // panelSwitcher
            // 
            resources.ApplyResources(this.panelSwitcher, "panelSwitcher");
            this.panelSwitcher.Controls.Add(this.tabPageMix);
            this.panelSwitcher.Controls.Add(this.tabPageRecipes);
            this.panelSwitcher.Controls.Add(this.tabPageIngredients);
            this.panelSwitcher.Name = "panelSwitcher";
            this.panelSwitcher.SelectedIndex = 0;
            // 
            // tabPageMix
            // 
            this.tabPageMix.Controls.Add(this.layoutMix);
            this.tabPageMix.Controls.Add(this.cmbMixRecipe);
            this.tabPageMix.Controls.Add(this.toolStripMix);
            resources.ApplyResources(this.tabPageMix, "tabPageMix");
            this.tabPageMix.Name = "tabPageMix";
            this.tabPageMix.UseVisualStyleBackColor = true;
            // 
            // layoutMix
            // 
            resources.ApplyResources(this.layoutMix, "layoutMix");
            this.layoutMix.Controls.Add(this.lblMixVolume, 0, 0);
            this.layoutMix.Controls.Add(this.lblMixNicotine, 0, 1);
            this.layoutMix.Controls.Add(this.lblMixVg, 0, 2);
            this.layoutMix.Controls.Add(this.lblMixPg, 0, 3);
            this.layoutMix.Controls.Add(this.numMixVg, 1, 2);
            this.layoutMix.Controls.Add(this.numMixPg, 1, 3);
            this.layoutMix.Controls.Add(this.numMixNicotine, 1, 1);
            this.layoutMix.Controls.Add(this.numMixVolume, 1, 0);
            this.layoutMix.Controls.Add(this.lblMixValid, 0, 4);
            this.layoutMix.Controls.Add(this.lblMixValidMessage, 1, 4);
            this.layoutMix.Controls.Add(this.gridMixResults, 0, 5);
            this.layoutMix.Name = "layoutMix";
            // 
            // lblMixVolume
            // 
            resources.ApplyResources(this.lblMixVolume, "lblMixVolume");
            this.lblMixVolume.Name = "lblMixVolume";
            // 
            // lblMixNicotine
            // 
            resources.ApplyResources(this.lblMixNicotine, "lblMixNicotine");
            this.lblMixNicotine.Name = "lblMixNicotine";
            // 
            // lblMixVg
            // 
            resources.ApplyResources(this.lblMixVg, "lblMixVg");
            this.lblMixVg.Name = "lblMixVg";
            // 
            // lblMixPg
            // 
            resources.ApplyResources(this.lblMixPg, "lblMixPg");
            this.lblMixPg.Name = "lblMixPg";
            // 
            // numMixVg
            // 
            resources.ApplyResources(this.numMixVg, "numMixVg");
            this.numMixVg.DecimalPlaces = 1;
            this.numMixVg.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numMixVg.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMixVg.Name = "numMixVg";
            // 
            // numMixPg
            // 
            resources.ApplyResources(this.numMixPg, "numMixPg");
            this.numMixPg.DecimalPlaces = 1;
            this.numMixPg.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numMixPg.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMixPg.Name = "numMixPg";
            // 
            // numMixNicotine
            // 
            resources.ApplyResources(this.numMixNicotine, "numMixNicotine");
            this.numMixNicotine.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMixNicotine.Name = "numMixNicotine";
            // 
            // numMixVolume
            // 
            resources.ApplyResources(this.numMixVolume, "numMixVolume");
            this.numMixVolume.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMixVolume.Name = "numMixVolume";
            // 
            // lblMixValid
            // 
            resources.ApplyResources(this.lblMixValid, "lblMixValid");
            this.lblMixValid.Name = "lblMixValid";
            // 
            // lblMixValidMessage
            // 
            resources.ApplyResources(this.lblMixValidMessage, "lblMixValidMessage");
            this.lblMixValidMessage.Name = "lblMixValidMessage";
            // 
            // gridMixResults
            // 
            this.gridMixResults.AllowUserToAddRows = false;
            this.gridMixResults.AllowUserToDeleteRows = false;
            this.gridMixResults.AllowUserToResizeRows = false;
            this.gridMixResults.AutoGenerateColumns = false;
            this.gridMixResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMixResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridMixResultsIngredientNameColumn,
            this.gridMixResultsIngredientTypeColumn,
            this.gridMixResultsComputedPercentageColumn,
            this.gridMixResultsComputedVolumeColumn,
            this.gridMixResultsComputedMassColumn});
            this.layoutMix.SetColumnSpan(this.gridMixResults, 2);
            this.gridMixResults.DataSource = this.mixIngredientModelBindingSource;
            resources.ApplyResources(this.gridMixResults, "gridMixResults");
            this.gridMixResults.Name = "gridMixResults";
            this.gridMixResults.ReadOnly = true;
            this.gridMixResults.RowHeadersVisible = false;
            this.gridMixResults.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnGridMixResultsCellFormatting);
            // 
            // gridMixResultsIngredientNameColumn
            // 
            this.gridMixResultsIngredientNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridMixResultsIngredientNameColumn.DataPropertyName = "IngredientName";
            resources.ApplyResources(this.gridMixResultsIngredientNameColumn, "gridMixResultsIngredientNameColumn");
            this.gridMixResultsIngredientNameColumn.Name = "gridMixResultsIngredientNameColumn";
            this.gridMixResultsIngredientNameColumn.ReadOnly = true;
            // 
            // gridMixResultsIngredientTypeColumn
            // 
            this.gridMixResultsIngredientTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridMixResultsIngredientTypeColumn.DataPropertyName = "IngredientType";
            resources.ApplyResources(this.gridMixResultsIngredientTypeColumn, "gridMixResultsIngredientTypeColumn");
            this.gridMixResultsIngredientTypeColumn.Name = "gridMixResultsIngredientTypeColumn";
            this.gridMixResultsIngredientTypeColumn.ReadOnly = true;
            // 
            // gridMixResultsComputedPercentageColumn
            // 
            this.gridMixResultsComputedPercentageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridMixResultsComputedPercentageColumn.DataPropertyName = "ComputedPercentage";
            dataGridViewCellStyle11.Format = "P";
            dataGridViewCellStyle11.NullValue = null;
            this.gridMixResultsComputedPercentageColumn.DefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.gridMixResultsComputedPercentageColumn, "gridMixResultsComputedPercentageColumn");
            this.gridMixResultsComputedPercentageColumn.Name = "gridMixResultsComputedPercentageColumn";
            this.gridMixResultsComputedPercentageColumn.ReadOnly = true;
            // 
            // gridMixResultsComputedVolumeColumn
            // 
            this.gridMixResultsComputedVolumeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridMixResultsComputedVolumeColumn.DataPropertyName = "ComputedVolume";
            dataGridViewCellStyle12.Format = "0.000 mL";
            dataGridViewCellStyle12.NullValue = null;
            this.gridMixResultsComputedVolumeColumn.DefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(this.gridMixResultsComputedVolumeColumn, "gridMixResultsComputedVolumeColumn");
            this.gridMixResultsComputedVolumeColumn.Name = "gridMixResultsComputedVolumeColumn";
            this.gridMixResultsComputedVolumeColumn.ReadOnly = true;
            // 
            // gridMixResultsComputedMassColumn
            // 
            this.gridMixResultsComputedMassColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridMixResultsComputedMassColumn.DataPropertyName = "ComputedMass";
            dataGridViewCellStyle13.Format = "0.000 g";
            dataGridViewCellStyle13.NullValue = null;
            this.gridMixResultsComputedMassColumn.DefaultCellStyle = dataGridViewCellStyle13;
            resources.ApplyResources(this.gridMixResultsComputedMassColumn, "gridMixResultsComputedMassColumn");
            this.gridMixResultsComputedMassColumn.Name = "gridMixResultsComputedMassColumn";
            this.gridMixResultsComputedMassColumn.ReadOnly = true;
            // 
            // mixIngredientModelBindingSource
            // 
            this.mixIngredientModelBindingSource.DataSource = typeof(EJuiceMaker.Models.MixIngredientModel);
            // 
            // cmbMixRecipe
            // 
            resources.ApplyResources(this.cmbMixRecipe, "cmbMixRecipe");
            this.cmbMixRecipe.DataSource = this.recipeBindingSource;
            this.cmbMixRecipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMixRecipe.FormattingEnabled = true;
            this.cmbMixRecipe.Name = "cmbMixRecipe";
            // 
            // recipeBindingSource
            // 
            this.recipeBindingSource.DataSource = typeof(EJuiceMaker.Data.Recipe);
            this.recipeBindingSource.CurrentChanged += new System.EventHandler(this.OnRecipeBindingSourceCurrentChanged);
            // 
            // toolStripMix
            // 
            this.toolStripMix.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMix.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMixEditRecipe,
            this.btnMixResetDefaults,
            this.btnMixSaveDefaults});
            resources.ApplyResources(this.toolStripMix, "toolStripMix");
            this.toolStripMix.Name = "toolStripMix";
            this.toolStripMix.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // btnMixEditRecipe
            // 
            this.btnMixEditRecipe.Image = global::EJuiceMaker.Properties.Resources.calculator_edit;
            resources.ApplyResources(this.btnMixEditRecipe, "btnMixEditRecipe");
            this.btnMixEditRecipe.Name = "btnMixEditRecipe";
            this.btnMixEditRecipe.Click += new System.EventHandler(this.OnMixEditRecipeClick);
            // 
            // btnMixResetDefaults
            // 
            this.btnMixResetDefaults.Image = global::EJuiceMaker.Properties.Resources.house;
            resources.ApplyResources(this.btnMixResetDefaults, "btnMixResetDefaults");
            this.btnMixResetDefaults.Name = "btnMixResetDefaults";
            this.btnMixResetDefaults.Click += new System.EventHandler(this.OnMixResetDefaultsClick);
            // 
            // btnMixSaveDefaults
            // 
            this.btnMixSaveDefaults.Image = global::EJuiceMaker.Properties.Resources.house_go;
            resources.ApplyResources(this.btnMixSaveDefaults, "btnMixSaveDefaults");
            this.btnMixSaveDefaults.Name = "btnMixSaveDefaults";
            this.btnMixSaveDefaults.Click += new System.EventHandler(this.OnMixSaveDefaultsClick);
            // 
            // tabPageRecipes
            // 
            this.tabPageRecipes.Controls.Add(this.layoutRecipes);
            this.tabPageRecipes.Controls.Add(this.cmbRecipes);
            this.tabPageRecipes.Controls.Add(this.toolStripRecipes);
            resources.ApplyResources(this.tabPageRecipes, "tabPageRecipes");
            this.tabPageRecipes.Name = "tabPageRecipes";
            this.tabPageRecipes.UseVisualStyleBackColor = true;
            // 
            // layoutRecipes
            // 
            resources.ApplyResources(this.layoutRecipes, "layoutRecipes");
            this.layoutRecipes.Name = "layoutRecipes";
            // 
            // layoutRecipes.Panel1
            // 
            this.layoutRecipes.Panel1.Controls.Add(this.layoutRecipeDetails);
            // 
            // layoutRecipes.Panel2
            // 
            this.layoutRecipes.Panel2.Controls.Add(this.toolStripRecipeIngredients);
            this.layoutRecipes.Panel2.Controls.Add(this.gridRecipeIngredients);
            // 
            // layoutRecipeDetails
            // 
            resources.ApplyResources(this.layoutRecipeDetails, "layoutRecipeDetails");
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeName, 0, 0);
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeDefaultNicotineDose, 0, 3);
            this.layoutRecipeDetails.Controls.Add(this.lblDefaultAmountToMake, 0, 4);
            this.layoutRecipeDetails.Controls.Add(this.lblDaysToSteep, 0, 5);
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeModified, 0, 9);
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeCreated, 0, 8);
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeModifiedValue, 1, 9);
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeCreatedValue, 1, 8);
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeNotes, 0, 6);
            this.layoutRecipeDetails.Controls.Add(this.txtRecipeName, 1, 0);
            this.layoutRecipeDetails.Controls.Add(this.txtRecipeNotes, 1, 6);
            this.layoutRecipeDetails.Controls.Add(this.numRecipeDefaultNicotineDose, 1, 3);
            this.layoutRecipeDetails.Controls.Add(this.numRecipeDefaultAmountToMake, 1, 4);
            this.layoutRecipeDetails.Controls.Add(this.numRecipeDaysToSteep, 1, 5);
            this.layoutRecipeDetails.Controls.Add(this.numRecipeDefaultVG, 1, 1);
            this.layoutRecipeDetails.Controls.Add(this.numRecipeDefaultPG, 1, 2);
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeDefaultVG, 0, 1);
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeDefaultPG, 0, 2);
            this.layoutRecipeDetails.Controls.Add(this.lblRecipeTags, 0, 7);
            this.layoutRecipeDetails.Controls.Add(this.txtRecipeTags, 1, 7);
            this.layoutRecipeDetails.Name = "layoutRecipeDetails";
            // 
            // lblRecipeName
            // 
            resources.ApplyResources(this.lblRecipeName, "lblRecipeName");
            this.lblRecipeName.Name = "lblRecipeName";
            // 
            // lblRecipeDefaultNicotineDose
            // 
            resources.ApplyResources(this.lblRecipeDefaultNicotineDose, "lblRecipeDefaultNicotineDose");
            this.lblRecipeDefaultNicotineDose.Name = "lblRecipeDefaultNicotineDose";
            // 
            // lblDefaultAmountToMake
            // 
            resources.ApplyResources(this.lblDefaultAmountToMake, "lblDefaultAmountToMake");
            this.lblDefaultAmountToMake.Name = "lblDefaultAmountToMake";
            // 
            // lblDaysToSteep
            // 
            resources.ApplyResources(this.lblDaysToSteep, "lblDaysToSteep");
            this.lblDaysToSteep.Name = "lblDaysToSteep";
            // 
            // lblRecipeModified
            // 
            resources.ApplyResources(this.lblRecipeModified, "lblRecipeModified");
            this.lblRecipeModified.Name = "lblRecipeModified";
            // 
            // lblRecipeCreated
            // 
            resources.ApplyResources(this.lblRecipeCreated, "lblRecipeCreated");
            this.lblRecipeCreated.Name = "lblRecipeCreated";
            // 
            // lblRecipeModifiedValue
            // 
            resources.ApplyResources(this.lblRecipeModifiedValue, "lblRecipeModifiedValue");
            this.lblRecipeModifiedValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "Modified", true));
            this.lblRecipeModifiedValue.Name = "lblRecipeModifiedValue";
            // 
            // lblRecipeCreatedValue
            // 
            resources.ApplyResources(this.lblRecipeCreatedValue, "lblRecipeCreatedValue");
            this.lblRecipeCreatedValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "Created", true));
            this.lblRecipeCreatedValue.Name = "lblRecipeCreatedValue";
            // 
            // lblRecipeNotes
            // 
            resources.ApplyResources(this.lblRecipeNotes, "lblRecipeNotes");
            this.lblRecipeNotes.Name = "lblRecipeNotes";
            // 
            // txtRecipeName
            // 
            resources.ApplyResources(this.txtRecipeName, "txtRecipeName");
            this.txtRecipeName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "Name", true));
            this.txtRecipeName.Name = "txtRecipeName";
            // 
            // txtRecipeNotes
            // 
            this.txtRecipeNotes.AcceptsReturn = true;
            this.txtRecipeNotes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipeBindingSource, "Notes", true));
            resources.ApplyResources(this.txtRecipeNotes, "txtRecipeNotes");
            this.txtRecipeNotes.Name = "txtRecipeNotes";
            // 
            // numRecipeDefaultNicotineDose
            // 
            resources.ApplyResources(this.numRecipeDefaultNicotineDose, "numRecipeDefaultNicotineDose");
            this.numRecipeDefaultNicotineDose.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.recipeBindingSource, "DefaultNicotineDose", true));
            this.numRecipeDefaultNicotineDose.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRecipeDefaultNicotineDose.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numRecipeDefaultNicotineDose.Name = "numRecipeDefaultNicotineDose";
            // 
            // numRecipeDefaultAmountToMake
            // 
            resources.ApplyResources(this.numRecipeDefaultAmountToMake, "numRecipeDefaultAmountToMake");
            this.numRecipeDefaultAmountToMake.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.recipeBindingSource, "DefaultAmountMl", true));
            this.numRecipeDefaultAmountToMake.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numRecipeDefaultAmountToMake.Name = "numRecipeDefaultAmountToMake";
            // 
            // numRecipeDaysToSteep
            // 
            resources.ApplyResources(this.numRecipeDaysToSteep, "numRecipeDaysToSteep");
            this.numRecipeDaysToSteep.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.recipeBindingSource, "DaysToSteep", true));
            this.numRecipeDaysToSteep.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numRecipeDaysToSteep.Name = "numRecipeDaysToSteep";
            // 
            // numRecipeDefaultVG
            // 
            resources.ApplyResources(this.numRecipeDefaultVG, "numRecipeDefaultVG");
            this.numRecipeDefaultVG.DecimalPlaces = 1;
            this.numRecipeDefaultVG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numRecipeDefaultVG.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRecipeDefaultVG.Name = "numRecipeDefaultVG";
            // 
            // numRecipeDefaultPG
            // 
            resources.ApplyResources(this.numRecipeDefaultPG, "numRecipeDefaultPG");
            this.numRecipeDefaultPG.DecimalPlaces = 1;
            this.numRecipeDefaultPG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numRecipeDefaultPG.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRecipeDefaultPG.Name = "numRecipeDefaultPG";
            // 
            // lblRecipeDefaultVG
            // 
            resources.ApplyResources(this.lblRecipeDefaultVG, "lblRecipeDefaultVG");
            this.lblRecipeDefaultVG.Name = "lblRecipeDefaultVG";
            // 
            // lblRecipeDefaultPG
            // 
            resources.ApplyResources(this.lblRecipeDefaultPG, "lblRecipeDefaultPG");
            this.lblRecipeDefaultPG.Name = "lblRecipeDefaultPG";
            // 
            // lblRecipeTags
            // 
            resources.ApplyResources(this.lblRecipeTags, "lblRecipeTags");
            this.lblRecipeTags.Name = "lblRecipeTags";
            // 
            // txtRecipeTags
            // 
            resources.ApplyResources(this.txtRecipeTags, "txtRecipeTags");
            this.txtRecipeTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecipeTags.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRecipeTags.Name = "txtRecipeTags";
            this.txtRecipeTags.TabStop = true;
            this.txtRecipeTags.TagBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtRecipeTags.TagPadding = new System.Windows.Forms.Padding(3);
            this.txtRecipeTags.TagAdding += new System.EventHandler<EJuiceMaker.Controls.TagAddingEventArgs>(this.OnRecipeTagsAdding);
            // 
            // toolStripRecipeIngredients
            // 
            this.toolStripRecipeIngredients.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripRecipeIngredients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbRecipeIngredientAdd,
            this.btnRecipeIngredientAdd,
            this.btnRecipeIngredientRemove,
            this.btnRecipeIngredientClear});
            resources.ApplyResources(this.toolStripRecipeIngredients, "toolStripRecipeIngredients");
            this.toolStripRecipeIngredients.Name = "toolStripRecipeIngredients";
            // 
            // cmbRecipeIngredientAdd
            // 
            this.cmbRecipeIngredientAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRecipeIngredientAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRecipeIngredientAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipeIngredientAdd.Name = "cmbRecipeIngredientAdd";
            resources.ApplyResources(this.cmbRecipeIngredientAdd, "cmbRecipeIngredientAdd");
            // 
            // btnRecipeIngredientAdd
            // 
            this.btnRecipeIngredientAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnRecipeIngredientAdd, "btnRecipeIngredientAdd");
            this.btnRecipeIngredientAdd.Name = "btnRecipeIngredientAdd";
            this.btnRecipeIngredientAdd.Click += new System.EventHandler(this.OnRecipeIngredientAddClick);
            // 
            // btnRecipeIngredientRemove
            // 
            this.btnRecipeIngredientRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnRecipeIngredientRemove, "btnRecipeIngredientRemove");
            this.btnRecipeIngredientRemove.Name = "btnRecipeIngredientRemove";
            this.btnRecipeIngredientRemove.Click += new System.EventHandler(this.OnRecipeIngredientRemoveClick);
            // 
            // btnRecipeIngredientClear
            // 
            this.btnRecipeIngredientClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRecipeIngredientClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnRecipeIngredientClear, "btnRecipeIngredientClear");
            this.btnRecipeIngredientClear.Name = "btnRecipeIngredientClear";
            this.btnRecipeIngredientClear.Click += new System.EventHandler(this.OnRecipeIngredientClearClick);
            // 
            // gridRecipeIngredients
            // 
            this.gridRecipeIngredients.AllowUserToAddRows = false;
            this.gridRecipeIngredients.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.gridRecipeIngredients, "gridRecipeIngredients");
            this.gridRecipeIngredients.AutoGenerateColumns = false;
            this.gridRecipeIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRecipeIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridRecipeIngredientsIngredientColumn,
            this.gridRecipeIngredientsPercentageColumn,
            this.gridRecipeIngredientsTypeColumn});
            this.gridRecipeIngredients.DataSource = this.recipeIngredientBindingSource;
            this.gridRecipeIngredients.Name = "gridRecipeIngredients";
            this.gridRecipeIngredients.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.OnGridRecipeIngredientsCellBeginEdit);
            this.gridRecipeIngredients.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnGridRecipeIngredientsCellFormatting);
            // 
            // gridRecipeIngredientsIngredientColumn
            // 
            this.gridRecipeIngredientsIngredientColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridRecipeIngredientsIngredientColumn.DataPropertyName = "Ingredient";
            resources.ApplyResources(this.gridRecipeIngredientsIngredientColumn, "gridRecipeIngredientsIngredientColumn");
            this.gridRecipeIngredientsIngredientColumn.Name = "gridRecipeIngredientsIngredientColumn";
            this.gridRecipeIngredientsIngredientColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gridRecipeIngredientsPercentageColumn
            // 
            this.gridRecipeIngredientsPercentageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridRecipeIngredientsPercentageColumn.DataPropertyName = "Percentage";
            dataGridViewCellStyle14.Format = "P";
            dataGridViewCellStyle14.NullValue = null;
            this.gridRecipeIngredientsPercentageColumn.DefaultCellStyle = dataGridViewCellStyle14;
            resources.ApplyResources(this.gridRecipeIngredientsPercentageColumn, "gridRecipeIngredientsPercentageColumn");
            this.gridRecipeIngredientsPercentageColumn.Name = "gridRecipeIngredientsPercentageColumn";
            // 
            // gridRecipeIngredientsTypeColumn
            // 
            this.gridRecipeIngredientsTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridRecipeIngredientsTypeColumn.DataPropertyName = "IngredientType";
            dataGridViewCellStyle15.NullValue = null;
            this.gridRecipeIngredientsTypeColumn.DefaultCellStyle = dataGridViewCellStyle15;
            resources.ApplyResources(this.gridRecipeIngredientsTypeColumn, "gridRecipeIngredientsTypeColumn");
            this.gridRecipeIngredientsTypeColumn.Name = "gridRecipeIngredientsTypeColumn";
            this.gridRecipeIngredientsTypeColumn.ReadOnly = true;
            this.gridRecipeIngredientsTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // recipeIngredientBindingSource
            // 
            this.recipeIngredientBindingSource.AllowNew = false;
            this.recipeIngredientBindingSource.DataSource = typeof(EJuiceMaker.Data.RecipeIngredient);
            // 
            // cmbRecipes
            // 
            resources.ApplyResources(this.cmbRecipes, "cmbRecipes");
            this.cmbRecipes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRecipes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRecipes.DataSource = this.recipeBindingSource;
            this.cmbRecipes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipes.FormattingEnabled = true;
            this.cmbRecipes.Name = "cmbRecipes";
            // 
            // toolStripRecipes
            // 
            this.toolStripRecipes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripRecipes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRecipesAdd,
            this.btnRecipesRemove,
            this.btnRecipesClear});
            resources.ApplyResources(this.toolStripRecipes, "toolStripRecipes");
            this.toolStripRecipes.Name = "toolStripRecipes";
            this.toolStripRecipes.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // btnRecipesAdd
            // 
            this.btnRecipesAdd.Image = global::EJuiceMaker.Properties.Resources.add;
            resources.ApplyResources(this.btnRecipesAdd, "btnRecipesAdd");
            this.btnRecipesAdd.Name = "btnRecipesAdd";
            this.btnRecipesAdd.Click += new System.EventHandler(this.OnRecipesAddClick);
            // 
            // btnRecipesRemove
            // 
            this.btnRecipesRemove.Image = global::EJuiceMaker.Properties.Resources.delete;
            resources.ApplyResources(this.btnRecipesRemove, "btnRecipesRemove");
            this.btnRecipesRemove.Name = "btnRecipesRemove";
            this.btnRecipesRemove.Click += new System.EventHandler(this.OnRecipesRemoveClick);
            // 
            // btnRecipesClear
            // 
            this.btnRecipesClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRecipesClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRecipesClear.Image = global::EJuiceMaker.Properties.Resources.bin_empty;
            resources.ApplyResources(this.btnRecipesClear, "btnRecipesClear");
            this.btnRecipesClear.Name = "btnRecipesClear";
            this.btnRecipesClear.Click += new System.EventHandler(this.OnRecipesClearClick);
            // 
            // tabPageIngredients
            // 
            this.tabPageIngredients.Controls.Add(this.propertyGridIngredients);
            this.tabPageIngredients.Controls.Add(this.comboBoxIngredients);
            this.tabPageIngredients.Controls.Add(this.toolStripIngredients);
            resources.ApplyResources(this.tabPageIngredients, "tabPageIngredients");
            this.tabPageIngredients.Name = "tabPageIngredients";
            this.tabPageIngredients.UseVisualStyleBackColor = true;
            // 
            // propertyGridIngredients
            // 
            resources.ApplyResources(this.propertyGridIngredients, "propertyGridIngredients");
            this.propertyGridIngredients.Name = "propertyGridIngredients";
            this.propertyGridIngredients.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGridIngredients.ToolbarVisible = false;
            // 
            // comboBoxIngredients
            // 
            resources.ApplyResources(this.comboBoxIngredients, "comboBoxIngredients");
            this.comboBoxIngredients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxIngredients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxIngredients.DataSource = this.ingredientBindingSource;
            this.comboBoxIngredients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIngredients.FormattingEnabled = true;
            this.comboBoxIngredients.Name = "comboBoxIngredients";
            // 
            // ingredientBindingSource
            // 
            this.ingredientBindingSource.AllowNew = false;
            this.ingredientBindingSource.DataSource = typeof(EJuiceMaker.Data.Ingredient);
            this.ingredientBindingSource.CurrentChanged += new System.EventHandler(this.OnIngredientBindingSourceCurrentChanged);
            // 
            // toolStripIngredients
            // 
            this.toolStripIngredients.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripIngredients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIngredientsAdd,
            this.btnIngredientsClear,
            this.btnIngredientsDelete});
            resources.ApplyResources(this.toolStripIngredients, "toolStripIngredients");
            this.toolStripIngredients.Name = "toolStripIngredients";
            this.toolStripIngredients.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // btnIngredientsAdd
            // 
            this.btnIngredientsAdd.Image = global::EJuiceMaker.Properties.Resources.add;
            resources.ApplyResources(this.btnIngredientsAdd, "btnIngredientsAdd");
            this.btnIngredientsAdd.Name = "btnIngredientsAdd";
            this.btnIngredientsAdd.Click += new System.EventHandler(this.OnIngredientsAddClick);
            // 
            // btnIngredientsClear
            // 
            this.btnIngredientsClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnIngredientsClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIngredientsClear.Image = global::EJuiceMaker.Properties.Resources.bin_empty;
            resources.ApplyResources(this.btnIngredientsClear, "btnIngredientsClear");
            this.btnIngredientsClear.Name = "btnIngredientsClear";
            this.btnIngredientsClear.Click += new System.EventHandler(this.OnIngredientsClearClick);
            // 
            // btnIngredientsDelete
            // 
            this.btnIngredientsDelete.Image = global::EJuiceMaker.Properties.Resources.delete;
            resources.ApplyResources(this.btnIngredientsDelete, "btnIngredientsDelete");
            this.btnIngredientsDelete.Name = "btnIngredientsDelete";
            this.btnIngredientsDelete.Click += new System.EventHandler(this.OnIngredientsDeleteClick);
            // 
            // saveFileDialog
            // 
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // recipeTagBindingSource
            // 
            this.recipeTagBindingSource.DataSource = typeof(EJuiceMaker.Data.RecipeTag);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSwitcher);
            this.Controls.Add(this.lstTabs);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            ((System.ComponentModel.ISupportInitialize)(this.tabPageEntryBindingSource)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.panelSwitcher.ResumeLayout(false);
            this.tabPageMix.ResumeLayout(false);
            this.tabPageMix.PerformLayout();
            this.layoutMix.ResumeLayout(false);
            this.layoutMix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMixVg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMixPg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMixNicotine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMixVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMixResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mixIngredientModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).EndInit();
            this.toolStripMix.ResumeLayout(false);
            this.toolStripMix.PerformLayout();
            this.tabPageRecipes.ResumeLayout(false);
            this.tabPageRecipes.PerformLayout();
            this.layoutRecipes.Panel1.ResumeLayout(false);
            this.layoutRecipes.Panel2.ResumeLayout(false);
            this.layoutRecipes.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutRecipes)).EndInit();
            this.layoutRecipes.ResumeLayout(false);
            this.layoutRecipeDetails.ResumeLayout(false);
            this.layoutRecipeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDefaultNicotineDose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDefaultAmountToMake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDaysToSteep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDefaultVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecipeDefaultPG)).EndInit();
            this.toolStripRecipeIngredients.ResumeLayout(false);
            this.toolStripRecipeIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecipeIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeIngredientBindingSource)).EndInit();
            this.toolStripRecipes.ResumeLayout(false);
            this.toolStripRecipes.PerformLayout();
            this.tabPageIngredients.ResumeLayout(false);
            this.tabPageIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
            this.toolStripIngredients.ResumeLayout(false);
            this.toolStripIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipeTagBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ListBoxEx lstTabs;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private Controls.PanelSwitcher panelSwitcher;
        private System.Windows.Forms.TabPage tabPageMix;
        private System.Windows.Forms.TabPage tabPageRecipes;
        private System.Windows.Forms.BindingSource tabPageEntryBindingSource;
        private System.Windows.Forms.TabPage tabPageIngredients;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveInventoryAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolStripIngredients;
        private System.Windows.Forms.ToolStripButton btnIngredientsClear;
        private System.Windows.Forms.ToolStripButton btnIngredientsAdd;
        private System.Windows.Forms.ToolStripButton btnIngredientsDelete;
        private System.Windows.Forms.BindingSource ingredientBindingSource;
        private System.Windows.Forms.PropertyGrid propertyGridIngredients;
        private System.Windows.Forms.ComboBox comboBoxIngredients;
        private System.Windows.Forms.ToolStrip toolStripRecipes;
        private System.Windows.Forms.ToolStripButton btnRecipesAdd;
        private System.Windows.Forms.ToolStripButton btnRecipesRemove;
        private System.Windows.Forms.ToolStripButton btnRecipesClear;
        private System.Windows.Forms.ComboBox cmbRecipes;
        private System.Windows.Forms.BindingSource recipeBindingSource;
        private System.Windows.Forms.TableLayoutPanel layoutRecipeDetails;
        private System.Windows.Forms.Label lblRecipeName;
        private System.Windows.Forms.Label lblRecipeDefaultNicotineDose;
        private System.Windows.Forms.Label lblDefaultAmountToMake;
        private System.Windows.Forms.Label lblDaysToSteep;
        private System.Windows.Forms.Label lblRecipeModified;
        private System.Windows.Forms.Label lblRecipeCreated;
        private System.Windows.Forms.Label lblRecipeModifiedValue;
        private System.Windows.Forms.Label lblRecipeCreatedValue;
        private System.Windows.Forms.Label lblRecipeNotes;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.TextBox txtRecipeNotes;
        private Controls.UnitNumericUpDown numRecipeDefaultNicotineDose;
        private Controls.UnitNumericUpDown numRecipeDefaultAmountToMake;
        private System.Windows.Forms.NumericUpDown numRecipeDaysToSteep;
        private System.Windows.Forms.DataGridView gridRecipeIngredients;
        private System.Windows.Forms.BindingSource recipeIngredientBindingSource;
        private System.Windows.Forms.SplitContainer layoutRecipes;
        private System.Windows.Forms.ToolStrip toolStripRecipeIngredients;
        private System.Windows.Forms.ToolStripButton btnRecipeIngredientAdd;
        private System.Windows.Forms.ToolStripButton btnRecipeIngredientRemove;
        private System.Windows.Forms.ToolStripButton btnRecipeIngredientClear;
        private System.Windows.Forms.ToolStripComboBox cmbRecipeIngredientAdd;
        private Controls.PercentNumericUpDown numRecipeDefaultVG;
        private Controls.PercentNumericUpDown numRecipeDefaultPG;
        private System.Windows.Forms.Label lblRecipeDefaultVG;
        private System.Windows.Forms.Label lblRecipeDefaultPG;
        private System.Windows.Forms.ComboBox cmbMixRecipe;
        private System.Windows.Forms.ToolStrip toolStripMix;
        private System.Windows.Forms.TableLayoutPanel layoutMix;
        private System.Windows.Forms.Label lblRecipeTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRecipeIngredientsIngredientColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRecipeIngredientsPercentageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRecipeIngredientsTypeColumn;
        private Controls.TagsListBox txtRecipeTags;
        private System.Windows.Forms.BindingSource recipeTagBindingSource;
        private System.Windows.Forms.Label lblMixVolume;
        private System.Windows.Forms.Label lblMixNicotine;
        private System.Windows.Forms.Label lblMixVg;
        private System.Windows.Forms.Label lblMixPg;
        private Controls.PercentNumericUpDown numMixVg;
        private Controls.PercentNumericUpDown numMixPg;
        private Controls.UnitNumericUpDown numMixNicotine;
        private Controls.UnitNumericUpDown numMixVolume;
        private System.Windows.Forms.Label lblMixValid;
        private System.Windows.Forms.Label lblMixValidMessage;
        private System.Windows.Forms.DataGridView gridMixResults;
        private System.Windows.Forms.BindingSource mixIngredientModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMixResultsIngredientNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMixResultsIngredientTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMixResultsComputedPercentageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMixResultsComputedVolumeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMixResultsComputedMassColumn;
        private System.Windows.Forms.ToolStripButton btnMixEditRecipe;
        private System.Windows.Forms.ToolStripButton btnMixSaveDefaults;
        private System.Windows.Forms.ToolStripButton btnMixResetDefaults;
    }
}

