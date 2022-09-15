using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_English_Words
{
    public partial class AddNewWord : Form
    {
        // Поля
        Size screenSize = Screen.PrimaryScreen.Bounds.Size;
        string path = "",
            configPath = "C:\\WordMem\\Config",
            pathToDocuments = "PathForDocument.dfp",
            pathToFileWords = "English words.mw",
            pathToFileTranslate = "Translate.mw",
            pathToSizeFile = "Number of the words.mw",
            pathToCorecctAnswerFile = "Counter of correct answer.mw",
            pathToSwitchColor = "Switch Color.ss";

        string strWord = "", strTranslate = "";
        private int IDWords = 0, G = 0;
        
        public AddNewWord()
        {
            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            MainWindowLocation();
            ThemeSettings();
            GetPath();
            SetIDWord();
        }

        private void ThemeSettings()
        {
            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToSwitchColor}"))
            {
                G = Convert.ToSByte(sr.ReadToEnd());
            }
            switch (G)
            {
                case 0:
                    BackColor = Color.FromArgb(20,20,20);
                    panel1.BackColor = Color.FromArgb(5,5,5);
                    panel2.BackColor = Color.FromArgb(15,15,15);
                    textBox1.BackColor = panel2.BackColor;
                    textBox2.BackColor = panel2.BackColor;
                    //----------
                    label5.ForeColor = Color.FromArgb(255,102,102);
                    label1.ForeColor = label5.ForeColor;
                    label2.ForeColor = label5.ForeColor;
                    textBox1.ForeColor = label2.ForeColor;
                    textBox2.ForeColor = label2.ForeColor;
                    button1.ForeColor = Color.FromArgb(255,0,0);
                    button2.ForeColor = button1.ForeColor;
                    break;
                case 1:
                    BackColor = Color.FromArgb(200, 200, 200);
                    panel1.BackColor = Color.FromArgb(255,255,255);
                    panel2.BackColor = Color.FromArgb(150, 150, 150);
                    textBox1.BackColor = panel2.BackColor;
                    textBox2.BackColor = panel2.BackColor;
                    //----------
                    label5.ForeColor = Color.FromArgb(0,0,0);
                    label1.ForeColor = label5.ForeColor;
                    label2.ForeColor = label5.ForeColor;
                    textBox1.ForeColor = label2.ForeColor;
                    textBox2.ForeColor = label2.ForeColor;
                    button1.ForeColor = Color.FromArgb(0, 0, 0);
                    button2.ForeColor = button1.ForeColor;
                    break;
            }
        }

        private void GetPath()
        {
            string pathSTR = "";
            string[] pathSTRArray;

            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToDocuments}"))
                pathSTR = sr.ReadToEnd();
            path = pathSTR;
        }

        private void MainWindowLocation()
        {
            Location = new Point((screenSize.Width/2)-(Size.Width/2),
                (screenSize.Height/2)-(Size.Height/2));
        }
        // Кнопка приховування вікна налаштування
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            await Task.Run(() =>
            {
                if (e.KeyValue == (char)Keys.D1 || e.KeyValue == (char)Keys.D2 ||
    e.KeyValue == (char)Keys.D3 || e.KeyValue == (char)Keys.D4 ||
    e.KeyValue == (char)Keys.D5 || e.KeyValue == (char)Keys.D6 ||
    e.KeyValue == (char)Keys.D7 || e.KeyValue == (char)Keys.D8 ||
    e.KeyValue == (char)Keys.D9 || e.KeyValue == (char)Keys.D0 ||
    e.KeyValue == (char)Keys.NumPad1 || e.KeyValue == (char)Keys.NumPad2 ||
    e.KeyValue == (char)Keys.NumPad3 || e.KeyValue == (char)Keys.NumPad4 ||
    e.KeyValue == (char)Keys.NumPad5 || e.KeyValue == (char)Keys.NumPad6 ||
    e.KeyValue == (char)Keys.NumPad7 || e.KeyValue == (char)Keys.NumPad8 ||
    e.KeyValue == (char)Keys.NumPad9 || e.KeyValue == (char)Keys.NumPad0)
                {
                    MessageBox.Show(
                        "You used a numeric character!", 
                        "Warning", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            });
        }

        async void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            await Task.Run(() =>
            {
                if (e.KeyValue == (char)Keys.D1 || e.KeyValue == (char)Keys.D2 ||
    e.KeyValue == (char)Keys.D3 || e.KeyValue == (char)Keys.D4 ||
    e.KeyValue == (char)Keys.D5 || e.KeyValue == (char)Keys.D6 ||
    e.KeyValue == (char)Keys.D7 || e.KeyValue == (char)Keys.D8 ||
    e.KeyValue == (char)Keys.D9 || e.KeyValue == (char)Keys.D0 ||
    e.KeyValue == (char)Keys.NumPad1 || e.KeyValue == (char)Keys.NumPad2 ||
    e.KeyValue == (char)Keys.NumPad3 || e.KeyValue == (char)Keys.NumPad4 ||
    e.KeyValue == (char)Keys.NumPad5 || e.KeyValue == (char)Keys.NumPad6 ||
    e.KeyValue == (char)Keys.NumPad7 || e.KeyValue == (char)Keys.NumPad8 ||
    e.KeyValue == (char)Keys.NumPad9 || e.KeyValue == (char)Keys.NumPad0)
                {
                    MessageBox.Show(
                        "You used a numeric character!",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            });
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            label3.Text = "";
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            label3.Text = "";
        }

        private void AddNewWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Hide();
        }


        // Метод встановлення кількості англійських слів у файлі
        private void SetIDWord()
        {
            using (StreamReader sr = new StreamReader($@"{path}\{pathToSizeFile}"))
                IDWords = Convert.ToInt32(sr.ReadLine());
        }
        // Кнопка запису слів та перекладу
        private void button2_Click(object sender, EventArgs e)
        {
            WriteWordsAndTranslate();
            label3.Font = new Font("Microsoft Sans Serif", 
                20.25F, FontStyle.Bold, 
                GraphicsUnit.Point, ((byte)(204)));
            label3.Text = "saved";
            label3.ForeColor = Color.LimeGreen;
            textBox1.Text = "";
            textBox2.Text = "";
        }
        // Метод створення файлу та запис кількості англійських слів 
        public void SaveNumberOfSize()
        {
            using (StreamWriter sw = new StreamWriter($@"{path}\{pathToSizeFile}"))
                sw.Write(IDWords);
        }
        // Метод запису нового слова та перекладу у файли
        // та збільшення числа слів на один
        public void WriteWordsAndTranslate()
        {
            strWord = textBox1.Text.ToLower();
            strTranslate = textBox2.Text.ToLower();

            string[] strWordArray = strWord.Split(' ');
            string[] strTranslateArray = strTranslate.Split(' ');

            using (StreamWriter sw1 = new StreamWriter($@"{path}\{pathToFileWords}", true))
                for (int i = 0; i < strWordArray.Length; i++)
                {
                    sw1.Write($"\n{strWordArray[i]}");
                    IDWords++;
                }
            using (StreamWriter sw2 = new StreamWriter($@"{path}\{pathToFileTranslate}", true))
                for (int i = 0; i < strTranslateArray.Length; i++)
                    sw2.Write($"\n{strTranslateArray[i]}");
            using (StreamWriter sw3 = new StreamWriter($@"{path}\{pathToCorecctAnswerFile}", true))
                for (int i = 0; i < strWordArray.Length; i++)
                    sw3.Write($"\n{0}");
            SaveNumberOfSize();
        }
    }

}