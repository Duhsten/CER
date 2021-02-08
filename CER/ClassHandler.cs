using System;
using System.Collections.Generic;
using System.Text;

namespace CER
{
    /// <summary>
    /// I dont know what to call this class so ClassHandler will have to do. It handles the class that is active.
    /// </summary>
    class ClassHandler
    {

        public Class CurrentClass()
        {
            Class empty = new Class
            {
                className = "No Class"

            };
            Logger logger = new Logger();
            ClassManager cM = new ClassManager();
            Class nextClass = cM.GetNextClass();
            List<Class> todaysClass = cM.GetTodaysClass();
            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            string[] curTime = currentTime.Split(":");
            int currentHour = Int32.Parse(curTime[0]);
            int currentMin = Int32.Parse(curTime[1]);

           
            foreach (Class todayC in todaysClass)
            {
                string classTime = todayC.classTime;
                string[] clTime = classTime.Split(":");
                int classHour = Int32.Parse(clTime[0]);
                int classMin = Int32.Parse(clTime[1]);

                if (classMin == 0)
                {
                    classMin = 60;
                }
                classHour = classHour - 1;
                classMin = classMin - 10;
                DateTime classpreT = DateTime.Parse(classHour + ":" + classMin);
                DateTime currT = DateTime.Parse(DateTime.Now.ToString("M/d/yyyy HH:mm:ss"));
                DateTime clasTime = DateTime.Parse(todayC.classTime);
                DateTime classEnd = DateTime.Parse(todayC.classEnd);

                if (currT.Ticks >= clasTime.Ticks && currT.Ticks < classEnd.Ticks)
                {
                    return todayC;
                }
            
            }
            return empty;

        }
        /// <summary>
        /// Checks to see if the next class is 10 minutes before and then it preps for class.
        /// </summary>
        public void PreInitCheck()
        {
       
                Class empty = new Class
                {
                    className = "No Class"

                };
                Logger logger = new Logger();
                ClassManager cM = new ClassManager();
                Class nextClass = cM.GetNextClass();
                List<Class> todaysClass = cM.GetTodaysClass();
                string currentTime = DateTime.Now.ToString("HH:mm:ss");
                string[] curTime = currentTime.Split(":");
                int currentHour = Int32.Parse(curTime[0]);
                int currentMin = Int32.Parse(curTime[1]);


                foreach (Class todayC in todaysClass)
                {
                    string classTime = todayC.classTime;
                    string[] clTime = classTime.Split(":");
                    int classHour = Int32.Parse(clTime[0]);
                    int classMin = Int32.Parse(clTime[1]);

                    if (classMin == 0)
                    {
                        classMin = 60;
                    }
                    classHour = classHour - 1;
                    classMin = classMin - 10;
                    DateTime classpreT = DateTime.Parse(classHour + ":" + classMin);
                    DateTime currT = DateTime.Parse(DateTime.Now.ToString("M/d/yyyy HH:mm:ss"));
                    DateTime clasTime = DateTime.Parse(todayC.classTime);
                    DateTime classEnd = DateTime.Parse(todayC.classEnd);
                    if (currT.Ticks >= classpreT.Ticks && currT.Ticks < clasTime.Ticks)
                    {
                    logger.Output("Starting preperations for Class " + todayC.className, true);
                    }


                }
              

            
        }
        public string GetStatus()
        {
            Logger logger = new Logger();
            ClassManager cM = new ClassManager();
            Class nextClass = cM.GetNextClass();
            List<Class> todaysClass = cM.GetTodaysClass();
            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            string[] curTime = currentTime.Split(":");
            int currentHour = Int32.Parse(curTime[0]);
            int currentMin = Int32.Parse(curTime[1]);


            foreach (Class todayC in todaysClass)
            {
                string classTime = todayC.classTime;
                string[] clTime = classTime.Split(":");
                int classHour = Int32.Parse(clTime[0]);
                int classMin = Int32.Parse(clTime[1]);
              //  logger.Output(todayC.classTime, true);
                if (classMin == 0)
                {
                    classMin = 60;
                }
                classHour = classHour - 1;
                classMin = classMin - 10;
                DateTime classpreT = DateTime.Parse(classHour + ":" + classMin);
                DateTime currT = DateTime.Parse(DateTime.Now.ToString("M/d/yyyy HH:mm:ss"));
                DateTime clasTime = DateTime.Parse(todayC.classTime);
                // Debug Log
                //  logger.Output("Current Time: "+ currT.Ticks, true);
                 // logger.Output("Class Time: " + clasTime.Ticks, true);
                if (currT.Ticks >= classpreT.Ticks)
                {
                    return "Starting Soon" + classpreT.ToString();
                }
                if (currT.Ticks >= clasTime.Ticks && currT.Ticks < clasTime.Ticks)
                {
                    return "In Progress";
                }
                if (currT.Ticks > clasTime.Ticks)
                {
                    return "Class Completed";
                }
                if  (currT.Ticks < clasTime.Ticks)
                    {
                        return "Up Soon";
                    }
            }
            return "Unknown";
        }
    }
}

