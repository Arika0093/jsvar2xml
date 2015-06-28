using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsvar2xml
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(String[] Params)
		{
			if(Params.Length == 0) {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Main());
			}
			else {
				var js2xml = new Convert_Js2Xml();
				js2xml.ExportPath = ( Params.Length >= 2 ? Params[1] : "" );
				js2xml.ImportPath = Params[0];
				js2xml.Convert();
			}
		}
	}
}
