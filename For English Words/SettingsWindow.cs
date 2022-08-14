using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace For_English_Words
{
    public partial class SettingsWindow : Form
    {
        Size screenSize = Screen.PrimaryScreen.Bounds.Size;

        string pathToCounterFile = $@"C:\FEW\Case index.ci",
            pathToApplySettingFile = $@"C:\FEW\Apply.bat",
            pathToValueParameters = $@"C:\FEW\Value of size window parameters.par";

        sbyte counterIndex = 0, G = 0;
        int counterParIndex = 0;
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            Size = new Size(966, 410);
            panel1.Size = new Size(771, 361);
            panel1.Location = new Point(196, 50);
            Location = new Point((screenSize.Width/2)-(Size.Width/2), (screenSize.Height/2)-(Size.Height/2));
            GetParameters();
            comboBox1.SelectedIndex = 0;
        }

        private void GetParameters()
        {
            string str = "", strArrays = "";
            string[] strArray1, strArray2;
            using (StreamReader sr = new StreamReader(pathToValueParameters))
                str = sr.ReadToEnd();
            strArray1 = str.Split('\n');
            counterParIndex = strArray1.Length - 1;
            using (StreamReader sr = new StreamReader(pathToCounterFile))
                strArrays = strArray1[Convert.ToSByte(sr.ReadToEnd())];
            strArray2 = strArrays.Split(',');
            label7.Text = $"X: {strArray2[0]}\nY: {strArray2[1]}";

        }
        private void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line}",
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                pictureBox1.Image = Properties.Resources.Black_color_0_0_0_;
            else if (comboBox1.SelectedIndex == 1)
                pictureBox1.Image = Properties.Resources.White_color_255_255_255_;
            else if (comboBox1.SelectedIndex == 2)
                pictureBox1.Image = Properties.Resources.Pink_color_255_0_240_;
            else if (comboBox1.SelectedIndex == 3)
                pictureBox1.Image = Properties.Resources.Light_green_color_211_255_105_;
            else if (comboBox1.SelectedIndex == 4)
                pictureBox1.Image = Properties.Resources.Brown_color_71_38_0_;
            else if (comboBox1.SelectedIndex == 5)
                pictureBox1.Image = Properties.Resources.Orange_color_255_132_0_;
            else if (comboBox1.SelectedIndex == 6)
                pictureBox1.Image = Properties.Resources.Yellow_color_255_255_0_;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strCounterIndex = "", str = "", strArrays = "";
            string[] strArray1, strArray2;
            using (StreamReader sr = new StreamReader(pathToCounterFile))
                strCounterIndex = sr.ReadToEnd();
            counterIndex = Convert.ToSByte(strCounterIndex);
            if (counterIndex < counterParIndex)
            {
                counterIndex++;

                using (StreamReader sr = new StreamReader(pathToValueParameters))
                    str = sr.ReadToEnd();
                strArray1 = str.Split('\n');
                strArrays = strArray1[counterIndex];
                strArray2 = strArrays.Split(',');
                label7.Text = $"X: {strArray2[0]}\nY: {strArray2[1]}";

                using (StreamWriter sw = new StreamWriter(pathToCounterFile))
                    sw.Write(counterIndex);
            }

            if (counterIndex == counterParIndex)
            {
                counterIndex = (sbyte)counterParIndex;

                using (StreamReader sr = new StreamReader(pathToValueParameters))
                    str = sr.ReadToEnd();
                strArray1 = str.Split('\n');
                strArrays = strArray1[counterIndex];
                strArray2 = strArrays.Split(',');
                label7.Text = $"X: {strArray2[0]}\nY: {strArray2[1]}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strCounterIndex = "", str = "", strArrays = "";
            string[] strArray1, strArray2;
            using (StreamReader sr = new StreamReader(pathToCounterFile))
                strCounterIndex = sr.ReadToEnd();
            counterIndex = Convert.ToSByte(strCounterIndex);
            if (counterIndex > 0)
                counterIndex--;
            if(counterIndex == 0)
                using (StreamWriter sw = new StreamWriter(pathToCounterFile))
                    sw.Write(0);

            using (StreamReader sr = new StreamReader(pathToValueParameters))
                str = sr.ReadToEnd();
            strArray1 = str.Split('\n');
            strArrays = strArray1[counterIndex];
            strArray2 = strArrays.Split(',');
            label7.Text = $"X: {strArray2[0]}\nY: {strArray2[1]}";

            using (StreamWriter sw = new StreamWriter(pathToCounterFile))
                sw.Write(counterIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cmd(pathToApplySettingFile);
        }
    }
}
