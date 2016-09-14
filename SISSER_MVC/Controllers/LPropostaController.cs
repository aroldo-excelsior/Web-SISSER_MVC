using System;
using System.Web.Mvc;
using SISSERHelper;
using System.Collections.Generic;
using SISSERCore;
using PagedList;

namespace SISSER_MVC.Controllers
{
	/// <summary>
	/// Description of LPropostaController.
	/// </summary>
	public class LPropostaController : Controller
	{
		
		
		public ActionResult LProIndex()
		{
			return View();
		}
		
		
		public ActionResult Listar(string textDtIni ,string textDtFin,int? pagina){
			
			DateTime dtini;
			DateTime dtfin;
			
			dtini = DateTime.Parse(textDtIni);
			dtfin = DateTime.Parse(textDtFin);
			
			textDtIni = dtini.ToString("yyy/MM/dd");
			textDtFin = dtfin.ToString("yyy/MM/dd");
			
			//List<SISSERHelper.Proposta> props = Controle.Getinstance().ResgatarPropostas("DESC",textDtIni,textDtFin);
			
			
			var props = Controle.Getinstance().ResgatarPropostas("DESC",textDtIni,textDtFin);
            int paginaTamanho = 10;
            int paginaNumero = (pagina ?? 1);

            return View("LProIndex","",props.ToPagedList(paginaNumero, paginaTamanho));
			
			//return "Data Inicial: "+textDtIni+" Data Final: "+textDtFin;
			
			//return View("LProIndex","",props);
		}
		
		
		public ActionResult Autorizar(string idd, string dataini,string datafin){
			
				int id = int.Parse(idd);
				String User = Request.ServerVariables["AUTH_USER"];
				
				Facade.Instance.AutorizarEnvioProposta(id,User);
		
				//return "Dataini: "+dataini+" Datafin: "+datafin;
			return	RedirectToAction("Listar","LProposta",new { textDtIni = dataini, textDtFin = datafin});
		}
	}
}