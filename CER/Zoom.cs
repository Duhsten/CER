using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace CER
{
    class Zoom
    {
        
        public string zoomPath = @"C:\Users\dusti_721ro61\AppData\Roaming\Zoom\bin\Zoom.exe";
        /// <summary>
        /// Starts the Zoom Application
        /// </summary>
        public void Start()
        {
            Config conf = new Config();
            Process.Start(conf.zoomLocation());
        }
        /// <summary>
        /// Joins a Zoom Meeting with String sessionID 
        /// </summary>
        public void JoinMeeting(string sessionID)
        {
            
        }
        /// <summary>
        /// Leaves the Zoom Meeting
        /// </summary>
        public void LeaveMeeting()
        {

        }

        private void BringtoFront()
        {

        }
    }
}
