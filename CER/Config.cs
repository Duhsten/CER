using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CER
{
    class Config
    {
        public string configPath = "config.json";
        /// <summary>
        /// Checks to verify the config from json file
        /// </summary>
        public bool checkConfig()
        {
            if (!File.Exists(configPath))
            {
                return false;
            }
            else if (File.Exists(configPath))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Allows the user to Edit the Config 
        /// </summary>
        public void editConfig()
        {
            Console.Clear();
            Console.WriteLine("Config Editor");
            Console.WriteLine();
            Console.WriteLine("Zoom Application Path: ");
            string rZ = Console.ReadLine();
            Console.WriteLine("OBS Application Path: ");
            string rO = Console.ReadLine();
            File.Delete(configPath);
            createConfig(rZ, rO);

        }
        /// <summary>
        /// Loads config into memory
        /// </summary>
        public void loadConfig()
        {
            string json = File.ReadAllText(configPath);
            Settings set = JsonConvert.DeserializeObject<Settings>(json);
        }
        public void createConfig(string z, string o)
        {
            Settings s = new Settings
            {
                zoomDir = @"" +  z,
                obsDir = @"" +  o
            };
            string jsonOut = JsonConvert.SerializeObject(s, Formatting.Indented);
            System.IO.File.WriteAllText(@"config.json", jsonOut);
            Console.WriteLine("Configuration Created");
        }
        public string zoomLocation()
        {
            string json = File.ReadAllText(configPath);
            Settings set = JsonConvert.DeserializeObject<Settings>(json);
            return set.zoomDir;
        }
        public string obsLocation()
        {
            string json = File.ReadAllText(configPath);
            Settings set = JsonConvert.DeserializeObject<Settings>(json);
            return set.obsDir;
        }
    }
}
