using System;
using System.Reflection;

namespace Artnman.Core.Utility.Data
{
    public class DataUtility
    {
        public static void CloneObject<T>(T from, ref T to)
        {
            PropertyInfo[] properties = from.GetType().GetProperties();
            PropertyInfo[] propertyInfoArray = to.GetType().GetProperties();
            for (int i = 0; i < (int)properties.Length; i++)
            {
                if (properties[i].PropertyType.BaseType == Type.GetType("System.ValueType") || properties[i].PropertyType == Type.GetType("System.String"))
                {
                    propertyInfoArray[i].SetValue(to, properties[i].GetValue(from, null), null);
                }
            }
        }
    }
}
