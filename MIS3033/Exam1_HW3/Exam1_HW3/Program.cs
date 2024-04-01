// MIS 3033
// Database Manipulations 
// Diana Huerta 

using a;

Console.WriteLine("DB");

//step 2 
//<StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory>

//step 3 
// add packages 
//Microsoft.EntityFrameworkCore.Design
//Microsoft.EntityFrameworkCore.Tools
//Microsoft.EntityFrameworkCore.Sqlite

//define menu 

string menuStr = @"
************************************
Option Menu 
1. Add a new city 
2. Show all cities
3. Search a city by name 
4. Delete a city by ID
5. Search cities in one state 
6. Calculate the total population 
7. Find the city with the largest population
Press other keys to exit 
************************************
";
Console.WriteLine(menuStr);

CityDB db;
db = new CityDB(); // database connection



while (true) // infinite loop
{
    Console.WriteLine(menuStr);
    Console.Write("Input an option: ");
    string optStr = Console.ReadLine();

    if (optStr =="1")
    {
        // Add a new city 
        Console.WriteLine("Add a new city");
        Console.Write("Input city ID: ");
        string idStr = Console.ReadLine();
        int id = Convert.ToInt32(idStr);

        Console.Write("Input a City name: ");
        string cityName = Console.ReadLine();

        Console.Write("Input state name: ");
        string stateName = Console.ReadLine();

        Console.WriteLine("Input population: ");
        string popStr = Console.ReadLine();
        int pop= Convert.ToInt32(popStr);

        Console.Write("Input lat: ");
        string latStr=Console.ReadLine();
        double lat = Convert.ToInt32(latStr);

        Console.Write("Input lon: ");
        string lonStr = Console.ReadLine();
        double lon = Convert.ToInt32(lonStr);

        City city = new City();
        city.Id = id;
        city.CityName = cityName;
        city.State = stateName;
        city.population = pop;
        city.lat = lat;
        city.lon = lon;

        db.cities.Add(city); // db is in the RAM
        
        db.SaveChanges(); // persist, save to file 



    }
    else if (optStr == "2")
    {
        //Show all cities
        Console.WriteLine("All cities");
        List<City> cityList = db.cities.ToList();
        for (int i = 0; i<cityList.Count; i++)
        {
            Console.WriteLine(cityList[i]);
        }
    }
    else if (optStr == "3")
    {
        //Search a city by name
        Console.WriteLine("Search a city by name");
        Console.Write("Input a city name: ");
        string cityName = Console.ReadLine();

        // you only get one city 
        //City city = db.cities.Where(x => x.CityName == cityName).FirstOrDefault(); // always return a collection
        List<City> cityList=db.cities.Where(x => x.CityName.ToLower() == cityName.ToLower()).ToList();

        for (int i = 0; i<cityList.Count; i++)
        {
            Console.WriteLine(cityList[i]);
        }
    }
    else if (optStr == "4")
    {
        //Delete a city by ID
        Console.WriteLine("Delete a city by ID");
        Console.Write("Input City ID: ");
        String cityIdStr = Console.ReadLine();
        int cityId = Convert.ToInt32(cityIdStr);

        City city = db.cities.Where(x => x.Id == cityId).FirstOrDefault();

        if (city == null)
        {
            Console.WriteLine("The city id does not exist in the DB");
        }
        else // we find the city 
        {
            db.cities.Remove(city); // we remove the city from db in the ram

            db.SaveChanges(); // save changes to the database file 
        }

    }
    else if (optStr =="5")
    {
        //Search all cities in one state
        Console.WriteLine("Search all cities in one state");
        Console.Write("Input a state name: ");
        string stateNameStr = Console.ReadLine();

        List<City> cityList = db.cities.Where(x=>x.State.ToLower()==stateNameStr.ToLower()).ToList();

        if (cityList.Count == 0) 
        {
            Console.WriteLine($"No city found in that state {stateNameStr}");
        }
        else // if found
        {
            Console.WriteLine($"{cityList.Count} cities are found in state {stateNameStr}");

            for (int i=0; i<cityList.Count;i++)
            {
                Console.WriteLine(cityList[i]);
            }

        }

    }
    else if (optStr == "6")
    {
        //Calculate the total population 
        Console.WriteLine("Sum of population");

        double sumPop = db.cities.Sum(x => x.population);

        Console.WriteLine($"Total population is {sumPop:F0}");

    }
    else if ( optStr == "7")
    {
        // Find the city with the largest population
        Console.WriteLine("City with the largest population");

        City city = db.cities.ToList().MaxBy(x => x.population);

        Console.WriteLine(city);
    }
    else
    {
        Console.WriteLine("Thank you and Goodbye!");
        break; //stop 
    }





}
