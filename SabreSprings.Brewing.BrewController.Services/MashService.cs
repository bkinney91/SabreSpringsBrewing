using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SabreSprings.Brewing.BrewController.Services
{
    public class MashService : IMashService
    {

        public decimal GetTemperature()
        {
            decimal temperature;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "rtd";
            start.Arguments = "0 read 5";
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
                    //Convert to decimal and save
                    temperature = Convert.ToDecimal(result);
                    //Covnert from Celsius to Farenheit
                    temperature = ((9.0m / 5.0m) * temperature) + 32;
                }
                else
                {
                    temperature = 0;
                }
            }
            return temperature;
        }
    }
}
