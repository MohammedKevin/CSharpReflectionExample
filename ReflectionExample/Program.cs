using System;
using System.Reflection;
using System.Linq;

namespace ReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person testperson = new Person("TestPerson");

            //Get Type
            Type type = typeof(Person);
            Type typeViaInstance = testperson.GetType();


            Console.WriteLine("Get typ");
            Console.WriteLine(type);
            Console.WriteLine(typeViaInstance);
            Console.Write("\n\n");




            Heading("Alle public Fields der Klasse");
            foreach (Object field in type.GetFields())
            {
                Console.WriteLine(field);
            }
            Console.Write("\n\n");

            Heading("Alle Fields der Klasse");
            foreach (Object field in type.GetRuntimeFields())
            {
                Console.WriteLine(field);
            }
            Console.Write("\n\n");





            Heading("Alle Methoden der Klasse");
            foreach (Object method in type.GetMethods())
            {
                Console.WriteLine(method);
            }
            Console.Write("\n\n");

            Heading("Alle runtime Methoden der Klasse");
            foreach (Object method in type.GetRuntimeMethods())
            {
                Console.WriteLine(method);
            }
            Console.Write("\n\n");





            Heading("Test person erstellen");
            Person p = new Person("Kevin");
            Console.Write("\n\n");






            Heading("Methode invoken");
            p.GoesWalking();
            Console.Write("\n\n");


            Heading("Methode invoken mit reflection");
            MethodInfo goesWalkingMethod = p.GetType().GetRuntimeMethods()
                .Where(method => method.Name == "GoesWalking")
                .FirstOrDefault();
            goesWalkingMethod.Invoke(p, null);
            Console.Write("\n\n");


            Heading("Beliebige Methode invoken mit reflection");
            Console.Write("Methoden name: ");
            string methodName = Console.ReadLine();
            methodName = methodName.Substring(0, methodName.Length);
            MethodInfo someMethod = p.GetType().GetRuntimeMethods()
                .Where(method => method.Name == methodName)
                .FirstOrDefault();
            someMethod.Invoke(p, null);
            Console.Write("\n\n");


            Heading("Static Method invoken");
            MethodInfo staticMethod = p.GetType().GetRuntimeMethods()
                .Where(method => method.Name == "NumberOfPeople")
                .FirstOrDefault();
            Console.Write("Anzahl an Personen: ");
            staticMethod.Invoke(null,null);
            Console.Write("\n\n");






            Heading("Instanz von Klasse");
            Type personType = typeof(Person);
            Type[] paramTypeArray = new Type[1];
            paramTypeArray[0] = typeof(string);
            ConstructorInfo ctor = personType.GetConstructor(paramTypeArray);
            Object[] paramArray = new Object[1];
            paramArray[0] = "Daniel";

            Person daniel = (Person)ctor.Invoke(paramArray);
            daniel.GoesRunning();
            Console.Write("\n\n");



            Heading("Setzen von firstname durch setter");
            p.SetFirstname("Pepi");
            p.GoesWalking();
            Console.Write("\n\n");


            Heading("Setzen von firstname");
            //p.firstname = "Jan";
            //Geht nicht weil firstname private ist

            Heading("Setzen von firstname mit Reflection");
            FieldInfo firstnameField = type.GetRuntimeFields()
                .Where(field => field.Name == "firstname")
                .FirstOrDefault();
            firstnameField.SetValue(p, "Jan");
            Console.WriteLine(p.GetFirstname());
            Console.Write("\n\n");





            Heading("Invoken von private Method");
            MethodInfo privateMethod = type.GetRuntimeMethods()
                .Where(method => method.Name == "GoesOnADate")
                .FirstOrDefault();
            privateMethod.Invoke(p, new Object[] {"Tami"});
            Console.Write("\n\n");



            Console.ReadLine();
        }

        static void Heading(String heading)
        {
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(heading);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
