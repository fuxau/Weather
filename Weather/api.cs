using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    public class WeatherRoot
    {
        public CityInfo city_info { get; set; }
        public CurrentCondition current_condition { get; set; }
        public FcstDay0 fcst_day_0 { get; set; }
        public FcstDay1 fcst_day_1 { get; set; }
        public FcstDay2 fcst_day_2 { get; set; }
        public FcstDay3 fcst_day_3 { get; set; }
        public FcstDay4 fcst_day_4 { get; set; }
    }

    public class CityInfo
    {
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class CurrentCondition
    {
        public string tmp { get; set; } // Température actuelle
        public string humidity { get; set; } // Humidité
        public string pressure { get; set; } // Pression

        public string icon { get; set; }
    }

    public class FcstDay0
    {
        public string date { get; set; }
        public string day_short { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string condition_key { get; set; }
        public string icon { get; set; }
        public string icon_big { get; set; }
    }

    public class FcstDay1
    {
        public string date { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string icon { get; set; }
    }

    public class FcstDay2
    {
        public string date { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string icon { get; set; }
    }

    public class FcstDay3
    {
        public string date { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string icon { get; set; }
    }

    public class FcstDay4
    {
        public string date { get; set; }
        public string day_long { get; set; }
        public int tmin { get; set; }
        public int tmax { get; set; }
        public string condition { get; set; }
        public string icon_big { get; set; }
        
    }
}
