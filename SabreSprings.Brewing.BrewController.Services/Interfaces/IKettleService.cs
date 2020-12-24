using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.BrewController.Services.Interfaces
{
    public interface IKettleService
    {
        int GetTargetTemperature();
        int GetCurrentTemperature();
        void SetTemperature(int temperature);
    }
}
