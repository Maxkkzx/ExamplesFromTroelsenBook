using EmployeeApp;

namespace EmployeeApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Marvin", 36, 456, 30000);

            emp.DisplayStats();
        }
    }
}