using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ObjectValidator
{
    public class Validator
    {
        public (bool isValid, List<string> validationErrors) Validate(User user)
        {
            var type = user.GetType();

            var propertiesForValidation = type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(prop => prop.GetCustomAttributes<MyBaseAttribute>(false).Any())
                .Select(prop => new
                {
                    PropertyType = prop.PropertyType,
                    AttributesForValidation = prop.GetCustomAttributes<MyBaseAttribute>(false),
                    Value = prop.GetValue(user)
                }).ToList();

            List<string> errorList = new List<string>();

            foreach (var propertyValidation in propertiesForValidation)
            {
                var requiredAttr = propertyValidation.AttributesForValidation
                    .First(attr => attr != null && attr is RequiredAttribute);

                if (propertyValidation.PropertyType == typeof(string))
                {
                    var value = (string)propertyValidation.Value;

                    if (string.IsNullOrEmpty(value))
                    {
                        errorList.Add(requiredAttr.Error);
                        continue;
                    }

                    var (isValid, error) = IsValidText(value, propertyValidation.AttributesForValidation);

                    if (!isValid)
                    {
                        errorList.Add(error);
                    }
                }

                else if (propertyValidation.PropertyType == typeof(int))
                {
                    var value = (int)propertyValidation.Value;

                    if (value == 0)
                    {
                        errorList.Add(requiredAttr.Error);
                        break;
                    }
                }
            }

            return errorList.Count == 0 ? (true, null) : (false, errorList);
        }


        private (bool, string) IsValidText(string value, IEnumerable<MyBaseAttribute> myAttributes)
        {
            string error = "";

            foreach (var attr in myAttributes)
            {

                if (attr != null && attr is RequiredAttribute)
                {

                    if (string.IsNullOrEmpty(value))
                    {
                        error = attr.Error;
                        break;
                    }
                }

                if (attr != null && attr is RegexAttribute regexAttr)
                {
                    var regex = new Regex(regexAttr.Pattern);

                    if (!regex.IsMatch(value))
                    {
                        error = attr.Error;
                        break;
                    }
                }
                if (attr != null && attr is LengthAttribute lengthAttr)
                {

                    if (value.Length <= lengthAttr.MinLength
                        || value.Length >= lengthAttr.MaxLength)
                    {
                        error = attr.Error;
                        break;
                    }
                }
            }

            return error.Length == 0 ? (true, null) : (false, error);
        }
    }
}