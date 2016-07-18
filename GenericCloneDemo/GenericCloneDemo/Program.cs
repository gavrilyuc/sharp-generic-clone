using System;
using GenericCloneDemo.Custom;

namespace GenericCloneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            Console.WriteLine("int Number = {0} object:", a);
            int intCloned = a.Clone();
            Console.WriteLine("Cloned object: {0}", intCloned);

            string b = "Hello world";
            Console.WriteLine("string = {0}", b);
            var stringCloned = b.Clone<string>();
            Console.WriteLine("Cloned string: {0}", stringCloned);


            var customUser = new CustomUser {
                CustomGroup =
                    new CustomGroup { Name = "Jeronimo", SubName = "Cloneable", Id = 5 },
                FirstName = "Havryliuk",
                LastName = "Viktorovuch",
                Name = "Dmitry",
                Id = 3
            };

            Console.WriteLine("Object:");
            Console.WriteLine(customUser);

            var clonedObject = customUser.Clone();

            clonedObject.CustomGroup.Name = "Hi";
            clonedObject.CustomGroup.SubName = "You Not Alone !";
            clonedObject.Id = 15;

            Console.WriteLine("Cloned and Changed Object:");
            Console.WriteLine(clonedObject);
            Console.WriteLine();
            Console.WriteLine("Prev Object:");
            Console.WriteLine(customUser);


            Console.WriteLine("Please entered key...");
            Console.ReadKey();
        }
    }


}
