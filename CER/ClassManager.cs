using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CER
{
    class ClassManager
    {
        string[] classDs;
        public string jsonPath = "classes.json";
        private int i;
        public int lastEntry;
        public List<int> classHours;
        /// <summary>
        /// checks the database for classes and outputs that Data
        /// </summary>
        public void InitClassData()
        {
            Class c1 = new Class
            {
                classTitle = "Calculus 1",
                className = "Calc 1",
                classDays = new string[] { "Monday", "Tuesday", "Wednesday", "Friday" },
                classInstructor = "Bob Wenta",
                classTime = "11:00:00 AM"

            };
            Class c2 = new Class
            {
                classTitle = "Computer Science 1440",
                className = "CS-1440",
                classDays = new string[] { "Monday", "Wednesday", "Friday" },
                classInstructor = "Abdel Hamza",
                classTime = "10:00:00 AM"

            };
            List<Class> classList = new List<Class>();
            classList.Add(c1);
            classList.Add(c2);

            string output = JsonConvert.SerializeObject(classList);
            Console.Write(output);
        }
        /// <summary>
        /// Allows the user to View/Edit Classes 
        /// </summary>
        public void editClass()
        {
            Console.WriteLine("***CLASS EDITOR***");

            bool configFound = checkJson();

            if (configFound)
            {
                Console.Clear();
                Console.WriteLine("Classes Found:");
                Console.WriteLine();
                string json = File.ReadAllText(jsonPath);
                List<Class> classList = JsonConvert.DeserializeObject<List<Class>>(json);
                int classCount = classList.Count;
                foreach (Class c in classList)
                {
                    Console.WriteLine(c.className);
                }
                Console.WriteLine();
                Console.WriteLine("Would you like to Edit Classes?");
                Console.WriteLine("1. Add Class");
                Console.WriteLine("2. Remove Class");
                string result = Console.ReadLine();
                if (result == "1")
                {
                    AddClass();
                }
                else if (result == "2")
                {
                    RemoveClass();
                }

            }
            else if (!configFound)
            {

            }


        }

        private bool checkJson()
        {
            if (!File.Exists(jsonPath))
            {
                return false;
            }
            else if (File.Exists(jsonPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Allows the user to add a new class entry
        /// </summary>
        private void AddClass()
        {
            Console.WriteLine();
            Console.WriteLine("Class Title?:");
            string title = Console.ReadLine();
            Console.WriteLine("Class Instructor?:");
            string instructor = Console.ReadLine();
            Console.WriteLine("Time of Class?:");
            string time = Console.ReadLine();
            Console.WriteLine("Class Days? (Seperate by (,):");
            string day = Console.ReadLine();
            string[] days = day.Split(',');
            Console.WriteLine("Class Abbr. Name:");
            string name = Console.ReadLine();

            Class c1 = new Class
            {
                classTitle = title,
                className = name,
                classDays = days,
                classInstructor = instructor,
                classTime = time

            };
            string json = File.ReadAllText(jsonPath);
            List<Class> classList = JsonConvert.DeserializeObject<List<Class>>(json);
            classList.Add(c1);
            string jsonOut = JsonConvert.SerializeObject(classList, Formatting.Indented);
            System.IO.File.WriteAllText(@"classes.json", jsonOut);
            Console.WriteLine("Class " + name + " added. Would you like to add another class? (Y/N)");
            string result = Console.ReadLine();
            if (result == "y")
            {
                AddClass();
            }
            else if (result == "n")
            {
                editClass();
            }
        }
        private void RemoveClass()
        {
            Console.WriteLine("What is the name of the class you want to remove? (Short Name)");
            string result = Console.ReadLine();
            string json = File.ReadAllText(jsonPath);
            List<Class> classList = JsonConvert.DeserializeObject<List<Class>>(json);

            foreach (Class c in classList)
            {

                if (c.className == result)
                {
                    Console.WriteLine("Found");
                    classList.Remove(classList[0]);
                }
            }
            string jsonOut = JsonConvert.SerializeObject(classList, Formatting.Indented);
            System.IO.File.WriteAllText(@"classes.json", jsonOut);
            Console.WriteLine("Removed Class " + result);
        }



        /// <summary>
        /// Gets the next class that is up based on the current time and day
        /// </summary>
        public List<Class> GetTodaysClass()
        {
            List<string> selDays = new List<string>();
            List<Class> selList = new List<Class>();
            string json = File.ReadAllText(jsonPath);
            List<Class> classList = JsonConvert.DeserializeObject<List<Class>>(json);
            string currentHourString = DateTime.Now.ToString("hh");
            string currentMinString = DateTime.Now.ToString("mm");
            string currentDayofTheWeek = DateTime.Now.ToString("dddd");
            int currentHour = Int32.Parse(currentHourString);
            int currentMinute = Int32.Parse(currentMinString);

            foreach (Class c in classList)
            {

                string[] days = c.classDays;
                foreach (string d in days)
                {
                    // If the results day is = too the current day
                    if (d == currentDayofTheWeek)
                    {

                        selList.Add(c);

                    }
                }
            }



            return selList;
        }
        public Class GetNextClass()
        {
            Class empty = new Class
            {
                className = "No Class"

            };
            string ret = "";
            Class resultClass = null;
            lastEntry = -1;
            int entry = 0;


            List<Class> tC = GetTodaysClass();
            List<DateTime> theDates = new List<DateTime>();
            foreach (Class today in tC)
            {
               
                theDates.Add(DateTime.Parse(today.classTime));
            }

            DateTime closestDate = DateTime.Parse("00:00:00");

            DateTime fileDate = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"));

            long min = long.MaxValue;
        


            foreach (DateTime date in theDates)
                if (Math.Abs(date.Ticks - fileDate.Ticks) < min)
                {

                    min = Math.Abs(date.Ticks - fileDate.Ticks);
                    if (date < fileDate)
                    {
                       // The time has passed
                    }
                    else
                    closestDate = date;
                }
            foreach(Class todaysClass in tC)
            {
                if (closestDate == DateTime.Parse(todaysClass.classTime))
                {
                    return todaysClass;
                }
            }



         
            return empty;
            
        }
    }
}
