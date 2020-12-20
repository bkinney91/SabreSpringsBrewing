using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SabreSprings.Brewing.BrewController.Services
{
    public class KettleService : IKettleService
    {

        public int GetCurrentTemperature()
        {
            int temperature;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python3";
            start.Arguments = AppDomain.CurrentDomain.BaseDirectory + "Scripts/pidController.py --current";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                string result = "";
                while (!process.HasExited)
                {
                    result += process.StandardOutput.ReadToEnd();
                }
                if (result != "")
                {
                    //Clean up input
                    result = result.Trim();      
                    decimal temp = Convert.ToDecimal(result);
                    temperature = (int)temp;
                }
                else
                {
                    temperature = 0;
                }
            }
            return temperature;
        }



        public int GetTargetTemperature()
        {
            int temperature;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python3";
            start.Arguments = AppDomain.CurrentDomain.BaseDirectory + "Scripts/pidController.py --target";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                string result = "";
                while (!process.HasExited)
                {
                    result += process.StandardOutput.ReadToEnd();
                }
                if (result != "")
                {
                    //Clean up input
                    result = result.Trim();
                    decimal temp = Convert.ToDecimal(result);
                    temperature = (int)temp;
                }
                else
                {
                    temperature = 0;
                }
            }
            return temperature;
        }

        public void SetTemperature(int temperature)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python3";
            start.Arguments = AppDomain.CurrentDomain.BaseDirectory + "Scripts/pidController.py --set" + temperature;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            Process process = Process.Start(start); 
            while(!process.HasExited)      {}     //Wait for process to finish 
        }
    }
}
