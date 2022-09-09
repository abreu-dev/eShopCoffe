using System.Reflection;

namespace eShopCoffe.Core.Tests.Utils
{
    public static class PrivateObjectUtil
    {
        private const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public;

        public static void SetProperty<TObject, TProperty>(TObject instance, string property, TProperty value)
        {
            var field = typeof(TObject).GetField(property, bindingFlags);
            if (field != null)
            {
                field.SetValue(instance, value);
                return;
            }

            var propertyInfo = typeof(TObject).GetProperty(property, bindingFlags);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(instance, value, null);
            }
        }

        public static object? GetProperty<TObject>(TObject instance, string property)
        {
            var field = typeof(TObject).GetField(property, bindingFlags);

            if (field != null)
            {
                return field.GetValue(instance);
            }

            return null;
        }
    }
}
