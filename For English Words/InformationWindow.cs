using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace For_English_Words
{
    public partial class InformationWindow : Form
    {
        Size screenSize = Screen.PrimaryScreen.Bounds.Size;
        //---------------------------------------------------------------------------------------------------------------------------------------------
        string configPath = "C:\\WordMem\\Config",
        pathToSwitchColor = "Switch Color.ss";
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public InformationWindow()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void InformationWindow_Load(object sender, EventArgs e)
        {
            ThemeSetings();
            LocationInfoWindow();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void LocationInfoWindow()
        {
            Location = new Point((screenSize.Width/2)-(Size.Width/2), (screenSize.Height/2)-(Size.Height/2));
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void ThemeSetings()
        {
            sbyte GG = 0;
            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToSwitchColor}"))
                GG = Convert.ToSByte(sr.ReadToEnd());
            switch (GG)
            {
                case 0:
                    BackColor = Color.FromArgb(20, 20, 20);
                    label1.ForeColor = Color.FromArgb(128, 255, 0);
                    label2.ForeColor = Color.FromArgb(255, 0, 0);
                    label3.ForeColor = label2.ForeColor;
                    label4.ForeColor = Color.FromArgb(0, 0, 255);
                    button1.ForeColor = Color.FromArgb(255, 0, 0);
                    break;
                case 1:
                    BackColor = Color.FromArgb(200, 200, 200);
                    label1.ForeColor = Color.FromArgb(128, 255, 0);
                    label2.ForeColor = Color.FromArgb(0, 0, 0);
                    label3.ForeColor = label2.ForeColor;
                    label4.ForeColor = Color.FromArgb(0, 0, 255);
                    button1.ForeColor = Color.FromArgb(0, 0, 0);
                    break;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Додавання тіні
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void InformationWindow_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }


        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
