using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties().Where(p => p.CustomAttributes.Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType))).ToArray();

            foreach (PropertyInfo property in properties)
            {
                object[] customAttributes = property.GetCustomAttributes().Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType())).ToArray();

                object propertyValue = property.GetValue(obj);

                foreach (object customAttribute in customAttributes)
                {
                    MethodInfo isValidMethod = customAttribute.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(m => m.Name == "IsValid");

                    if (isValidMethod == null)
                    {
                        throw new InvalidOperationException("Your custom attribute does not have \"IsValid\" method!");
                    }

                    bool result = (bool)isValidMethod.Invoke(customAttribute, new object[] { propertyValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
