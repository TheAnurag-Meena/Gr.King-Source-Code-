#region usings
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
#endregion

/*
 * © 2020, Chiper.IO
 * Thank you for choosing Chiper.IO's services!
 * https://discord.gg/qUUCg4mFEH
 * 
 * .NET version API Example: 1.0.8
 * 
 */



internal class Swifty
{
    public Swifty(string appname, string program_key, string api_encryption, string version)
    {
        Auth.appName = appname;
        Auth.App_Version = version;
        Auth.App_Key = program_key;
        Auth.API_Encrytion = api_encryption;
    }


    public Swifty Connect()
    {
        new Auth().Initialize();

        return this;
    }

    public bool Login(string username, string password)
    {
        if (!Auth.Initialized)
        {
            // documentation: https://chiper.gitbook.io/chiper-io/
            MessageBox.Show("Badly executed program, you must initialize the application before logging in!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }


        controlVars.Handler.Add("password", password);
        return Auth.Login(username, password);
    }

    public bool Register(string username, string password, string license)
    {
        if (!Auth.Initialized)
        {
            // documentation: https://chiper.gitbook.io/chiper-io/
            MessageBox.Show("Badly executed program, you must initialize the application before logging in!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        return Auth.Register(username, password, license);
    }

    public bool ExtendTime(string username, string password, string license)
    {
        if (!Auth.Initialized)
        {
            // documentation: https://chiper.gitbook.io/chiper-io/
            MessageBox.Show("Badly executed program, you must initialize the application before logging in!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        return Auth.ExtendTime(username, password, license);
    }

    public string captureVariable(string variable_code)
    {
        if (controlVars.Vars.ContainsKey(variable_code))
            return controlVars.Vars[variable_code];

        return Auth.Variable_capture(variable_code);
    }

    public bool licenseLogin(string licenseKey)
    {
        if (!Auth.Initialized)
        {
            // documentation: https://chiper.gitbook.io/chiper-io/
            MessageBox.Show("Badly executed program, you must initialize the application before logging in!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }


        controlVars.Handler.Add("password", licenseKey);
        return Auth.licenseLogin(licenseKey);
    }
}

public class Info
{
    public static string Username { get; set; }
    public static string License { get; set; }
    public static string Level { get; set; }
    public static string Expires { get; set; }
    public static string IP { get; set; }
    public static string HWID { get; set; }
}

public class controlVars
{
    public static Dictionary<string, string> Handler = new Dictionary<string, string>();

    public static Dictionary<string, string> Vars = new Dictionary<string, string>();
}

public class App
{
    public static void configuration(Dictionary<string, object> data)
    {
        Version = (string)data["version"];
        updaterLink = (string)data["updater_link"] == null ? "Undefined" : (string)data["updater_link"];

        Enabled = (string)data["enabled"] == "1";
        HWIDLock = (string)data["hwidlock"] == "1";
        Freemode = (string)data["freemode"] == "1";
        devMode = (string)data["devmode"] == "1";
        hashcheck = (string)data["hashcheck"] == "1";
        enableUpdater = (string)data["optionalupdater"] == "1";

        if (hashcheck)
            hashProgram = (string)data["hash"] == null ? "Undefined" : (string)data["hash"];
    }

    public static string Version { get; set; }
    public static bool Freemode { get; set; }
    public static bool Enabled { get; set; }
    public static bool hashcheck { get; set; }
    public static string hashProgram { get; set; }
    public static bool devMode { get; set; }
    public static bool HWIDLock { get; set; }
    public static bool enableUpdater { get; set; }
    public static string updaterLink { get; set; }

}

public class Auth
{
    public string APIStartup = "https://restapi.chiper.io/";
    public static string certification_Key { get; } = "048B0DBBE8B435A1C9E8F2DFBAB602C832C6AB593AEE5AC03442A535ED134F4D152203043C14CE306D9672EEC79794DB8F171A4B6DE456979DC1B3F3E586947B08";
    public static bool SessionStarted { get; set; }
    public static string appName { get; set; }
    public static string API_Encrytion { get; set; }
    public static bool AIO { get; set; }
    public static string App_Key { get; set; }
    public static string App_Version { get; set; }
    public static bool Initialized { get; set; } = false;
    public static bool isLogged { get; set; } = false;
    public static bool isRegistered { get; set; } = false;
    public static bool isExtended { get; set; } = false;
    public static bool Task_Done { get; set; } = false;

    public static controlVars variables { get; }
    public static SecureConnection secure = new SecureConnection();
    public static Security GetSecurity = new Security();

    public void Initialize()
    {
        if (string.IsNullOrEmpty(API_Encrytion))
        {
            MessageBox.Show("You must place your encryption code!", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        secure.Start_Session();

        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        secure.OnResponseReceived += Secure_OnResponseReceiveds;
        secure.EstablishSecureConnectionAsync();

        while (!secure.SecureConnectionEstablished)
        {
            Application.DoEvents();
        }

        secure.End_Session();

        app_Initialize();
    }



    private void app_Initialize()
    {
        secure.SendMessageSecureAsync(new JavaScriptSerializer().Serialize(new Dictionary<string, string>
        {
            ["action"] = "initialize",
            ["application_id"] = App_Key
        }));

        while (!Task_Done)
        {
            Application.DoEvents();
        }

        Task_Done = false;
    }

    public static bool Login(string username, string password)
    {
        if (secure.SecureConnectionEstablished)
        {
            secure.SendMessageSecureAsync(new JavaScriptSerializer().Serialize(new Dictionary<string, string>
            {
                ["action"] = "login",
                ["username"] = username,
                ["password"] = password,
                ["hwid"] = GetSecurity.HWIDPC(),
                ["date"] = DateTime.Now.ToString(),
                ["application_id"] = App_Key
            }));

            while (!Task_Done)
            {
                Application.DoEvents();
            }

            Task_Done = false;
            return isLogged;

        }
        else
        {
            Application.DoEvents();
        }
        return false;
    }

    public static bool Register(string username, string password, string license)
    {
        if (secure.SecureConnectionEstablished)
        {
            secure.SendMessageSecureAsync(new JavaScriptSerializer().Serialize(new Dictionary<string, string>
            {
                ["action"] = "register",
                ["username"] = username,
                ["password"] = password,
                ["license"] = license,
                ["ip"] = GetSecurity.IP(),
                ["hwid"] = GetSecurity.HWIDPC(),
                ["application_id"] = App_Key
            }));

            while (!Task_Done)
            {
                Application.DoEvents();
            }

            Task_Done = false;
            return isRegistered;

        }
        else
        {
            Application.DoEvents();
        }
        return false;
    }

    public static bool ExtendTime(string username, string password, string license)
    {
        if (secure.SecureConnectionEstablished)
        {
            secure.SendMessageSecureAsync(new JavaScriptSerializer().Serialize(new Dictionary<string, string>
            {
                ["action"] = "extend_subscription",
                ["username"] = username,
                ["password"] = password,
                ["license"] = license,
                ["hwid"] = GetSecurity.HWIDPC(),
                ["application_id"] = App_Key
            }));

            while (!Task_Done)
            {
                Application.DoEvents();
            }

            Task_Done = false;
            return isExtended;

        }
        else
        {
            Application.DoEvents();
        }
        return false;
    }

    public static string Variable_capture(string var_code)
    {
        if (!isLogged)
        {
            MessageBox.Show("You must be logged in to capture variables!", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        else
        {
            if (secure.SecureConnectionEstablished)
            {
                secure.SendMessageSecureAsync(new JavaScriptSerializer().Serialize(new Dictionary<string, string>
                {
                    ["action"] = "variable",
                    ["username"] = Info.Username,
                    ["password"] = controlVars.Handler["password"],
                    ["hwid"] = GetSecurity.HWIDPC(),
                    ["application_id"] = App_Key,
                    ["variable_code"] = var_code
                }));

                while (!Task_Done)
                {
                    Application.DoEvents();
                }

                Task_Done = false;
                return controlVars.Vars.ContainsKey(var_code) ? controlVars.Vars[var_code] : "N/A";
            }
            else
            {
                Application.DoEvents();
            }
        }

        return "N/A";
    }

    public static bool licenseLogin(string license)
    {
        if (secure.SecureConnectionEstablished)
        {
            secure.SendMessageSecureAsync(new JavaScriptSerializer().Serialize(new Dictionary<string, string>
            {
                ["action"] = "licenseLogin",
                ["license"] = license,
                ["hwid"] = GetSecurity.HWIDPC(),
                ["ip"] = GetSecurity.IP(),
                ["date"] = DateTime.Now.ToString(),
                ["application_id"] = App_Key,
            }));

            while (!Task_Done)
            {
                Application.DoEvents();
            }

            Task_Done = false;
            return isLogged;

        }
        else
        {
            Application.DoEvents();
        }
        return false;
    }


    #region handling initialize response
    private void init_response(Dictionary<string, object> keyValuePairs)
    {
        switch (GetSecurity.getMD5((string)keyValuePairs["status"]))
        {
            case "260CA9DD8A4577FC00B7BD5810298076":
                App.configuration(keyValuePairs);

                if (!App.Enabled)
                {
                    MessageBox.Show("Program disabled by the administrator.", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }

                if (App.enableUpdater)
                {
                    if (App.Version != App_Version)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        MessageBox.Show("There is a new update found! | [" + App.Version + "]", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Console.ResetColor();
                        string page = !App.updaterLink.Contains("http") || !App.updaterLink.Contains("://") ? "https://" + App.updaterLink : App.updaterLink;
                        Process.Start(page);
                        Environment.Exit(0);
                    }
                }

                #region hash checker
                if (App.hashcheck)
                {
                    if (string.IsNullOrEmpty(App.hashProgram))
                    {
                        MessageBox.Show("No hashes found to check application integrity!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    else if (GetSecurity.program_hash(Assembly.GetEntryAssembly().Location) != App.hashProgram && !App.devMode)
                    {
                        MessageBox.Show("The hash of this application does not match the hash uploaded to the server!, if you think this is a mistake, contact your developer.", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    else if (GetSecurity.program_hash(Assembly.GetEntryAssembly().Location) != App.hashProgram && App.devMode)
                    {
                        File.AppendAllText("integrity.txt", GetSecurity.program_hash(Assembly.GetEntryAssembly().Location) + Environment.NewLine);
                        MessageBox.Show("The hash of this application was saved in the text : hash.txt !", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion

                if (App.Freemode)
                {
                    MessageBox.Show("Free mode activated!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Initialized = true;
                break;

            case "CB5E100E5A9A3E7F6D1FD97512215282": // error
                MessageBox.Show((string)keyValuePairs["info"], Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;
        }


    }
    #endregion

    #region handling login response
    private void login_response(Dictionary<string, object> keyValuePairs)
    {
        switch ((string)keyValuePairs["status"])
        {
            case "incorrect_hwid":
                MessageBox.Show("The HWID is incorrect!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "hwid_reseted":
                MessageBox.Show("Your HWID has been reset!, please login again.", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
                break;

            case "incorrect_details":
                MessageBox.Show("Invalid name or password!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "expired_time":
                MessageBox.Show("Your key has expired!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "banned_user":
                MessageBox.Show("This key is banned!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "success":
                Info.Username = (string)keyValuePairs["username"];
                Info.HWID = (string)keyValuePairs["hwid"];
                Info.License = (string)keyValuePairs["license"];
                Info.Level = (string)keyValuePairs["level"];
                Info.IP = GetSecurity.IP();
                Info.Expires = (string)keyValuePairs["expires"];


                if (Info.HWID != GetSecurity.HWIDPC() && App.HWIDLock)
                {
                    MessageBox.Show("Your HWID does not match!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                else
                {
                    isLogged = true;
                }
                break;
        }
    }
    #endregion

    #region handling license key login response
    private void licenseLogin_response(Dictionary<string, object> keyValuePairs)
    {
        switch ((string)keyValuePairs["status"])
        {
            case "expired_time":
                MessageBox.Show("Your key has expired!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "incorrect_hwid":
                MessageBox.Show("The HWID is incorrect!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "banned_user":
                MessageBox.Show("This key is banned", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "incorrect_details":
                MessageBox.Show("Invalid license key!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "success":

                Info.Username = (string)keyValuePairs["license"];
                Info.HWID = (string)keyValuePairs["hwid"];
                Info.License = (string)keyValuePairs["license"];
                Info.Level = (string)keyValuePairs["level"];
                Info.IP = (string)keyValuePairs["ip"];
                Info.Expires = (string)keyValuePairs["expires"];


                if (Info.HWID != GetSecurity.HWIDPC() && App.HWIDLock)
                {
                    MessageBox.Show("Your HWID does not match!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                else
                {
                    isLogged = true;
                }
                break;
        }
    }
    #endregion

    #region handling register response  
    private void register_response(Dictionary<string, object> valuePairs)
    {
        switch ((string)valuePairs["status"])
        {
            case "username_used":
                MessageBox.Show("That username is already in use!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "max_quote": // Having a subscription, don't even worry about this
                MessageBox.Show("Program owner has exceeded their max user quota.", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "invalid_license":
                MessageBox.Show("Your license is invalid!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "success":
                isRegistered = true;
                break;
        }
    }
    #endregion

    #region handling extend subscription time response  
    private void extendtime_response(Dictionary<string, object> valuePairs)
    {
        switch ((string)valuePairs["status"])
        {
            case "incorrect_details":
                MessageBox.Show("Invalid name or password!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "banned_user":
                MessageBox.Show("Your account is banned from this application!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "incorrect_hwid":
                MessageBox.Show("The HWID is incorrect!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "incorrect_license":
                MessageBox.Show("The license entered does not exist!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "success":
                isExtended = true;
                break;
        }
    }
    #endregion

    #region handling variable response
    private void var_response(Dictionary<string, object> keyValues)
    {
        switch ((string)keyValues["status"])
        {
            case "incorrect_details":
                MessageBox.Show("Invalid name or password!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                break;

            case "success":
                if (!controlVars.Vars.ContainsKey((string)keyValues["code"]))
                    controlVars.Vars.Add((string)keyValues["code"], (string)keyValues["var_value"]);
                break;
        }
    }
    #endregion

    #region handling of all responses
    private void Secure_OnResponseReceiveds(object sender, ResponseReceivedEventArgs e)
    {
        var data = e.Response;
        Dictionary<string, object> result = new JavaScriptSerializer().DeserializeObject(data) as Dictionary<string, object>;

        string action = (string)result["action"];

        if (action == "banned_app")
        {
            MessageBox.Show("This application is banned, please contact the developer.", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        else if (action == "failed_connection" || action == "internal_error")
        {
            MessageBox.Show("There was an error in the connection to the server!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        else if (action == "null_entry")
        {
            MessageBox.Show("Key does not exits!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        else if (action == "unfound_application")
        {
            MessageBox.Show("The application could not be found!", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        else if (action == "initialize")
        {
            init_response(result);
            Task_Done = true;
        }
        else if (action == "login")
        {
            login_response(result);
            Task_Done = true;
        }
        else if (action == "licenseLogin")
        {
            licenseLogin_response(result);
            Task_Done = true;
        }
        else if (action == "register")
        {
            register_response(result);
            Task_Done = true;
        }
        else if (action == "extend_subscription")
        {
            extendtime_response(result);
            Task_Done = true;
        }
        else if (action == "var")
        {
            var_response(result);
            Task_Done = true;
        }
    }
    #endregion

}

#region security application
public class Security
{
    #region ARP Poisoning
    public class ARPPoisoning
    {
        public static System.Threading.Timer timer { get; set; }
        public string lastGateway { get; set; }

        public void Start() // Credits to Outbuilt by ARP Poisoning
        {
            lastGateway = getGatewayMAC();
            timer = new System.Threading.Timer(_ => onCallback(), null, 5000, Timeout.Infinite);
        }

        public void onCallback()
        {
            timer.Dispose();
            if (getGatewayMAC() != lastGateway)
            {
                MessageBox.Show("Security breach detected!, Closing...", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }
        }

        public IPAddress getDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .FirstOrDefault(a => a != null);
        }

        public string GET_ARPTable()
        {
            var start = new ProcessStartInfo
            {
                FileName = @"C:\Windows\System32\arp.exe",
                Arguments = "-a",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(start))
            {
                if (process == null)
                    return string.Empty;

                using (StreamReader reader = process.StandardOutput)
                {
                    return reader.ReadToEnd();
                }

            }
        }

        public string getGatewayMAC()
        {
            return new Regex($@"({getDefaultGateway()} [\W]*) ([a-z0-9-]*)").Match(GET_ARPTable()).Groups[2].ToString();
        }

    }
    #endregion
    public string IP()
    {
        return new WebClient().DownloadString("https://api.ipify.org/");
    }

    public string HWIDPC()
    {
        return new HWIDUser().ID;
    }

    // Get the program hash
    public string program_hash(string file)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(file))
            {
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }

    // get the text hash
    public string getMD5(string text)
    {
        byte[] arrBytTarget;
        MD5 hash = new MD5CryptoServiceProvider();
        arrBytTarget = hash.ComputeHash(ASCIIEncoding.Default.GetBytes(text));
        return BitConverter.ToString(arrBytTarget).Replace("-", "");
    }


    internal class HWIDUser
    {
        public string ID { get; set; }
        public HWIDUser()
        {
           // var volumenSerial = GetDiskId();
            //var CPUID = GetCpuId();
            var WindowsID = GetWindowsId();
            //ID = volumenSerial + CPUID + WindowsID;
            ID = WindowsID;
        }


        private string GetDiskId()
        {
            string diskLetter = string.Empty;

            //Find first drive

            foreach (var compDrive in DriveInfo.GetDrives())
            {
                if (compDrive.IsReady)
                {
                    diskLetter = compDrive.RootDirectory.ToString();
                    break;
                }
            }

            if (!string.IsNullOrEmpty(diskLetter) && diskLetter.EndsWith(":\\"))
            {
                //C:\ -> C
                diskLetter = diskLetter.Substring(0, diskLetter.Length - 2);
            }
            var disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + diskLetter + @":""");
            disk.Get();

            var volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }



        [DllImport("user32", EntryPoint = "CallWindowProcW", CharSet = CharSet.Unicode, SetLastError = true,
        ExactSpelling = true)]
        private static extern IntPtr CallWindowProcW([In] byte[] bytes, IntPtr hWnd, int msg, [In, Out] byte[] wParam,
        IntPtr lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool VirtualProtect([In] byte[] bytes, IntPtr size, int newProtect, out int oldProtect);

        const int PAGE_EXECUTE_READWRITE = 0x40;

        public static string GetCpuId()
        {
            var sn = new byte[8];

            return !ExecuteCode(ref sn) ? "ND" : string.Format("{0:X8}{1:X8}", BitConverter.ToUInt32(sn, 4), BitConverter.ToUInt32(sn, 0));
        }

        private static bool ExecuteCode(ref byte[] result)
        {
            /* The opcodes below implement a C function with the signature:
             * __stdcall CpuIdWindowProc(hWnd, Msg, wParam, lParam);
             * with wParam interpreted as an 8 byte unsigned character buffer.
             * */

            var isX64Process = IntPtr.Size == 8;
            byte[] code;

            if (isX64Process)
            {
                code = new byte[]
                {
                    0x53, /* push rbx */
                    0x48, 0xc7, 0xc0, 0x01, 0x00, 0x00, 0x00, /* mov rax, 0x1 */
                    0x0f, 0xa2, /* cpuid */
                    0x41, 0x89, 0x00, /* mov [r8], eax */
                    0x41, 0x89, 0x50, 0x04, /* mov [r8+0x4], edx */
                    0x5b, /* pop rbx */
                    0xc3, /* ret */
                };
            }
            else
            {
                code = new byte[]
                {
                    0x55, /* push ebp */
                    0x89, 0xe5, /* mov  ebp, esp */
                    0x57, /* push edi */
                    0x8b, 0x7d, 0x10, /* mov  edi, [ebp+0x10] */
                    0x6a, 0x01, /* push 0x1 */
                    0x58, /* pop  eax */
                    0x53, /* push ebx */
                    0x0f, 0xa2, /* cpuid    */
                    0x89, 0x07, /* mov  [edi], eax */
                    0x89, 0x57, 0x04, /* mov  [edi+0x4], edx */
                    0x5b, /* pop  ebx */
                    0x5f, /* pop  edi */
                    0x89, 0xec, /* mov  esp, ebp */
                    0x5d, /* pop  ebp */
                    0xc2, 0x10, 0x00, /* ret  0x10 */
                };
            }

            var ptr = new IntPtr(code.Length);

            if (!VirtualProtect(code, ptr, PAGE_EXECUTE_READWRITE, out _))
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            ptr = new IntPtr(result.Length);
            return CallWindowProcW(code, IntPtr.Zero, 0, result, ptr) != IntPtr.Zero;

        }



        public static string GetWindowsId()
        {
            /*
             var windowsInfo = string.Empty;
             var managClass = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");

             var managCollec = managClass.Get();

             var is64Bits = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));

             foreach (var o in managCollec)
             {
                 var managObj = (ManagementObject)o;
                 windowsInfo = managObj.Properties["Caption"].Value + Environment.UserName + (string)managObj.Properties["Version"].Value;
                 break;
             }
             windowsInfo = windowsInfo.Replace(" ", "")
                 .Replace("Windows", "")
                 .Replace("windows", "");

             windowsInfo += (is64Bits) ? " 64bit" : " 32bit";

             return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(windowsInfo))).Replace("-", "");
            */
            return WindowsIdentity.GetCurrent().User.Value;
        }


    }

}

#endregion

public class SecureConnection : Auth
{
    #region making secure connection
    private bool inUse { get; set; } = false;
    private string asyncResponse;
    private readonly BackgroundWorker background = new BackgroundWorker();
    private readonly BackgroundWorker eventSender = new BackgroundWorker();
    private readonly HttpControl httpControl = new HttpControl();
    private readonly RSACryptography RSACrypt = new RSACryptography();
    private readonly AESCryptography AESCrypt = new AESCryptography();

    internal event ResponseReceivedHandler OnResponseReceived;

    internal delegate void ResponseReceivedHandler(object sender, ResponseReceivedEventArgs e);
    internal bool SecureConnectionEstablished { get; set; }

    internal SecureConnection()
    {
        SecureConnectionEstablished = false;
        background.DoWork += background_DoWork;
        background.RunWorkerCompleted += background_RunWorkerCompleted;
        eventSender.DoWork += sender_DoWork;
        eventSender.RunWorkerCompleted += sender_RunWorkerCompleted;
    }

    #endregion


    #region secure sessions

    // this is to get a secure connection between the client -> server
    public void Start_Session()
    {
        if (SessionStarted)
        {
            MessageBox.Show("Session already started, closing for security reasons...", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        else
        {
            string hosts_Path = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\drivers\\etc\\hosts";

            if (File.Exists(hosts_Path))
            {
                using (StreamReader reader = new StreamReader(hosts_Path))
                {
                    if (reader.ReadToEnd().Contains("chiper.io"))
                    {
                        MessageBox.Show("DNS redirection found, closing the application...", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }
            }

            new Security.ARPPoisoning().Start();

            Auth.SessionStarted = true;
            ServicePointManager.ServerCertificateValidationCallback += pinPublicKey;
        }
    }

    public void End_Session()
    {
        if (!Auth.SessionStarted)
        {
            MessageBox.Show("The session hasn't started yet, closing for security reasons...", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        Auth.SessionStarted = false;
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
    }

    private bool pinPublicKey(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (cert != null && cert.GetPublicKeyString() == Auth.certification_Key)
            return true;
        MessageBox.Show("Error when establishing a secure SSL connection with the server.", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        Environment.Exit(0);
        return false;
    }
    #endregion

    #region encryption connection 
    private void background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (!SecureConnectionEstablished)
        {
            MessageBox.Show("It was not possible to establish a secure communication with the server.", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
    }

    private void background_DoWork(object sender, DoWorkEventArgs e)
    {
        var cert = httpControl.Post(APIStartup, "code=" + API_Encrytion);

        if (cert.Contains("invalid_key"))
        {
            MessageBox.Show("Invalid encryption key", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        else if (string.IsNullOrEmpty(cert))
        {
            MessageBox.Show("Invalid communication with the server ; null certificate", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        RSACrypt.LoadCertification(cert);
        AESCrypt.GenerateRandomKeys();

        string key = Utils.ToUrlSafeBase64(RSACrypt.Encrypt(AESCrypt.EncryptionKey));
        string iv = Utils.ToUrlSafeBase64(RSACrypt.Encrypt(AESCrypt.EncryptionIV));
        string result = httpControl.Post(APIStartup, "session_key=" + key + "&session_iv=" + iv + "&session_access=" + API_Encrytion);
        SecureConnectionEstablished = AESCrypt.Decrypt(result) == "AES OK";
    }


    internal void EstablishSecureConnectionAsync()
    {
        if (!background.IsBusy)
            background.RunWorkerAsync();
    }

    internal string SendMessageSecure(string message)
    {
        if (SecureConnectionEstablished)
        {
            string encrypted = AESCrypt.Encrypt(message);
            string response = httpControl.Post(APIStartup, "data=" + encrypted);
            return AESCrypt.Decrypt(response);
        }

        return "NOT CONNECTED";
    }

    // Send an encrypted message and wait for a secure response
    internal void SendMessageSecureAsync(string message)
    {
        if (SecureConnectionEstablished && !inUse) eventSender.RunWorkerAsync(message);
    }

    private void sender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        inUse = false;
        OnResponseReceived?.Invoke(this, new ResponseReceivedEventArgs(asyncResponse));
    }

    private void sender_DoWork(object sender, DoWorkEventArgs e)
    {
        inUse = true;
        asyncResponse = SendMessageSecure((string)e.Argument);
    }
    #endregion
}

internal class ResponseReceivedEventArgs
{
    internal string Response { get; set; }

    internal ResponseReceivedEventArgs(string response)
    {
        Response = response;
    }
}

internal class RSACryptography
{
    private X509Certificate2 cert;
    private bool initialized;
    internal RSACryptography()
    {
        initialized = false;
    }

    internal void LoadCertification(string certificateText)
    {
        try
        {
            cert = GetCertificate(certificateText);
            initialized = true;
        }
        catch
        {
            initialized = false;
            MessageBox.Show("Could not connect properly with the server certificate.", Auth.appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
    }

    private static X509Certificate2 GetCertificate(string key)
    {
        try
        {
            if (key.Contains("-----"))
            {
                key = key.Replace("-----", "").Replace("\n", "").Replace("BEGIN CERTIFICATE", "").Replace("END CERTIFICATE", "");
            }

            key = key.Replace("\n", "");

            return new X509Certificate2(Convert.FromBase64String(key));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);
            throw new FormatException("The certificate key was not in the expected format.", ex);
        }
    }


    internal byte[] Encrypt(byte[] message)
    {
        if (initialized)
        {
            var publicprovider = (RSACryptoServiceProvider)cert.PublicKey.Key;
            return publicprovider.Encrypt(message, false);
        }

        throw new Exception("The RSA engine has not been initialized with a certificate yet.");
    }
}

internal class HttpControl
{
    private readonly CookieContainer cookies;

    internal HttpControl()
    {
        cookies = new CookieContainer();
    }

    internal string Post(string url, string data)
    {
        try
        {
            var buffer = Encoding.ASCII.GetBytes(data);
            var request = (HttpWebRequest)WebRequest.Create(url);

            // Send request
            request.Proxy = null;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = buffer.Length;
            request.CookieContainer = cookies;
            var postData = request.GetRequestStream();
            postData.Write(buffer, 0, buffer.Length);
            postData.Close();

            // Get and return response
            var response = (HttpWebResponse)request.GetResponse();
            var Answer = response.GetResponseStream();
            var answer = new StreamReader(Answer);
            return answer.ReadToEnd();
        }
        catch (Exception ex)
        {
            return "ERROR: " + ex.Message;
        }
    }
}

internal class Utils
{
    internal static string ToUrlSafeBase64(byte[] input)
    {
        return Convert.ToBase64String(input).Replace("+", "-").Replace("/", "_");
    }

    internal static byte[] FromUrlSafeBase64(string input)
    {
        return Convert.FromBase64String(input.Replace("-", "+").Replace("_", "/"));
    }
}



internal class AESCryptography
{
    internal byte[] EncryptionKey { get; }
    internal byte[] EncryptionIV { get; }

    internal AESCryptography()
    {
        EncryptionKey = new byte[256 / 8];
        EncryptionIV = new byte[128 / 8];

        GenerateRandomKeys();
    }

    internal void GenerateRandomKeys()
    {
        var random = new RNGCryptoServiceProvider();
        random.GetBytes(EncryptionKey);
        random.GetBytes(EncryptionIV);
    }

    internal string Encrypt(string plainText)
    {
        try
        {
            var aes = new RijndaelManaged
            {
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC,
                KeySize = 256,
                Key = EncryptionKey,
                IV = EncryptionIV
            };

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            var msEncrypt = new MemoryStream();
            var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            var swEncrypt = new StreamWriter(csEncrypt);

            swEncrypt.Write(plainText);

            swEncrypt.Close();
            csEncrypt.Close();
            aes.Clear();

            return Utils.ToUrlSafeBase64(msEncrypt.ToArray());
        }
        catch (Exception ex)
        {
            throw new CryptographicException("Problem trying to encrypt.", ex);
        }
    }

    internal string Decrypt(string cipherText)
    {
        try
        {
            var aes = new RijndaelManaged
            {
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC,
                KeySize = 256,
                Key = EncryptionKey,
                IV = EncryptionIV
            };

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            var msDecrypt = new MemoryStream(Utils.FromUrlSafeBase64(cipherText));
            var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            var srDecrypt = new StreamReader(csDecrypt);

            string plaintext = srDecrypt.ReadToEnd();

            srDecrypt.Close();
            csDecrypt.Close();
            msDecrypt.Close();
            aes.Clear();

            return plaintext;
        }
        catch (Exception ex)
        {
            throw new CryptographicException("Problem trying to decrypt.", ex);
        }
    }
}

