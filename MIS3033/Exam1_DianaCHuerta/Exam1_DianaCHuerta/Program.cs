// MIS 3033 Exam 1 
// March 1,2024
//Diana C Huerta 
// 113553066

using Exam1_DianaCHuerta.Data;
using Exam1_DianaCHuerta.Models;

Console.WriteLine("[SRPR]"); // I will get exam code during the exam and replace it

Exam1DBCon db = new Exam1DBCon(); // database connection

//var r = db.Employees.FirstOrDefault(); // first row, r is employee 
//Console.WriteLine(r.Id);

string menuStr = @"
************************************************
Menu Options
1. Add a new employee
2. Show all employees 
3. Show the employee with the highest salary
Press other keys to exit 
*************************************************
";

while (true)
{

    Console.WriteLine(menuStr);
    Console.Write("Enter your option: ");
    string optStr = Console.ReadLine();

    if (optStr == "1")
    {
        //Add a new employee
        Console.WriteLine("ADD A NEW EMPLOYEE");

        Console.Write("ID: ");
        string idstr = Console.ReadLine();

        Console.Write("Name: ");
        string nameStr= Console.ReadLine();

        Console.Write("Hours: ");
        double hoursDbl;
        string hoursStr = Console.ReadLine();
        hoursDbl = Convert.ToDouble(hoursStr);

        // add the employee

        Employee e = new Employee();

        e.Id = idstr;
        e.Name = nameStr;
        e.Hours = hoursDbl;

        e.Level = e.CalculateSalaryLevel();

        db.Employees.Add(e);
        db.SaveChanges();

        Console.WriteLine("NEW EMPLOYEE ADDED SUCCESSFULLY!");
        Console.Write(e);



    }
    else if (optStr == "2")
    {
        //Show all employees

        Console.WriteLine("ALL EMPLOYEES");

        List<Employee> employeeList = db.Employees.ToList();

        for (int i = 0; i<employeeList.Count; i++ )
        {
            Console.WriteLine(employeeList[i]);
        }
    }
    else if (optStr == "3")
    {
        //Show the employee with the highest salary
        Console.WriteLine("EMPLOYEE WITH THE HIGHEST SALARY");

        List<Employee> employeeList = db.Employees.ToList();

        Employee employee = employeeList.MaxBy(x => x.Salary);
        Console.Write(employee);
    }
    else
    {
        Console.WriteLine("Thank you and goodbye!");
        break;
    }









}

