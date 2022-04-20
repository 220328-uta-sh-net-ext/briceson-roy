using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{

    enum Authority
    {
        Hire, Fire, Delegate
    }
    //Parent or super class
    public class Employee
    {
        // members -> variables, constants, methods, events, constructors etc....
        // variables => States of the object itself
        public string firstName = "Rick", lastName = "Hunter", id = "101";
        
        
        public string FirstName {
         get {  if (string.IsNullOrEmpty(firstName))
                    throw new ArgumentNullException("Please enter a first name. Cannot be blank...");
                else
                    return firstName; } //properties allows to read values
            set { firstName = value; } //enables writing 
        }

        public string Password { get; set; } //auto- propety no private variable declared but it would be declared behind the scenes

        public const string planet = "Earth";
        protected int age;
        //Salary components
        internal decimal payRate, taxes, healthCare, bonus,  reimbursements;
        internal decimal hours, overtimeHours; 
        public virtual decimal PayCalc() // no parameters
        {
            return payRate * hours +reimbursements + bonus - healthCare - taxes;
        }

        public decimal PayCalc(decimal payRate, decimal taxes) // method overload with different number of parameters
        {
              return payRate* hours-taxes;
        }

        public decimal PayCalc(string payRate, string taxes) // method with different swquence of parameters
        {
            return decimal.Parse(payRate) * hours - decimal.Parse(taxes);
        }

        //Behavior is dictated through methods
        public void DoTask(string firstName, string lastName, string id, float hours)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id; 

            Console.WriteLine($"{firstName} {lastName} programs in C# for {hours}");
        }
    }

    //Inheritance
    //sub-class or derived class
    class Manager:Employee
    {
        public Authority authority;

        internal decimal housing, paidVacation;
        // method overriding - re-defiing the method of a base class in child classes
        public override decimal PayCalc()
        {
            return base.payRate*base.hours + base.bonus + base.reimbursements - base.healthCare - base.taxes + housing + paidVacation;
        }

        public override string ToString()
        {
            return $"Manager ID - {base.id}\nManager Name - {base.firstName} {base.lastName}\nAge - {base.age}";
        }

        /*public string GetDetails(string firstName, string lastName, string id, int age)
        {
            base.firstName = firstName;
            base.lastName = lastName;
            base.id = id; 
            base.age = age; 
            authority = Authority.Hire;
            return $"Name - {firstName} {lastName}\n Age - {age}\nEmployee id -{id}";
        }*/
    }
}
                  