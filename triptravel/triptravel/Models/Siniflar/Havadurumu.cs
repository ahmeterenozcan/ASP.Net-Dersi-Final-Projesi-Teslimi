using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace triptravel.Models.Siniflar
{
	public class WeatherResponse
	{
		public List<Weather> weather { get; set; }
		public Main main { get; set; }
		public string name { get; set; }
	}

	public class Weather
	{
		public string description { get; set; }
		public string icon { get; set; }
	}

	public class Main
	{
		public float temp { get; set; }
		public float feels_like { get; set; }
		public int pressure { get; set; }
		public int humidity { get; set; }
	}
}