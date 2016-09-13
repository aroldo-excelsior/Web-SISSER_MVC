using System;
using System.Web.Mvc;

namespace SISSER_MVC.Controllers
{
	/// <summary>
	/// Description of Error.
	/// </summary>
	public class ErrorController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult Mapa()
		{
			return View();
		}
		
		public ActionResult notfound()
		{
			return View();
		}
	}
}