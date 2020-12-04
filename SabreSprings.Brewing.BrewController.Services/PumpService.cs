using System;
using System.Diagnostics;
using System.IO;

namespace SabreSprings.Brewing.BrewController.Services
{
    public class PumpService
    {
        public void PowerPump1()
        {
            decimal temperature;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = "pumpRealy.py";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    temperature = Convert.ToInt32(reader.ReadToEnd());
                    
                }
            }
        }

        public void PowerPump2()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = "pumpRelay.py";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string output = reader.ReadToEnd();
                    
                }
            }
        }
    }
}
