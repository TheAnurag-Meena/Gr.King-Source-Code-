using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace GR_King
{
    internal class EMU
    {
        public string pathgameloop;

        public void pathgameloop1()
        {
            try
            {
                pathgameloop = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI", "InstallPath", "").ToString();

            }
            catch
            {
            }
        }
        public void Exitemu()
        {
            try
            { 
                foreach (Process process in Process.GetProcessesByName("Core.dll"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("Core"))
                    process.Kill();
            }
            catch
            {
            }

            try { File.Delete(pathgameloop + "\\aow.log"); } catch { }
            try { File.Delete(pathgameloop + "\\aow_0.log"); } catch { }
            try { File.Delete(pathgameloop + "\\aow_100.log"); } catch { }


            string str313 = "netsh advfirewall firewall delete rule name=private & netsh advfirewall firewall delete rule name=private1 & netsh advfirewall firewall delete rule name=private2 & netsh advfirewall firewall delete rule name=update & del C:\\Windows\\Help\\Windows\\Core.dll /f /q & del C:\\Windows\\Help\\Windows\\Utransfer.dll & del C:\\Windows\\System32\\drivers\\etc\\hosts /f /q";
            Interaction.Shell("cmd /c" + str313, AppWinStyle.Hide, true, -1);
            

        }

        public void appmarketkill()
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName("MGDetector"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("TUpdate"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("Updater32"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("syzs_dl_svr"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("appmarket"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("GameLoader"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("QMEmulatorService"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("RuntimeBroker"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("TBSWebRenderer.exe"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("TInst.exe"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("TxGaDcc"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("QQPCExternal"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("TP3Helper"))
                    process.Kill();

            }
            catch
            {
            }


        }
        public void emulatorkill()
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName("AndroidEmulator"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("MGDetector"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("TUpdate"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("Updater32"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("syzs_dl_svr"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("appmarket"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("aow_exe"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("GameLoader"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("QMEmulatorService"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("RuntimeBroker"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("adb"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("TSettingCenter"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("Core.dll"))
                    process.Kill();
                foreach (Process process1 in Process.GetProcessesByName("aow_exe"))
                    process1.Kill();
                foreach (Process process in Process.GetProcessesByName("ProjectTitan"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("AndroidProcess"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("TitanService"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("Conhost"))
                    process.Kill();

            }
            catch
            {
            }

            string str312 = "net stop aow_drv & net stop QMEmulatorService & net stop UniSafe";
            Interaction.Shell("cmd /c" + str312, AppWinStyle.Hide, true, -1);
        }

        
    }
}
