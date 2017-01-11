using System;
using System.Web.Mvc;
using SISSERCore;
using System.Collections.Generic;
using PagedList;

namespace SISSER_MVC.Controllers
{
	/// <summary>
	/// Description of AgenProcController.
	/// </summary>
	public class AgenProcController : Controller
	{
		
		
		public ActionResult AgenProcIndex(int? pagina)
		{
			ViewData["progress"] = "0";
			
			//Response.AddHeader("Refresh", "15");
            
			int paginaTamanho = 10;
            int paginaNumero = (pagina ?? 1);
            
			List<ExecucaoProcesso> proclist = Facade.Instance.ListarExecucaoProcesso(null);
			return View(proclist.ToPagedList(paginaNumero, paginaTamanho));
		}
		
		public ActionResult Agendar(int? pagina){
		
			Facade f = Facade.Instance;
			
			String User = Request.ServerVariables["AUTH_USER"];
			
			int minuto = DateTime.Now.Minute+1;
			
			if(minuto > 59){
				minuto -= 60;
			}
			
			
			DateTime inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            DateTime final = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, minuto , 0);

            ExecucaoProcesso proc = new ExecucaoProcesso();
            proc.DtInicioVigencia = inicio;
            proc.DtFinalVigencia = final;
            proc.HoraExecucao = DateTime.Now.TimeOfDay;
            proc.StatusExecucao = EnumExecucaoProcessoStatus.Pendente;
            proc.Descricao = "Processo Agendado";
            
            

            f.Inserir(proc, User);
			
          
            
            return  RedirectToAction("AgenProcIndex");
			
		}
		public PartialViewResult Updatedbutton(int? pagina){
		
			
			int paginaTamanho = 10;
            int paginaNumero = (pagina ?? 1);
			
			List<ExecucaoProcesso> proclist = Facade.Instance.ListarExecucaoProcesso(null);
			if(proclist.Count != 0){
				ViewData["progress"]="0";
				DateTime Dtlastproc = (DateTime)proclist[proclist.Count-1].DtFinalVigencia;
			
				Dtlastproc = Dtlastproc.AddMinutes(1);
				DateTime agora = DateTime.Now;
			
				TimeSpan dif = Dtlastproc - agora;
			
				int segunds = 60;
				ViewData["progress"] = (dif.Seconds*100)/segunds;
				
			}else{
				ViewData["progress"] = "0";
			}
			
			return PartialView(proclist.ToPagedList(paginaNumero, paginaTamanho));
			
			
		}
	}
}