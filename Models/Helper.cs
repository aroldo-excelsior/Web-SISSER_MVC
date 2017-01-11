/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 21/09/2016
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SISSER_MVC.Models
{
	/// <summary>
	/// Description of Helper.
	/// </summary>
	public class Helper
	{
		
		private static string _erroMessage;
		
		
		public static string erroMessage{
		
			get{return _erroMessage;}
			set{_erroMessage = value;}
			
		}
		
		public Helper()
		{
		
			
		}
		
		
		
	}
}
