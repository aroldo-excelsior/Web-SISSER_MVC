using System;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using SISSERHelper;
using SISSERCore;

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
		
		
		
		public ActionResult Listar(string proposta)
		{
			
			List<SISSERHelper.EventLog> ev = Controle.Getinstance().ResgatarEventLogs(proposta);
			if(ev.Count != 0)
			ev[0].Proposta = long.Parse(proposta);
			
			return View("PProIndex","",ev);
		}
		
		
		
		public ActionResult Atualizar(string proposta){
		
			List<SISSERHelper.EventLog> ev = Controle.Getinstance().ResgatarEventLogs(proposta);
			ev[0].Proposta = long.Parse(proposta);
			
			return View("PProIndex","",ev);
			
		}
		
		
		public ActionResult Autorizar(int id,string proposta)
		{
			
			int idd = id;
			String User = Request.ServerVariables["AUTH_USER"];
			
			//f.AutorizarEnvioProposta(id,User);
			
			return RedirectToAction("Atualizar", new {proposta=proposta});
		}
		
		public ActionResult ShowXml(int id, string comando){
			
			
				
			if(comando.Equals("dados")){
			
				 Response.Clear();
   	 			 Response.Buffer = true;
    			 Response.Charset = "";
    			// Response.Cache.SetCacheability(HttpCacheability.NoCache);
    			 Response.ContentType = "application/xml";
    			 Response.Write(Controle.Getinstance().ResgatarArgsStackTraceEventLogs(id.ToString()).Argumento);
    			 Response.Flush();
    			 Response.End();
				
			}else if(comando.Equals("trace")){
			
			 	 Response.Clear();
   	 			 Response.Buffer = true;
    			 Response.Charset = "";
    			// Response.Cache.SetCacheability(HttpCacheability.NoCache);
    			 Response.ContentType = "application/xml";
    			 Response.Write(Controle.Getinstance().ResgatarArgsStackTraceEventLogs(id.ToString()).Stack_Trace);
    			 Response.Flush();
    			 Response.End();
    			 
			}
		
			return View();
		}
		
		
		
	}
}