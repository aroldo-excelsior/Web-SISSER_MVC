using System;
using System.Web.Mvc;
using System.Collections.Generic;
using SISSERCore;

namespace SISSER_MVC.Controllers
{
	/// <summary>
	/// Description of CLimite.
	/// </summary>
	public class CLimiteController : Controller
	{
		public ActionResult CLimIndex()
		{
			
			
			return View();
		}
		
		
		[HttpPost]
		public ActionResult CLimIndex(String TCPF, String anos)
		{
			
			String login = Request.ServerVariables["AUTH_USER"];
			List<Segurado> segurados = Facade.Instance.ConsultarLimiteFinanceiroSegurado(TCPF,int.Parse(anos),login);
			
			
			return View(segurados);
		}
	}
}