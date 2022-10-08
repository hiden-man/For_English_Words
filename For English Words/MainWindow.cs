using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace For_English_Words
{
    public partial class MainWindow : Form
    {
        // Поля
        Size screenSize = Screen.PrimaryScreen.Bounds.Size;
        Random random = new Random();
        AddNewWord AddNewWordWindow = new AddNewWord();
        SettingsWindow settingsWindow = new SettingsWindow();
        SettingsClass settingsClass = new SettingsClass();
        CreaterSomeFiles csf;
        //---------------------------------------------------------------------------------------------------------------------------------------------
        string defaultPath = "C:\\WordMem\\Data",
            configPath = "C:\\WordMem\\Config",
            pathToFileWords = "English words.mw",
            pathToFileTranslate = "Translate.mw",
            pathToCorecctAnswerFile = "Counter of correct answer.mw",
            pathToRandomAsnwer = "Random answer.mw",
            pathToSwitchIndex = "Switch index.mw",
            pathToValueParameters = "Value of size window parameters.par",
            pathToValueParameters2 = "Value of font main text parameters.par",
            pathToValueParameters3 = "Value of font answer text parameters.par",
            pathToValueParameters4 = "Value of font button text parameters.par",
            pathToValueParameters5 = "Value of size textBox parameters.par",
            pathToValueParameters6 = "Value of size button parameters.par",
            pathToValueParameters7 = "Value of size correct answer picture parameters.par",
            pathToCounterFile = "Case index.ci",
            pathToCounterFile2 = "Index for switch.ci",
            pathToApplySettingFile = "Apply.bat",
            pathToSizeFile = "Number of the words.mw",
            pathLocationMF = "Switch_location.sl",
            pathLocationInfo = "Location_Info.li",
            pathToPathToRegistry = "Path For Registry.pr",
            pathToSwitchColor = "Switch Color.ss";
        //---------------------------------------------------------------------------------------------------------------------------------------------
        string[] defaultWords = {
            "white","black","orange","blue","green","red","brown","gray","pink","yellow","magenta","purple",
            "maroon","advice","agree","urgently","continue","meet","rarely","colleagues","classmate","neighbors",
            "husband","wife","get","expensive","perfectly","better","mistakes","effectively","take","useful",
            "workers","offer","ticket","mean","explain","speak","spend","strange","grow","garden","suppliers",
            "situation","answer","clients","hate","swim","promise","refuse"},
            defaultTranslate = {
            "білий","чорний","помаранчевий","блакитний","зелений","червоний","коричневий","сірий","рожевий",
            "жовтий","пурпурний","фіолетовий","бордовий","порада","згоден","терміново","продовжити","зустріч",
            "рідко","колеги","однокласник","сусіди","чоловік","дружина","отримувати","дорого","прекрасно",
            "краще","помилки","ефективно","брати","корисно","робітники","пропозиція","білет","означати",
            "пояснювати","говорити","проводити","дивний","вирощувати","сад","постачальники","ситуація","відповідь",
            "кліенти","ненавидіти","плавати","обіцяти","відмова"};
        //---------------------------------------------------------------------------------------------------------------------------------------------
        uint fontS = 14, fontSB = 8, fontSRButton = 8;
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private int
            IDWords = 0, IDTranslate = 0, randomIDWord = 0,
            correctItem = 0, randomChoise = 0, x = 440, y = 81,
            indexParam = 0, numberOfIter = 0, xB = 70, yB = 22,
            sizeTextBoxX = 229, sizePicture = 15, switchIndexCor = 0;
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Проценти
        private const byte 
            perCentS = 20, perCentST = 30, 
            perCentSB = 20, perCentSRB = 31,
            perCentSTextBox = 19;
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDirectoryAndFiles();
            SwitcherLocationMainForm();
            MySettings();
            RecountTheNumberOfWords();
            Repetition();
            button1.Location = new Point(Size.Width - button1.Size.Width,0);
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // МЕТОДИ !!!!!
        // Метод Оновлення
        private void Repetition()
        {
            SetIDWord();
            OutputRandomWord();
            OutputAnswer();
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
        //---------------------------------------------------------------------------------------------------------
        // Метод створення директорії та неохідних файлів
        private void CreateDirectoryAndFiles()
        {
            // Перевірка на навність необхідних файлів
            if (!Directory.Exists(configPath))
            {
                Directory.CreateDirectory(configPath);
                Directory.CreateDirectory(defaultPath);
            }
            //-------------------------------------------------------------------------------------
            csf = new CreaterSomeFiles(configPath, pathToPathToRegistry, Path.GetFullPath("For English Words.exe"));
            csf = new CreaterSomeFiles(configPath, pathLocationInfo, "0", 1);
            csf = new CreaterSomeFiles(configPath, pathLocationMF, "0");
            csf = new CreaterSomeFiles(defaultPath, pathToSwitchIndex, "0");
            csf = new CreaterSomeFiles(configPath, pathToCounterFile, "0");
            csf = new CreaterSomeFiles(defaultPath, pathToRandomAsnwer);
            csf = new CreaterSomeFiles(defaultPath, pathToCounterFile2, "2");
            csf = new CreaterSomeFiles(configPath, pathToSwitchColor, "0");
            //-------------------------------------------------------------------------------------
            // Створення файла для слів
            if (!File.Exists($@"{defaultPath}\{pathToFileWords}"))
            {
                using (StreamWriter sw1 = new StreamWriter($@"{defaultPath}\{pathToFileWords}"))
                    // запис дефолтних слів
                    foreach (string words in defaultWords)
                    {
                        if (IDWords == 0)
                            sw1.Write($"{words.ToLower()}");
                        else
                            sw1.Write($"\n{words.ToLower()}");
                        IDWords++;
                    }
            }
            //-------------------------------------------------------------------------------------
            // Створення файла для перекладу
            if (!File.Exists($@"{defaultPath}\{pathToFileTranslate}"))
            {
                using (StreamWriter sw2 = new StreamWriter($@"{defaultPath}\{pathToFileTranslate}"))
                    // запис дефолтних перекладів
                    foreach (string translate in defaultTranslate)
                    {
                        if (IDTranslate == 0)
                            sw2.Write($"{translate.ToLower()}");
                        else
                            sw2.Write($"\n{translate.ToLower()}");
                        IDTranslate++;
                    }
            }
            //-------------------------------------------------------------------------------------
            // Створення файла для вірних відповідей
            if (!File.Exists($@"{defaultPath}\{pathToCorecctAnswerFile}"))
            {
                using (StreamWriter sw3 = new StreamWriter($@"{defaultPath}\{pathToCorecctAnswerFile}"))
                    // нумерація комірок
                    for (int i = 0; i < IDWords; i++)
                        if (i == 0)
                            sw3.Write(correctItem);
                        else
                            sw3.Write($"\n{correctItem}");
            }
            //-------------------------------------------------------------------------------------
            // Створення файлів для параметрів
            if (!File.Exists($@"{configPath}\{pathToValueParameters}"))
            {
                using (StreamWriter sw6 = new StreamWriter($@"{configPath}\{pathToValueParameters}"))
                {
                    bool boolerCheck = true;
                    for (int i = 0; boolerCheck;)
                    {
                        // 440 * 20 / 100 + 440 = 528

                        int tempXY = x * perCentS / 100 + x;
                        if (tempXY < screenSize.Width)
                        {
                            if (i == 0)
                                sw6.Write($"{x},{y}");
                            else
                            {
                                x = x * perCentS / 100 + x;
                                y = y * perCentS / 100 + y;
                                sw6.Write($"\n{x},{y}");
                            }
                            i++;
                        }
                        if (tempXY == screenSize.Width || tempXY > screenSize.Width)
                        {
                            boolerCheck = false;
                        }
                        numberOfIter = i;
                    }
                }
            }
            //-------------------------------------------------------------------------------------
            if (!File.Exists($@"{configPath}\{pathToValueParameters2}"))
            {
                using (StreamWriter sw = new StreamWriter($@"{configPath}\{pathToValueParameters2}"))
                {
                    for (int i = 0; i < numberOfIter; i++)
                    {
                        if (i == 0)
                        {
                            sw.Write($"{fontS}");
                        }
                        else
                        {
                            fontS = fontS * perCentST / 100 + fontS;
                            sw.Write($"\n{fontS}");
                        }
                    }
                }
            }
            //-------------------------------------------------------------------------------------
            if (!File.Exists($@"{configPath}\{pathToValueParameters3}"))
            {
                using (StreamWriter sw = new StreamWriter($@"{configPath}\{pathToValueParameters3}"))
                {
                    for (int i = 0; i < numberOfIter; i++)
                    {
                        if (i == 0)
                        {
                            sw.Write(fontSRButton);
                        }
                        else
                        {
                            fontSRButton = fontSRButton * perCentSRB / 100 + fontSRButton;
                            sw.Write($"\n{fontSRButton}");
                        }
                    }
                }
            }
            //-------------------------------------------------------------------------------------
            if (!File.Exists($@"{configPath}\{pathToValueParameters4}"))
            {
                using (StreamWriter sw = new StreamWriter($@"{configPath}\{pathToValueParameters4}"))
                {
                    for (int i = 0; i < numberOfIter; i++)
                    {
                        if (i == 0)
                        {
                            sw.Write(fontSB);
                        }
                        else
                        {
                            fontSB = fontSB * perCentSB / 100 + fontSB;
                            sw.Write($"\n{fontSB}");
                        }
                    }
                }
            }
            //-------------------------------------------------------------------------------------
            if (!File.Exists($@"{configPath}\{pathToValueParameters5}"))
            {
                using (StreamWriter sw = new StreamWriter($@"{configPath}\{pathToValueParameters5}"))
                {
                    for (int i = 0; i < numberOfIter; i++)
                    {
                        if (i == 0)
                        {
                            sw.Write(sizeTextBoxX);
                        }
                        else
                        {
                            sizeTextBoxX = sizeTextBoxX * perCentSTextBox / 100 + sizeTextBoxX;
                            sw.Write($"\n{sizeTextBoxX}");
                        }
                    }
                }
            }
            //-------------------------------------------------------------------------------------
            if (!File.Exists($@"{configPath}\{pathToValueParameters6}"))
            {
                using (StreamWriter sw = new StreamWriter($@"{configPath}\{pathToValueParameters6}"))
                {
                    for (int i = 0; i < numberOfIter; i++)
                    {
                        if (i == 0)
                        {
                            sw.Write($"{xB},{yB}");
                        }
                        else
                        {
                            xB = xB * perCentSB / 100 + xB;
                            yB = yB * perCentSB / 100 + yB;
                            sw.Write($"\n{xB},{yB}");
                        }
                    }
                }
            }
            //-------------------------------------------------------------------------------------
            if (!File.Exists($@"{configPath}\{pathToValueParameters7}"))
            {
                using (StreamWriter sw = new StreamWriter($@"{configPath}\{pathToValueParameters7}"))
                {
                    for (int i = 0; i < numberOfIter; i++)
                    {
                        if (i == 0)
                        {
                            sw.Write($"{sizePicture}");
                        }
                        else
                        {
                            sizePicture = sizePicture + 5;
                            sw.Write($"\n{sizePicture}");
                        }
                    }
                }
            }
            //-------------------------------------------------------------------------------------
            if (!File.Exists($"{configPath}\\{pathToApplySettingFile}"))
            {
                string str = Path.GetFullPath("For English Words.exe");
                using (StreamWriter sw = new StreamWriter($"{configPath}\\{pathToApplySettingFile}"))
                {
                    sw.Write($@"taskkill /IM ""For English Words.exe"" /F
start """" ""{str}""");
                }
            }
            //-------------------------------------------------------------------------------------
            // Запис кількості слів у текстовий файл
            if (!File.Exists($@"{defaultPath}\{pathToSizeFile}"))
            {
                SaveNumberOfSize();
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void SwitcherLocationMainForm()
        {
            switch (settingsClass.SwitcherLocationMainForm())
            {
                case 0:
                    Location = new Point((screenSize.Width / 2) - (Size.Width / 2), 0);
                    break;

                case 1:
                    Location = new Point(0, 0);
                    break;
                case 2:
                    Location = new Point(screenSize.Width - Size.Width, 0);
                    break;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод налаштувань
        private void MySettings()
        {
            string strParam = "", strParam2 = "";
            string[] strParamArray, strIndexParamArray;
            using (StreamReader streamR = new StreamReader($@"{configPath}\{pathToValueParameters}"))
                strParam = streamR.ReadToEnd();
            strParamArray = strParam.Split('\n');
            using (StreamReader streamR1 = new StreamReader($@"{configPath}\{pathToCounterFile}"))
                indexParam = Convert.ToInt32(streamR1.ReadToEnd());
            strParam2 = strParamArray[indexParam];
            strIndexParamArray = strParam2.Split(',');
            x = Convert.ToInt32(strIndexParamArray[0]);
            y = Convert.ToInt32(strIndexParamArray[1]);
            string strParamMainText = "";
            string[] strParamMainTextArray;

            using (StreamReader sr2 = new StreamReader($@"{configPath}\{pathToValueParameters2}"))
                strParamMainText = sr2.ReadToEnd();
            strParamMainTextArray = strParamMainText.Split('\n');
            fontS = Convert.ToUInt32(strParamMainTextArray[indexParam]);
            string strParamTextBoxX = "";
            string[] strParamTextBoxXArray;

            using (StreamReader sr3 = new StreamReader($@"{configPath}\{pathToValueParameters5}"))
                strParamTextBoxX = sr3.ReadToEnd();
            strParamTextBoxXArray = strParamTextBoxX.Split('\n');
            sizeTextBoxX = Convert.ToInt32(strParamTextBoxXArray[indexParam]);
            string strParamSRB = "";
            string[] strParamSRBArray;
            using (StreamReader sr4 = new StreamReader($@"{configPath}\{pathToValueParameters3}"))
                strParamSRB = sr4.ReadToEnd();
            strParamSRBArray = strParamSRB.Split('\n');
            fontSRButton = Convert.ToUInt32(strParamSRBArray[indexParam]);
            string strParamSB = "";
            string[] strParamSBArray;
            using (StreamReader sr5 = new StreamReader($@"{configPath}\{pathToValueParameters4}"))
                strParamSB = sr5.ReadToEnd();
            strParamSBArray = strParamSB.Split('\n');
            fontSB = Convert.ToUInt32(strParamSBArray[indexParam]);
            string strParamSB2 = "";// strParamSB2 = "";
            string[] strParamSBArray2; //strParamSBArray2;
            using (StreamReader sr5 = new StreamReader($@"{configPath}\{pathToValueParameters6}"))
                strParamSB = sr5.ReadToEnd();
            strParamSBArray = strParamSB.Split('\n');
            strParamSB2 = strParamSBArray[indexParam];
            strParamSBArray2 = strParamSB2.Split(',');
            xB = Convert.ToInt32(strParamSBArray2[0]);
            yB = Convert.ToInt32(strParamSBArray2[1]);
            string strParamSP = "";
            string[] strParamSPArray;
            using (StreamReader sr6 = new StreamReader($@"{configPath}\{pathToValueParameters7}"))
                strParamSP = sr6.ReadToEnd();
            strParamSPArray = strParamSP.Split('\n');
            sizePicture = Convert.ToInt32(strParamSPArray[indexParam]);
            Size = new Size(x, y);
            textBox1.Font = new Font("Microsoft Sans Serif", fontS, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Size = new Size(sizeTextBoxX, textBox1.Size.Height);
            pictureBox1.Size = new Size(sizePicture, sizePicture);
            radioButton1.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton2.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton3.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Font = new Font("Microsoft Sans Serif", fontSB, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Size = new Size(xB, yB);
            button5.Font = new Font("Microsoft Sans Serif", fontSB, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Size = new Size(xB, yB);
            button6.Font = new Font("Microsoft Sans Serif", fontSB, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Size = new Size(xB, yB);
            radioButton1.Location = new Point(textBox1.Location.X + textBox1.Size.Width + pictureBox1.Size.Width + 10, 3);
            radioButton2.Location = new Point(radioButton1.Location.X, radioButton1.Location.Y + radioButton1.Size.Height + 5);
            radioButton3.Location = new Point(radioButton1.Location.X, radioButton2.Location.Y + radioButton2.Size.Height + 5);
            pictureBox1.Location = new Point();
            button6.Location = new Point(textBox1.Location.X, textBox1.Location.Y + textBox1.Size.Height + 5);
            button5.Location = new Point(button6.Location.X + button6.Size.Width + 4, button6.Location.Y);
            button4.Location = new Point(button5.Location.X + button5.Size.Width + 2, button5.Location.Y);
            SwitcherLocationMainForm();
            CountSetting();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод вибору налаштувань
        private void CountSetting()
        {
            byte numSett = 0;
            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToSwitchColor}"))
                numSett = Convert.ToByte(sr.ReadToEnd());
            switch (numSett)
            {
                case 0:
                    button2.ForeColor = Color.FromArgb(255, 0, 0);
                    button3.ForeColor = Color.FromArgb(255, 0, 0);
                    button4.ForeColor = Color.FromArgb(255, 0, 0);
                    button5.ForeColor = Color.FromArgb(255, 0, 0);
                    button6.ForeColor = Color.FromArgb(255, 0, 0);
                    button8.ForeColor = Color.FromArgb(255, 0, 0);
                    radioButton1.ForeColor = Color.FromArgb(255, 102, 102);
                    radioButton2.ForeColor = Color.FromArgb(255, 102, 102);
                    radioButton3.ForeColor = Color.FromArgb(255, 102, 102);
                    textBox1.ForeColor = Color.FromArgb(255, 102, 102);
                    BackColor = Color.FromArgb(20,20,20);
                    textBox1.BackColor = Color.FromArgb(20,20,20);
                    panel1.BackColor = Color.FromArgb(20,20,20);
                    break;
                case 1:
                    button2.ForeColor = Color.FromArgb(0,0,0);
                    button3.ForeColor = Color.FromArgb(0,0,0);
                    button4.ForeColor = Color.FromArgb(0,0,0);
                    button5.ForeColor = Color.FromArgb(0,0,0);
                    button6.ForeColor = Color.FromArgb(0,0,0);
                    button8.ForeColor = Color.FromArgb(0,0,0);
                    radioButton1.ForeColor = Color.FromArgb(0,0,0);
                    radioButton2.ForeColor = Color.FromArgb(0,0,0);
                    radioButton3.ForeColor = Color.FromArgb(0,0,0);
                    textBox1.ForeColor = Color.FromArgb(0,0,0);
                    BackColor = Color.FromArgb(200, 200, 200);
                    textBox1.BackColor = Color.FromArgb(200, 200, 200);
                    panel1.BackColor = Color.FromArgb(200, 200, 200);
                    break;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод перераховування кількості слів при повторному відкритті программи
        private void RecountTheNumberOfWords()
        {
            string strRecount = "";
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToFileWords}"))
                strRecount = sr.ReadToEnd();
            string[] strRecountArray = strRecount.Split('\n');
            for (int i = 0; i < strRecountArray.GetLength(0); i++)
                IDWords++;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод створення файлу та запис кількості англійських слів
        public void SaveNumberOfSize()
        {
            using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToSizeFile}"))
                sw.Write($"{IDWords}");
            SetIDWord();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод встановлення кількості англійських слів у файлі
        private void SetIDWord()
        {
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToSizeFile}"))
                IDWords = Convert.ToInt32(sr.ReadToEnd());
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод випадкової вибірки слова із списка 
        private void OutputRandomWord()
        {
            randomIDWord = random.Next(IDWords);
            // Рядок для запису даних із текстового файлу
            string strCorNum = "";
            // Читаємо данні з файлу
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToCorecctAnswerFile}"))
                // Записуємо дані з файлу у текстовий рядок
                strCorNum = sr.ReadToEnd();
            // перетворюємо текстовий рядок у масив
            string[] strCorNumArray = strCorNum.Split('\n');
            // цикл для проходу по всій довжині масиву
            for (int i = 0; i < strCorNumArray.Length; i++)
            {
                // перевірка досягнутості потрібної комарки масиву
                if (i == randomIDWord)
                {
                    int sizeNumber = 0;
                    // корнвертація текстових даних у числові
                    int digCorNum = Convert.ToInt32(strCorNumArray[randomIDWord]);
                    // перевірка рівнозначності числа
                    if (digCorNum >= 100)
                    {
                        // створення масиву для видаленя потрібної комірки
                        string[] shortStrCorNum = new string[strCorNumArray.Length - 1];
                        // лічильник ітерацій циклу для проходу по іншому масиву
                        int countCorNum = 0;
                        // цикл для проходу по іншому масиву
                        for (int j = 0; j < strCorNumArray.Length; j++)
                        {
                        // маркер для переходу оператора Goto
                        Deleting:
                            // перевірки досягнутості потрібної комірки
                            if (j != randomIDWord)
                            {
                                // запис інших комірок без змін
                                shortStrCorNum[countCorNum] = strCorNumArray[j];
                                countCorNum++;
                            }
                            // видаленя потрібної комірки
                            if (j == randomIDWord)
                            {
                                j++;
                                goto Deleting;
                            }
                            // перевірка досягнутості кінця другого масиву
                            if (j == shortStrCorNum.Length)
                            {
                                break;
                            }
                        }
                        using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToCorecctAnswerFile}"))
                        {
                            for (int t = 0; t < shortStrCorNum.Length; t++)
                            {
                                if (t == 0)
                                    sw.Write($"{shortStrCorNum[t]}");
                                else
                                {
                                    sw.Write($"\n{shortStrCorNum[t]}");
                                }
                                sizeNumber++;
                            }
                        }
                        string str11 = "";
                        using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToFileWords}"))
                            str11 = sr.ReadToEnd();
                        string[] strWorNumArray = str11.Split('\n');
                        string[] shortStrWorNumArray = new string[strWorNumArray.Length - 1];
                        int countWorNum = 0;
                        for (int e = 0; e < strWorNumArray.Length; e++)
                        {
                        Deleting:
                            if (e != randomIDWord)
                            {
                                shortStrWorNumArray[countWorNum] = strWorNumArray[e];
                                countWorNum++;
                            }
                            if (e == randomIDWord)
                            {
                                e++;
                                goto Deleting;
                            }
                            if (e == shortStrWorNumArray.Length)
                            {
                                break;
                            }
                        }
                        using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToFileWords}"))
                        {
                            for (int y = 0; y < shortStrWorNumArray.Length; y++)
                            {
                                if (y == 0)
                                    sw.Write($"{shortStrWorNumArray[y]}");
                                else
                                    sw.Write($"\n{shortStrWorNumArray[y]}");
                            }
                        }
                        string str22 = "";
                        using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToFileTranslate}"))
                            str22 = sr.ReadToEnd();
                        string[] strTraNumArray = str22.Split('\n');
                        string[] shortStrTraNumArray = new string[strTraNumArray.Length - 1];
                        int countTraNum = 0;
                        for (int g = 0; g < strTraNumArray.Length; g++)
                        {
                        Deleting:
                            if (g != randomIDWord)
                            {
                                shortStrTraNumArray[countTraNum] = strTraNumArray[g];
                                countTraNum++;
                            }
                            if (g == randomIDWord)
                            {
                                g++;
                                goto Deleting;
                            }
                            if (g == shortStrTraNumArray.Length)
                            {
                                break;
                            }
                        }
                        using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToFileTranslate}"))
                        {
                            for (int f = 0; f < shortStrTraNumArray.Length; f++)
                            {
                                if (f == 0)
                                    sw.Write($"{shortStrTraNumArray[f]}");
                                else
                                    sw.Write($"\n{shortStrTraNumArray[f]}");
                            }
                        }
                        using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToSizeFile}"))
                            sw.Write(sizeNumber);
                    }
                }
            }
            string stringWord = "";
            using (StreamReader sr1 = new StreamReader($@"{defaultPath}\{pathToFileWords}"))
                stringWord = sr1.ReadToEnd();
            string[] wordsArray = stringWord.Split('\n');
            textBox1.Text = wordsArray[randomIDWord];
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод виводу відповідей 
        private void OutputAnswer()
        {

            string stringTranslate = "";
            // Запис перекладів слів у рядок
            using (StreamReader sr1 = new StreamReader($@"{defaultPath}\{pathToFileTranslate}"))
                stringTranslate = sr1.ReadToEnd();

            // Перетворення рядка перекладів слів у масив
            string[] translateArray = stringTranslate.Split('\n');

            // Запис парвельної відповіді у файл відповідей
            using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToRandomAsnwer}"))
                sw.Write(translateArray[randomIDWord]);
            // створення масиву для збереження масиву з видаленим значенням
            string[] newTranslateArray = new string [translateArray.Length-1];
            // лічильник для рахування кількості комірок нового масиву
            int countIter = 0;
            // цикл з перевіркою для видалення потрібної комірки
            for (int i = 0; i < translateArray.Length; i++)
            {
                Deleting:
                if (i == randomIDWord)
                {
                    i++;
                    goto Deleting;
                }
                // запис у новий масив
                if (i < translateArray.Length)
                {
                    newTranslateArray[countIter] = translateArray[i];
                    countIter++;
                }
                // перевірка досягнутості кінця нового масиву
                if (i == newTranslateArray.Length)
                {
                    break;
                }
            }
            // доповнює запис двома випадковими відповідями у файлі відповідей
            using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToRandomAsnwer}", true))
            {
                for (int i = 0; i < 2; i++)
                {
                    sw.Write($"\n{newTranslateArray[random.Next(IDWords-1)]}");
                }
            }
            // випадковий вибір варіанту перемішуваня відповідей
            randomChoise = random.Next(6);
            // запис відповідей з перезаписаного списку відповідей без правельної відповіді у текстовий рядок
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToRandomAsnwer}"))
                stringTranslate = sr.ReadToEnd();
            // перетворення рядку у масив
            translateArray = stringTranslate.Split('\n');
            // випадковий вибір перемішування відповідей
            switch (randomChoise)
            {
                case 0:
                    radioButton1.Text = translateArray[0];
                    radioButton2.Text = translateArray[1];
                    radioButton3.Text = translateArray[2];
                    break;
                case 1:
                    radioButton1.Text = translateArray[1];
                    radioButton2.Text = translateArray[0];
                    radioButton3.Text = translateArray[2];
                    break;
                case 2:
                    radioButton1.Text = translateArray[2];
                    radioButton2.Text = translateArray[1];
                    radioButton3.Text = translateArray[0];
                    break;
                case 3:
                    radioButton1.Text = translateArray[0];
                    radioButton2.Text = translateArray[2];
                    radioButton3.Text = translateArray[1];
                    break;
                case 4:
                    radioButton1.Text = translateArray[1];
                    radioButton2.Text = translateArray[2];
                    radioButton3.Text = translateArray[0];
                    break;
                case 5:
                    radioButton1.Text = translateArray[2];
                    radioButton2.Text = translateArray[0];
                    radioButton3.Text = translateArray[1];
                    break;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод запису кількості правельних відповідей
        private void WriteNumberOfCorrectAnswers()
        {
            using (StreamReader sr = new StreamReader($@"{defaultPath}\{pathToSwitchIndex}"))
                switchIndexCor = Convert.ToInt32(sr.ReadToEnd());
            if (switchIndexCor == 0)
            {
                string str1 = "";
                using (StreamReader streamReader = new StreamReader($@"{defaultPath}\{pathToCorecctAnswerFile}"))
                    str1 = streamReader.ReadToEnd();
                string[] str1Array = str1.Split('\n');
                int diNumber = int.Parse(str1Array[randomIDWord]) + 1;
                str1Array[randomIDWord] = diNumber.ToString();
                using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToCorecctAnswerFile}"))
                {
                    for (int i = 0; i < str1Array.GetLength(0); i++)
                        if (i == 0)
                            sw.Write(str1Array[i]);
                        else
                            sw.Write($"\n{str1Array[i]}");
                }
            }
            else
            {
                string str1 = "";
                using (StreamReader streamReader = new StreamReader($@"{defaultPath}\{pathToCorecctAnswerFile}"))
                    str1 = streamReader.ReadToEnd();
                string[] str1Array = str1.Split('\n');
                int diNumber = int.Parse(str1Array[randomIDWord]) + 1;
                str1Array[randomIDWord] = diNumber.ToString();
                using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToCorecctAnswerFile}"))
                    for (int i = 0; i < str1Array.GetLength(0); i++)
                        if (i == 0)
                            sw.Write(str1Array[i]);
                        else
                            sw.Write($"\n{str1Array[i]}");
            }

            using (StreamWriter sw = new StreamWriter($@"{defaultPath}\{pathToSwitchIndex}"))
                sw.Write(1);
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Метод перевірки вірності відповіді
        private void CheckCorrectAnswer()
        {
            // створення пустого рядку
            string str1 = "";
            // запис списку перекладів у рядок
            using (StreamReader sr4 = new StreamReader($@"{defaultPath}\{pathToFileTranslate}"))
                str1 = sr4.ReadToEnd();
            // перетворення рядка у масив
            string[] corrAnswer = str1.Split('\n');
            // перевірка вибору відповіді
            if (radioButton1.Checked)
            {
                if (radioButton1.Text == corrAnswer[randomIDWord])
                {
                    pictureBox1.Location = new Point(radioButton1.Location.X - (pictureBox1.Size.Width + 5), 
                        radioButton1.Location.Y + ((radioButton1.Size.Height/2)-(pictureBox1.Size.Height/2)));
                    pictureBox1.Visible = true;
                }
                if (radioButton2.Text == corrAnswer[randomIDWord])
                {
                    pictureBox1.Location = new Point(radioButton2.Location.X - (pictureBox1.Size.Width + 5),
                        radioButton2.Location.Y + ((radioButton2.Size.Height/2)-(pictureBox1.Size.Height/2)));
                    pictureBox1.Visible = true;
                }
                if (radioButton3.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton3.Location.X - (pictureBox1.Size.Width + 5),
                        radioButton3.Location.Y + ((radioButton3.Size.Height/2)-(pictureBox1.Size.Height/2)));
                    pictureBox1.Visible = true;
                }

            }
            if (radioButton2.Checked)
            {
                if (radioButton1.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton1.Location.X - (pictureBox1.Size.Width + 5),
                        radioButton1.Location.Y + ((radioButton1.Size.Height/2)-(pictureBox1.Size.Height/2)));
                    pictureBox1.Visible = true;                                                                                     
                }                                                                                                                   
                if (radioButton2.Text == corrAnswer[randomIDWord])                                                                  
                {                                                                                                                   
                    pictureBox1.Location = new Point(radioButton2.Location.X - (pictureBox1.Size.Width + 5),
                        radioButton2.Location.Y + ((radioButton2.Size.Height/2)-(pictureBox1.Size.Height/2)));
                    pictureBox1.Visible = true;                                                                                     
                }                                                                                                                   
                if (radioButton3.Text == corrAnswer[randomIDWord])                                                                  
                {                                                                                                                   
                    pictureBox1.Location = new Point(radioButton3.Location.X - (pictureBox1.Size.Width + 5),
                        radioButton3.Location.Y + ((radioButton3.Size.Height/2)-(pictureBox1.Size.Height/2)));
                    pictureBox1.Visible = true;
                }
            }
            if (radioButton3.Checked)
            {
                if (radioButton1.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton1.Location.X - (pictureBox1.Size.Width + 5),
                        radioButton1.Location.Y + ((radioButton1.Size.Height/2)-(pictureBox1.Size.Height/2)));
                    pictureBox1.Visible = true;
                }
                if (radioButton2.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton2.Location.X - (pictureBox1.Size.Width + 5),
                        radioButton2.Location.Y + ((radioButton2.Size.Height/2)-(pictureBox1.Size.Height/2)));
                    pictureBox1.Visible = true;
                }
                if (radioButton3.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton3.Location.X - (pictureBox1.Size.Width + 5),
                        radioButton3.Location.Y + ((radioButton3.Size.Height/2)-(pictureBox1.Size.Height/2)));
                    pictureBox1.Visible = true;
                }
            }
        }
        /*
        //---------------------------------------------------------------------------------------------------------
        //Методи вираховування розмірів контролерів
        private void CalculateSizeControlsUp()
        {
            using (StreamReader sr6 = new StreamReader($@"{configPath}\{pathToCounterFile}"))
                indexParam = Convert.ToInt32(sr6.ReadToEnd());

            string param = "", param2 = "";
            string[] paramArray, paramArray2;

            using (StreamReader sr1 = new StreamReader($@"{configPath}\{pathToValueParameters}"))
                param = sr1.ReadToEnd();
            paramArray = param.Split('\n');
            indexParam++;
            param2 = paramArray[indexParam];
            paramArray2 = param2.Split(',');

            x = Convert.ToInt32(paramArray2[0]);
            y = Convert.ToInt32(paramArray2[1]);

            using (StreamWriter sw = new StreamWriter($@"{configPath}\{pathToCounterFile}"))
                sw.Write(indexParam);

            //---------------------------------------------------------------------------------------------------------

            string strParamMainText = "";
            string[] strParamMainTextArray;

            using (StreamReader sr2 = new StreamReader($@"{configPath}\{pathToValueParameters2}"))
                strParamMainText = sr2.ReadToEnd();
            strParamMainTextArray = strParamMainText.Split('\n');
            fontS = Convert.ToUInt32(strParamMainTextArray[indexParam]);

            //---------------------------------------------------------------------------------------------------------

            string strParamTextBoxX = "";
            string[] strParamTextBoxXArray;

            using (StreamReader sr3 = new StreamReader($@"{configPath}\{pathToValueParameters5}"))
                strParamTextBoxX = sr3.ReadToEnd();
            strParamTextBoxXArray = strParamTextBoxX.Split('\n');
            sizeTextBoxX = Convert.ToInt32(strParamTextBoxXArray[indexParam]);

            //---------------------------------------------------------------------------------------------------------

            string strParamSRB = "";
            string[] strParamSRBArray;

            using (StreamReader sr4 = new StreamReader($@"{configPath}\{pathToValueParameters3}"))
                strParamSRB = sr4.ReadToEnd();
            strParamSRBArray = strParamSRB.Split('\n');
            fontSRButton = Convert.ToUInt32(strParamSRBArray[indexParam]);

            //---------------------------------------------------------------------------------------------------------

            string strParamSB = "";
            string[] strParamSBArray;

            using (StreamReader sr5 = new StreamReader($@"{configPath}\{pathToValueParameters4}"))
                strParamSB = sr5.ReadToEnd();
            strParamSBArray = strParamSB.Split('\n');
            fontSB = Convert.ToUInt32(strParamSBArray[indexParam]);

            //---------------------------------------------------------------------------------------------------------

            string strParamSB1 = "", strParamSB2 = "";
            string[] strParamSBArray1, strParamSBArray2;

            using (StreamReader sr5 = new StreamReader($@"{configPath}\{pathToValueParameters6}"))
                strParamSB = sr5.ReadToEnd();
            strParamSBArray = strParamSB.Split('\n');
            strParamSB2 = strParamSBArray[indexParam];
            strParamSBArray2 = strParamSB2.Split(',');

            xB = Convert.ToInt32(strParamSBArray2[0]);
            yB = Convert.ToInt32(strParamSBArray2[1]);

            //---------------------------------------------------------------------------------------------------------

            string strParamSP = "";
            string[] strParamSPArray;
            using (StreamReader sr6 = new StreamReader($@"{configPath}\{pathToValueParameters7}"))
                strParamSP = sr6.ReadToEnd();
            strParamSPArray = strParamSP.Split('\n');
            sizePicture = Convert.ToInt32(strParamSPArray[indexParam]);

            Size = new Size(x, y);
            textBox1.Font = new Font("Microsoft Sans Serif", fontS, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Size = new Size(sizeTextBoxX, textBox1.Size.Height);
            pictureBox1.Size = new Size(sizePicture, sizePicture);
            radioButton1.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton2.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton3.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Font = new Font("Microsoft Sans Serif", fontSB, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Size = new Size(xB, yB);
            button5.Font = new Font("Microsoft Sans Serif", fontSB, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Size = new Size(xB, yB);
            button6.Font = new Font("Microsoft Sans Serif", fontSB, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Size = new Size(xB, yB);
        }
        //---------------------------------------------------------------------------------------------------------
        private void CalculateSizeControlsDown()
        {
            using (StreamReader sr6 = new StreamReader($@"{configPath}\{pathToCounterFile}"))
                indexParam = Convert.ToInt32(sr6.ReadToEnd());

            string param = "", param2 = "";
            string[] paramArray, paramArray2;

            using (StreamReader sr1 = new StreamReader($@"{configPath}\{pathToValueParameters}"))
                param = sr1.ReadToEnd();
            paramArray = param.Split('\n');
            if (indexParam > 0)
                indexParam--;
            if (indexParam == 0)
                indexParam = 0;
            param2 = paramArray[indexParam];
            paramArray2 = param2.Split(',');

            x = Convert.ToInt32(paramArray2[0]);
            y = Convert.ToInt32(paramArray2[1]);

            using (StreamWriter sw = new StreamWriter($@"{configPath}\{pathToCounterFile}"))
                sw.Write(indexParam);

            //---------------------------------------------------------------------------------------------------------

            if (indexParam > 0)
            {
                string strParamMainText = "";
                string[] strParamMainTextArray;

                using (StreamReader sr1 = new StreamReader($@"{configPath}\{pathToValueParameters2}"))
                    strParamMainText = sr1.ReadToEnd();
                strParamMainTextArray = strParamMainText.Split('\n');
                fontS = Convert.ToUInt32(strParamMainTextArray[indexParam]);

                //---------------------------------------------------------------------------------------------------------

                string strParamTextBoxX = "";
                string[] strParamTextBoxXArray;

                using (StreamReader sr1 = new StreamReader($@"{configPath}\{pathToValueParameters5}"))
                    strParamTextBoxX = sr1.ReadToEnd();
                strParamTextBoxXArray = strParamTextBoxX.Split('\n');
                sizeTextBoxX = Convert.ToInt32(strParamTextBoxXArray[indexParam]);

                //---------------------------------------------------------------------------------------------------------

                string strParamSRB = "";
                string[] strParamSRBArray;

                using (StreamReader sr1 = new StreamReader($@"{configPath}\{pathToValueParameters3}"))
                    strParamSRB = sr1.ReadToEnd();
                strParamSRBArray = strParamSRB.Split('\n');
                fontSRButton = Convert.ToUInt32(strParamSRBArray[indexParam]);

                //---------------------------------------------------------------------------------------------------------

                string strParamSB = "";
                string[] strParamSBArray;

                using (StreamReader sr5 = new StreamReader($@"{configPath}\{pathToValueParameters4}"))
                    strParamSB = sr5.ReadToEnd();
                strParamSBArray = strParamSB.Split('\n');
                fontSB = Convert.ToUInt32(strParamSBArray[indexParam]);

                //---------------------------------------------------------------------------------------------------------

                string strParamSB1 = "", strParamSB2 = "";
                string[] strParamSBArray1, strParamSBArray2;

                using (StreamReader sr5 = new StreamReader($@"{configPath}\{pathToValueParameters6}"))
                    strParamSB1 = sr5.ReadToEnd();
                strParamSBArray1 = strParamSB1.Split('\n');
                strParamSB2 = strParamSBArray1[indexParam];
                strParamSBArray2 = strParamSB2.Split(',');

                xB = Convert.ToInt32(strParamSBArray2[0]);
                yB = Convert.ToInt32(strParamSBArray2[1]);

                //--------------------------------------------------------------------------------------------------------

                string strParamSP = "";
                string[] strParamSPArray;
                using (StreamReader sr6 = new StreamReader($@"{configPath}\{pathToValueParameters7}"))
                    strParamSP = sr6.ReadToEnd();
                strParamSPArray = strParamSP.Split('\n');
                sizePicture = Convert.ToInt32(strParamSPArray[indexParam]);
            }
            if (indexParam == 0)
            {
                xB = 64;
                yB = 22;
                sizeTextBoxX = 229;
                fontSRButton = 8;
                fontS = 14;
                fontSB = 8;
                pictureBox1.Size = new Size(20, 20);
            }

            Size = new Size(x, y);
            textBox1.Font = new Font("Microsoft Sans Serif", fontS, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Size = new Size(sizeTextBoxX, textBox1.Size.Height);
            pictureBox1.Size = new Size(pictureBox1.Size.Width - 5, pictureBox1.Size.Height - 5);
            radioButton1.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton2.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton3.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Font = new Font("Microsoft Sans Serif", fontSB, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Size = new Size(xB, yB);
            button5.Font = new Font("Microsoft Sans Serif", fontSB, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Size = new Size(xB, yB);
            button6.Font = new Font("Microsoft Sans Serif", fontSB, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Size = new Size(xB, yB);
        }
        */

        // КОНТРОЛЕРИ
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Кнопка відкриття меню
        private void button6_Click(object sender, EventArgs e)
        {
            button6.Focus();
            panel1.Location = new Point(0, 0);
            panel1.Visible = true;
            
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Кнопка закриття меню
        private void button7_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            panel1.Visible = false;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Кнопка відкриття налаштувань
        private void button2_Click(object sender, EventArgs e)
        {
            settingsWindow.Show();
            panel1.Visible = false;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Кнопка відповіді
        private void button5_Click(object sender, EventArgs e)
        {
            CheckCorrectAnswer();
            WriteNumberOfCorrectAnswers();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Кнопка додавання нових слів
        private void button3_Click(object sender, EventArgs e)
        {
            AddNewWordWindow.Show();
            panel1.Visible = false;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Кнопка оновлення
        private void button4_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            pictureBox1.Visible = false;
            Repetition();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // Close button
        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        // для переміщення форми
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //---------------------------------------------------------------------------------------------------------------------------------------------
        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}