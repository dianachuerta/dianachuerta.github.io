// MIS 3033
// Patient DB Manipulations
// Diana Huerta 
// 113553066
using a;
using System.ComponentModel.Design;

Console.WriteLine("DB");

string menuStr = @"
*****************************************************
1. Add a new patient
2. Show all patients
3. Search for one patient based on a given ID
4. Delete one patient based on a given ID
5. Show the average age of all patients
6. Show the patient information with the lowest age
Press other keys to exit
*****************************************************
";

PatientDB db;
db = new PatientDB();// load the database from the file to RAM

while (true)
{
    Console.WriteLine(menuStr);

    Console.Write("Enter an option: ");
    string optStr = Console.ReadLine();

    if (optStr == "1")
    {
        // Add a new patient
        Console.WriteLine("Add a new patient");
        Console.Write("ID: ");
        string idStr = Console.ReadLine();

        Console.Write("Age: ");
        string ageStr = Console.ReadLine();
        int ageInt=Convert.ToInt32(ageStr);

        // create a patient 
        Patient patient;
        patient = new Patient();

        patient.PID = idStr;
        patient.Age =ageInt;

        // call the age level 
        patient.GetAgeLevel();

        // add patient to the patient table in RAM
        db.patients.Add(patient);

        // persist 
        db.SaveChanges(); // save the db from RAM to file 

        Console.WriteLine("Patient added successfully!");
        Console.WriteLine(patient);


    }
    else if (optStr == "2")
    {
        // Show all patients 
        Console.WriteLine("Show all patients");

        List<Patient> pList = db.patients.ToList();

        for (int i=0;i<pList.Count; i++)
        {
            Console.WriteLine(pList[i]);
        }
    }
    else if (optStr == "3")
    {
        // search for one patient based on a given ID
        Console.WriteLine("Search for one patient based on a given ID");

        Console.Write("ID: ");
        string idStr = Console.ReadLine();


        // null
        Patient p = db.patients.Where(x => x.PID == idStr).FirstOrDefault();

        if (p != null) 
        {
            Console.WriteLine(p);
            //Console.WriteLine(p.ToString());
        }
        else // p is null, no patient
        {
            Console.WriteLine($"PID {idStr} does not exist in the DB!");
        }

    }
    else if (optStr == "4")
    {
        // Delte one patient based on a given ID
        Console.WriteLine("Delete one patient based on a given ID");
        Console.Write("ID: ");
        string idStr = Console.ReadLine();

        // query to find the patient 
        Patient p = db.patients.Where(x => x.PID == idStr).FirstOrDefault();

        // remove from the table in teh RAM
        if ( p!= null )
        {
            db.patients.Remove(p); // remove from table or collection in the RAM
            Console.WriteLine("Patient removed successfully!");
            Console.WriteLine(p);
        }
        else
        {
            Console.WriteLine($"PID {idStr} does not exist in the DB!");
        }

        // persis 
        db.SaveChanges(); // save changes to the file 
;    }
    else if (optStr == "5")
    {
        // show the average of all patients 
        Console.WriteLine("Show the average of all patients");

        double aveAge=db.patients.Average(x=>x.Age);

        Console.WriteLine($"{aveAge:F2}");
    }
    else if (optStr == "6")
    {
        //Show the patient information with the lowest age
        Console.WriteLine("Show the patient information with the lowest age");

        Patient p = db.patients.ToList().MinBy(x => x.Age);

        Console.WriteLine(p);
    }
    else
    {
        Console.WriteLine("Thank you and goodbye!");
        break; // stop loop
    }
} 