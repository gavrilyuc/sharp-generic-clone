using System.Reflection;

namespace GenericCloneDemo
{
    public static class ObjectCloneExtension
    {
        /// <summary>
        /// Clone Object
        /// </summary>
        /// <typeparam name="T">type object</typeparam>
        /// <param name="a">Object</param>
        /// <returns>Cloned Object</returns>
        public static T Clone<T>(this T a)
        {
            return (T)a.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(a, null);
        }
    }
}