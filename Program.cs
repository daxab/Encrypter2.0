using System;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

		
class MainClaas
{
	[DllImport("kernel32.dll")]
	static extern IntPtr GetConsoleWindow();

	[DllImport("user32.dll")]
	static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	
	[STAThread]
	public static void Main (string[] args)
	{
		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		var handle = GetConsoleWindow();
		ShowWindow(handle, SW_HIDE);
		Application.EnableVisualStyles ();
		Application.Run (new Program ());
	}

}
}

