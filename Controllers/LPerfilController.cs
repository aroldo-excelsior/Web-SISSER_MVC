using System;
using System.Web.Mvc;
using PagedList;
using System.Collections.Generic;
using SISSERHelper;

namespace SISSER_MVC.Controllers
{
	/// <summary>
	/// Description of LPerfilController.
	/// </summary>
	public class LPerfilController : Controller
	{
		public ActionResult LPerfilIndex()
		{
		
            return View();
		}
		
		
		public ActionResult Listar(string textDtIni ,string textDtFin,int? pagina){
		
			DateTime DtIni = new DateTime();
			DateTime DtFin = new DateTime();
			try{
			DtIni = DateTime.Parse(textDtIni);
			DtFin = DateTime.Parse(textDtFin);
			}catch(ArgumentNullException){
			
				return RedirectToAction("LPerfilIndex");
				
			}
			
			List<SISSERHelper.Models.PerfilEnvioProgramaSubvencao> props = Controle.Getinstance().getPerfilsByDate(DtIni,DtFin);
			
			
			foreach(var p in props){
			
				p.dt_inicio_vigencia_perfil = DateTime.Parse(p.dt_inicio_vigencia_perfil).ToString("dd/MM/yyyy");
				p.dt_final_vigencia_perfil = DateTime.Parse(p.dt_final_vigencia_perfil).ToString("dd/MM/yyyy");
				p.dt_inicio_vigencia_proposta = DateTime.Parse(p.dt_inicio_vigencia_proposta).ToString("dd/MM/yyyy");
				p.dt_final_vigencia_proposta = DateTime.Parse(p.dt_final_vigencia_proposta).ToString("dd/MM/yyyy");
				
			}
            int paginaTamanho = 10;
            int paginaNumero = (pagina ?? 1);
			
			
			 return View("LPerfilIndex","",props.ToPagedList(paginaNumero, paginaTamanho));
			
		}
	}
}