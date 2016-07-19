using System;
using System.Linq;

namespace GenericCloneDemo.Custom
{
    public class CustomUser : CustomModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Id { get; set; }

        public CustomGroup CustomGroup { get; set; }

        public string GroupName => $"{CustomGroup.Name} - {CustomGroup.SubName}";
        public string FullName => $"{FirstName} {Name} {LastName}";

        public override string ToString()
        {
            string str = $"\t{FullName}\t{Id}\n\t{GroupName}\n\tGroup Id: {CustomGroup.Id}";

            int max = str.Split('\n').Max(e => e.Replace("\t", new string(' ', 10)).Length);

            string separator = new string('-', max);

            return $"{separator}\n{str}\n{separator}\n";
        }
    }
}