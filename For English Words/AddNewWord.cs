using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_English_Words
{
    public partial class AddNewWord : Form
    {
        // Поля
        Size screenSize = Screen.PrimaryScreen.Bounds.Size;
        string defaultPath = "C:\\WordMem\\Data",
            configPath = "C:\\WordMem\\Config",
            pathToFileWords = "English words.mw",
            pathToFileTranslate = "Translate.mw",
            pathToSizeFile = "Number of the words.mw",
            pathToCorecctAnswerFile = "Counter of correct answer.mw",
            pathToSwitchColor = "Switch Color.ss";
        //---------------------------------------------------------------------------------------------------------------------------------------------
        int j = 0;
        byte g = 0, q = 0;
        string str = "";
        string[] strings, stringsMainWord;
        //---------------------------------------------------------------------------------------------------------------------------------------------
        string strWord = "", strTranslate = "";
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private int IDWords = 0, G = 0;
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public AddNewWord()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void Settings_Load(object sender, EventArgs e)
        {
            MainWindowLocation();
            ThemeSettings();
            SetIDWord();
            label3.Visible = false;
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
        private void ThemeSettings()
        {
            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToSwitchColor}"))
                G = Convert.ToSByte(sr.ReadToEnd());
            switch (G)
            {
                case 0:
                    BackColor = Color.FromArgb(20, 20, 20);
                    panel1.BackColor = Color.FromArgb(5, 5, 5);
                    panel2.BackColor = Color.FromArgb(15, 15, 15);
                    textBox1.BackColor = panel2.BackColor;
                    textBox2.BackColor = panel2.BackColor;
                    //----------
                    label5.ForeColor = Color.FromArgb(255, 102, 102);
                    label1.ForeColor = label5.ForeColor;
                    label2.ForeColor = label5.ForeColor;
                    textBox1.ForeColor = label2.ForeColor;
                    textBox2.ForeColor = label2.ForeColor;
                    button1.ForeColor = Color.FromArgb(255, 0, 0);
                    button2.ForeColor = button1.ForeColor;
                    break;
                case 1:
                    BackColor = Color.FromArgb(200, 200, 200);
                    panel1.BackColor = Color.FromArgb(255, 255, 255);
                    panel2.BackColor = Color.FromArgb(150, 150, 150);
                    textBox1.BackColor = panel2.BackColor;
                    textBox2.BackColor = panel2.BackColor;
                    //----------
                    label5.ForeColor = Color.FromArgb(0, 0, 0);
                    label1.ForeColor = label5.ForeColor;
                    label2.ForeColor = label5.ForeColor;
                    textBox1.ForeColor = label2.ForeColor;
                    textBox2.ForeColor = label2.ForeColor;
                    button1.ForeColor = Color.FromArgb(0, 0, 0);
                    button2.ForeColor = button1.ForeColor;
                    break;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void MainWindowLocation()
        {
            Location = new Point((screenSize.Width/2)-(Size.Width/2),
                (screenSize.Height/2)-(Size.Height/2));
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Кнопка приховування вікна налаштування
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AddNewWord_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
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
                    MessageBox.Show("Ви вписали цифру", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
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
                    MessageBox.Show("Ви вписали цифру", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            label3.Visible = false;
            
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            label3.Visible = false;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод встановлення кількості англійських слів у файлі
        private void SetIDWord()
        {
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToSizeFile}"))
                IDWords = Convert.ToInt32(sr.ReadLine());
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Кнопка запису слів та перекладу
        private void button2_Click(object sender, EventArgs e)
        {
            WriteWordsAndTranslate();
            label3.Font = new Font("Microsoft Sans Serif",
                20.25F, FontStyle.Bold,
                GraphicsUnit.Point, ((byte)(204)));
            label3.Visible = true;
            label3.ForeColor = Color.LimeGreen;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод створення файлу та запис кількості англійських слів 
        public void SaveNumberOfSize()
        {
            using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToSizeFile}"))
                sw.Write(IDWords);
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод запису нового слова та перекладу у файли
        // та збільшення числа слів на один
        public void WriteWordsAndTranslate()
        {
            if (textBox1.Text[0] == ' ')
            {
                MessageBox.Show(
                    "На початку першого поля стоїть пробіл",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (textBox2.Text[0] == ' ')
            {
                MessageBox.Show(
                    "На початку другого поля стоїть пробіл",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (textBox1.Text[textBox1.Text.Length-1] == ' ')
            {
                MessageBox.Show(
                    "В кінці першого поля стоїть пробіл",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (textBox2.Text[textBox2.Text.Length-1] == ' ')
            {
                MessageBox.Show(
                    "В кінці другого поля стоїть пробіл",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                string[] strings3, strings4;
                using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToFileWords}"))
                    stringsMainWord = sr.ReadToEnd().Split('\n');
                // перетворення введеного списку слів у масив
                strings3 = textBox1.Text.ToLower().Split(' ');
                strings4 = textBox2.Text.ToLower().Split(' ');
                // перевірка на наявність повторення та запис номеру позиції
                for (int i = 0; i < strings3.Length; i++)
                {
                    for (int f = 0; f < stringsMainWord.Length; f++)
                    {
                        if (strings3[i] == stringsMainWord[f])
                        {
                            if (q == 0)
                            {
                                // запис номеру позиції у простий рядок
                                str = i.ToString();
                                q = 1;
                            }
                            else
                                str += $" {i}";
                        }
                    }
                }
                // перетворення простого рядка у масив
                strings = str.Split(' ');
                // видалення слів які повторюються у списках
                for (int i = 0; i < strings3.Length; i++)
                {
                    if (q != 0)
                    {
                        if (j != strings.Length)
                        {
                            if (i == Convert.ToInt32(strings[j]))
                            {
                                j++;
                                continue;
                            }
                            else
                            {
                                if (g == 0)
                                {
                                    g = 1;
                                    textBox1.Text = strings3[i];
                                }
                                else
                                    textBox1.Text += $" {strings3[i]}";
                            }
                        }
                        else
                        {
                            if (g == 0)
                            {
                                g = 1;
                                textBox1.Text = strings3[i];
                            }
                            else
                                textBox1.Text += $" {strings3[i]}";
                        }
                    }
                    if(q == 0)
                    {
                        if (g == 0)
                        {
                            g = 1;
                            textBox1.Text = strings3[i];
                        }
                        else
                            textBox1.Text += $" {strings3[i]}";
                    }
                }
                string[] sArray = textBox1.Text.Split(' ');
                for (int i = 0; i < sArray.Length; i++)
                {
                    IDWords++;
                }
                using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToFileWords}", true))
                    for (int i = 0; i < sArray.Length; i++)
                        sw.Write($"\n{sArray[i]}");
                // Зробити запис підрахування кількості слів
                //------------------------------
                j = 0;
                g = 0;
                for (int i = 0; i < strings4.Length; i++)
                {
                    if (q != 0)
                    {
                        if (j != strings.Length)
                        {
                            if (i == Convert.ToInt32(strings[j]))
                            {
                                j++;
                                continue;
                            }
                            else
                            {
                                if (g == 0)
                                {
                                    g = 1;
                                    textBox2.Text = strings4[i];
                                }
                                else
                                    textBox2.Text += $" {strings4[i]}";
                            }
                        }
                        else
                        {
                            if (g == 0)
                            {
                                g = 1;
                                textBox2.Text = strings4[i];
                            }
                            else
                                textBox2.Text += $" {strings4[i]}";
                        }
                    }
                    if (q == 0)
                    {
                        if (g == 0)
                        {
                            g = 1;
                            textBox2.Text = strings4[i];
                        }
                        else
                            textBox2.Text += $" {strings4[i]}";
                    }
                }
                string[] sArray2 = textBox2.Text.Split(' ');
                using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToFileTranslate}", true))
                    for (int i = 0; i < sArray2.Length; i++)
                        sw.Write($"\n{sArray2[i]}");

                using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToCorecctAnswerFile}", true))
                    for (int i = 0; i < sArray.Length; i++)
                        sw.Write($"\n{0}");
                SaveNumberOfSize();
                label3.Text = "Збережено";
            }
        }
    }
}