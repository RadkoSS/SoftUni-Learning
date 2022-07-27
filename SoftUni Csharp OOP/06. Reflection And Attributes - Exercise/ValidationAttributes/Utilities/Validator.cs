namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objectType = obj.GetType();

            PropertyInfo[] properties = objectType.GetProperties()
                .Where(p => p.CustomAttributes.Any(atr => atr.AttributeType.BaseType == typeof(MyValidationAttribute))).ToArray();

            foreach (PropertyInfo property in properties)
            {
                object propertyValue = property.GetValue(obj);

                foreach (CustomAttributeData customAttribute in property.CustomAttributes)
                {
                    Type customAttributeType = customAttribute.AttributeType;

                    object customAttributeInstance = property.GetCustomAttribute(customAttributeType);

                    MethodInfo validationMethod =
                        customAttributeType.GetMethods().First(method => method.Name == "IsValid");

                    bool result = (bool)validationMethod.Invoke(customAttributeInstance, new object[] { propertyValue });

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
