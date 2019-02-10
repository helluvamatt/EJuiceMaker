using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJuiceMaker.Properties
{
    // TODO [SettingsProvider(typeof(RegistrySettingsProvider))]
    internal sealed partial class Settings : ApplicationSettingsBase
    {
        private Settings()
        {
            
        }

        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(sender, e);
            Save();
        }
    }

    internal sealed class RegistrySettingsProvider : SettingsProvider
    {
        public override string ApplicationName { get; set; }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (string.IsNullOrEmpty(name)) name = typeof(RegistrySettingsProvider).Name;
            base.Initialize(name, config);
            if (string.IsNullOrEmpty(ApplicationName)) ApplicationName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            var values = new SettingsPropertyValueCollection();
            // TODO Custom settings provider: Read
            return values;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            // TODO Custom settings provider: Write
        }
    }
}
