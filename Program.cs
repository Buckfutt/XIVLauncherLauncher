using INI;
using System.Diagnostics;

IniFile ini = new IniFile("Launcher", false, "");
string ACTPath;
string LauncherPath;

ACTPath = ini.IniReadValue("Paths", "ACT");
Console.WriteLine("Launching ACT...");
Process.Start(ACTPath, @" -onlyone");

LauncherPath = ini.IniReadValue("Paths", "XIVLauncher");
Console.WriteLine("Launching FFXIVLauncher...");
Process.Start(LauncherPath);

Environment.Exit(0);