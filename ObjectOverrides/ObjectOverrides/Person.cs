using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Person
    {   // class Person extends Object
        public string FirstName { get; set; } = "none";
        public string LastName { get; set; } = "none";
        public int Age { get; set; } = 0;
        public string SSN { get; set; } = "";
        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }
        public Person() { }
        public override int GetHashCode()// => ToString().GetHashCode();
        {
            // with a well-designed ToString() override, you could:
            return ToString().GetHashCode();
            // or use something else that could be unique/self-identifying:
            // return SSN.GetHashCode();
        }
        // Expression-bodied member override bool Equals(), leverages a well-designed ToString() override
       public override bool Equals(object obj) => obj?.ToString() == ToString();
        public override string ToString()
        {
            // a well-designed (tm) ToString() override
            return $"[First Name: {FirstName}; Last Name: {LastName}; Age: {Age}]";
        }
    }
}
