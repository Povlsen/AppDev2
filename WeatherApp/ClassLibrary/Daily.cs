﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Daily
    {
        public int dt { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public Temp temp { get; set; }
        public FeelsLike feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double dew_point { get; set; }
        public double wind_speed { get; set; }
        public int wind_deg { get; set; }
        public List<Weather> weather { get; set; }
        public int clouds { get; set; }
        public int pop { get; set; }
        public double uvi { get; set; }
    }
}
