using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace EJuiceMaker.Data
{
    public sealed class InventoryManager : INotifyPropertyChanged
    {
        private readonly Dictionary<Type, long> _Sequences;

        private Inventory _Inventory;
        private bool _IsDirty;
        private bool _SkipDirty;

        public InventoryManager()
        {
            _Sequences = new Dictionary<Type, long>();
        }

        #region Inventory property

        public Inventory Inventory
        {
            get => _Inventory;
            private set
            {
                if (_Inventory != value)
                {
                    if (_Inventory != null) _Inventory.PropertyChanged -= OnInventoryPropertyChanged;
                    _Inventory = value;
                    if (_Inventory != null) _Inventory.PropertyChanged += OnInventoryPropertyChanged;
                    _Sequences.Clear();
                    OnPropertyChanged(nameof(Inventory));
                }
            }
        }

        private void OnInventoryPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!_SkipDirty) IsDirty = true;
        }
        
        #endregion

        #region IsDirty property

        public bool IsDirty
        {
            get => _IsDirty;
            set
            {
                if (_IsDirty != value)
                {
                    _IsDirty = value;
                    OnPropertyChanged(nameof(IsDirty));
                }
            }
        }

        #endregion

        #region Loading / Saving

        public void New(string name)
        {
            Inventory = new Inventory { Name = name };
        }

        public void Load(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                Load(stream);
            }
        }

        public void Load(Stream stream)
        {
            var xml = new XmlSerializer(typeof(Inventory), "http://schneenet.com/EJuiceMaker/Inventory.xsd");
            _SkipDirty = true;
            Inventory = (Inventory)xml.Deserialize(stream);
            _SkipDirty = false;
        }

        public void Save(string filename)
        {
            // Backup existing, if needed
            if (File.Exists(filename))
            {
                string backupFilename = filename + ".bak";
                if (File.Exists(backupFilename)) File.Delete(backupFilename);
                File.Move(filename, backupFilename);
            }

            // Write new file. If the backup failed for some reason, I want this to fail so we don't lose a backup
            using (var stream = new FileStream(filename, FileMode.CreateNew, FileAccess.Write))
            {
                Save(stream);
            }
        }

        public void Save(Stream stream)
        {
            if (Inventory == null) return;
            var xml = new XmlSerializer(typeof(Inventory), "http://schneenet.com/EJuiceMaker/Inventory.xsd");
            xml.Serialize(stream, Inventory);
            IsDirty = false;
        }

        #endregion

        #region CreateNew

        public T CreateNew<T>() where T : BaseModel, new() => Inventory != null ? new T { ID = SequenceNextVal(typeof(T)) } : null;
        public T CreateNew<T>(string nameFormat) where T : NamedBaseModel, new() => Inventory != null ? new T { ID = SequenceNextVal(typeof(T)), Name = CreateNewName<T>(nameFormat) } : null;

        public RecipeIngredient CreateNew(Ingredient ingredient) => Inventory != null ? new RecipeIngredient(ingredient) { ID = SequenceNextVal(typeof(RecipeIngredient)) } : null;

        private string CreateNewName<T>(string nameFormat)
        {
            if (typeof(T) == typeof(Ingredient))
            {
                int newIndex = 0;
                string newName;
                do
                {
                    newIndex++;
                    newName = string.Format(nameFormat, newIndex);
                } while (Inventory.IngredientList.Any(i => i.Name == newName));
                return newName;
            }
            else if (typeof(T) == typeof(Recipe))
            {
                int newIndex = 0;
                string newName;
                do
                {
                    newIndex++;
                    newName = string.Format(nameFormat, newIndex);
                } while (Inventory.RecipeList.Any(r => r.Name == newName));
                return newName;
            }
            return nameFormat;
        }

        #endregion

        #region Sequences

        private long SequenceNextVal(Type type)
        {
            if (!_Sequences.ContainsKey(type))
            {
                _Sequences.Add(type, 1);
            }
            return _Sequences[type]++;
        }

        public long SequencePeek(Type type) => _Sequences.ContainsKey(type) ? _Sequences[type] : 1;

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
