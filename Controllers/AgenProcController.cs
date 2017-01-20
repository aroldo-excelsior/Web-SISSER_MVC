using System;
using System.Web.Mvc;
using SISSERCore;
using System.Collections.Generic;
using PagedList;
using SISSERHelper.Enums;

namespace SISSER_MVC.Controllers
{
	/// <summary>
	/// Description of AgenProcController.
	/// </summary>
	public class AgenProcController : Controller
	{
		
		
		public ActionResult AgenProcIndex(int? paginaproc, int? paginatask)
		{
		
			
			return View(GenerateModel(paginaproc,paginatask));
			
		}
		
		public PartialViewResult Updatedpanel(int? paginaproc,int? paginatask){
			
			
			return PartialView(GenerateModel(paginaproc,paginatask));
			
		}
		
		public ActionResult Agendar(int? paginaproc, int? paginatask, EnumExecucaoTarefaTipo com){
			Facade f = Facade.Instance;
			
			String User = Request.ServerVariables["AUTH_USER"];
			
			if(com == EnumExecucaoTarefaTipo.EnviarPropostaProgramaSub){
			
				ExecucaoTarefa tafvin = new ExecucaoTarefa();
				tafvin.TarefaTipoID = (int)EnumExecucaoTarefaTipo.VincularProgramaSubProposta;
				f.Inserir(tafvin,User);
				
			}
			          
           ExecucaoTarefa taf = new ExecucaoTarefa();
           
           taf.TarefaTipoID = (int) com;
         
           f.Inserir(taf,User);
			
			
            
            return  RedirectToAction("AgenProcIndex",new {paginaproc = paginaproc,paginatask = paginatask});
			
		}
		
		private List<IPagedList> GenerateModel(int? paginaproc,int? paginatask){
		
			
			int  paginaTamanho = 10;
			
			List<IPagedList> Pageds = new List<IPagedList>();
            
			
			/*Model[0]*/
            int paginaNumerotask = (paginatask ?? 1);
            List<ExecucaoTarefa> taskList = Facade.Instance.ListarExecucaoTarefa(null);
            Pageds.Add(taskList.ToPagedList(paginaNumerotask, paginaTamanho));
            
            
            /*Model[1]*/
            int paginaNumeroproc = (paginaproc ?? 1);
            List<ExecucaoProcesso> proclist = Facade.Instance.ListarExecucaoProcesso(null);
			Pageds.Add(proclist.ToPagedList(paginaNumeroproc, paginaTamanho));
			
			return(Pageds);
			
			
		}
		
		
	}
}