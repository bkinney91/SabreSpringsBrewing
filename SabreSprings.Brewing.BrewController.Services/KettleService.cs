using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

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
                Console.WriteLine("Value is " + result + "| END");
                if (result != "")
                {
                    //Clean up input
                    result = string.Concat(result.Where(c => !char.IsWhiteSpace(c)));
                    temperature = Convert.ToInt32(result);
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
                Console.WriteLine("Value is " + result + "| END");
                if (result != "")
                {
                    //Clean up input
                    result = string.Concat(result.Where(c => !char.IsWhiteSpace(c)));
                    temperature = Convert.ToInt32(result);
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
            start.Arguments = AppDomain.CurrentDomain.BaseDirectory + "Scripts/pidController.py --target" + temperature;
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
