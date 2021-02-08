using System;
using System.Collections.Generic;
using System.Threading;

namespace CER
{
    class Program
    {
        public bool startArg;
        static void Main(string[] args)
        {
            if (args[0] == "-start")
            {
                Start();
            }
            if (args[0] == "-debug")
            {
                ClassManager c = new ClassManager();
                c.GetTodaysClass();
            }
            else if (args[0] == "-edit")
            {
                if (args[1] == "classes")
                {
                    ClassManager cmm = new ClassManager();
                    cmm.editClass();
                }
                else if (args[1] == "config")
                {
                    Config con = new Config();
                    con.editConfig();
                }
            }
            else
            {
                Console.WriteLine("ERROR: Unknown arguments at launch");
            }
           

        }

        public static void Start()
        {
            ClassHandler cH = new ClassHandler();
            Logger Log = new Logger();
            Config conf = new Config();
            bool cr = conf.checkConfig();
            ClassManager cm = new ClassManager();
            OBS o = new OBS();
            Zoom z = new Zoom();
            // cm.InitClassData();
            //   z.Start();
            //  o.Start();
           
            Console.Clear();
            Log.Output("**************************************",false);
            Log.Output("***   CLASS ENVIROMENT RECORDER    ***",false);
            Log.Output("**************************************",false);
            Log.Output("***  Developed by: Dustin Osborne  +++",false);
            Log.Output("**************************************",false);
            Console.WriteLine();
            Thread.Sleep(500);
            Log.Output("Initiating Class Enviroment Recorder",true);
            Thread.Sleep(500);

            if (cr)
            {
                Log.Output("Configuration found, loading settings",true);
                Thread.Sleep(500);
                Log.Output("Zoom: " + conf.zoomLocation(),true);
                Thread.Sleep(500);
                Log.Output("OBS Studio: " + conf.obsLocation(),true);
                Thread.Sleep(500);
            }
            else if (!cr)
            {
                Log.Output("Configuration Not Found. Please enter the following Information",true);
                Thread.Sleep(500);
                Console.WriteLine("Zoom Application Directory: ");
                string zResult = Console.ReadLine();
                Console.WriteLine("OBS Application Directory: ");
                string oResult = Console.ReadLine();
                conf.createConfig(zResult, oResult);
                conf.loadConfig();

            }
            Log.Output("Starting Class Enviroment Recorder", true);
            Thread.Sleep(500);
            Console.WriteLine("Press ESC to stop");
            do
            {
                Console.Clear();
                while (!Console.KeyAvailable)
                {
                    // THE RUN LOOP
                    Class currentClass = cH.CurrentClass();
                    Class nextClass = cm.GetNextClass();
                    cH.PreInitCheck();
                    string prompt = "";
                    string prompt2 = "";
                    //Some stupid shit
                    if (nextClass.className == "No Class")
                    {
                        prompt = "No more classes left today";
                       
                    }
                    else
                    {
                        prompt2 = "Next Class: " + nextClass.className + " at " + nextClass.classTime;
                    }

                    // Run 
                    
                    List<Class> todaysClass = cm.GetTodaysClass();
                    Log.Output("**************************************", false);
                    Log.Output("***   CLASS ENVIROMENT RECORDER    ***", false);
                    Log.Output("**************************************", false);
                    Log.Output("*****       STATUS: RUNNING      *****", false);
                    Log.Output("**************************************", false);
                    Console.WriteLine();
                    string time = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt");
                    Log.Output("********************************************", false);
                    Log.Output("Current Time: " + time + " ***", false);
                    Log.Output("********************************************", false);
                    Log.Output("Current Class: " + currentClass.className, false);
                    Log.Output("********************************************", false);
                    Log.Output(prompt + prompt2 , false);
                    Log.Output("********************************************", false);
                    Log.Output("********************************************", false);
                    Log.Output( "Classes Today:                       ", false);
                    foreach (Class s in todaysClass)
                    {
                        DateTime classTime = DateTime.Parse(s.classTime);
                        DateTime currTime = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                        string status = cH.GetStatus();

                        Log.Output(s.className + " : " + classTime.ToString("h:mm tt") + " : " + status, false); 
                    }
                    Log.Output("********************************************", false);
                    cH.PreInitCheck();
                    Console.WriteLine();
                    Console.WriteLine("Press ESC to stop");
                    Thread.Sleep(1000);
                    Console.Clear();

                    cH.CurrentClass();

                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Log.Output("Stopping Class Enviroment Recorder", true);
            Thread.Sleep(500);
            Console.Clear();
            Log.Output("**************************************", false);
            Log.Output("***   CLASS ENVIROMENT RECORDER    ***", false);
            Log.Output("**************************************", false);
            Log.Output("*****       STATUS: STOPPED      *****", false);
            Log.Output("**************************************", false);
        }
    }
}
