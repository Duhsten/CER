using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CER
{
    class OBS
    {
        public string obsPath = @"C:\Program Files\obs-studio\bin\64bit\";
        public string obsExec = "obs64.exe";
     //   Process[] processes = Process.GetProcessesByName("obs64");
        /// <summary>
        ///  Starts OBS on the local machine
        /// </summary>
        public void Start()
        {
            Process.Start(obsPath + obsExec);
        }
        /// <summary>
        /// Stops OBS on the local machine
        /// </summary>
        public void Stop()
        {

        }
        /// <summary>
        /// Starts recording in OBS
        /// </summary>
        public void StartRecording()
        {

        }
        /// <summary>
        /// Stops Recording in OBS
        /// </summary>
        public void StopRecording()
        {

        }




        private void BringOBSFront()
        {

        }
    }
}
