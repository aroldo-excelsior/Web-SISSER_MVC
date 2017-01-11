using System;
using System.Data.SqlClient;
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
		
		
		public ActionResult Listar(string textDtIni ,string textDtFin,int? pagina, int? act){
			
			DateTime dtini;
			DateTime dtfin;
			
			act = act ?? 1;
			
			if(Session["lOrder"] == null){
				Session["lOrder"] = "DESC";
			}else if(act == 2 && Session["lOrder"].ToString().Equals("DESC")){
				Session["lOrder"] ="ASC";
			}else if(act == 2){
				Session["lOrder"] = "DESC";
			}
			
			try{
			dtini = DateTime.Parse(textDtIni);
			dtfin = DateTime.Parse(textDtFin);
			}catch(ArgumentNullException){
			
				return RedirectToAction("LProIndex");
				
			}
			
			
			textDtIni = dtini.ToString("yyyyMMdd");
			textDtFin = dtfin.ToString("yyyyMMdd");
			
			//List<SISSERHelper.Proposta> props = Controle.Getinstance().ResgatarPropostas("DESC",textDtIni,textDtFin);
			
			
			List<SISSERHelper.Models.Proposta> props = Controle.Getinstance().ResgatarPropostas(Session["lOrder"].ToString(),textDtIni,textDtFin);
			
			
            int paginaTamanho = 10;
            int paginaNumero = (pagina ?? 1);
            
           
            //Response.Write(props.Count);
            return View("LProIndex","",props.ToPagedList(paginaNumero, paginaTamanho));
			
			//return "Data Inicial: "+textDtIni+" Data Final: "+textDtFin;
			
			//return View("LProIndex","",props);
		}
		
		
		public ActionResult Autorizar(string idd, string dataini,string datafin, int pag){
			
				int id = int.Parse(idd);
				String User = Request.ServerVariables["AUTH_USER"];
				
				Facade.Instance.AutorizarEnvioProposta(id,User);
		
				//return "Dataini: "+dataini+" Datafin: "+datafin;
			return	RedirectToAction("Listar","LProposta",new { textDtIni = dataini, textDtFin = datafin, pagina = pag});
		}
	}
}