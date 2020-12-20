using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionExample
{
    [Obsolete]
    class Person
    {
        //fields
        private String firstname;

        public String id;

        //static fields
        private static int numberOfPeople;

        //ctor
        public Person(String firstname)
        {
            this.firstname = firstname;
            numberOfPeople++;
        }

        //Getter und Setter
        public String GetFirstname()
        {
            return firstname;
        }

        public void SetFirstname(String firstname)
        {
            this.firstname = firstname;
        }


        //Methods
        public void GoesWalking()
        {
            Console.WriteLine(firstname + " geht spazieren");
        }

        public void GoesRunning()
        {
            Console.WriteLine(firstname + " geht laufen");
        }


        private void GoesOnADate(string partner)
        {
            Console.WriteLine(firstname + " geht auf ein Date mit " + partner);
        }

        //Static Methods
        public static void NumberOfPeople()
        {
            Console.WriteLine(numberOfPeople);
        }

    }
}
