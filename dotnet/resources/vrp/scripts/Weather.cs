using GTANetworkAPI;
using GTANetworkInternals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;


/// <summary>
/// Class for managing weather
/// </summary>
class WeatherManager :Script
{
    public WeatherManager()
    {
        TimerEx.SetTimer(() =>
        {
            NAPI.World.SetWeather(Weather.EXTRASUNNY);
        }, 120000, 0);
    }

}
