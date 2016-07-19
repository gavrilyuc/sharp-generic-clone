using System;
using System.Collections.Generic;
using GenericCloneDemo.Custom;
using Console = GenericCloneDemo.ConsoleExtension;

namespace GenericCloneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            Console.WriteLine("int Number = {0}", a);
            int intCloned = a.Clone();
            Console.WriteLine("Cloned: {0}", intCloned);
            System.Console.WriteLine();

            string b = "Hello world";
            Console.WriteLine("string = {0}", b);
            // так как в строки уже есть метод Clone, то мы явно указываем что мы хотим вызвать наш метод Clone
            var stringCloned = b.Clone<string>();
            Console.WriteLine("Cloned string: {0}", stringCloned);
            System.Console.WriteLine();

            var customUser = new CustomUser {
                CustomGroup =
                    new CustomGroup { Name = "Jeronimo", SubName = "Cloneable", Id = 5 },
                FirstName = "Havryliuk",
                LastName = "Viktorovuch",
                Name = "Dmitry",
                Id = 3
            };

            Console.WriteLine("^gCustom Object:");
            System.Console.WriteLine(customUser);
            System.Console.WriteLine();
            var clonedObject = customUser.Clone();

            clonedObject.CustomGroup.Name = "Hi";
            clonedObject.CustomGroup.SubName = "You Not Alone !";
            clonedObject.Id = 15;

            Console.WriteLine("^yCloned and Changed Object:");
            System.Console.WriteLine(clonedObject);
            System.Console.WriteLine();
            Console.WriteLine("Prev Object:");
            System.Console.WriteLine(customUser);
            System.Console.WriteLine();

            CustomModel modelBaseObject = clonedObject.Clone<CustomModel>();
            Console.WriteLine("^yClone from Model Base:");
            System.Console.WriteLine(modelBaseObject);
            System.Console.WriteLine();

            List<string> listObjects = new List<string>(10) {
                "A a", "B b", "C c",
                "D d", "E e", "F f",
                "G g", "I i", "K k",
                "L l"
            };
            Console.WriteLine("^gList Objects:");
            Console.WriteLine("{0} {1} {2}", "{", string.Join(", ", listObjects.ToArray()), "}");
            System.Console.WriteLine();

            List<string> clonedListObjects = listObjects.Clone();
            clonedListObjects.RemoveAt(5);

            Console.WriteLine("^yCloned and Changed list Objects:");
            Console.WriteLine("{0} {1} {2}", "{", string.Join(", ", clonedListObjects.ToArray()), "}");
            System.Console.WriteLine();

            Console.WriteLine("^gPrev List Objects:");
            Console.WriteLine("{0} {1} {2}", "{", string.Join(", ", listObjects.ToArray()), "}");
            System.Console.WriteLine();

            System.Console.WriteLine();
            Console.WriteLine("^yPlease entered key...");
            System.Console.ReadKey();
        }
    }
}