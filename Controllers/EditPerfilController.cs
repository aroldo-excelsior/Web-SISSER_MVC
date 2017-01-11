using System;
using System.Web.Mvc;
using SISSERHelper.Models;
using SISSERHelper;
using SISSERHelper.Enums;
using SISSER_MVC.Models;

namespace SISSER_MVC.Controllers
{
	/// <summary>
	/// Description of EditPerfilController.
	/// </summary>
	public class EditPerfilController : Controller
	{
		public ActionResult EditPerfIndex(int id)
		{
			PerfilEnvioProgramaSubvencao perf = Controle.Getinstance().getPerfilEnvioProgramaSubvencaoById(id);
			perf.inserted = EnumInserted.Updating;
			
			perf.dt_inicio_vigencia_perfil = DateTime.Parse(perf.dt_inicio_vigencia_perfil).ToString("dd/MM/yyyy");
			perf.dt_final_vigencia_perfil = DateTime.Parse(perf.dt_final_vigencia_perfil).ToString("dd/MM/yyyy");
			perf.dt_inicio_vigencia_proposta = DateTime.Parse(perf.dt_inicio_vigencia_proposta).ToString("dd/MM/yyyy");
			perf.dt_final_vigencia_proposta = DateTime.Parse(perf.dt_final_vigencia_proposta).ToString("dd/MM/yyyy");
			return View(perf);
		}
		
		[HttpPost]
		public ActionResult EditPerfIndex(PerfilEnvioProgramaSubvencao perf){
		
			if(ModelState.IsValid){
				
				perf.inserted = Controle.Getinstance().UpdatePerfilEnvioProgramaSubvencao(perf);
				
			}else{
				perf.inserted = EnumInserted.ModelIsNotValid;
			}
			
			return View(perf);
		}
	}
}