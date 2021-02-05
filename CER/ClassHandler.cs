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

        public void CurrentClass()
        {
            Logger logger = new Logger();
            ClassManager cM = new ClassManager();
            Class nextClass = cM.GetNextClass();
            List<Class> todaysClass = cM.GetTodaysClass();
            string currentTime = DateTime.Now.ToString("HH:mm:ss");
            string[] curTime = currentTime.Split(":");
            int currentHour = Int32.Parse(curTime[0]);
            int currentMin = Int32.Parse(curTime[1]);

            logger.Output(nextClass.classTime, true);
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
                DateTime classT = DateTime.Parse(classHour + ":" + classMin);
                DateTime currT = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                if (currT >= classT)
                {
                    logger.Output("10 Minutes before class", true);
                }
                else if (DateTime.Parse(todayC.classTime) >= currT && currT < DateTime.Parse(todayC.classEnd))
                {
                    logger.Output(todayC.className + " In progress " + currT.ToString(), true);
                }
                if (currT > DateTime.Parse(todayC.classEnd))
                {
                    logger.Output("Class ended", true);
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
                logger.Output(todayC.classTime, true);
                if (classMin == 0)
                {
                    classMin = 60;
                }
                classHour = classHour - 1;
                classMin = classMin - 10;
                DateTime classT = DateTime.Parse(classHour + ":" + classMin);
                DateTime currT = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                if (currT >= classT)
                {
                    return "Starting Soon" + classT.ToString();
                }
                else if (DateTime.Parse(todayC.classTime) <= currT && currT < DateTime.Parse(todayC.classEnd))
                {
                    return "In Progress";
                }
                if (currT > DateTime.Parse(todayC.classEnd))
                {
                    return "Class Completed";
                }
            }
            return "";
        }
    }
}

