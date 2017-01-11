using System;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using SISSERHelper;
using SISSERCore;
using PagedList;

namespace SISSER_MVC.Controllers
{
	/// <summary>
	/// Description of PPropostaController.
	/// </summary>
	public class PPropostaController : Controller
	{
		Facade f = Facade.Instance;
	
		public ActionResult PProIndex(){
			
			
			
			return View();
		}
		
		
		
		public ActionResult Listar(string proposta, int? pagina, int? act)
		{
			
			act = act ?? 1;
			
			if(Session["pOrder"] == null){
				Session["pOrder"] = "DESC";
			}else if(act == 2 &&Session["pOrder"].ToString().Equals("DESC")){
				Session["pOrder"] ="ASC";
			}else if(act == 2){
				Session["pOrder"] = "DESC";
			}
			
			SISSERHelper.Models.Proposta prop = Controle.Getinstance().BuscarProposta(proposta);
			List<SISSERHelper.Models.EventLog> ev = new List<SISSERHelper.Models.EventLog>();
			
			if(prop.nrProposta != null){
			
				ev = Controle.Getinstance().ResgatarEventLogs(Session["pOrder"].ToString(),prop.id);
				prop.nrProposta = proposta;
				ViewBag.apolice = prop;
				
			}
			
			
            int paginaTamanho = 10;
            int paginaNumero = (pagina ?? 1);

            return View("PProIndex","",ev.ToPagedList(paginaNumero, paginaTamanho));
			
		}
		
		
		
		public ActionResult Autorizar(int id,string proposta)
		{
			
			int idd = id;
			String User = Request.ServerVariables["AUTH_USER"];
			
			f.AutorizarEnvioProposta(id,User);
			
			return RedirectToAction("Listar", new {proposta=proposta});
		}
		
		public ActionResult ShowXml(int id, string comando){
			
			
				
			if(comando.Equals("dados")){
			
				 Response.Clear();
   	 			 Response.Buffer = true;
    			 Response.Charset = "";
    			// Response.Cache.SetCacheability(HttpCacheability.NoCache);
    			 Response.ContentType = "application/xml";
    			 Response.Write(Controle.Getinstance().ResgatarArgsStackTraceEventLogs(id.ToString()).argumento);
    			 Response.Flush();
    			 Response.End();
				
			}else if(comando.Equals("trace")){
			
			 	 Response.Clear();
   	 			 Response.Buffer = true;
    			 Response.Charset = "";
    			// Response.Cache.SetCacheability(HttpCacheability.NoCache);
    			 Response.ContentType = "application/xml";
    			 Response.Write(Controle.Getinstance().ResgatarArgsStackTraceEventLogs(id.ToString()).stack_Trace);
    			 Response.Flush();
    			 Response.End();
    			 
			}
		
			return View();
		}
		
		
		
	}
}