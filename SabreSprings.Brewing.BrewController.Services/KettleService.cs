using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace SabreSprings.Brewing.BrewController.Services
{
    public class KettleService : IKettleService
    {

        public int GetCurrentTemperature()
        {
            int temperature;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = AppDomain.CurrentDomain.BaseDirectory + "Scripts\\test.py --current";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    temperature = Convert.ToInt32(reader.ReadToEnd());
                    
                }
            }
            return temperature;
        }



        public int GetTargetTemperature()
        {
            int temperature;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = AppDomain.CurrentDomain.BaseDirectory + "Scripts\\test.py --target";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    temperature = Convert.ToInt32(reader.ReadToEnd());
                    
                }
            }
            return temperature;
        }

        public void SetTemperature(int temperature)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = "pidController.py --set " + temperature;
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
