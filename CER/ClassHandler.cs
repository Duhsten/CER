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
            string currentTime = DateTime.Now.ToString("HH:mm");
            string[] curTime = currentTime.Split(":");
            int currentHour = Int32.Parse(curTime[0]);
            int currentMin = Int32.Parse(curTime[1]);
            string classTime = nextClass.classTime;
            string[] clTime = classTime.Split(":");
            int classHour = Int32.Parse(clTime[0]);
            int classMin = Int32.Parse(clTime[1]);
            if(classMin == 0)
            { 
                classMin = 60;
            }

            if(currentHour == classHour - 1)
            { 
                if(currentMin >= classMin - 10 )
                {
                    logger.Output("10 Minutes till " + nextClass.className, true);   
                }
            }


        }
    }
}
