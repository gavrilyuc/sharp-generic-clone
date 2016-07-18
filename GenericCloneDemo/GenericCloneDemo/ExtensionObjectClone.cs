using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace GenericCloneDemo
{
    public static class ExtensionObjectClone
    {
        /// <summary>
        /// Clone Object
        /// </summary>
        /// <typeparam name="T">type object</typeparam>
        /// <param name="a">Object</param>
        /// <returns>Cloned Object</returns>
        public static T Clone<T>(this T a)
        {
            Type objType = a.GetType();

            if (objType.IsSerializable)
                return a.CloneOfMemory();

            T instance = (T)Activator.CreateInstance(objType);

            foreach (PropertyInfo property in objType.GetProperties().Where(e => e.CanRead && e.CanWrite))
            {
                object value = property.GetValue(a, null);
                if (value != null)
                    property.SetValue(instance, value.Clone(), null);
            }
            if (!objType.IsArray) return instance;

            var ins = instance as IList;

            if (ins == null) return a;

            foreach (object item in (IEnumerable)a)
                ins.Add(item);

            return (T)ins;
        }

        private static readonly BinaryFormatter Formatter;
        static ExtensionObjectClone()
        {
            Formatter = new BinaryFormatter();
        }

        private static T CloneOfMemory<T>(this T a)
        {
            T objResult;
            using (MemoryStream ms = new MemoryStream())
            {
                Formatter.Serialize(ms, a);
                ms.Position = 0;
                objResult = (T)Formatter.Deserialize(ms);
            }
            return objResult;
        }
    }

}