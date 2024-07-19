using System;
using System.Runtime.InteropServices;
using System.Text;

namespace INI
{
	// Create a New INI file to store or load data
	public class IniFile
	{
		public string path;

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section,string key,string val,string filePath);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder retVal,int size,string filePath);

		// INIFile Constructor.
		//File Name
		//Use Config Folder
		//Config Folder Name
		public IniFile(string FileName, bool ConfigFolder = false, string ConfigFolderName = "config")
		{
			if (ConfigFolder) { path = Environment.CurrentDirectory + "\\" + ConfigFolderName + "\\" + FileName + ".ini"; }
			else { path = Environment.CurrentDirectory + "\\" + FileName + ".ini"; }
		}

		// Write Data to the INI File
		// Section name
		// Key Name
		// Value Name
		public void IniWriteValue(string Section,string Key,string Value)
		{
			WritePrivateProfileString(Section,Key,Value,path);
		}

		/// Read Data Value From the Ini File
		// Section name
		// Key Name
		// Value Name
		public string IniReadValue(string Section,string Key)
		{
			StringBuilder temp = new StringBuilder(255);
			int i = GetPrivateProfileString(Section,Key,"",temp,255,path);
			return temp.ToString();

		}
	}
}