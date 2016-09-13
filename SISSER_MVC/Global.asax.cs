/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 26/08/2016
 * Time: 13:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SISSER_MVC
{
	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Ignore("{resource}.axd/{*pathInfo}");
			
			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new {
					controller = "Home",
					action = "Index",
					id = UrlParameter.Optional
				});
			
			routes.MapRoute(
				"PProposta",
				"{controller}/{action}/{id}",
				new {
					controller = "PProposta",
					action = "PProIndex",
					id = UrlParameter.Optional
				});
		}
		
		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
		}
	}
}
