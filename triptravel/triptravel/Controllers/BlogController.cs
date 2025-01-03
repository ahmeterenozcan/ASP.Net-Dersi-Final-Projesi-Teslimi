using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Mvc;
using triptravel.Models;
using triptravel.Models.Siniflar;

namespace triptravel.Controllers
{
	public class BlogController : Controller
	{
		BlogYorum by = new BlogYorum();
		Context c = new Context();

		public ActionResult Index()
		{
			by.Deger1 = c.Blogs.ToList();
			by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
			return View(by);
		}

		public ActionResult BlogDetay(int id)
		{
			by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
			by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
			by.Deger4 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();

			var blog = c.Blogs.FirstOrDefault(x => x.ID == id);
			if (blog != null)
			{
				by.VideoUrl = blog.VideoUrl;
			}

			// Burada hava durumu API'sine istek atıyoruz
			// 1) Şehir bilgisini blog tablosundan alabilirsiniz (örneğin blog.CityName) 
			//    ya da direkt sabit "Istanbul" olarak kullanabilirsiniz.
			string cityName = blog.City;
			// blog tablonuzda şehir varsa => string cityName = blog.City; gibi...

			// 2) API keyinizi buraya yazın
			string apiKey = "cf090882e2b70c1a104f326ed7252cd4";
			string requestUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric&lang=tr";

			// 3) HttpClient ile isteği gönderip yanıtı alma
			using (HttpClient client = new HttpClient())
			{
				var response = client.GetAsync(requestUrl).Result;
				if (response.IsSuccessStatusCode)
				{
					string jsonString = response.Content.ReadAsStringAsync().Result;
					var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(jsonString);

					// BlogYorum modelindeki WeatherData’ya atıyoruz.
					by.WeatherData = weatherData;
				}
			}

			return View(by);
		}

		[HttpGet]
		public PartialViewResult YorumYap(int id)
		{
			ViewBag.deger = id;
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult YorumYap(Yorumlar y)
		{
			c.Yorumlars.Add(y);
			c.SaveChanges();
			return PartialView();
		}
	}
}
