using System;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

public class Encrypter
{
	public static string ApplyXOR(string message, string key)
	{
		int ch;
		int n;
		int int_key = 0;
		string result = "";
		for( int i = 0; i < key.Length; i ++)
		{
			int_key += Convert.ToInt32 ((key).ToCharArray()[i]);

		}


		for(int i = 0; i < message.Length; i++)
		{
			ch = (int) message[i];
			n = ch^int_key;
			result += (char)n;
		}
		return result;
	}

}


