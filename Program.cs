using System;
using System.Windows.Forms;

namespace GR_King
{
    static class Program
    {
        public static readonly Swifty Chiper =
                    new Swifty("GR King Antiban", "v49pyc5z3ym8776710vob0sd1jagsok4", "226850", "1.0");

        [STAThread]
        static void Main()
        {
            anticrack.checkblockeduser();
            anticrack.Start();
            Chiper.Connect();
            Application.Run(new Login());

        }
    }
}
