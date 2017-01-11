using System;
using System.Web.Mvc;
using SISSERCore;
using System.Collections.Generic;
using SISSERHelper;
using SISSER_MVC.Models;
using SISSERHelper.Enums;

namespace SISSER_MVC.Controllers
{
	/// <summary>
	/// Description of CadPerfilController.
	/// </summary>
	public class CadPerfilController : Controller
	{
		public ActionResult CadPerfIndex()
		{
			
			return View();
			
		}
		
		[HttpPost]
		public ActionResult CadPerfIndex(SISSERHelper.Models.PerfilEnvioProgramaSubvencao perf)
		{
			
			if(ModelState.IsValid){
				if(!Controle.Getinstance().PerfildescricaoExists(perf.descricao.Trim())){
					perf.inserted = Controle.Getinstance().InsertPerfilEnvioProgramaSubvencao(perf);
				}else{
					Helper.erroMessage = "Já existe um perfil com essa descrição.";
					perf.inserted = EnumInserted.DescricaoExists;
					
				}
			}else{
				perf.inserted = EnumInserted.ModelIsNotValid;
			}
			
			return View(perf);
		}
	}
}