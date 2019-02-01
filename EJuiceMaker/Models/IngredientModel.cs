using EJuiceMaker.Controls;
using EJuiceMaker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using DateTimeEditor = EJuiceMaker.Controls.DateTimeEditor;
using R = EJuiceMaker.Properties.Resources;

namespace EJuiceMaker.Models
{
    internal class IngredientModel : PropertyModel<Ingredient>
    {
        public IngredientModel(Ingredient instance) : base(instance) { }

        protected override Attribute[] CreateAttributes(PropertyDescriptor pd)
        {
            var attrs = new List<Attribute>();
            attrs.AddRange(CreateDefaultAttributes(pd));
            switch (pd.Name)
            {
                case nameof(Ingredient.Type):
                    attrs.Add(new TypeConverterAttribute(typeof(EnumConverterEx)));
                    break;
                case nameof(Ingredient.Notes):
                    attrs.Add(new EditorAttribute(typeof(MultilineStringEditor), typeof(UITypeEditor)));
                    attrs.Add(new TypeConverterAttribute(typeof(FirstLineConverter)));
                    break;
                case nameof(Ingredient.PgContent):
                case nameof(Ingredient.VgContent):
                case nameof(Ingredient.WaterContent):
                case nameof(Ingredient.AlcoholContent):
                    attrs.Add(new TypeConverterAttribute(typeof(PercentConverter)));
                    break;
                case nameof(Ingredient.CostPerMl):
                    attrs.Add(new TypeConverterAttribute(typeof(CurrencyConverter)));
                    break;
                case nameof(Ingredient.LastPurchaseDate):
                    attrs.Add(new EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor)));
                    break;
                case nameof(Ingredient.QtyLowAlertEnabled):
                case nameof(Ingredient.QtyLowWarnEnabled):
                    attrs.Add(new TypeConverterAttribute(typeof(YesNoConverter)));
                    break;
            }
            return attrs.ToArray();
        }

        protected override IEnumerable<PropertyDescriptor> GetOrderedProperties()
        {
            var allProps = base.GetOrderedProperties().ToDictionary(pd => pd.Name);

            var orderedNames = new string[]
            {
                // Basic
                nameof(Ingredient.Name),
                nameof(Ingredient.SKU),
                nameof(Ingredient.UPC),
                nameof(Ingredient.Type),
                nameof(Ingredient.Manufacturer),
                nameof(Ingredient.Vendor),
                nameof(Ingredient.Notes),
                // Details
                nameof(Ingredient.PgContent),
                nameof(Ingredient.VgContent),
                nameof(Ingredient.WaterContent),
                nameof(Ingredient.AlcoholContent),
                nameof(Ingredient.NicotineDose),
                nameof(Ingredient.SpecificGravity),
                // Inventory
                nameof(Ingredient.CostPerMl),
                nameof(Ingredient.QtyOnHand),
                nameof(Ingredient.QtyLowAlert),
                nameof(Ingredient.QtyLowAlertEnabled),
                nameof(Ingredient.QtyLowWarn),
                nameof(Ingredient.QtyLowWarnEnabled),
                nameof(Ingredient.LastPurchaseDate),
            };

            foreach (var name in orderedNames)
            {
                if (allProps.ContainsKey(name)) yield return allProps[name];
            }
        }

        protected override string GetCategory(PropertyDescriptor pd)
        {
            switch (pd.Name)
            {
                case nameof(Ingredient.Name):
                case nameof(Ingredient.SKU):
                case nameof(Ingredient.UPC):
                case nameof(Ingredient.Type):
                case nameof(Ingredient.Manufacturer):
                case nameof(Ingredient.Vendor):
                case nameof(Ingredient.Notes):
                    return R.Category_Basic;
                case nameof(Ingredient.PgContent):
                case nameof(Ingredient.VgContent):
                case nameof(Ingredient.WaterContent):
                case nameof(Ingredient.AlcoholContent):
                case nameof(Ingredient.NicotineDose):
                case nameof(Ingredient.SpecificGravity):
                    return R.Category_Details;
                case nameof(Ingredient.CostPerMl):
                case nameof(Ingredient.QtyOnHand):
                case nameof(Ingredient.QtyLowAlert):
                case nameof(Ingredient.QtyLowAlertEnabled):
                case nameof(Ingredient.QtyLowWarn):
                case nameof(Ingredient.QtyLowWarnEnabled):
                case nameof(Ingredient.LastPurchaseDate):
                    return R.Category_Inventory;
            }
            return null;
        }
    }
}
