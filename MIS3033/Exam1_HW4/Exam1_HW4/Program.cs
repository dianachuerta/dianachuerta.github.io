// Diana Huerta 
// 113553066

using c;
using System.ComponentModel.Design;
using System.Data;

Console.WriteLine("HW DB");

// Menu Loop 

string menuStr = @"
****************************************************************
1. Add a new student’s information
2. Show all the students’ information
3. Show one student’s information for a given Student ID
4. Edit one student’s information for a given Student ID
5. Delete one student’s information for a given Student ID
6. Show the student’s information with highest grade
7. Show the average grade of all the students
Press other keys to exit
****************************************************************
";

StuDB db;
db = new StuDB();

while (true)
{
    Console.WriteLine(menuStr);
    Console.Write("Input a choice: ");
    string userChoiceStr;
    userChoiceStr= Console.ReadLine();

    if (userChoiceStr == "1")
    {
        //1. Add a new student’s information
        Console.WriteLine("Add a new student's information");
        
        Console.Write("Enter ID: ");
        string idStr = Console.ReadLine();

        Console.Write("Enter Name: ");
        string nameStr = Console.ReadLine();

        Console.Write("Enter Grade: ");
        double gradeDbl;
        string gradeStr = Console.ReadLine();
        gradeDbl = Convert.ToDouble(gradeStr);
        
        Student stu = new Student();
        stu.ID = idStr;
        stu.name = nameStr;
        stu.grade = gradeDbl;

        stu.gradeLevel = stu.GetGradeLevel();

        Console.WriteLine(stu);

        // add to the student db table 
        db.Students.Add(stu);

        db.SaveChanges();

        Console.WriteLine("New student information added to database!");


    }
    else if (userChoiceStr == "2")
    {
        //2.  Show all the students’ information
        Console.WriteLine("All the student's information: ");
        List<Student> stuList = db.Students.ToList(); // convert table to a list 

        for (int i = 0; i < stuList.Count; i++)
        {
            Console.WriteLine(stuList[i]);
        }

    }
    else if (userChoiceStr=="3")
    {

        //3.  Show one student’s information for a given Student ID
        Console.WriteLine("Show one student’s information for a given Student ID");

        Console.WriteLine("Enter ID: ");
        string idStr = Console.ReadLine();

        //query 
        List<Student> stuList = db.Students.ToList();

        // WHERE always results in a table or a collection 
        Student stu = stuList.Where(s => s.ID.ToLower() == idStr.ToLower()).FirstOrDefault();
        if (stu != null)
        {
            Console.WriteLine(stu);
        }
        else // does not exist 
        {
            Console.WriteLine($"ID {idStr} does not exist in the DB!");
        }


    }
    else if (userChoiceStr=="4")
    {
        //4.  Edit one student’s information for a given Student ID
        Console.WriteLine("Edit one student’s information for a given Student ID");
        Console.Write("Enter ID: ");
        string IdStr = Console.ReadLine();

        Student stu = db.Students.ToList().Where(x => x.ID.ToLower() == IdStr.ToLower()).FirstOrDefault();

        if (stu != null)
        {
            Console.WriteLine("The current information is: ");
            Console.WriteLine(stu);

            Console.WriteLine("Enter new name: ");
            string nameStr = Console.ReadLine();

            Console.WriteLine("Enter new grade: ");
            string gradeStr = Console.ReadLine();
            double gradeDbl = Convert.ToDouble(gradeStr);

            stu.name = nameStr;
            stu.grade = gradeDbl;

            stu.gradeLevel = stu.GetGradeLevel(); // update grade level

            db.SaveChanges();

            Console.WriteLine("Save edition successfully!");
            Console.WriteLine("The new information is: ");
            Console.WriteLine(stu);

        }
        else
        {
            Console.WriteLine($"ID {IdStr} is not in DB!");
        }

       



    }
    else if (userChoiceStr=="5")
    {
        //5.  Delete one student’s information for a given Student ID
        Console.WriteLine("Delete one student’s information for a given Student ID");
        Console.Write("Enter ID: ");
        string idStr = Console.ReadLine();

        Student stu=db.Students.Where(x=>x.ID.ToLower()==idStr.ToLower()).FirstOrDefault();

        if (stu != null)
        {
            //delete 
            db.Students.Remove(stu);

            db.SaveChanges();
            Console.WriteLine("Delete Successfully!");
            Console.WriteLine("The deleted information is: ");
            Console.WriteLine(stu);
        }
        else
        {
            Console.WriteLine($"ID {idStr} does not exist in DB!");
        }
      
        
       




    }
    else if (userChoiceStr=="6")
    {
        //6. Show the student’s information with highest grade
        Console.WriteLine("Show the student’s information with highest grade");
        Console.WriteLine("The student with highest grade: ");

        Student stu = db.Students.ToList().MaxBy(x => x.grade);
        Console.WriteLine(stu);

    }
    else if (userChoiceStr=="7")
    {
        //7.  Show the average grade of all the students
        Console.WriteLine("Show the average grade of all the students");
        double ave = db.Students.ToList().Average(x => x.grade);

        Console.WriteLine($"The average grade is:{ave:F2}");
        
    }
    else
    {
        Console.WriteLine("Thank you and goodbye!");
        break;
    }





}
