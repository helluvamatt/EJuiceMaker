using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using R = EJuiceMaker.Properties.Resources;

namespace EJuiceMaker.Models
{
    internal abstract class PropertyModel<T> : CustomTypeDescriptor
    {
        private readonly T _Instance;
        private readonly ICustomTypeDescriptor _OriginalDescriptor;

        protected PropertyModel(T instance) : this(instance, TypeDescriptor.GetProvider(instance).GetTypeDescriptor(instance)) { }

        private PropertyModel(T instance, ICustomTypeDescriptor originalDescriptor) : base(originalDescriptor)
        {
            // Need to keep references to these so they aren't garbage collected
            _Instance = instance;
            _OriginalDescriptor = originalDescriptor;
        }

        protected Attribute[] CreateDefaultAttributes(PropertyDescriptor pd)
        {
            var attrs = new List<Attribute>();
            var typeName = typeof(T).Name;
            var displayName = R.ResourceManager.GetString($"DisplayName_{typeName}_{pd.Name}");
            if (!string.IsNullOrEmpty(displayName)) attrs.Add(new DisplayNameAttribute(displayName));
            var description = R.ResourceManager.GetString($"Description_{typeName}_{pd.Name}");
            if (!string.IsNullOrEmpty(description)) attrs.Add(new DescriptionAttribute(description));
            var category = GetCategory(pd);
            if (!string.IsNullOrEmpty(category)) attrs.Add(new CategoryAttribute(category));
            return attrs.ToArray();
        }

        protected abstract Attribute[] CreateAttributes(PropertyDescriptor pd);

        protected virtual IEnumerable<PropertyDescriptor> GetOrderedProperties()
        {
            return base.GetProperties().Cast<PropertyDescriptor>();
        }

        protected virtual string GetCategory(PropertyDescriptor pd)
        {
            var typeName = typeof(T).Name;
            return R.ResourceManager.GetString($"Category_{typeName}_{pd.Name}");
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return new PropertyDescriptorCollection(
                GetOrderedProperties().Select(pd =>
                {
                    var attrs = CreateAttributes(pd);
                    return attrs != null ? TypeDescriptor.CreateProperty(typeof(T), pd, attrs) : pd;
                }).ToArray()                
            );
        }

        public override PropertyDescriptorCollection GetProperties()
        {
            return GetProperties(null);
        }
    }
}
