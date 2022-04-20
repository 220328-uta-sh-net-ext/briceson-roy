using UI;
namespace BL
{
    public abstract class EmployeeOperations
    {
        //AddEmployee
        public abstract void Add(DL.Employee employee);

        //RemoveEmployee
        public abstract void Delete(DL.Employee employee);
        //FindEmployee
        public abstract DL.Employee SearchEmployee(string id);
        //EditEmployee
        public abstract DL.Employee UpdateEmployee(DL.Employee employee);

        //CalculateSalary
        public decimal PayCalc(string payRate, string taxes) // method with different swquence of parameters
        {
            return decimal.Parse(payRate) * hours - decimal.Parse(taxes);
        }

    public class EmployeeImplementation : EmployeeOperations
    {
        public  void Add(DL.Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(DL.Employee employee)
            {
                throw new NotImplementedException();
            }
        
        public void SearchEmployee(DL.Employee employee)
            {
                throw new NotImplementedException();
            }

        public void Upda 

    }
}