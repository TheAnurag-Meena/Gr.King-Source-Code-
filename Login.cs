using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace GR_King
{
    
    public partial class Login : Form
    {

        private files f = new files();
        public Login()
        {
            InitializeComponent();
            cracklable.Hide();
            try
            {
                //Login msg
                string loginmsg = new WebClient().DownloadString("https://textbin.net/raw/1bascwcg2W");
                Process.Start(loginmsg);
            }
            catch
            {

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Minimize Button
            this.WindowState = FormWindowState.Minimized;
        }

        private void CloseBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
        private void button2_Click(object sender, EventArgs e)
        {
            //Login Button
            sound();
            if (Program.Chiper.licenseLogin(KEY.Text))
            {
                try
                {

                    cracklable.Text = Program.Chiper.captureVariable("A9bAae788a9d8eafb7655ADCbF0aa7adDd1");
                    if (cracklable.Text == "2")
                    {

                        //if login Success

                        if (checkBox1.Checked == true)
                        {
                            try
                            {
                                Properties.Settings.Default.loginkey = this.KEY.Text;
                                Properties.Settings.Default.Save();
                            }
                            catch
                            {

                            }

                            try
                            {
                                using (StreamWriter stremWriter = new StreamWriter("login.ini"))
                                {
                                    stremWriter.WriteLine(KEY.Text);
                                }
                            }
                            catch { }


                        }
                        if (checkBox1.Checked == false)
                        {
                            try
                            {
                                Properties.Settings.Default.loginkey = "";
                                Properties.Settings.Default.Save();

                            }
                            catch
                            {

                            }
                            string fileName = "login.ini";
                            string path12 = Path.Combine(Application.StartupPath, fileName);
                            try
                            {
                                File.Delete(fileName);
                            }
                            catch { }
                        }

                        _ = MessageBox.Show("Key Expire : " + Info.Expires, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 form1 = new Form1();
                        this.Hide();
                        form1.Show();

                    }
                    else
                    {

                        Application.Exit();
                        Environment.Exit(0);
                    }
                }
                catch
                {

                    Application.Exit();
                    Environment.Exit(0);
                }
                //System.Threading.Thread.Sleep(2000);

            }
            else
            {
                Environment.Exit(0);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //DISCORD
            try
            {
                string discord = new WebClient().DownloadString("https://grdownload.ml/grkingdc.txt");
                Process.Start(discord);
            }
            catch
            {

            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.f.soundfileextract();
            try
            {
                if (Properties.Settings.Default.loginkey != String.Empty)
                {
                    KEY.Text = Properties.Settings.Default.loginkey;

                }
            }
            catch { }

            try
            {
                using (StreamReader streamReader = new StreamReader("login.ini"))
                {
                    KEY.Text = streamReader.ReadLine();
                }
            }
            catch { }

        }

    }
}
