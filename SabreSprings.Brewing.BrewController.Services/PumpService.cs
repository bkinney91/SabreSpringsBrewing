using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System.Device.Gpio;


namespace SabreSprings.Brewing.BrewController.Services
{
    public class PumpService : IPumpService
    {
        public bool Pump1Enabled {get; private set;}
        public bool Pump2Enabled {get; private set;}
        private GpioController Rpi;
        private const int Pump1Pin = 20;
        private const int Pump2Pin = 26;
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
