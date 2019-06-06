using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_base_class
{
    public abstract class Employee
    {
        //Fields
        private string _firstname;
        private string _lastname;
        private int _employeeID;
        //CTROs
        public Employee() { }
        public Employee(string firstname, string lastname, int employeeID)
        {
            _firstname = firstname;
            _lastname = lastname;
            _employeeID = employeeID;
        }
        //Properties

        //Methods
        public override string ToString()
        {
            return $"{this.GetType().Name,-20} {_firstname,-10} {_lastname,-12} {_employeeID}";
        }
        // define a method that computes and returns the weekly salary of an employee
        // since the computation of weekly salary depends on the type of employee
        // this method() does not have enough info to compute the weekly salary
        // it is not practical to just return 0
        // it is best to not provide any code so child classes can override it
        // and add the appropriate code
        // normally a method() *must* have some code, so defining it as ABSTRACT
        // the method() can be defined "without a body"
        public abstract decimal GetWeeklySalary();
        // an abstract method or property is defined as a method or property without a body and MUST be contained within an abstract class
    }
}
