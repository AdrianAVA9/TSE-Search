using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TSE.App.Persistance.Repository
{
    public class BuilderObjects<T> where T:class
    {
        public T Build(Dictionary<string, object> dict, T obj)
        {
            Dictionary<string, object>.KeyCollection keys = dict.Keys;

            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                if (dict.ContainsKey(ChangeFormat(property.Name)))
                {
                    if (property.CanWrite)
                        SetValue(obj, property, dict);
                }
            }

            return obj;
        }

        private void SetValue(T obj, PropertyInfo property, Dictionary<string, object> dict)
        {
            if (property.PropertyType == typeof(int))
            {
                property.SetValue(obj, int.Parse(dict[ChangeFormat(property.Name)].ToString()), null);
            }
            else
            {
                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(obj, dict[ChangeFormat(property.Name)].ToString(), null);
                }
                else
                {
                    if (property.PropertyType == typeof(bool))
                    {
                        property.SetValue(obj, bool.Parse(dict[ChangeFormat(property.Name)].ToString()), null);
                    }
                    else
                    {
                        if (property.PropertyType == typeof(DateTime))
                        {
                            property.SetValue(obj, DateTime.Parse(dict[ChangeFormat(property.Name)].ToString()), null);
                        }
                        else
                        {
                            if (property.PropertyType == typeof(decimal))
                            {
                                property.SetValue(obj, decimal.Parse(dict[ChangeFormat(property.Name)].ToString()), null);
                            }
                        }
                    }
                }
            }
        }


        public string ChangeFormat(string value)
        {
            StringBuilder format = new StringBuilder();
            bool firstLetter = true;

            foreach (char letter in value)
            {
                if (char.IsUpper(letter) && !firstLetter)
                {
                    format.Append(string.Concat("_" + letter));
                }
                else
                {
                    format.Append(letter);
                    firstLetter = false;
                }
            }

            return format.ToString().ToUpper();
        }
    }
}
