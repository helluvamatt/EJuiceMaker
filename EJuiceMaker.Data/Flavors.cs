using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace EJuiceMaker.Data
{
    [Serializable]
    [XmlRoot("Flavors", Namespace = "http://schneenet.com/EJuiceMaker/Flavors.xsd", IsNullable = false)]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Flavors.xsd")]
    public sealed class FlavorCollection
    {
        private readonly BindingListEx<Flavor> _FlavorBindingList;

        public FlavorCollection()
        {
            _FlavorBindingList = new BindingListEx<Flavor>();
        }

        [XmlIgnore]
        public IList<Flavor> FlavorList => _FlavorBindingList;

        [XmlElement("Flavor")]
        public Flavor[] Flavors
        {
            get => _FlavorBindingList.ToArray();
            set
            {
                _FlavorBindingList.Clear();
                if (value != null) _FlavorBindingList.AddAll(value);
            }
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://schneenet.com/EJuiceMaker/Flavors.xsd")]
    public sealed class Flavor : INotifyPropertyChanged
    {
        private string _VendorSKU;
        [XmlAttribute("SKU")]
        public string VendorSKU
        {
            get => _VendorSKU;
            set
            {
                if (_VendorSKU != value)
                {
                    _VendorSKU = value;
                    OnPropertyChanged(nameof(VendorSKU));
                }
            }
        }


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

        private float _SpecificGravity;
        [XmlAttribute("SpecificGravity")]
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

        private float _FlashPoint;
        [XmlAttribute("FlashPoint")]
        public float FlashPoint
        {
            get => _FlashPoint;
            set
            {
                if (_FlashPoint != value)
                {
                    _FlashPoint = value;
                    OnPropertyChanged(nameof(FlashPoint));
                }
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
