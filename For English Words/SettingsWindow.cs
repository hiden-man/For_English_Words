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

        string defaultPath = "",
            tempStr = "",
            configPath = "C:\\WordMem\\Config",
            pathToCounterFile = "Case index.ci",
            pathToApplySettingFile = "Apply.bat",
            pathToDocuments = "PathForDocument.dfp",
            pathToValueParameters = "Value of size window parameters.par",
            pathToSwitchColor = "Switch Color.ss",
            //--------------------------------------------------------------
            pathToFileWords = "English words.mw",
            pathToFileTranslate = "Translate.mw",
            pathToCorecctAnswerFile = "Counter of correct answer.mw",
            pathToRandomAsnwer = "Random answer.mw",
            pathToSwitchIndex = "Switch index.mw",
            pathToValueParameters2 ="Value of font main text parameters.par",
            pathToValueParameters3 = "Value of font answer text parameters.par",
            pathToValueParameters4 = "Value of font button text parameters.par",
            pathToValueParameters5 = "Value of size textBox parameters.par",
            pathToValueParameters6 = "Value of size button parameters.par",
            pathToValueParameters7 = "Value of size correct answer picture parameters.par",
            pathToCounterFile2 = "Index for switch.ci",
            pathToSizeFile = "Number of the words.mw";

        sbyte counterIndex = 0, G = 0;
        int counterParIndex = 0;
        bool ctrl = false, n = false, m = false, q = false;


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
            GetPath();
            Size = new Size(668, 410);
            Location = new Point((screenSize.Width/2)-(Size.Width/2), (screenSize.Height/2)-(Size.Height/2));
            GetParameters();
            ThemeSetings();
            textBox1.Text = defaultPath+"\\";
        }

        private void ThemeSetings()
        {
            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToSwitchColor}"))
            {
                G = Convert.ToSByte(sr.ReadToEnd());
            }

            switch (G)
            {
                case 0:
                    BackColor = Color.FromArgb(20,20,20);
                    panel6.BackColor = Color.FromArgb(5,5,5);
                    panel1.BackColor = Color.FromArgb(15,15,15);
                    panel5.BackColor = panel1.BackColor;
                    comboBox1.BackColor = panel1.BackColor;
                    comboBox2.BackColor = panel1.BackColor;
                    comboBox3.BackColor = panel1.BackColor;
                    comboBox4.BackColor = panel1.BackColor;
                    comboBox5.BackColor = panel1.BackColor;
                    comboBox6.BackColor = panel1.BackColor;
                    comboBox7.BackColor = panel1.BackColor;
                    comboBox8.BackColor = panel1.BackColor;
                    comboBox9.BackColor = panel1.BackColor;
                    comboBox10.BackColor = panel1.BackColor;
                    comboBox11.BackColor = panel1.BackColor;
                    comboBox12.BackColor = panel1.BackColor;
                    comboBox13.BackColor = panel1.BackColor;
                    comboBox14.BackColor = panel1.BackColor;
                    comboBox15.BackColor = panel1.BackColor;
                    comboBox16.BackColor = panel1.BackColor;
                    textBox1.BackColor = panel1.BackColor;
                    //------------
                    label5.ForeColor = Color.FromArgb(255,102,102);
                    label1.ForeColor = label5.ForeColor;
                    label2.ForeColor = label5.ForeColor;
                    label3.ForeColor = label5.ForeColor;
                    label4.ForeColor = label5.ForeColor;
                    label7.ForeColor = label5.ForeColor;
                    label6.ForeColor = label5.ForeColor;
                    label8.ForeColor = label5.ForeColor;
                    button1.ForeColor = Color.FromArgb(255,0,0);
                    button5.ForeColor = button1.ForeColor;
                    button8.ForeColor = button1.ForeColor;
                    button17.ForeColor = button1.ForeColor;
                    button19.ForeColor = button1.ForeColor;
                    button4.ForeColor = button1.ForeColor;
                    button2.ForeColor = button1.ForeColor;
                    button3.ForeColor = button1.ForeColor;
                    button9.ForeColor = button1.ForeColor;
                    button10.ForeColor = button1.ForeColor;
                    button11.ForeColor = button1.ForeColor;
                    groupBox1.ForeColor = label5.ForeColor;
                    groupBox2.ForeColor = label5.ForeColor;
                    groupBox3.ForeColor = label5.ForeColor;
                    groupBox4.ForeColor = label5.ForeColor;
                    comboBox1.ForeColor = label5.ForeColor;
                    comboBox2.ForeColor = label5.ForeColor;
                    comboBox3.ForeColor = label5.ForeColor;
                    comboBox4.ForeColor = label5.ForeColor;
                    comboBox5.ForeColor = label5.ForeColor;
                    comboBox6.ForeColor = label5.ForeColor;
                    comboBox7.ForeColor = label5.ForeColor;
                    comboBox8.ForeColor = label5.ForeColor;
                    comboBox9.ForeColor = label5.ForeColor;
                    comboBox10.ForeColor = label5.ForeColor;
                    comboBox11.ForeColor = label5.ForeColor;
                    comboBox12.ForeColor = label5.ForeColor;
                    comboBox13.ForeColor = label5.ForeColor;
                    comboBox14.ForeColor = label5.ForeColor;
                    comboBox15.ForeColor = label5.ForeColor;
                    comboBox16.ForeColor = label5.ForeColor;
                    textBox1.ForeColor = label5.ForeColor;
                    break;
                case 1:
                    BackColor = Color.FromArgb(200, 200, 200);
                    panel2.BackColor = BackColor;
                    panel6.BackColor = Color.FromArgb(255, 255, 255);
                    panel1.BackColor = Color.FromArgb(150, 150, 150);
                    panel5.BackColor = panel1.BackColor;
                    comboBox1.BackColor = panel1.BackColor;
                    comboBox2.BackColor = panel1.BackColor;
                    comboBox3.BackColor = panel1.BackColor;
                    comboBox4.BackColor = panel1.BackColor;
                    comboBox5.BackColor = panel1.BackColor;
                    comboBox6.BackColor = panel1.BackColor;
                    comboBox7.BackColor = panel1.BackColor;
                    comboBox8.BackColor = panel1.BackColor;
                    comboBox9.BackColor = panel1.BackColor;
                    comboBox10.BackColor = panel1.BackColor;
                    comboBox11.BackColor = panel1.BackColor;
                    comboBox12.BackColor = panel1.BackColor;
                    comboBox13.BackColor = panel1.BackColor;
                    comboBox14.BackColor = panel1.BackColor;
                    comboBox15.BackColor = panel1.BackColor;
                    comboBox16.BackColor = panel1.BackColor;
                    textBox1.BackColor = panel1.BackColor;
                    //------------
                    label5.ForeColor = Color.FromArgb(0,0,0);
                    label1.ForeColor = label5.ForeColor;
                    label2.ForeColor = label5.ForeColor;
                    label3.ForeColor = label5.ForeColor;
                    label4.ForeColor = label5.ForeColor;
                    label7.ForeColor = label5.ForeColor;
                    label6.ForeColor = label5.ForeColor;
                    button5.ForeColor = label5.ForeColor;
                    button8.ForeColor = label5.ForeColor;
                    button1.ForeColor = label5.ForeColor;
                    button17.ForeColor = label5.ForeColor;
                    button19.ForeColor = label5.ForeColor;
                    button4.ForeColor = label5.ForeColor;
                    button2.ForeColor = label5.ForeColor;
                    button3.ForeColor = label5.ForeColor;
                    button9.ForeColor = label5.ForeColor;
                    button10.ForeColor = label5.ForeColor;
                    button11.ForeColor = label5.ForeColor;
                    groupBox1.ForeColor = label5.ForeColor;
                    groupBox2.ForeColor = label5.ForeColor;
                    groupBox3.ForeColor = label5.ForeColor;
                    groupBox4.ForeColor = label5.ForeColor;
                    comboBox1.ForeColor = label5.ForeColor;
                    comboBox2.ForeColor = label5.ForeColor;
                    comboBox3.ForeColor = label5.ForeColor;
                    comboBox4.ForeColor = label5.ForeColor;
                    comboBox5.ForeColor = label5.ForeColor;
                    comboBox6.ForeColor = label5.ForeColor;
                    comboBox7.ForeColor = label5.ForeColor;
                    comboBox8.ForeColor = label5.ForeColor;
                    comboBox9.ForeColor = label5.ForeColor;
                    comboBox10.ForeColor = label5.ForeColor;
                    comboBox11.ForeColor = label5.ForeColor;
                    comboBox12.ForeColor = label5.ForeColor;
                    comboBox13.ForeColor = label5.ForeColor;
                    comboBox14.ForeColor = label5.ForeColor;
                    comboBox15.ForeColor = label5.ForeColor;
                    comboBox16.ForeColor = label5.ForeColor;
                    textBox1.ForeColor = label5.ForeColor;
                    break;
            }
        }

        private void GetPath()
        {
            string pathSTR = "";
            string[] pathSTRArray;

            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToDocuments}"))
                pathSTR = sr.ReadToEnd();
            defaultPath = pathSTR;
        }

        private void GetParameters()
        {
            string str = "", strArrays = "";
            string[] strArray1, strArray2;
            using (StreamReader sr = new StreamReader($@"{configPath}\{pathToValueParameters}"))
                str = sr.ReadToEnd();
            strArray1 = str.Split('\n');
            counterParIndex = strArray1.Length - 1;
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToCounterFile}"))
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
            {
                using (StreamWriter sw = new StreamWriter($"{configPath}\\{pathToSwitchColor}"))
                {
                    sw.Write(0);
                }
                panel2.BackColor = Color.FromArgb(20,20,20);
                label1.ForeColor = Color.FromArgb(255,102,102);
                label2.ForeColor = label1.ForeColor;
                label3.ForeColor = label1.ForeColor;
                label4.ForeColor = label1.ForeColor;
                button9.ForeColor = Color.FromArgb(255,0,0);
                button10.ForeColor = button9.ForeColor;
                button11.ForeColor = button9.ForeColor;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                using (StreamWriter sw = new StreamWriter($"{configPath}\\{pathToSwitchColor}"))
                {
                    sw.Write(1);
                }
                panel2.BackColor = Color.FromArgb(200, 200, 200);
                label1.ForeColor = Color.FromArgb(0,0,0);
                label2.ForeColor = label1.ForeColor;
                label3.ForeColor = label1.ForeColor;
                label4.ForeColor = label1.ForeColor;
                button9.ForeColor = Color.FromArgb(0,0,0);
                button10.ForeColor = button9.ForeColor;
                button11.ForeColor = button9.ForeColor;
            }
        }
        //------------------------------------------------------------
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(30,30,30);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Transparent;
        }

        //------------------------------------------------------------
        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(30, 30, 30);
        }
        //------------------------------------------------------------

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel5.Size = new Size(475, 361);
            panel5.Location = new Point(196, 50);
            panel5.Visible = true;

        }
        //------------------------------------------------------------

        private void button17_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
        }
        //------------------------------------------------------------

        private void button8_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel1.Size = new Size(475, 361);
            panel1.Location = new Point(196, 50);
            panel1.Visible = true;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.Transparent;
        }

        //------------------------------------------------------------
        private void SettingsWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                ctrl = true;
            else if (e.KeyCode == Keys.N)
                n = true;
            else if (e.KeyCode == Keys.M)
                m = true;
            else if (e.KeyCode == Keys.Q)
                q = true;
            //------------------------------
            if (ctrl && q)
            {
                ctrl = false;
                q = false;
                Hide();
            }

        }
        private void SettingsWindow_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.ControlKey)
                ctrl = false;
            else if (e.KeyCode == Keys.N)
                n = false;
            else if (e.KeyCode == Keys.M)
                m = false;
            else if (e.KeyCode == Keys.Q)
                q = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strCounterIndex = "", str = "", strArrays = "";
            string[] strArray1, strArray2;
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToCounterFile}"))
                strCounterIndex = sr.ReadToEnd();
            counterIndex = Convert.ToSByte(strCounterIndex);
            if (counterIndex < counterParIndex)
            {
                counterIndex++;

                using (StreamReader sr = new StreamReader($@"{configPath}\{pathToValueParameters}"))
                    str = sr.ReadToEnd();
                strArray1 = str.Split('\n');
                strArrays = strArray1[counterIndex];
                strArray2 = strArrays.Split(',');
                label7.Text = $"X: {strArray2[0]}\nY: {strArray2[1]}";

                using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToCounterFile}"))
                    sw.Write(counterIndex);
            }

            if (counterIndex == counterParIndex)
            {
                counterIndex = (sbyte)counterParIndex;

                using (StreamReader sr = new StreamReader($@"{configPath}\{pathToValueParameters}"))
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
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToCounterFile}"))
                strCounterIndex = sr.ReadToEnd();
            counterIndex = Convert.ToSByte(strCounterIndex);
            if (counterIndex > 0)
                counterIndex--;
            if(counterIndex == 0)
                using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToCounterFile}"))
                    sw.Write(0);

            using (StreamReader sr = new StreamReader($@"{configPath}\{pathToValueParameters}"))
                str = sr.ReadToEnd();
            strArray1 = str.Split('\n');
            strArrays = strArray1[counterIndex];
            strArray2 = strArrays.Split(',');
            label7.Text = $"X: {strArray2[0]}\nY: {strArray2[1]}";

            using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToCounterFile}"))
                sw.Write(counterIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cmd($@"{configPath}\{pathToApplySettingFile}");
        }
    }
}
