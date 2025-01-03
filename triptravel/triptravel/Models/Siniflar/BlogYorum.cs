using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace triptravel.Models.Siniflar
{
	public class BlogYorum
	{
		public IEnumerable<Blog> Deger1 { get; set; }
		public IEnumerable<Yorumlar> Deger2 { get; set; }

		public IEnumerable<Blog> Deger3 { get; set; }

		public IEnumerable<Blog> Deger4 { get; set; }
		
		public string VideoUrl {  get; set; }

		public WeatherResponse WeatherData { get; set; }


	}
}