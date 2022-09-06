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
            //--------------------------------------------------------------
            pathToFileWords = "English words.mw",
            pathToFileTranslate = "Translate.mw",
            pathToCorecctAnswerFile = "Counter of correct answer.mw",
            pathToRandomAsnwer = "Random answer.mw",
            pathToSwitchIndex = "Switch index.mw",
            //pathToConfigFile = "Config.cfg",
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
            panel1.Size = new Size(771, 361);
            panel1.Location = new Point(196, 50);
            Location = new Point((screenSize.Width/2)-(Size.Width/2), (screenSize.Height/2)-(Size.Height/2));
            GetParameters();
            comboBox1.SelectedIndex = 0;
            textBox1.Text = defaultPath+"\\";
        }

        private void GetPath()
        {
            string pathSTR = "";
            string[] pathSTRArray;

            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToDocuments}"))
                pathSTR = sr.ReadToEnd();
            pathSTRArray = pathSTR.Split('\n');
            defaultPath = pathSTRArray[1];
        }

        private void GetParameters()
        {
            string str = "", strArrays = "";
            string[] strArray1, strArray2;
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToValueParameters}"))
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
            if (comboBox1.SelectedIndex == 0) {
                panel2.BackColor = Color.FromArgb(20, 20, 20);
                label1.ForeColor = Color.FromArgb(255, 102, 102);
                label2.ForeColor = Color.FromArgb(255, 102, 102);
                label3.ForeColor = Color.FromArgb(255, 102, 102);
                label4.ForeColor = Color.FromArgb(255, 102, 102);
                button9.ForeColor = Color.FromArgb(255, 0, 0);
                button10.ForeColor = Color.FromArgb(255, 0, 0);
                button11.ForeColor = Color.FromArgb(255, 0, 0);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                panel2.BackColor = Color.FromArgb(255,255,255);
                label1.ForeColor = Color.FromArgb(0,0,0);
                label2.ForeColor = Color.FromArgb(0,0,0);
                label3.ForeColor = Color.FromArgb(0,0,0);
                label4.ForeColor = Color.FromArgb(0,0,0);
                button9.ForeColor = Color.FromArgb(0, 0, 255);
                button10.ForeColor = Color.FromArgb(0, 0, 255);
                button11.ForeColor = Color.FromArgb(0, 0, 255);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                panel2.BackColor = Color.FromArgb(224, 150, 246);
                label1.ForeColor = Color.FromArgb(255, 0, 0);
                label2.ForeColor = Color.FromArgb(255, 0, 0);
                label3.ForeColor = Color.FromArgb(255, 0, 0);
                label4.ForeColor = Color.FromArgb(255, 0, 0);
                button9.ForeColor = Color.FromArgb(255, 51, 255);
                button10.ForeColor = Color.FromArgb(255, 51, 255);
                button11.ForeColor = Color.FromArgb(255, 51, 255);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                panel2.BackColor = Color.FromArgb(153,255,153);
                label1.ForeColor = Color.FromArgb(0, 0, 255);
                label2.ForeColor = Color.FromArgb(0, 0, 255);
                label3.ForeColor = Color.FromArgb(0, 0, 255);
                label4.ForeColor = Color.FromArgb(0, 0, 255);
                button9.ForeColor = Color.FromArgb(153, 0, 153);
                button10.ForeColor = Color.FromArgb(153, 0, 153);
                button11.ForeColor = Color.FromArgb(153, 0, 153);
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
            panel5.Visible = true;
        }
        //------------------------------------------------------------

        private void button17_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
        }
        //------------------------------------------------------------
        
        private void button18_Click(object sender, EventArgs e)
        {// ?????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????
         // видалити кнопку збереження шляху

            string pathSTR1 = "";
            string[] pathSTRArray1;

            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToDocuments}"))
                pathSTR1 = sr.ReadToEnd();
            pathSTRArray1 = pathSTR1.Split('\n');
            pathSTRArray1[0] = defaultPath;
            pathSTRArray1[1] = textBox1.Text;

           
            using (StreamWriter sw18 = new StreamWriter($"{configPath}\\{pathToDocuments}"))
                for (int i = 0; i < pathSTRArray1.Length; i++)
                {
                    if (i == 0)
                        sw18.Write(pathSTRArray1[i]);
                    else
                        sw18.Write($"\n{pathSTRArray1[i]}");
                }
        }
        //------------------------------------------------------------

        private void button8_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
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
            if(ctrl && n)
                label12.Text = "ctrl + n";
            if (ctrl && m)
                label12.Text = "ctrl + m";
            else if (e.KeyCode == Keys.Escape)
                Hide();

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

                using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToValueParameters}"))
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

                using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToValueParameters}"))
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

            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToValueParameters}"))
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
            //Cmd($@"{Path.GetFullPath(pathToApplySettingFile)}"); // ??????????????????????????????????????
            Cmd($@"{configPath}\{pathToApplySettingFile}"); // ??????????????????????????????????????
        }
    }
}
