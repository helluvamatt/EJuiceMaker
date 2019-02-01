using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EJuiceMaker.Data
{
    [Serializable]
    [XmlRoot("Inventory", Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd", IsNullable = false)]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public sealed class Inventory : NamedBaseModel
    {
        private bool _HasNewIngredientList;
        private bool _HasNewRecipeList;

        public Inventory()
        {
            _Ingredients = new IngredientCollection();
            _Recipes = new RecipeCollection();
        }

        #region Ingredients list

        private IngredientCollection _Ingredients;
        [XmlElement("Ingredients")]
        public IngredientCollection Ingredients
        {
            get => _Ingredients;
            set
            {
                if (_Ingredients != null)
                {
                    OnIngredientBindingListChanging();
                    _Ingredients.IngredientBindingListChanging -= OnIngredientBindingListChanging;
                    _Ingredients.IngredientBindingListChanged -= OnIngredientBindingListChanged;
                }
                _Ingredients = value;
                if (_Ingredients != null)
                {
                    _Ingredients.IngredientBindingListChanging += OnIngredientBindingListChanging;
                    _Ingredients.IngredientBindingListChanged += OnIngredientBindingListChanged;
                    OnIngredientBindingListChanged();
                }
            }
        }

        private void OnIngredientBindingListChanging()
        {
            _Ingredients.IngredientBindingList.ListChanged -= OnIngredientListChanged;
            _Ingredients.IngredientBindingList.ItemDeleting -= OnIngredientListItemDeleting;
        }

        private void OnIngredientBindingListChanged()
        {
            _Ingredients.IngredientBindingList.ListChanged += OnIngredientListChanged;
            _Ingredients.IngredientBindingList.ItemDeleting += OnIngredientListItemDeleting;
            _HasNewIngredientList = true;
            CheckBindings();
        }

        private void OnIngredientListItemDeleting(object sender, ItemDeletingEventArgs<Ingredient> e)
        {
            // Delete all references to the ingredient from all the affected recipes
            foreach (var recipe in RecipeList)
            {
                foreach (var toRemove in recipe.IngredientList.Where(ri => ri.IngredientID == e.Item.ID).ToList())
                {
                    recipe.IngredientList.Remove(toRemove);
                }
            }
        }

        private void OnIngredientListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IngredientList));
            OnPropertyChanged(nameof(Ingredients));
        }

        [XmlIgnore]
        public IList<Ingredient> IngredientList => _Ingredients.IngredientBindingList;

        #endregion

        #region Recipes list

        private RecipeCollection _Recipes;
        [XmlElement("Recipes")]
        public RecipeCollection Recipes
        {
            get => _Recipes;
            set
            {
                if (_Recipes != value)
                {
                    if (_Recipes != null)
                    {
                        OnRecipeBindingListChanging();
                        _Recipes.RecipeBindingListChanging -= OnRecipeBindingListChanging;
                        _Recipes.RecipeBindingListChanged -= OnRecipeBindingListChanged;
                    }
                    _Recipes = value;
                    if (_Recipes != null)
                    {
                        _Recipes.RecipeBindingListChanging += OnRecipeBindingListChanging;
                        _Recipes.RecipeBindingListChanged += OnRecipeBindingListChanged;
                        OnRecipeBindingListChanged();
                    }
                }
            }
        }

        private void OnRecipeBindingListChanging()
        {
            _Recipes.RecipeBindingList.ListChanged -= OnRecipeListChanged;
        }

        private void OnRecipeBindingListChanged()
        {
            _Recipes.RecipeBindingList.ListChanged += OnRecipeListChanged;
            _HasNewRecipeList = true;
            CheckBindings();
        }

        private void OnRecipeListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged(nameof(RecipeList));
            OnPropertyChanged(nameof(Recipes));
        }

        [XmlIgnore]
        public IList<Recipe> RecipeList => _Recipes.RecipeBindingList;

        #endregion

        private void CheckBindings()
        {
            if (_HasNewIngredientList && _HasNewRecipeList)
            {
                // Set up ingredient references
                foreach (var recipe in RecipeList)
                {
                    foreach (var ingredient in recipe.IngredientList)
                    {
                        ingredient.Ingredient = IngredientList.FirstOrDefault(ig => ig.ID == ingredient.IngredientID)
                            ?? throw new KeyNotFoundException($"A recipe references an ingredient that does not exist or was deleted. Recipe = {recipe.Name} IngredientID = {ingredient.IngredientID}");
                    }
                }
                _HasNewIngredientList = _HasNewRecipeList = false;
            }
        }
    }
    
    [Serializable]
    [XmlType("BaseModel", Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public abstract class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [XmlAttribute("ID")]
        public long ID { get; set; }
    }

    [Serializable]
    [XmlType("NamedBaseModel", Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public abstract class NamedBaseModel : BaseModel
    {
        private string _Name;
        [XmlAttribute("Name")]
        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public sealed class IngredientCollection
    {
        public IngredientCollection()
        {
            _IngredientBindingList = new BindingListEx<Ingredient>();
        }

        private BindingListEx<Ingredient> _IngredientBindingList;
        [XmlIgnore]
        internal BindingListEx<Ingredient> IngredientBindingList
        {
            get => _IngredientBindingList;
            set
            {
                if (_IngredientBindingList != value)
                {
                    IngredientBindingListChanging?.Invoke();
                    _IngredientBindingList = value;
                    IngredientBindingListChanged?.Invoke();
                }
            }
        }

        internal event Action IngredientBindingListChanging;
        internal event Action IngredientBindingListChanged;

        [XmlElement("Ingredient")]
        public Ingredient[] Ingredients
        {
            get => IngredientBindingList.ToArray();
            set
            {
                IngredientBindingList = new BindingListEx<Ingredient>();
                if (value != null) IngredientBindingList.AddAll(value);
            }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public sealed class Ingredient : NamedBaseModel
    {
        public Ingredient()
        {
            _WaterContent = 0;
            _AlcoholContent = 0;
            _NicotineDose = 0;
            _SpecificGravity = 1.0f;
            _CostPerMl = 0;
            _QtyOnHand = 0;
            _QtyLowWarn = 0;
            _QtyLowAlertEnabled = false;
            _QtyLowAlert = 0;
            _QtyLowAlertEnabled = false;
            _LastPurchaseDate = null;
        }

        private string _SKU;
        [XmlAttribute("SKU")]
        public string SKU
        {
            get => _SKU;
            set
            {
                if (_SKU != value)
                {
                    _SKU = value;
                    OnPropertyChanged(nameof(SKU));
                }
            }
        }

        private string _UPC;
        [XmlAttribute("UPC")]
        public string UPC
        {
            get => _UPC;
            set
            {
                if (_UPC != value)
                {
                    _UPC = value;
                    OnPropertyChanged(nameof(UPC));
                }
            }
        }

        private IngredientType _Type;
        [XmlAttribute("Type")]
        public IngredientType Type
        {
            get => _Type;
            set
            {
                if (_Type != value)
                {
                    _Type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        private string _Vendor;
        [XmlAttribute("Vendor")]
        public string Vendor
        {
            get => _Vendor;
            set
            {
                if (_Vendor != value)
                {
                    _Vendor = value;
                    OnPropertyChanged(nameof(Vendor));
                }
            }
        }

        private string _Manufacturer;
        [XmlAttribute("Manufacturer")]
        public string Manufacturer
        {
            get => _Manufacturer;
            set
            {
                if (_Manufacturer != value)
                {
                    _Manufacturer = value;
                    OnPropertyChanged(nameof(Manufacturer));
                }
            }
        }

        private float _PgContent;
        [XmlAttribute("PgContent")]
        public float PgContent
        {
            get => _PgContent;
            set
            {
                if (_PgContent != value)
                {
                    _PgContent = value;
                    OnPropertyChanged(nameof(PgContent));
                }
            }
        }

        private float _VgContent;
        [XmlAttribute("VgContent")]
        public float VgContent
        {
            get => _VgContent;
            set
            {
                if (_VgContent != value)
                {
                    _VgContent = value;
                    OnPropertyChanged(nameof(VgContent));
                }
            }
        }

        private float _WaterContent;
        [XmlAttribute("WaterContent")]
        [DefaultValue(0.0f)]
        public float WaterContent
        {
            get => _WaterContent;
            set
            {
                if (_WaterContent != value)
                {
                    _WaterContent = value;
                    OnPropertyChanged(nameof(WaterContent));
                }
            }
        }

        private float _AlcoholContent;
        [XmlAttribute("AlcoholContent")]
        [DefaultValue(0.0f)]
        public float AlcoholContent
        {
            get => _AlcoholContent;
            set
            {
                if (_AlcoholContent != value)
                {
                    _AlcoholContent = value;
                    OnPropertyChanged(nameof(AlcoholContent));
                }
            }
        }

        private float _NicotineDose;
        [XmlAttribute("NicotineDose")]
        [DefaultValue(0.0f)]
        public float NicotineDose
        {
            get => _NicotineDose;
            set
            {
                if (_NicotineDose != value)
                {
                    _NicotineDose = value;
                    OnPropertyChanged(nameof(NicotineDose));
                }
            }
        }

        private float _SpecificGravity;
        [XmlAttribute("SpecificGravity")]
        [DefaultValue(1.0f)]
        public float SpecificGravity
        {
            get => _SpecificGravity;
            set
            {
                if (_SpecificGravity != value)
                {
                    _SpecificGravity = value;
                    OnPropertyChanged(nameof(SpecificGravity));
                }
            }
        }

        private decimal _CostPerMl;
        [XmlAttribute("CostPerMl")]
        [DefaultValue(typeof(decimal), "0")]
        public decimal CostPerMl
        {
            get => _CostPerMl;
            set
            {
                if (_CostPerMl != value)
                {
                    _CostPerMl = value;
                    OnPropertyChanged(nameof(CostPerMl));
                }
            }
        }

        private float _QtyOnHand;
        [XmlAttribute("QtyOnHand")]
        [DefaultValue(0.0f)]
        public float QtyOnHand
        {
            get => _QtyOnHand;
            set
            {
                if (_QtyOnHand != value)
                {
                    _QtyOnHand = value;
                    OnPropertyChanged(nameof(QtyOnHand));
                }
            }
        }

        private float _QtyLowAlert;
        [XmlAttribute("QtyLowAlert")]
        [DefaultValue(0.0f)]
        public float QtyLowAlert
        {
            get => _QtyLowAlert;
            set
            {
                if (_QtyLowAlert != value)
                {
                    _QtyLowAlert = value;
                    OnPropertyChanged(nameof(QtyLowAlert));
                }
            }
        }

        private bool _QtyLowAlertEnabled;
        [XmlAttribute("QtyLowAlertEnabled")]
        [DefaultValue(false)]
        public bool QtyLowAlertEnabled
        {
            get => _QtyLowAlertEnabled;
            set
            {
                if (_QtyLowAlertEnabled != value)
                {
                    _QtyLowAlertEnabled = value;
                    OnPropertyChanged(nameof(QtyLowAlertEnabled));
                }
            }
        }

        private float _QtyLowWarn;
        [XmlAttribute("QtyLowWarn")]
        [DefaultValue(0.0f)]
        public float QtyLowWarn
        {
            get => _QtyLowWarn;
            set
            {
                if (_QtyLowWarn != value)
                {
                    _QtyLowWarn = value;
                    OnPropertyChanged(nameof(QtyLowWarn));
                }
            }
        }

        private bool _QtyLowWarnEnabled;
        [XmlAttribute("QtyLowWarnEnabled")]
        [DefaultValue(false)]
        public bool QtyLowWarnEnabled
        {
            get => _QtyLowWarnEnabled;
            set
            {
                if (_QtyLowWarnEnabled != value)
                {
                    _QtyLowWarnEnabled = value;
                    OnPropertyChanged(nameof(QtyLowWarnEnabled));
                }
            }
        }

        private DateTime? _LastPurchaseDate;
        [XmlIgnore]
        public DateTime? LastPurchaseDate
        {
            get => _LastPurchaseDate;
            set
            {
                if (_LastPurchaseDate != value)
                {
                    _LastPurchaseDate = value;
                    OnPropertyChanged(nameof(LastPurchaseDate));
                }
            }
        }

        [XmlAttribute("LastPurchaseDate")]
        internal string LastPurchaseDateValue
        {
            get => LastPurchaseDate?.ToString("o");
            set
            {
                if (!string.IsNullOrEmpty(value)) LastPurchaseDate = DateTime.ParseExact(value, "o", null);
                else LastPurchaseDate = null;
            }
        }

        [XmlIgnore]
        internal bool LastPurchaseDateValueSpecified => LastPurchaseDate.HasValue;

        private string _Notes;
        [XmlAttribute("Notes")]
        public string Notes
        {
            get => _Notes;
            set
            {
                if (_Notes != value)
                {
                    _Notes = value;
                    OnPropertyChanged(nameof(Notes));
                }
            }
        }

        public override string ToString() => Name + (!string.IsNullOrEmpty(Manufacturer) ? (" (" + Manufacturer + ")") : "");
        public override int GetHashCode() => ID.GetHashCode();
        public override bool Equals(object obj) => obj is Ingredient other && other.ID == ID;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public enum IngredientType
    {
        [XmlEnum(nameof(None))]
        None = 0,

        [XmlEnum(nameof(NicotineBase))]
        NicotineBase = 1,

        [XmlEnum(nameof(VegetableGlycerin))]
        VegetableGlycerin = 2,

        [XmlEnum(nameof(PropyleneGlycol))]
        PropyleneGlycol = 3,

        [XmlEnum(nameof(Flavor))]
        Flavor = 4,

        [XmlEnum(nameof(Other))]
        Other = 5
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public sealed class RecipeCollection
    {
        public RecipeCollection()
        {
            _RecipeBindingList = new BindingListEx<Recipe>();
        }

        private BindingListEx<Recipe> _RecipeBindingList;
        [XmlIgnore]
        internal BindingListEx<Recipe> RecipeBindingList
        {
            get => _RecipeBindingList;
            set
            {
                if (_RecipeBindingList != value)
                {
                    RecipeBindingListChanging?.Invoke();
                    _RecipeBindingList = value;
                    RecipeBindingListChanged?.Invoke();
                }
            }
        }

        internal event Action RecipeBindingListChanging;
        internal event Action RecipeBindingListChanged;

        [XmlElement("Recipe")]
        public Recipe[] Recipes
        {
            get => RecipeBindingList.ToArray();
            set
            {
                RecipeBindingList = new BindingListEx<Recipe>();
                if (value != null) RecipeBindingList.AddAll(value);
            }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public sealed class Recipe : NamedBaseModel
    {
        public Recipe()
        {
            _Ingredients = new RecipeIngredientCollection();
            _Tags = new RecipeTagCollection();
            _DefaultPg = 0.5f;
            _DefaultVg = 0.5f;
        }

        private float _DefaultNicotineDose;
        [XmlAttribute("DefaultNicotineDose")]
        public float DefaultNicotineDose
        {
            get => _DefaultNicotineDose;
            set
            {
                if (_DefaultNicotineDose != value)
                {
                    _DefaultNicotineDose = value;
                    OnPropertyChanged(nameof(DefaultNicotineDose));
                }
            }
        }

        private float _DefaultVg;
        [XmlAttribute("DefaultVg")]
        [DefaultValue(0.5f)]
        public float DefaultVg
        {
            get => _DefaultVg;
            set
            {
                if (_DefaultVg != value)
                {
                    _DefaultVg = value;
                    OnPropertyChanged(nameof(DefaultVg));
                }
            }
        }

        private float _DefaultPg;
        [XmlAttribute("DefaultPg")]
        [DefaultValue(0.5f)]
        public float DefaultPg
        {
            get => _DefaultPg;
            set
            {
                if (_DefaultPg != value)
                {
                    _DefaultPg = value;
                    OnPropertyChanged(nameof(DefaultVg));
                }
            }
        }
        
        private float _DefaultAmountMl;
        [XmlAttribute("DefaultAmountMl")]
        public float DefaultAmountMl
        {
            get => _DefaultAmountMl;
            set
            {
                if (_DefaultAmountMl != value)
                {
                    _DefaultAmountMl = value;
                    OnPropertyChanged(nameof(DefaultAmountMl));
                }
            }
        }

        private int _DaysToSteep;
        [XmlAttribute("DaysToSteep")]
        public int DaysToSteep
        {
            get => _DaysToSteep;
            set
            {
                if (_DaysToSteep != value)
                {
                    _DaysToSteep = value;
                    OnPropertyChanged(nameof(DaysToSteep));
                }
            }
        }

        private string _Notes;
        [XmlAttribute("Notes")]
        public string Notes
        {
            get => _Notes;
            set
            {
                if (_Notes != value)
                {
                    _Notes = value;
                    OnPropertyChanged(nameof(Notes));
                }
            }
        }

        #region Created property

        private DateTime? _Created;
        [XmlIgnore]
        public DateTime? Created
        {
            get => _Created;
            set
            {
                if (_Created != value)
                {
                    _Created = value;
                    OnPropertyChanged(nameof(Created));
                }
            }
        }

        [XmlAttribute("LastPurchaseDate")]
        internal string CreatedValue
        {
            get => Created?.ToString("o");
            set
            {
                if (!string.IsNullOrEmpty(value)) Created = DateTime.ParseExact(value, "o", null);
                else Created = null;
            }
        }

        [XmlIgnore]
        internal bool CreatedValueSpecified => Created.HasValue;

        #endregion

        #region Modified property

        private DateTime? _Modified;
        [XmlIgnore]
        public DateTime? Modified
        {
            get => _Modified;
            set
            {
                if (_Modified != value)
                {
                    _Modified = value;
                    OnPropertyChanged(nameof(Modified));
                }
            }
        }

        [XmlAttribute("LastPurchaseDate")]
        internal string ModifiedValue
        {
            get => Modified?.ToString("o");
            set
            {
                if (!string.IsNullOrEmpty(value)) Modified = DateTime.ParseExact(value, "o", null);
                else Modified = null;
            }
        }

        [XmlIgnore]
        internal bool ModifiedValueSpecified => Modified.HasValue;

        #endregion

        #region Tags property

        private RecipeTagCollection _Tags;
        [XmlElement("Tags")]
        public RecipeTagCollection Tags
        {
            get => _Tags;
            set
            {
                if (_Tags != null)
                {
                    OnTagBindingListChanging();
                    _Tags.TagBindingListChanging -= OnTagBindingListChanging;
                    _Tags.TagBindingListChanged -= OnTagBindingListChanged;
                }
                _Tags = value;
                if (_Tags != null)
                {
                    _Tags.TagBindingListChanging += OnTagBindingListChanging;
                    _Tags.TagBindingListChanged += OnTagBindingListChanged;
                    OnTagBindingListChanged();
                }
            }
        }

        private void OnTagBindingListChanging()
        {
            Tags.TagBindingList.ListChanged -= OnTagListChanged;
        }

        private void OnTagBindingListChanged()
        {
            Tags.TagBindingList.ListChanged += OnTagListChanged;
        }

        private void OnTagListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TagList));
            OnPropertyChanged(nameof(Tags));
        }

        public IList<RecipeTag> TagList => _Tags.TagBindingList;

        #endregion

        #region Ingredients property

        private RecipeIngredientCollection _Ingredients;
        [XmlElement("Ingredients")]
        public RecipeIngredientCollection Ingredients
        {
            get => _Ingredients;
            set
            {
                if (_Ingredients != null)
                {
                    OnIngredientBindingListChanging();
                    _Ingredients.IngredientBindingListChanging -= OnIngredientBindingListChanging;
                    _Ingredients.IngredientBindingListChanged -= OnIngredientBindingListChanged;
                }
                _Ingredients = value;
                if (_Ingredients != null)
                {
                    _Ingredients.IngredientBindingListChanging += OnIngredientBindingListChanging;
                    _Ingredients.IngredientBindingListChanged += OnIngredientBindingListChanged;
                    OnIngredientBindingListChanged();
                }
            }
        }

        private void OnIngredientBindingListChanging()
        {
            _Ingredients.IngredientBindingList.ListChanged -= OnIngredientListChanged;
        }

        private void OnIngredientBindingListChanged()
        {
            _Ingredients.IngredientBindingList.ListChanged += OnIngredientListChanged;
        }

        private void OnIngredientListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IngredientList));
            OnPropertyChanged(nameof(Ingredients));
            IngredientsListChanged?.Invoke(this, e);
        }

        [XmlIgnore]
        public IList<RecipeIngredient> IngredientList => _Ingredients?.IngredientBindingList;

        #endregion

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (!Created.HasValue) Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        public event ListChangedEventHandler IngredientsListChanged;

        public override string ToString() => Name + (TagList.Count > 0 ? (" (" + string.Join(", ", TagList.Select(t => t.Tag)) + ")") : "");
        public override int GetHashCode() => ID.GetHashCode();
        public override bool Equals(object obj) => obj is Recipe other && other.ID == ID;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public sealed class RecipeTagCollection
    {
        public RecipeTagCollection()
        {
            _TagBindingList = new BindingListEx<RecipeTag>();
        }

        private BindingListEx<RecipeTag> _TagBindingList;
        [XmlIgnore]
        internal BindingListEx<RecipeTag> TagBindingList
        {
            get => _TagBindingList;
            set
            {
                if (_TagBindingList != value)
                {
                    TagBindingListChanging?.Invoke();
                    _TagBindingList = value;
                    TagBindingListChanged?.Invoke();
                }
            }
        }

        internal event Action TagBindingListChanging;
        internal event Action TagBindingListChanged;

        [XmlElement("Tag")]
        public RecipeTag[] Tags
        {
            get => TagBindingList.ToArray();
            set
            {
                TagBindingList = new BindingListEx<RecipeTag>();
                if (value != null) TagBindingList.AddAll(value);
            }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public sealed class RecipeTag : BaseModel
    {
        private string _Tag;
        [XmlText]
        public string Tag
        {
            get => _Tag;
            set
            {
                if (_Tag != value)
                {
                    _Tag = value;
                    OnPropertyChanged(nameof(Tag));
                }
            }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public sealed class RecipeIngredientCollection
    {
        public RecipeIngredientCollection()
        {
            _IngredientBindingList = new BindingListEx<RecipeIngredient>();
        }

        private BindingListEx<RecipeIngredient> _IngredientBindingList;
        [XmlIgnore]
        internal BindingListEx<RecipeIngredient> IngredientBindingList
        {
            get => _IngredientBindingList;
            set
            {
                if (_IngredientBindingList != value)
                {
                    IngredientBindingListChanging?.Invoke();
                    _IngredientBindingList = value;
                    IngredientBindingListChanged?.Invoke();
                }
            }
        }

        internal event Action IngredientBindingListChanging;
        internal event Action IngredientBindingListChanged;

        [XmlElement("Ingredient")]
        public RecipeIngredient[] Ingredients
        {
            get => IngredientBindingList.ToArray();
            set
            {
                IngredientBindingList = new BindingListEx<RecipeIngredient>();
                if (value != null) IngredientBindingList.AddAll(value);
            }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Inventory.xsd")]
    public sealed class RecipeIngredient : BaseModel
    {
        // For XML
        internal RecipeIngredient() { }

        // For User
        public RecipeIngredient(Ingredient ingredient)
        {
            Ingredient = ingredient ?? throw new ArgumentNullException(nameof(ingredient));
        }

        private long _IngredientID;
        [XmlAttribute("IngredientID")]
        public long IngredientID
        {
            get => _IngredientID;
            set
            {
                if (_IngredientID != value)
                {
                    _IngredientID = value;
                    OnPropertyChanged(nameof(IngredientID));
                }
            }
        }

        private Ingredient _Ingredient;
        [XmlIgnore]
        public Ingredient Ingredient
        {
            get => _Ingredient;
            set
            {
                if (_Ingredient != value)
                {
                    _Ingredient = value;
                    IngredientID = _Ingredient.ID;
                    OnPropertyChanged(nameof(Ingredient));
                    OnPropertyChanged(nameof(HasNicotine));
                    OnPropertyChanged(nameof(NicotineAmount));
                }
            }
        }

        private float _Percentage;
        [XmlAttribute("Percentage")]
        [DefaultValue(0.0f)]
        public float Percentage
        {
            get => _Percentage;
            set
            {
                if (_Percentage != value)
                {
                    _Percentage = value;
                    OnPropertyChanged(nameof(Percentage));
                }
            }
        }

        [XmlIgnore]
        public bool HasNicotine => Ingredient.NicotineDose > 0;

        [XmlIgnore]
        public float NicotineAmount => Ingredient.NicotineDose;

        [XmlIgnore]
        public IngredientType IngredientType => Ingredient.Type;
    }

}
