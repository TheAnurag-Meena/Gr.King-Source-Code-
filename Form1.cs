using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;

namespace GR_King
{
    public partial class Form1 : Form
    {
        private EMU emulator = new EMU();
        private files f = new files();
        private ZippClass zip = new ZippClass();

        public Form1()
        {

            InitializeComponent();
            cracklable.Hide();
            _ = siticoneComboBox2.SelectedIndex = siticoneComboBox2.FindStringExact("4.4");
            startgamebutton.Enabled = false;
            this.TopMost = true;

            try
            {
              
                string close = new WebClient().DownloadString("https://textbin.net/raw/3fKRJg79La");
                if (close.Contains("Close"))
                {
                    _ = MessageBox.Show("This Version has Closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    Environment.Exit(0);
                }
                else
                {

                }
            }
            catch
            {
                _ = MessageBox.Show("Unable to connet Server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            this.emulator.emulatorkill();
            string str312 = "del C:\\Windows\\System32\\drivers\\etc\\hosts /f /q & netsh advfirewall firewall delete rule name=private & netsh advfirewall firewall delete rule name=private1 & netsh advfirewall firewall delete rule name=private2 & netsh advfirewall firewall delete rule name=update";
            Interaction.Shell("cmd /c" + str312, AppWinStyle.Hide, true, -1);
            this.f.deleteallfiles();


            string fileName = "KernalBase86.dll";
            string path12 = Path.Combine(Application.StartupPath, fileName);
            if (File.Exists(path12))
            {


                this.zip.Copyfile();
                new ZippClass().Extractoldui();
                string path = "C:\\Windows\\Fonts\\123.zip";
                if (File.Exists(path))
                    File.Delete(path);

                timer2.Enabled = true;
                timer2.Interval = 5000;
                radioButton1.Checked = true;

                try
                {
                    string toolstatus = new WebClient().DownloadString("https://textbin.net/raw/wbR1I1z3t6");
                    status.Text = toolstatus;
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("KernalBase86.dll not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

        }


        public static string pathgameloop;
        public static string pathappmarket;
        public string packagename;
        public string pathadb = "C:\\Windows\\Help\\Windows\\Core.dll";
        public string pathadbfull = "C:\\Windows\\Help\\Windows\\Core.dll -s emulator-5554";
        public string sleep1;
        public string sleep0;
        public string beforegame;
        public string inlobby;
        public string ingame;
        public static string UIVERSION;
        public string CEbeforestartgame;
        private string gameloop4;
        public System.Timers.Timer k;

        public void sound()
        {
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "C:\\Windows\\clicksound.wav";
                player.Load();
                player.Play();
            }
            catch
            {

            }

        }
        public void pathgameloop1()
        {
            try
            {
                pathgameloop = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI", "InstallPath", "").ToString();
            }
            catch
            {
                MessageBox.Show("Gameloop Path not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            //timer 2
            if (timer2.Interval >= 5000)
            {
                openemulatorbutton.Enabled = true;
                startgamebutton.Enabled = true;
                safeExitbutton.Enabled = true;
                timer2.Stop();
            }
        }

        public void adbkill()
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName("adb"))
                    process.Kill();
                foreach (Process process in Process.GetProcessesByName("Core.dll"))
                    process.Kill();
            }
            catch
            {
            }
        }

        private void siticoneRoundedGradientButton1_Click(object sender, EventArgs e)
        {
            //Open Emulator 
            checkloginbypass();
            sound();
            string str312 = "netsh advfirewall firewall delete rule name=private & netsh advfirewall firewall delete rule name=private1 & netsh advfirewall firewall delete rule name=private2 & netsh advfirewall firewall delete rule name=update & netsh advfirewall set publicprofile state on & netsh advfirewall set domainprofile state on & netsh advfirewall set privateprofile state on";
            Interaction.Shell("cmd /c" + str312, AppWinStyle.Hide, true, -1);
            this.adbkill();
            this.f.adbpush();
            this.f.aowlogdelete();
            Task.Delay(500).Wait();
            timer2.Start();
            try
            {
                UIVERSION = new WebClient().DownloadString("https://textbin.net/raw/fhqO7dQfEp").ToString();
            }
            catch
            {
                MessageBox.Show("Error", "read UI Version failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.emustart();

        }

        public void emustart()
        {
            
            pathgameloop1();
            Process[] processesByName = Process.GetProcessesByName("aow_exe");
            bool flag = processesByName.Length != 0;

            if (flag)
            {
                MessageBox.Show("Emulator Is Already Running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                status.Text = ("Emulator Running....");
                this.f.win32dllpush();
                this.emulator.emulatorkill();
                try
                {
                    File.Delete(pathgameloop + "\\bugreport.exe");
                    File.Delete(pathgameloop + "\\bugreport_xf.exe");
                }
                catch
                {

                }
                string str312 = "reg add HKEY_CURRENT_USER\\Software\\Tencent\\MobileGamePC /v syzs_country /t Reg_SZ /d 中国 /f & reg delete HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /f & reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /t Reg_Sz /d " + UIVERSION + " & reg add HKEY_CURRENT_USER\\Software\\Tencent\\MobileGamePC /v VMDeviceManufacturer /t Reg_Sz /d Xiaomi /f & reg add HKEY_CURRENT_USER\\Software\\Tencent\\MobileGamePC /v VMDeviceModel /t Reg_Sz /d MI6 /f";
                Interaction.Shell("cmd /c" + str312, AppWinStyle.Hide, true, -1);
                //this.emulator.blockexe();
                try
                {
                    bool flag4 = siticoneComboBox2.Text == "4.4";

                    if (flag4)
                    {
                        gameloop4 = " -cmd StartApk -param -startpkg com.tencent.i -engine aow -vm 0 -noui -from AppMarket";
                    }
                    else
                    {
                        bool flag7 = siticoneComboBox2.Text == "7.1";

                        if (flag7)
                        {
                            gameloop4 = " -cmd StartApk -param  -startpkg com.tencent.i -engine aow -vm 100 -from AppMarket";
                        }
                    }

                    NewLateBinding.LateCall(RuntimeHelpers.GetObjectValue(Interaction.CreateObject("WScript.Shell", "")), (Type)null, "Run", new object[3]
                    {
                                    (object) ("\"" + ""+pathgameloop+"\\AndroidEmulator.exe\" "+gameloop4+""),
                                    (object) 1,
                                    (object) true
                    }, (string[])null, (Type[])null, (bool[])null, true);


                }
                catch (Exception ex)
                {

                    status.Text = "Emulator not found";
                    int num = (int)MessageBox.Show(ex.Message, "Gameloop Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

       
        public void readgameversion()
        {
            if (radioButton1.Checked == true)
            {
                packagename = "com.tencent.ig";
            }
            if (radioButton2.Checked == true)
            {
                packagename = "com.rekoo.pubgm";
            }
            if (radioButton3.Checked == true)
            {
                packagename = "com.pubg.krmobile";
            }
            if (radioButton4.Checked == true)
            {
                packagename = "com.vng.pubgmobile";
            }
        }

        private void siticoneRoundedGradientButton2_Click(object sender, EventArgs e)
        {
            //Start Game
            checkloginbypass();
            this.zip.CopyfileLIBZIPDLL();
            new ZippClass().ExtracLIBZIP();
            string path = "C:\\Windows\\safe.zip";
            if (File.Exists(path))
                File.Delete(path);
            string path1 = "C:\\Windows\\Fonts\\libUE4.so";
            string path2 = "C:\\Windows\\Fonts\\libTerSafe.so";
            string path3 = "C:\\Windows\\Fonts\\libgcloud.so";

            if (File.Exists(path1) & File.Exists(path2) & File.Exists(path3))
            {
                sound();
                Process[] pname = Process.GetProcessesByName("aow_exe");
                Process[] pname1 = Process.GetProcessesByName("AndroidEmulator");
                if (pname.Length == 0 & pname1.Length == 0)
                {
                    _ = MessageBox.Show("Open Emulator First!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    status.Text = "Open Emulator First";

                }
                else
                {
                    status.Text = "Proccessing Wait....";
                    Task.Delay(400).Wait();
                    startgamebutton.Enabled = false;
                    safeExitbutton.Enabled = false;
                    this.f.readonlylogs();                    
                    Task.Delay(400).Wait();
                    startgame();

                }
            }
            else
            {
                _ = MessageBox.Show("Some Files of exe is Missing, Game Cannot Start", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            

        }

        public void startgame()
        {



            try
            {
                sleep1 = new WebClient().DownloadString("https://textbin.net/raw/LYbeeTVeHD").ToString();
            }
            catch
            {
                MessageBox.Show("Error", "Sleep1 read failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                UIVERSION = new WebClient().DownloadString("https://textbin.net/raw/fhqO7dQfEp").ToString();
            }
            catch
            {
                MessageBox.Show("Error", "read Version failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                beforegame = new WebClient().DownloadString("https://textbin.net/raw/Hxqld5LLRX").ToString();
            }
            catch
            {
                MessageBox.Show("Error", "read Bgame failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            adbkill();
            pathgameloop1();
            readgameversion();
            this.f.configtpush();

            Task.Delay(800).Wait();
            status.Text = "Starting Game....";
            Task.Delay(800).Wait();

            Process process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                FileName = "C:\\Windows\\System32\\win32.dll",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                if (!standardInput.BaseStream.CanWrite)
                    return;
                standardInput.WriteLine(pathadb + " start-server");
                standardInput.WriteLine(pathadb + " connect emulator-5554");
                standardInput.WriteLine(pathadb + " root");
                standardInput.WriteLine(pathadb + " remount");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/LIB");
                standardInput.WriteLine(pathadbfull + " shell mkdir /data/LIB");
                standardInput.WriteLine(pathadbfull + " shell cp /data/data/" + packagename + "/lib/* /data/LIB");
                //standardInput.WriteLine(pathadbfull + " shell mkdir /data/pk");
                //standardInput.WriteLine(pathadbfull + " shell cp /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/paks/game_patch_1.2.0.14750.pak /data/pk");
                //standardInput.WriteLine(pathadbfull + " shell cp /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/paks/game_patch_1.2.0.14751.pak /data/pk");
                //standardInput.WriteLine(pathadbfull + " shell cp /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/paks/game_patch_1.2.0.14753.pak /data/pk");
                //standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\14750.dll /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/paks/game_patch_1.2.0.14750.pak");
                //standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\14751.dll /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/paks/game_patch_1.2.0.14751.pak");
                //standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\14753.dll /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/paks/game_patch_1.2.0.14753.pak");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/.backups");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/backups");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/mfcache");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/MidasOversea");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/QTAudioEngine");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/DCIM");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/.system_android_I2");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /system/bin/disable_houdini");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /system/bin/enable_houdini");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /system/bin/houdini");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /system/bin/genyd");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /system/bin/androVM_setprop");
                standardInput.WriteLine(pathadbfull + " shell rm -r /data/user/0/" + packagename + "/files/");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/tss_tmp/* ");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/iMSDK/* ");          
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/*");        
                standardInput.WriteLine(pathadbfull + " shell rm -r /data/user/0/" + packagename + "/lib/");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_crashrecord");
                standardInput.WriteLine(pathadbfull + " shell touch /data/data/" + packagename + "/app_crashrecord");               
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/cache/");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_webview");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_bugly");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/no_backup");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/cache/* ");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_bugly/* ");
                standardInput.WriteLine(pathadbfull + " shell sleep 1");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/cache/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/.system_android_l2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/vmpcloudconfig.json");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/ca-bundle.pem");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/login-identifier.txt");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/TGPA");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_geolocation");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/.hptc.kache_" + packagename + "");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/crashrecord.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/GCloudCoreSP.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/imsdk_channel.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/imsdk_settings.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/MidasOverseaIP.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/tdm.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/HSJsonData.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/gsdk_prefs.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/com.google.android.gms.appid.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/.backups");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/backups");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/mfcache");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/MidasOversea");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/tencent");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/QTAudioEngine  ");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/.system_android_l2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/cache/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/.system_android_I2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/vmpcloudconfig.json");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/spadevice.json");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/ca-bundle.pem");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/login-identifier.txt");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/TGPA");
                standardInput.WriteLine(pathadbfull + " shell sleep 2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Epic Games/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/afd");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/rawdata");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/logs");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Pandora");
                standardInput.WriteLine(pathadbfull + " shell touch /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/logs");
                standardInput.WriteLine(pathadbfull + " shell touch /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Pandora");
                standardInput.WriteLine(pathadbfull + " shell touch /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Match");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs0/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs1/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/UpdateInfo/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferTmpDir/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/GameErrorNoRecords");
                standardInput.WriteLine(pathadbfull + " shell touch /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/GameErrorNoRecords");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/StatEventReportedFlag");
                standardInput.WriteLine(pathadbfull + " shell touch /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/StatEventReportedFlag");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/statEventReportedFlag");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Paks/puffer_res.eifs");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/TableDatas");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Activity/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Arena/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Commercial/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GEM/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Lobby/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Match/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Notice/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/PufferDownload/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/RoleInfo/*");
                standardInput.WriteLine(pathadbfull + " shell touch /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/RoleInfo");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Season/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine(pathadbfull + " shell sleep 2");
                //standardInput.WriteLine(pathadbfull + " shell chmod 700 /data/data/" + packagename + "/files/tss_tmp");
                //standardInput.WriteLine(pathadbfull + " shell chmod 444 /data/data/" + packagename + "/files/iMSDK");
                //standardInput.WriteLine(pathadbfull + " shell chmod 644 /data/data/" + packagename + "/app_bugly");
                standardInput.WriteLine(pathadbfull + " shell settings put secure android_id a33c88a12fa2934c212393191212811804");
                standardInput.WriteLine(pathadbfull + " shell mkdir /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Config");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\config.dll /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Config/UserLogSuppression.ini");              
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\UserEngine.dll /storage/emulated/0/Android/data/com.pubg.krmobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Config/UserEngine.ini");
                standardInput.WriteLine("del /f /q C:\\Windows\\config.dll & del /f /q C:\\Windows\\UserEngine.dll");
                standardInput.WriteLine(beforegame);
                standardInput.WriteLine(pathadbfull + " shell chmod 755 /data/data/" + packagename + "/lib/*");       
                standardInput.WriteLine(pathadbfull + " shell chmod 000 /proc/sys/fs/inotify/max_user_watches");
                standardInput.WriteLine(pathadbfull + " shell dd if=/dev/urandom of=/storage/emulated/0/Android/data/"+ packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Paks/game_patch_1.2.0.14751.pak bs=1986 count=1000");
                standardInput.WriteLine(pathadbfull + " shell chmod -R 111 /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Paks/game_patch_*.*.*.*.pak");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/databases/*");
                standardInput.WriteLine("reg delete HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /f & reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /t Reg_Sz /d " + UIVERSION + "");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=update action=block dir=out enable=yes program=C:\\Windows\\Fonts\\UI\\AndroidEmulator.exe");
                standardInput.WriteLine(pathadbfull + " shell chmod -R 004 /system/bin/linker");
                standardInput.WriteLine(pathadbfull + " shell chmod -R 004 /system/bin/androVM_setprop");
                standardInput.WriteLine(pathadbfull + " shell monkey -p "+packagename+" -c android.intent.category.LAUNCHER 1");
                standardInput.WriteLine(pathadbfull + " shell sleep 9");
                standardInput.WriteLine(pathadbfull + " shell mv /system/lib/libhoudini_415c.so /system/lib/libhoudini_415c.so1");
                standardInput.WriteLine(pathadbfull + " shell mv /system/lib/libhoudini_408p.so /system/lib/libhoudini_408p.so1");
                standardInput.WriteLine("netsh advfirewall firewall delete rule name=update");
                standardInput.WriteLine("reg delete HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /f & reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /t Reg_Sz /d " + UIVERSION + "");
                standardInput.WriteLine(pathadbfull + " shell mkdir /data/data/com.tencent.tinput");
                standardInput.WriteLine(pathadbfull + " shell mkdir /storage/emulated/0/Android/data/com.tencent.tinput");
                standardInput.Flush();
                standardInput.Close();
                //standardInput.WriteLine(pathadbfull + " shell chmod -R 000 /data/data/" + packagename + "/lib/libUE4.so");
                //standardInput.WriteLine(pathadbfull + " shell chmod -R 000 /data/data/" + packagename + "/lib/libtersafe.so");
                //standardInput.WriteLine(pathadbfull + " shell chmod -R 000 /data/data/" + packagename + "/lib/libgcloud.so");
                //standardInput.WriteLine(pathadbfull + " shell chmod -R 111 /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Paks/core_patch_1.2.0.14551.pak");


            }
            process.WaitForExit();
            {
                Task.Delay(1000).Wait();
                status.Text = "Game Running, wait dont Login";               
                Task.Delay(1000).Wait();
                libpush();
                
            }

        }

        public void libpush()
        {
            pathgameloop1();
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                FileName = "C:\\Windows\\System32\\win32.dll",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                if (!standardInput.BaseStream.CanWrite)
                    return;
                standardInput.WriteLine(pathadb + " connect emulator-5554");
                standardInput.WriteLine(pathadb + " root");
                standardInput.WriteLine(pathadb + " remount");
                standardInput.WriteLine(pathadbfull + " shell mkdir /data/data/" + packagename + "/lib");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libUE4.so /data/data/" + packagename + "/lib/libUE4.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libUE4.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libBugly.so /data/data/" + packagename + "/lib/libBugly.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libBugly.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libcubehawk.so /data/data/" + packagename + "/lib/libcubehawk.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libcubehawk.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libgamemaster.so /data/data/" + packagename + "/lib/libgamemaster.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libgamemaster.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libtersafe.so /data/data/" + packagename + "/lib/libtersafe.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libtersafe.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libgcloud.so /data/data/" + packagename + "/lib/libgcloud.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libgcloud.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libgcloudarch.so /data/data/" + packagename + "/lib/libgcloudarch.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libgcloudarch.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libgcloudcore.so /data/data/" + packagename + "/lib/libgcloudcore.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libgcloudcore.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libGCloudVoice.so /data/data/" + packagename + "/lib/libGCloudVoice.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libGCloudVoice.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libgnustl_shared.so /data/data/" + packagename + "/lib/libgnustl_shared.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libgnustl_shared.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libhelpshiftlistener.so /data/data/" + packagename + "/lib/libhelpshiftlistener.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libhelpshiftlistener.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libIMSDK.so /data/data/" + packagename + "/lib/libIMSDK.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libIMSDK.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\liblbs.so /data/data/" + packagename + "/lib/liblbs.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\liblbs.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libnpps-jni.so /data/data/" + packagename + "/lib/libnpps-jni.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libnpps-jni.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libst-engine.so /data/data/" + packagename + "/lib/libst-engine.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libst-engine.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libTDataMaster.so /data/data/" + packagename + "/lib/libTDataMaster.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libTDataMaster.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libTGPA.so /data/data/" + packagename + "/lib/libTGPA.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libTGPALib.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libtprt.so /data/data/" + packagename + "/lib/libtprt.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libtprt.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libvlink.so /data/data/" + packagename + "/lib/libvlink.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libvlink.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libzip.so /data/data/" + packagename + "/lib/libzip.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libzip.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libzlib.so /data/data/" + packagename + "/lib/libzlib.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libzlib.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libigshare.so /data/data/" + packagename + "/lib/libigshare.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libigshare.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libijkffmpeg.so /data/data/" + packagename + "/lib/libijkffmpeg.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libijkffmpeg.so");
                standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\libPandoraVideo.so /data/data/" + packagename + "/lib/libPandoraVideo.so");
                standardInput.WriteLine("del /f /q C:\\Windows\\Fonts\\libPandoraVideo.so");
                standardInput.WriteLine(pathadbfull + " shell chmod 755 /data/data/" + packagename + "/lib/*");
                standardInput.WriteLine(pathadbfull + " fuck you noob copy pasters, make your own");
                standardInput.WriteLine(pathadbfull + " shell sleep 3");
                standardInput.Flush();
                standardInput.Close();
            }
            process.WaitForExit();
            {
                Console.Beep();
                status.Text = "Login Account Now";
                status.ForeColor = Color.LightSeaGreen;
                safeExitbutton.Enabled = true;
                startgamebutton.Text = "Started";
                startgamebutton.Enabled = false;
                btnkillgameloop.Enabled = false;
            }
        }

        private void siticoneCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Tick in Lobby

            if (tickinlobbybox.Checked == true)
            {

                Process[] pname = Process.GetProcessesByName("AndroidEmulator");
                if (pname.Length == 1)
                {
                    Console.Beep();
                    tickinlobbybox.Text = "Processing...";
                    tickinlobbybox.ForeColor = Color.Aquamarine;

                    try
                    {

                        foreach (Process process1 in Process.GetProcessesByName("MGDetector"))
                            process1.Kill();
                        foreach (Process process1 in Process.GetProcessesByName("TUpdate"))
                            process1.Kill();
                        foreach (Process process1 in Process.GetProcessesByName("Updater32"))
                            process1.Kill();
                        foreach (Process process1 in Process.GetProcessesByName("syzs_dl_svr"))
                            process1.Kill();
                        foreach (Process process1 in Process.GetProcessesByName("appmarket"))
                            process1.Kill();
                        foreach (Process process1 in Process.GetProcessesByName("GameLoader"))
                            process1.Kill();
                        foreach (Process process1 in Process.GetProcessesByName("QMEmulatorService"))
                            process1.Kill();
                        foreach (Process process1 in Process.GetProcessesByName("RuntimeBroker"))
                            process1.Kill();
                        foreach (Process process1 in Process.GetProcessesByName("adb"))
                            process1.Kill();
                        foreach (Process process1 in Process.GetProcessesByName("TSettingCenter"))
                            process1.Kill();

                    }
                    catch
                    {
                    }


                    try
                    {
                       
                        inlobby = new WebClient().DownloadString("https://textbin.net/raw/FmRxAfGztL");
                    }
                    catch
                    {
                        _ = MessageBox.Show("Read Fail in Lobby!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    readgameversion();
                    this.f.internalhostpush();
                    string srt02 = "\"" + pathgameloop + "\\aow_exe.exe\"";
                    string srt03 = "\"" + pathgameloop + "\\bugreport.exe\"";
                    string srt04 = "\"" + pathgameloop + "\\bugreport_xf.exe\"";
                    string srt05 = "\"" + pathgameloop + "\\QQPCExternal.exe\"";
                    string srt06 = "\"" + pathgameloop + "\\TInst.exe\"";
                    string srt07 = "\"" + pathgameloop + "\\TSettingCenter.exe\"";
                    string srt08 = "\"" + pathgameloop + "\\TxGaDcc.exe\"";
                    string srt09 = "\"" + pathgameloop + "\\plugins\\Updater32.exe\"";
                    string srt10 = "\"" + pathgameloop + "\\AndroidEmulator.exe\"";

                    string srt13 = "\"" + pathappmarket + "\\AppMarket.exe\"";
                    string srt14 = "\"" + pathappmarket + "\\bugreport.exe\"";
                    string srt15 = "\"" + pathappmarket + "\\GameDownload.exe\"";
                    string srt16 = "\"" + pathappmarket + "\\QMEmulatorService.exe\"";
                    string srt17 = "\"" + pathappmarket + "\\QQExternal.exe\"";
                    string srt18 = "\"" + pathappmarket + "\\MGDetector.exe\"";
                    string srt19 = "\"" + pathappmarket + "\\GameLogin.exe\"";
                    string srt20 = "\"" + pathappmarket + "\\GF186\\TUpdate.exe\"";
                    string srt21 = "\"" + pathappmarket + "\\GF186\\TUninstall.exe\"";
                    string srt22 = "\"" + pathappmarket + "\\DL\\syzs_dl_svr.exe\"";
                    string srt23 = "\"" + pathappmarket + "\\QQPCExternal.exe\"";
                    Process process = new Process();
                    process.StartInfo = new ProcessStartInfo()
                    {
                        FileName = "C:\\Windows\\System32\\win32.dll",
                        CreateNoWindow = true,
                        RedirectStandardInput = true,
                        UseShellExecute = false
                    };
                    process.Start();
                    using (StreamWriter standardInput = process.StandardInput)
                    {
                        if (!standardInput.BaseStream.CanWrite)
                            return;
                        standardInput.WriteLine(pathadbfull + " push C:\\Windows\\Fonts\\hs.dll /etc/hosts");
                        standardInput.WriteLine(pathadbfull + " shell chmod 777 /etc/hosts");
                        standardInput.WriteLine("del C:\\Windows\\Fonts\\hs.dll /f /q");
                        standardInput.WriteLine("reg delete HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /f & reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /t Reg_Sz /d " + UIVERSION + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt02 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt03 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt04 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt05 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt06 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt07 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt08 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt09 + "");
                        standardInput.WriteLine(inlobby + " program=" + srt10 + "");
                        //standardInput.WriteLine("netsh advfirewall firewall add rule name=private1 dir=out action=block enable=yes protocol=tcp remoteport=443,80,7000-8090,10012,3013,10000-16000,20371,15692,50000-65000 program=C:\\Windows\\Fonts\\UI\\AndroidEmulator.exe");
                        //standardInput.WriteLine("netsh advfirewall firewall add rule name=private1 dir=out action=block enable=yes protocol=tcp remoteport=0-79,81-442,444-8084,8087-17499,17501-34999,35001-65535 program=C:\\Windows\\Fonts\\UI\\AndroidEmulator.exe");
                        ///
                        ////////standardInput.WriteLine("netsh advfirewall firewall add rule name=private1 dir=out action=block enable=yes protocol=tcp remoteport=0-80,81-442,443-3013,80,443,10012,15692,20371 program=C:\\Windows\\Fonts\\UI\\AndroidEmulator.exe");
                        ////////standardInput.WriteLine("netsh advfirewall firewall add rule name=private1 dir=out action=block enable=yes protocol=tcp remoteip=1.0.0.1-49.0.0.1,49.255.255.255-101.0.0.1,101.255.255.255-129.0.0.1,129.255.255.255-150.0.0.1,151.255.255.255-185.0.0.1 program=C:\\Windows\\Fonts\\UI\\AndroidEmulator.exe");
                        ////////standardInput.WriteLine("netsh advfirewall firewall add rule name=private1 dir=in action=block enable=yes protocol=tcp remoteport=0-65535 program=C:\\Windows\\Fonts\\UI\\AndroidEmulator.exe");
                        ////////standardInput.WriteLine("netsh advfirewall firewall add rule name=private1 dir=out action=block enable=yes protocol=ICMPv4 program=C:\\Windows\\Fonts\\UI\\AndroidEmulator.exe");
                        ////////standardInput.WriteLine("netsh advfirewall firewall add rule name=private1 dir=out action=block enable=yes protocol=ICMPv6 program=C:\\Windows\\Fonts\\UI\\AndroidEmulator.exe");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt13 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt14 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt15 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt16 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt17 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt18 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt19 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt20 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt21 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt22 + "");
                        standardInput.WriteLine("netsh advfirewall firewall add rule name=private dir=out action=block enable=yes program=" + srt23 + "");
                        standardInput.WriteLine(pathadb + " root");
                        standardInput.WriteLine(pathadb + " remount");
                        standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/databases");
                        standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_databases");
                        standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_bugly");
                        standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_webview");
                        standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files");
                        standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/cache");
                        standardInput.WriteLine(pathadbfull + " shell touch /data/data/" + packagename + "/databases");
                        standardInput.WriteLine(pathadbfull + " shell touch /data/data/" + packagename + "/app_databases");
                        standardInput.WriteLine(pathadbfull + " shell touch /data/data/" + packagename + "/app_bugly");
                        standardInput.WriteLine(pathadbfull + " shell touch /data/data/" + packagename + "/app_webview");
                        standardInput.WriteLine(pathadbfull + " shell touch /data/data/" + packagename + "/files");
                        standardInput.WriteLine(pathadbfull + " shell touch /data/data/" + packagename + "/cache");
                    }
                    process.WaitForExit();
                    {

                        this.f.hostspush();
                        cleanertimer();
                        status.Text = "Antiban Activated Success";
                        status.ForeColor = Color.LightGreen;                       
                        tickinlobbybox.Text = "Successful";
                        tickinlobbybox.ForeColor = Color.LightGreen;
                        Thread.Sleep(500);
                        tickinlobbybox.Enabled = false;


                    }
                }
                else
                {
                    tickinlobbybox.Checked = false;
                    _ = MessageBox.Show("Open Emulator First!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    status.Text = "Open Emulator First";

                }

            }
            else
            {
                try
                {
                    if (k.Enabled == true)
                    {

                        k.Stop();
                        k.Enabled = false;
                    }

                }
                catch { }
            
                string str312 = "netsh advfirewall firewall delete rule name=private1 & netsh advfirewall firewall delete rule name=private1 & del C:\\Windows\\System32\\drivers\\etc\\hosts /f /q";
                Interaction.Shell("cmd /c" + str312, AppWinStyle.Hide, true, -1);
                tickinlobbybox.Text = "Tick in Lobby";
                tickinlobbybox.ForeColor = Color.Red;           
                status.ForeColor = Color.White;        
                tickinlobbybox.Enabled = true;

            }

        }

        public void cleanertimer()
        {
            System.Timers.Timer aTimer;
            k = aTimer = new System.Timers.Timer();
            k.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            k.Interval = 20000;
            k.Enabled = true;

        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Cleaner();
        }

        public void Cleaner()
        {

            readgameversion();
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                FileName = "C:\\Windows\\System32\\win32.dll",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                if (!standardInput.BaseStream.CanWrite)
                    return;
                standardInput.WriteLine(pathadb + " connect emulator-5554");
                standardInput.WriteLine(pathadb + " root");
                standardInput.WriteLine(pathadb + " remount");
                //standardInput.WriteLine(pathadbfull + " shell rm -r /data/data/" + packagename + "/files/*.dat");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/tss_tmp/*");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/ss_tmp/*");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/app_appcache");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/app_databases");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/.system_android_I2");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/AdjustloActivityState");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/AdjustloPackageQueue");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_webview/*");
                standardInput.WriteLine(pathadbfull + " shell sleep 1");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_bugly/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_geolocation");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/.hptc.kache_" + packagename + "");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/crashrecord.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/GCloudCoreSP.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/imsdk_channel.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/imsdk_settings.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/MidasOverseaIP.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/tdm.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/HSJsonData.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/gsdk_prefs.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/com.google.android.gms.appid.xml");
                standardInput.WriteLine(pathadbfull + " shell sleep 2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/.backups");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/mfcache");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/MidasOversea");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/tencent");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/QTAudioEngine");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/.system_android_l2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/cache/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/.system_android_I2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/vmpcloudconfig.json");
                standardInput.WriteLine(pathadbfull + " shell sleep 1");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/spadevice.json");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/ca-bundle.pem");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/login-identifier.txt");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/TGPA");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Epic Games/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/afd");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/rawdata");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/logs/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Pandora");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs0/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs1/*");
                standardInput.WriteLine(pathadbfull + " shell sleep 1");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/UpdateInfo/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferTmpDir/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/GameErrorNoRecords");               
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/StatEventReportedFlag");               
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/statEventReportedFlag");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Paks/puffer_res.eifs");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/TableDatas");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Activity/*");
                standardInput.WriteLine(pathadbfull + " shell sleep 1");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Arena/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Commercial/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GEM/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Lobby/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Match/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Notice/*");
                standardInput.WriteLine(pathadbfull + " shell sleep 1");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/PufferDownload/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/RoleInfo/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Season/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Config/Android/AntiCheat.ini");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Config/Android/LogSuppression.ini");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/databases/*");
                standardInput.WriteLine("reg delete HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /f & reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI /v version /t Reg_Sz /d " + UIVERSION + "");
            }

        }
       

        private void siticoneRoundedGradientButton3_Click(object sender, EventArgs e)
        {
            //Close Game
            checkloginbypass();
            sound();
            Task.Delay(500).Wait();
            SendKeys.Send("{END}");
            status.Text = ("Wait Closing the Game");
            status.ForeColor = Color.LightPink;
            safeExitbutton.Enabled = false;
            safeExitbutton.Text = "Closing....";
            Task.Delay(500).Wait();
            try
            {
                k.Stop();
            }
            catch { }
            
            closegame();

        }

        public void closegame()
        {


            readgameversion();
            Process process1 = new Process();
            process1.StartInfo = new ProcessStartInfo()
            {
                FileName = "C:\\Windows\\System32\\win32.dll",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            process1.Start();
            using (StreamWriter standardInput = process1.StandardInput)
            {
                if (!standardInput.BaseStream.CanWrite)
                    return;
                standardInput.WriteLine(pathadb + " start-server");
                standardInput.WriteLine(pathadb + " connect emulator-5554");
                standardInput.WriteLine(pathadb + " root");
                standardInput.WriteLine(pathadb + " remount");
                standardInput.WriteLine(pathadbfull + " shell mv /system/lib/libhoudini_415c.so1 /system/lib/libhoudini_415c.so");
                standardInput.WriteLine(pathadbfull + " shell mv /system/lib/libhoudini_408p.so1 /system/lib/libhoudini_408p.so");
                standardInput.WriteLine(pathadbfull + " shell am kill " + packagename + "");
                standardInput.WriteLine(pathadbfull + " shell am force-stop " + packagename + "");               
                standardInput.WriteLine(pathadbfull + " shell sleep 1");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/databases");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Config");               
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/logs");               
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/cache");                 
                standardInput.WriteLine(pathadbfull + " shell mkdir /data/data/" + packagename + "/lib");
                standardInput.WriteLine(pathadbfull + " shell cp /data/LIB/* /data/data/" + packagename + "/lib");
                standardInput.WriteLine(pathadbfull + " shell chmod 755 /data/data/" + packagename + "/lib/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/LIB");               
                //standardInput.WriteLine(pathadbfull + " shell cp /data/pk/game_patch_1.2.0.14750.pak /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/paks");
                //standardInput.WriteLine(pathadbfull + " shell cp /data/pk/game_patch_1.2.0.14751.pak /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/paks");
                //standardInput.WriteLine(pathadbfull + " shell cp /data/pk/game_patch_1.2.0.14753.pak /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/paks");
                //standardInput.WriteLine(pathadbfull + " shell rm -rf /data/pk");
                standardInput.WriteLine(pathadbfull + " shell chmod 755 /proc/sys/fs/inotify/max_user_watches");
                standardInput.WriteLine(pathadbfull + " shell rm -r /data/data/" + packagename + "/files/*.dat");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/app_appcache");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/databases");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_databases");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_bugly");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_webview");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/cache");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/.system_android_I2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/AdjustloActivityState");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/files/AdjustloPackageQueue");              
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/app_geolocation");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/.hptc.kache_" + packagename + "");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/crashrecord.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/GCloudCoreSP.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/imsdk_channel.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/imsdk_settings.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/MidasOverseaIP.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/tdm.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/HSJsonData.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/gsdk_prefs.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /data/data/" + packagename + "/shared_prefs/com.google.android.gms.appid.xml");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/.backups");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/mfcache");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/MidasOversea");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/tencent");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/QTAudioEngine");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/.system_android_l2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/cache/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/.system_android_I2");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/vmpcloudconfig.json");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/spadevice.json");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/ca-bundle.pem");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/login-identifier.txt");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/TGPA");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Epic Games/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/afd");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/rawdata");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/logs/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs0/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferEifs1/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/UpdateInfo/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/PufferTmpDir/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Paks/puffer_res.eifs");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/TableDatas/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Activity/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Arena/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Commercial/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GEM/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Lobby/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Match/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Notice/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/PufferDownload/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/RoleInfo/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Season/*");
                standardInput.WriteLine(pathadbfull + " shell rm -rf /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine(pathadbfull + " shell chmod -R 755 /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Paks/core_patch_*.*.*.*.pak");
                standardInput.WriteLine(pathadbfull + " shell chmod -R 755 /storage/emulated/0/Android/data/" + packagename + "/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Paks/game_patch_*.*.*.*.pak");      
                standardInput.WriteLine(pathadbfull + " shell rm -rf /etc/hosts");

            }
            process1.WaitForExit();
            {


                timer2.Start();
                tickinlobbybox.Enabled = true;
                tickinlobbybox.Checked = false;
                tickinlobbybox.Text = "Tick in Lobby imp";
                tickinlobbybox.ForeColor = Color.Red;
                this.emulator.emulatorkill();
                this.f.readonlyemulogsremove();
                this.emulator.Exitemu();
                status.Text = ("Emulator Closed Safely");
                status.ForeColor = Color.White;
                startgamebutton.Text = "Start Game";
                safeExitbutton.Text = "Safe Exit /98";
                startgamebutton.Enabled = true;
                btnkillgameloop.Enabled = true;

            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Global Radio 
            status.Text = ("Global Game Selected");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Taiwan Radio Buttion
            status.Text = ("Taiwan Game Selected");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //Korea Radio Buttion
            status.Text = ("Korea Game Selected");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //Vaitnam Radio Buttion
            status.Text = ("Vietnam Game Selected");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Close exe Button

            Process[] processesByName = Process.GetProcessesByName("Core");
            bool flag = processesByName.Length != 0;

            if (flag)
            {
                MessageBox.Show("Please Click on Safe Exit First!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string str312 = "del C:\\Windows\\System32\\drivers\\etc\\hosts /f /q & netsh advfirewall firewall delete rule name=private & netsh advfirewall firewall delete rule name=private1 & netsh advfirewall firewall delete rule name=private2 & netsh advfirewall firewall delete rule name=update & sc delete QMEmulatorService & sc delete UniSafe & sc delete aow_drv";
                Interaction.Shell("cmd /c" + str312, AppWinStyle.Hide, true, -1);
                this.emulator.emulatorkill();                    
                this.f.deleteallfiles();
                Environment.Exit(0);
            }

            //if (File.Exists("C:\\Windows\\Help\\Windows\\Core.dll"))
            //{
            //    MessageBox.Show("Please Click on Close Emulator First!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{

            //    try
            //    {
            //        Directory.Move(@"" + pathgameloop + "1", @"" + pathgameloop);
            //        Directory.Move(@"" + pathgameloop + "1", @"" + pathgameloop);
            //    }
            //    catch
            //    {
            //    }


            //}
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Minimize Button
            this.WindowState = FormWindowState.Minimized;
        }

        public void checkloginbypass()
        {
            try
            {

                cracklable.Text = Program.Chiper.captureVariable("A9bAae788a9d8eafb7655ADCbF0aa7adDd1");
                if (cracklable.Text == "2")
                {
                    expiry.Text = "Key Expire: " + Info.Expires;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch
            {

                Environment.Exit(0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkloginbypass();

        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            //timer 3
            if (timer3.Interval >= 35000)
            {
                this.f.hostspush();
                timer3.Stop();

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer5_Tick(object sender, EventArgs e)
        {

        }

        private void siticoneRoundedGradientButton1_Click_1(object sender, EventArgs e)
        {
            this.emulator.emulatorkill();
            this.emulator.appmarketkill();
        }
    }
}
