using EJuiceMaker.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using R = EJuiceMaker.Properties.Resources;

namespace EJuiceMaker.Models
{
    internal class MixModel : INotifyPropertyChanged
    {
        private const float Epsilon = 0.000001f;

        public MixModel()
        {
            _Ingredients = new MixIngredientsModelCollection();
        }

        private Recipe _Recipe;
        public Recipe Recipe
        {
            get => _Recipe;
            set
            {
                if (_Recipe != value)
                {
                    if (_Recipe != null) _Recipe.IngredientsListChanged -= OnRecipeIngredientsListChanged;
                    _Recipe = value;
                    if (_Recipe != null) _Recipe.IngredientsListChanged += OnRecipeIngredientsListChanged;
                    OnPropertyChanged(nameof(Recipe));
                    PopulateFromRecipe();
                }
            }
        }

        private void OnRecipeIngredientsListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    _Ingredients.Insert(e.NewIndex, new MixIngredientModel(_Recipe.IngredientList[e.NewIndex]));
                    break;
                case ListChangedType.ItemChanged:
                    _Ingredients[e.NewIndex] = new MixIngredientModel(_Recipe.IngredientList[e.NewIndex]);
                    break;
                case ListChangedType.ItemDeleted:
                    _Ingredients.RemoveAt(e.NewIndex);
                    break;
                case ListChangedType.ItemMoved:
                    var oldItem = _Ingredients[e.OldIndex];
                    _Ingredients.RemoveAt(e.OldIndex);
                    _Ingredients.Insert(e.NewIndex, oldItem);
                    break;
                default:
                    _Ingredients.SetItems(_Recipe.IngredientList);
                    break;
            }
            Compute();
        }

        private float _NicotineDose;
        public float NicotineDose
        {
            get => _NicotineDose;
            set
            {
                if (_NicotineDose != value)
                {
                    _NicotineDose = value;
                    OnPropertyChanged(nameof(NicotineDose));
                    Compute();
                }
            }
        }

        private float _Volume;
        public float Volume
        {
            get => _Volume;
            set
            {
                if (_Volume != value)
                {
                    _Volume = value;
                    OnPropertyChanged(nameof(Volume));
                    Compute();
                }
            }
        }

        private float _VgPercentage;
        public float VgPercentage
        {
            get => _VgPercentage;
            set
            {
                if (_VgPercentage != value)
                {
                    _VgPercentage = value;
                    OnPropertyChanged(nameof(VgPercentage));
                    _PgPercentage = 1 - _VgPercentage;
                    OnPropertyChanged(nameof(PgPercentage));
                    Compute();
                }
            }
        }

        private float _PgPercentage;
        public float PgPercentage
        {
            get => _PgPercentage;
            set
            {
                if (_PgPercentage != value)
                {
                    _PgPercentage = value;
                    OnPropertyChanged(nameof(PgPercentage));
                    _VgPercentage = 1 - _PgPercentage;
                    OnPropertyChanged(nameof(VgPercentage));
                    Compute();
                }
            }
        }

        private string[] _Errors;
        public string[] Errors
        {
            get => _Errors;
            private set
            {
                if (_Errors != value)
                {
                    _Errors = value;
                    OnPropertyChanged(nameof(Errors));
                }
            }
        }

        private readonly MixIngredientsModelCollection _Ingredients;
        public IList<MixIngredientModel> Ingredients => _Ingredients;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void PopulateFromRecipe()
        {
            if (Recipe != null)
            {
                _Ingredients.SetItems(_Recipe.IngredientList);
                _NicotineDose = Recipe.DefaultNicotineDose;
                _Volume = Recipe.DefaultAmountMl;
                _VgPercentage = Recipe.DefaultVg;
                _PgPercentage = Recipe.DefaultPg;
            }
            else
            {
                _Ingredients.Clear();
                _NicotineDose = 0;
                _Volume = 10;
                _VgPercentage = 0.5f;
                _PgPercentage = 0.5f;
            }
            OnPropertyChanged(nameof(NicotineDose));
            OnPropertyChanged(nameof(Volume));
            OnPropertyChanged(nameof(VgPercentage));
            OnPropertyChanged(nameof(PgPercentage));
            Compute();
        }

        private void Compute()
        {
            if (!Compute(out string[] errors)) Errors = errors;
            else Errors = new string[0];
            OnPropertyChanged(nameof(Ingredients));
        }

        private bool Compute(out string[] errors)
        {
            var errorSet = new HashSet<string>();

            if (_Ingredients != null)
            {
                float vgTotalVolume, pgTotalVolume, vgRemaining, pgRemaining;
                var fillInVg = new List<MixIngredientModel>();
                var fillInPg = new List<MixIngredientModel>();
                vgTotalVolume = vgRemaining = Volume * VgPercentage;
                pgTotalVolume = pgRemaining = Volume * PgPercentage;
                foreach (var ingredient in _Ingredients)
                {
                    float ingredientVolume = 0;
                    float vgVolume = 0;
                    float pgVolume = 0;
                    switch (ingredient.IngredientType)
                    {
                        case IngredientType.NicotineBase:
                            ingredientVolume = (NicotineDose / ingredient.IngredientNicotineAmount) * Volume;
                            ingredient.Compute(ingredientVolume, out vgVolume, out pgVolume);
                            ingredient.SetVolume(ingredientVolume, Volume);
                            break;
                        case IngredientType.Flavor:
                            ingredientVolume = Volume * ingredient.IngredientPercentage;
                            ingredient.Compute(ingredientVolume, out vgVolume, out pgVolume);
                            ingredient.SetVolume(ingredientVolume, Volume);
                            break;
                        case IngredientType.VegetableGlycerin:
                            fillInVg.Add(ingredient);
                            break;
                        case IngredientType.PropyleneGlycol:
                            fillInPg.Add(ingredient);
                            break;
                    }
                    vgRemaining -= vgVolume;
                    pgRemaining -= pgVolume;
                    if (vgRemaining < -Epsilon) errorSet.Add(R.ErrorMixTooMuchVg);
                    if (pgRemaining < -Epsilon) errorSet.Add(R.ErrorMixTooMuchPg);
                }

                // Fill in VG
                if (fillInVg.Count > 0)
                {
                    float vgVolumeSplit = vgRemaining / fillInVg.Count;
                    foreach (var ingredient in fillInVg) ingredient.SetVolume(vgVolumeSplit, Volume);
                    vgRemaining = 0;
                }

                // Fill in PG
                if (fillInPg.Count > 0)
                {
                    float pgVolumeSplit = pgRemaining / fillInPg.Count;
                    foreach (var ingredient in fillInPg) ingredient.SetVolume(pgVolumeSplit, Volume);
                    pgRemaining = 0;
                }

                if (vgRemaining > Epsilon) errorSet.Add(R.ErrorMixNotEnoughVg);
                if (pgRemaining > Epsilon) errorSet.Add(R.ErrorMixNotEnoughPg);
            }
            else
            {
                errorSet.Add(R.ErrorMixNoIngredients);
            }

            errors = errorSet.ToArray();
            return errorSet.Count == 0;
        }

        private class MixIngredientsModelCollection : BindingList<MixIngredientModel>
        {
            public void SetItems(IEnumerable<RecipeIngredient> items)
            {
                RaiseListChangedEvents = false;
                Clear();
                foreach (var ingredient in items) Add(new MixIngredientModel(ingredient));
                RaiseListChangedEvents = true;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }
    }

    internal class MixIngredientModel
    {
        private readonly RecipeIngredient _Ingredient;

        public MixIngredientModel(RecipeIngredient ingredient)
        {
            _Ingredient = ingredient;
        }

        private float _ComputedPercentage;
        public float ComputedPercentage
        {
            get => _ComputedPercentage;
            private set
            {
                if (_ComputedPercentage != value)
                {
                    _ComputedPercentage = value;
                    OnPropertyChanged(nameof(ComputedPercentage));
                }
            }
        }

        private float _ComputedVolume;
        public float ComputedVolume
        {
            get => _ComputedVolume;
            private set
            {
                if (_ComputedVolume != value)
                {
                    _ComputedVolume = value;
                    OnPropertyChanged(nameof(ComputedVolume));
                    ComputedMass = ComputedVolume * _Ingredient.Ingredient.SpecificGravity;
                }
            }
        }

        private float _ComputedMass;
        public float ComputedMass
        {
            get => _ComputedMass;
            private set
            {
                if (_ComputedMass != value)
                {
                    _ComputedMass = value;
                    OnPropertyChanged(nameof(ComputedMass));
                }
            }
        }

        public string IngredientName => _Ingredient.Ingredient.Name;
        public float IngredientPercentage => _Ingredient.Percentage;
        public IngredientType IngredientType => _Ingredient.IngredientType;
        public float IngredientNicotineAmount => _Ingredient.NicotineAmount;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public void Compute(float volume, out float vgVolume, out float pgVolume)
        {
            vgVolume = volume * _Ingredient.Ingredient.VgContent;
            pgVolume = volume * _Ingredient.Ingredient.PgContent;
        }

        public void SetVolume(float volume, float totalVolume)
        {
            ComputedPercentage = volume / totalVolume;
            ComputedVolume = volume;
        }
    }
}
