using System;
using System.Reflection;

namespace GoodToCode.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static void Fill(this object item, object sourceItem)
        {
            var sourceType = sourceItem.GetType();

            foreach (PropertyInfo sourceProperty in sourceType.GetRuntimeProperties())
            {
                PropertyInfo destinationProperty = item.GetType().GetRuntimeProperty(sourceProperty.Name);
                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    // Copy data only for Primitive-ish types including Value types, Guid, String, etc.
                    Type destinationPropertyType = destinationProperty.PropertyType;
                    if (destinationPropertyType.GetTypeInfo().IsPrimitive || destinationPropertyType.GetTypeInfo().IsValueType
                        || (destinationPropertyType == typeof(string)) || (destinationPropertyType == typeof(Guid)))
                    {
                        destinationProperty.SetValue(item, sourceProperty.GetValue(sourceItem, null), null);
                    }
                }
            }
        }
    }
}
