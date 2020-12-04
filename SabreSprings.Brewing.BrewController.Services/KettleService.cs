using System;
using System.Diagnostics;
using System.IO;

namespace SabreSprings.Brewing.BrewController.Services
{
    public class KettleService
    {
        public decimal GetTemperature()
        {
            decimal temperature;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = "getKettleTemperature.py";
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

        public void SetTemperature(decimal temperature)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = "setKettleTemperature.py " + temperature;
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
