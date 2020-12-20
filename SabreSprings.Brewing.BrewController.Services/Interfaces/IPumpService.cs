using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.BrewController.Services.Interfaces
{
    public interface IPumpService
    {
        void Pump1(bool enablePower);
        void Pump2(bool enablePower);
        bool GetPump1PowerState();
        bool GetPump2PowerState();
       
    }
}
