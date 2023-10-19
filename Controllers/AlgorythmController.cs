
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Policy;
using url_shortener_service.Areas.Identity.Data;
using url_shortener_service.Models;

namespace url_shortener_service.Controllers
{
	public class AlgorythmController : Controller
	{

		private readonly ApplicationDbContext _context;
		public AlgorythmController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			return View();
		}


		private static string RandomString(int length)
		{
			Random random = new Random();
			const string chars = "ABCDEFHGIJKLMNOPQRSTUVWXYZ123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		public IActionResult ShortUrl(url_shortener_service.Areas.Identity.Data.Url url)
		{
			url.ShortValue = RandomString(10);
			_context.Urls.Add(url);
			_context.SaveChanges();
			return View("GetUrl", url);
		}

		public IActionResult RedirectByUrl()
		{
			return View();
		}


		public IActionResult ForceRedirectByUrl(url_shortener_service.Areas.Identity.Data.Url url)
		{
			var shorturl = _context.Urls.FirstOrDefault(u => u.ShortValue == url.OriginValue);
			return Redirect(shorturl.OriginValue);

		}
	}
	


		
}
	

