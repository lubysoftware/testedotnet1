using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Luby.Util
{
    public static class Objects
    {
        public static dynamic MergeObjects(this object srcObject, object destObject)
        {
            // If any this null throw an exception
            if (srcObject == null || destObject == null)
                throw new Exception("Source or/and Destination Objects are null");
            // Getting the Types of the objects
            Type typeDest = destObject.GetType();
            Type typeSrc = srcObject.GetType();

            // Iterate the Properties of the source instance and  
            // populate them from their desination counterparts  
            PropertyInfo[] srcProps = typeSrc.GetProperties();
            foreach (PropertyInfo srcProp in srcProps)
            {
                if (!srcProp.CanRead)
                {
                    continue;
                }
                PropertyInfo targetProperty = typeDest.GetProperty(srcProp.Name);
                if (targetProperty == null)
                {
                    continue;
                }
                if (!targetProperty.CanWrite)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod() == null)
                    continue;
                if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                {
                    continue;
                }
                if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                {
                    continue;
                }
                PropertyInfo fieldPropertyInfo = srcObject.GetType().GetProperties().FirstOrDefault(f => f.Name.ToLower() == srcProp.Name.ToLower());
                if (fieldPropertyInfo == null)
                {
                    continue;
                }
                if (GetDefaultValue(srcProp) == null && fieldPropertyInfo.GetValue(srcObject, null) == null)
                {
                    continue;
                }
                if (GetDefaultValue(srcProp) != null && GetDefaultValue(srcProp).Equals(fieldPropertyInfo.GetValue(srcObject, null)))
                {
                    continue;
                }
                targetProperty.SetValue(destObject, srcProp.GetValue(srcObject, null), null);
            }
            return destObject;
        }

        static object GetDefaultValue(PropertyInfo prop)
        {
            if (prop.PropertyType.IsValueType)
                return Activator.CreateInstance(prop.PropertyType);
            return null;
        }

    }
}
