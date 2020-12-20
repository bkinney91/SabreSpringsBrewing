using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SabreSprings.Brewing.BrewController.Services
{
    public class PumpService : IPumpService
    {
        public bool Pump1Enabled {get; private set;}
        public bool Pump2Enabled {get; private set;}
        private GpioController Rpi;
        private const int Pump1Pin = 26;
        private const int Pump2Pin = 20;
        public PumpService()
        {
            Pump1Enabled = false;
            Pump2Enabled = false;
            Rpi = new GpioController();
            Rpi.OpenPin(Pump1Pin, PinMode.Output);
            Rpi.OpenPin(Pump2Pin, PinMode.Output);
        }

        ~PumpService()
        {
            Rpi.Dispose();
        }

        public void Pump1(bool enablePower)
        {
            Pump1Enabled = enablePower;
            Rpi.Write(Pump1Pin, enablePower ? PinValue.High: PinValue.Low);
        }

        public void Pump2(bool enablePower)
        {
            Pump2Enabled = enablePower;
            Rpi.Write(Pump2Pin, enablePower ? PinValue.High: PinValue.Low);
        }

        public bool GetPump1PowerState()
        {
            PinValue pinValue = Rpi.Read(Pump1Pin);
            return pinValue == PinValue.High;
        }

        public bool GetPump2PowerState()
        {
            PinValue pinValue = Rpi.Read(Pump2Pin);
            return pinValue == PinValue.High;
        }


    }
}
