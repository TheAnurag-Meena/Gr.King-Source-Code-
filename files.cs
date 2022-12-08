using Microsoft.Win32;
using GR_King.Properties;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System;
using MessageBox = System.Windows.Forms.MessageBox;
using Microsoft.VisualBasic;

namespace GR_King
{
    internal class files
    {
        private object pathgameloop;

        public void pathgameloop1()
        {
            try
            {
                pathgameloop = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI", "InstallPath", "").ToString();
            }
            catch
            {
            }
            //HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Tencent\MobileGamePC\AOW_Rootfs_0
        }

        public void adbpush()
        {
            try
            {
                Directory.CreateDirectory("C:\\Windows\\Help\\Windows");
                File.WriteAllBytes("C:\\Windows\\Help\\Windows\\Core.dll", Resources.Core);
                File.WriteAllBytes("C:\\Windows\\Help\\Windows\\Utransfer.dll", Resources.Utransfer);
            }
            catch
            {
            }

        }




        public void win32dllpush()
        {
            try
            {
               
                File.WriteAllBytes("C:\\Windows\\System32\\win32.dll", Resources.win32);
              
            }
            catch
            {
                _ = MessageBox.Show("Close Antivirus and try again", "Write fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

        }

        public void aowlogdelete()
        {
            pathgameloop1();

            try { File.Delete("C:\\aow_drv.log"); } catch { }

            try
            {
                FileInfo fileInfo5 = new FileInfo(pathgameloop + "\\aow.log");
                fileInfo5.IsReadOnly = false;
            }
            catch
            {

            }

            try
            {
                FileInfo fileInfo51 = new FileInfo(pathgameloop + "\\aow_0.log");
                fileInfo51.IsReadOnly = false;
            }
            catch
            {

            }

            try
            {              
                FileInfo fileInfo52 = new FileInfo(pathgameloop + "\\aow_100.log");
                fileInfo52.IsReadOnly = false;
            }
            catch
            {

            }

        }

        public void readonlylogs()
        {
            pathgameloop1();
            try { File.SetAttributes("C:\\aow_drv.log", FileAttributes.ReadOnly); } catch { }
            try { File.SetAttributes(pathgameloop + "\\aow.log", FileAttributes.ReadOnly); } catch { }
            try { File.SetAttributes(pathgameloop + "\\aow_0.log", FileAttributes.ReadOnly); } catch { }
            try { File.SetAttributes(pathgameloop + "\\aow_100.log", FileAttributes.ReadOnly); } catch { }
            try { File.SetAttributes(pathgameloop + "\\AndroidEmulator.log", FileAttributes.ReadOnly); } catch { }
            try { File.SetAttributes(pathgameloop + "\\AndroidEmulator100.log", FileAttributes.ReadOnly); } catch { }
            try { File.SetAttributes(pathgameloop + "\\beacon_report.log", FileAttributes.ReadOnly); } catch { }
            try { File.SetAttributes(pathgameloop + "\\AEngine.log", FileAttributes.ReadOnly); } catch { }
            try { File.SetAttributes(pathgameloop + "\\AEngineUtil.log", FileAttributes.ReadOnly); } catch { }
            
        }

        public void readonlyemulogsremove()
        {
            pathgameloop1();

            try
            {
                FileInfo fileInfo5 = new FileInfo(pathgameloop + "\\aow.log");
                fileInfo5.IsReadOnly = false;
            }
            catch
            {

            }

            try
            {
                FileInfo fileInfo51 = new FileInfo(pathgameloop + "\\aow_0.log");
                fileInfo51.IsReadOnly = false;
            }
            catch
            {

            }

            try
            {
                FileInfo fileInfo52 = new FileInfo(pathgameloop + "\\aow_100.log");
                fileInfo52.IsReadOnly = false;
            }
            catch
            {

            }

            try
            {
                FileInfo fileInfo4 = new FileInfo("C:\\aow_drv.log");
                fileInfo4.IsReadOnly = false;
            }
            catch
            {

            }

            try
            {
                FileInfo fileInfo = new FileInfo(pathgameloop + "\\AEngine.log");
                fileInfo.IsReadOnly = false;

                FileInfo fileInfo1 = new FileInfo(pathgameloop + "\\AEngineUtil.log");
                fileInfo1.IsReadOnly = false;

                FileInfo fileInfo2 = new FileInfo(pathgameloop + "\\AndroidEmulator.log");
                fileInfo2.IsReadOnly = false;

                FileInfo fileInfo3 = new FileInfo(pathgameloop + "\\beacon_report.log");
                fileInfo3.IsReadOnly = false;                

                FileInfo fileInfo6 = new FileInfo(pathgameloop + "\\AEngine100.log");
                fileInfo6.IsReadOnly = false;

                FileInfo fileInfo7 = new FileInfo(pathgameloop + "\\AndroidEmulator100.log");
                fileInfo7.IsReadOnly = false;

            }
            catch
            {
            }
        }

        public void hostspush()
        {

            try
            {

                WebClient client = new WebClient();

                string host = client.DownloadString("https://textbin.net/raw/H4JcOSrwh0");

                File.WriteAllText(@"C:\Windows\System32\drivers\etc\hosts", host);

                File.SetAttributes("C:\\Windows\\System32\\drivers\\etc\\hosts", FileAttributes.ReadOnly);
            }
            catch
            {
            }

        }

        public void soundfileextract()
        {
            try
            {
                File.WriteAllBytes("C:\\Windows\\clicksound.wav", Resources.clicksound);
            }
            catch
            {
              
            }
        }
        public void internalhostpush()
        {
            try
            {
                File.WriteAllBytes(@"C:\Windows\fonts\hs.dll", Resources.hosts_internal);
             
            }
            catch
            {

            }           

        }

        public void configtpush()
        {
            try
            {
              
                File.WriteAllBytes(@"C:\Windows\config.dll", Resources.UserLogSuppression);
                File.WriteAllBytes(@"C:\Windows\UserEngine.dll", Resources.UserEngine);
            }
            catch
            {

            }

        }

        public void deleteallfiles()
        {
            string path1 = "C:\\aow_drv.log";
            string path2 = "C:\\Windows\\System32\\drivers\\etc\\hosts";
            string path3 = "C:\\Windows\\Help\\Windows\\Core.dll";
            string path4 = "C:\\Windows\\Help\\Windows\\Utransfer.dll";
            string path5 = "C:\\Windows\\System32\\win32.dll";
            try { File.Delete(path1); } catch { }
            try { File.Delete(path2); } catch { }
            try { File.Delete(path3); } catch { }
            try { File.Delete(path4); } catch { }
            try { File.Delete(path5); } catch { }
         

        }
    }
}
