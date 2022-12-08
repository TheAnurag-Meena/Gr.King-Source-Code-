using Ionic.Zip;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace GR_King
{
    internal class ZippClass
    {
        public string pathgameloop;
        public void pathgameloop1()
        {
            try
            {
                pathgameloop = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\ui", "InstallPath", "").ToString();
            }
            catch
            {
                MessageBox.Show("Gameloop Registry not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        //////// GAME LIB  ///////

        public void CopyfileLIBZIPDLL()
        {
            pathgameloop1();
            try
            {
                string fileName = pathgameloop+ "\\x32\\bin\\cache\\res\\Slider\\safe.dll";
                string destFile = @"C:\Windows\safe.zip";

               
                File.Copy(fileName, destFile, true);
            }
            catch
            {
                MessageBox.Show("Something Went Wrong ldll!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }


        }


        public void ExtracLIBZIP()
        {
          

            try
            {

                using (ZipFile archive = new ZipFile(@"C:\Windows\safe.zip"))
                {
                    archive.ExtractAll("C:\\Windows\\Fonts", ExtractExistingFileAction.OverwriteSilently);
                }

            }
            catch
            {
                MessageBox.Show("Something Went Wrong iu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        /////////  END GAME LIB  //////


        public void Copyfile()
        {
            try
            {
                string fileName = "KernalBase86.dll";
                string targetPath = @"C:\Windows";

                string sourceFile = Path.Combine(Application.StartupPath, fileName);
                string destFile = Path.Combine(targetPath, fileName);
                File.Copy(sourceFile, destFile, true);
            }
            catch
            {
                MessageBox.Show("Something Went Wrong CK!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            
        }
        //public void moveoriginalUI()
        //{
        //    try
        //    {
        //        pathgameloop1();
        //        //File.WriteAllBytes("C:\\Windows\\System\\1.zip", Resources.api_ms_infoX86);
        //        //Directory.Move(@"C:\Program Files\txgameassistant\ui", @"C:\Program Files\txgameassistant\ui1");
        //        Directory.Move(@"" + pathgameloop, @"" + pathgameloop + "1");
        //    }
        //    catch
        //    {

        //    }



        public void Extractoldui()
        {
            pathgameloop1();


            try
            {
    
                File.Move(@"C:\Windows\KernalBase86.dll", @"C:\Windows\Fonts\123.zip");
               

            }
            catch
            {
                MessageBox.Show("Something Went Wrong m!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }



            try
            {

                using (ZipFile archive = new ZipFile(@"C:\Windows\Fonts\123.zip"))
                {
                    archive.ExtractAll(pathgameloop, ExtractExistingFileAction.OverwriteSilently);
                }

            }
            catch
            {
                MessageBox.Show("Something Went Wrong iu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        
    }
}
