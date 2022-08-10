﻿using System;
using System.Drawing;
using System.IO;
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

        string defaultPath = @"C:\FEW",
            pathToFileWords = $@"C:\FEW\English words.mw",
            pathToFileTranslate = $@"C:\FEW\Translate.mw",
            pathToCorecctAnswerFile = $@"C:\FEW\Counter of correct answer.mw",
            pathToRandomAsnwer = $@"C:\FEW\Random answer.mw",
            pathToSwitchIndex = $@"C:\FEW\Switch index.mw",
            pathToConfigFile = $@"C:\FEW\Config.cfg",
            pathToValueParameters = $@"C:\FEW\Value of size window parameters.par",
            pathToValueParameters2 = $@"C:\FEW\Value of font main text parameters.par",
            pathToValueParameters3 = $@"C:\FEW\Value of font answer text parameters.par",
            pathToValueParameters4 = $@"C:\FEW\Value of font button text parameters.par",
            pathToValueParameters5 = $@"C:\FEW\Value of size textBox parameters.par",
            pathToCounterFile = $@"C:\FEW\Case index.ci",
            pathToSizeFile = $@"C:\FEW\Number of the words.mw";

        string defaultSettings = 
$@"Main_window:
Size-440,81
Random_word_field_Location-12,3
Random_word_field_Size-14.25
Random_word_field_Font-Microsoft Sans Serif
Random_word_field_Color-255,102,102
radioButton1_Color-255,102,102
radioButton1_Size-8.25
radioButton2_Color-255,102,102
radioButton2_Size-8.25
radioButton3_Color-255,102,102
radioButton3_Size-8.25";

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

        uint fontS = 14, fontSB = 8, fontSRButton = 8;

        private int
            IDWords = 0, IDTranslate = 0, randomIDWord = 0,
            correctItem = 0, randomChoise = 0, x = 440, y = 81, 
            indexParam = 0, numberOfIter = 0, 
            sizeTextBoxX = 229;

        private const byte 
            perCentS = 20, perCentST = 30, 
            perCentSB = 20, perCentSRB = 31,
            perCentSTextBox = 19;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MainWindowLocation();
            CreateDirectoryAndFiles();
            MySettings();
            RecountTheNumberOfWords();
            Repetition();
        }
        // МЕТОДИ !!!!!
        //---------------------------------------------------------------------------------------------------------
        // Метод повтору
        private void Repetition()
        {
            SetIDWord();
            OutputRandomWord();
            OutputAnswer();
        }
        //---------------------------------------------------------------------------------------------------------
        private void MainWindowLocation()
        {
            Location = new Point((screenSize.Width / 2) - (Size.Width / 2), 0);
        }
        //---------------------------------------------------------------------------------------------------------
        // Метод дефолтних налаштувань
        private void MySettings()
        {
            string strParam = "", strParam2 = "";
            string[] strParamArray, strIndexParamArray;

            using (StreamReader streamR = new StreamReader(pathToValueParameters))
                strParam = streamR.ReadToEnd();

            strParamArray = strParam.Split('\n');

            using (StreamReader streamR1 = new StreamReader(pathToCounterFile))
                indexParam = Convert.ToInt32(streamR1.ReadToEnd());

            strParam2 = strParamArray[indexParam];
            strIndexParamArray = strParam2.Split(',');

            x = Convert.ToInt32(strIndexParamArray[0]);
            y = Convert.ToInt32(strIndexParamArray[1]);

            Size = new Size(x, y);

            radioButton1.Location = new Point(textBox1.Location.X + textBox1.Size.Width + pictureBox1.Size.Width + 10, 3);
            radioButton2.Location = new Point(radioButton1.Location.X, radioButton1.Location.Y + radioButton1.Size.Height + 5);
            radioButton3.Location = new Point(radioButton1.Location.X, radioButton2.Location.Y + radioButton2.Size.Height + 5);

            button6.Location = new Point(textBox1.Location.X, textBox1.Location.Y + textBox1.Size.Height + 5);
            button5.Location = new Point(button6.Location.X + button6.Size.Width + 4, button6.Location.Y);
            button4.Location = new Point(button5.Location.X + button5.Size.Width + 2, button5.Location.Y);
            // for test
            textBox2.Location = new Point(0, button4.Location.Y + button4.Size.Height+2);

            MainWindowLocation();
        }
        //---------------------------------------------------------------------------------------------------------
        // Метод створення директорії та неохідних файлів
        private void CreateDirectoryAndFiles()
        {
            // Створення дерикторії
            Directory.CreateDirectory(defaultPath);

            // Перевірка на навність необхідних файлів
            // Створення файла для слів
            if (!File.Exists(pathToFileWords))
            {
                using (StreamWriter sw1 = new StreamWriter(pathToFileWords))
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

            // Створення файла для перекладу
            if (!File.Exists(pathToFileTranslate))
            {
                using (StreamWriter sw2 = new StreamWriter(pathToFileTranslate))
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

            // Створення файла для вірних відповідей
            if (!File.Exists(pathToCorecctAnswerFile))
            {
                using (StreamWriter sw3 = new StreamWriter(pathToCorecctAnswerFile))
                    // нумерація комірок
                    for (int i = 0; i < IDWords; i++)
                        if (i == 0)
                            sw3.Write(correctItem);
                        else
                            sw3.Write($"\n{correctItem}");
            }

            // Створення файла для перемішування відповідей
            if (!File.Exists(pathToRandomAsnwer))
                using (FileStream fs1 = new FileStream(pathToRandomAsnwer, FileMode.Create)) { };

            //// Створення Config файла
            //if (!File.Exists(pathToConfigFile))
            //    using (StreamWriter sw4 = new StreamWriter(pathToConfigFile))
            //    {
            //        sw4.Write($@"");
            //    }

            // Створення файла для лічильника
            if (!File.Exists(pathToCounterFile))
            {
                using (StreamWriter sw8 = new StreamWriter(pathToCounterFile))
                    sw8.Write(0);
            }

            // Створення файлів для параметрів
            if (!File.Exists(pathToValueParameters))
            {
                using (StreamWriter sw6 = new StreamWriter(pathToValueParameters))
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
            //---------------------------------------------------------------------------------------------------------
            if (!File.Exists(pathToValueParameters2))
            {
                using (StreamWriter sw = new StreamWriter(pathToValueParameters2))
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
            //---------------------------------------------------------------------------------------------------------
            if (!File.Exists(pathToValueParameters3))
            {
                using (StreamWriter sw = new StreamWriter(pathToValueParameters3))
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
            //---------------------------------------------------------------------------------------------------------
            if (!File.Exists(pathToValueParameters4))
            {
                using (StreamWriter sw = new StreamWriter(pathToValueParameters4))
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
            //---------------------------------------------------------------------------------------------------------
            if (!File.Exists(pathToValueParameters5))
            {
                using (StreamWriter sw = new StreamWriter(pathToValueParameters5))
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

            // Запис кількості слів у текстовий файл
            if (!File.Exists(pathToSizeFile))
            {
                SaveNumberOfSize();
            }
        }

        //---------------------------------------------------------------------------------------------------------
        // Метод перераховування кількості слів при повторному відкритті программи
        private void RecountTheNumberOfWords()
        {
            string strRecount = "";
            using (StreamReader sr = new StreamReader(pathToFileWords))
                strRecount = sr.ReadToEnd();
            string[] strRecountArray = strRecount.Split('\n');
            for (int i = 0; i < strRecountArray.GetLength(0); i++)
                IDWords++;
        }
        //---------------------------------------------------------------------------------------------------------
        // Метод створення файлу та запис кількості англійських слів
        public void SaveNumberOfSize()
        {
            using (StreamWriter sw = new StreamWriter(pathToSizeFile))
                sw.Write($"{IDWords}");
            SetIDWord();
        }
        //---------------------------------------------------------------------------------------------------------
        // Метод встановлення кількості англійських слів у файлі
        private void SetIDWord()
        {
            using (StreamReader sr = new StreamReader(pathToSizeFile))
                IDWords = Convert.ToInt32(sr.ReadToEnd());
        }
        //---------------------------------------------------------------------------------------------------------
        // Метод випадкової вибірки слова із списка 
        private void OutputRandomWord()
        {
            randomIDWord = random.Next(IDWords);

            // Рядок для запису даних із текстового файлу
            string strCorNum = "";
            // Читаємо данні з файлу
            using (StreamReader sr = new StreamReader(pathToCorecctAnswerFile))
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
                        using (StreamWriter sw = new StreamWriter(pathToCorecctAnswerFile))
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
                        //---------------------------------------------------------------
                        string str11 = "";
                        using (StreamReader sr = new StreamReader(pathToFileWords))
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
                        using (StreamWriter sw = new StreamWriter(pathToFileWords))
                        {
                            for (int y = 0; y < shortStrWorNumArray.Length; y++)
                            {
                                if (y == 0)
                                    sw.Write($"{shortStrWorNumArray[y]}");
                                else
                                    sw.Write($"\n{shortStrWorNumArray[y]}");
                            }
                        }
                        //---------------------------------------------------------------
                        string str22 = "";
                        using (StreamReader sr = new StreamReader(pathToFileTranslate))
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
                        using (StreamWriter sw = new StreamWriter(pathToFileTranslate))
                        {
                            for (int f = 0; f < shortStrTraNumArray.Length; f++)
                            {
                                if (f == 0)
                                    sw.Write($"{shortStrTraNumArray[f]}");
                                else
                                    sw.Write($"\n{shortStrTraNumArray[f]}");
                            }
                        }
                        //---------------------------------------------------------------
                        using (StreamWriter sw = new StreamWriter(pathToSizeFile))
                            sw.Write(sizeNumber);
                    }
                }
            }

            string stringWord = "";
            using (StreamReader sr1 = new StreamReader(pathToFileWords))
                stringWord = sr1.ReadToEnd();
            string[] wordsArray = stringWord.Split('\n');
            //label3.Text = wordsArray[randomIDWord];
            textBox1.Text = wordsArray[randomIDWord];
        }
        //---------------------------------------------------------------------------------------------------------
        // Метод виводу відповідей 
        private void OutputAnswer()
        {

            string stringTranslate = "";
            // Запис перекладів слів у рядок
            using (StreamReader sr1 = new StreamReader(pathToFileTranslate))
                stringTranslate = sr1.ReadToEnd();

            // Перетворення рядка перекладів слів у масив
            string[] translateArray = stringTranslate.Split('\n');

            // Запис парвельної відповіді у файл відповідей
            using (StreamWriter sw = new StreamWriter(pathToRandomAsnwer))
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
            using (StreamWriter sw = new StreamWriter(pathToRandomAsnwer, true))
            {
                for (int i = 0; i < 2; i++)
                {
                    sw.Write($"\n{newTranslateArray[random.Next(IDWords-1)]}");
                }
            }
            // випадковий вибір варіанту перемішуваня відповідей
            randomChoise = random.Next(6);
            // запис відповідей з перезаписаного списку відповідей без правельної відповіді у текстовий рядок
            using (StreamReader sr = new StreamReader(pathToRandomAsnwer))
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
        //---------------------------------------------------------------------------------------------------------
        // Метод запису кількості правельних відповідей
        private void WriteNumberOfCorrectAnswers()
        {
            if (!File.Exists(pathToSwitchIndex))
            {
                using (FileStream fs = new FileStream(pathToSwitchIndex, FileMode.Create)) { };

                string str1 = "";
                using (StreamReader streamReader = new StreamReader(pathToCorecctAnswerFile))
                    str1 = streamReader.ReadToEnd();
                string[] str1Array = str1.Split('\n');
                int diNumber = int.Parse(str1Array[randomIDWord]) + 1;
                str1Array[randomIDWord] = diNumber.ToString();
                using (StreamWriter sw = new StreamWriter(pathToCorecctAnswerFile))
                {
                    for (int i = 0; i < str1Array.GetLength(0); i++)
                        if (i == 0)
                            sw.Write(str1Array[i]);
                        else
                            sw.Write($"\n{str1Array[i]}");
                }
            }
            //--------------------------------------------------------------
            else
            {
                string str1 = "";
                using (StreamReader streamReader = new StreamReader(pathToCorecctAnswerFile))
                    str1 = streamReader.ReadToEnd();
                string[] str1Array = str1.Split('\n');
                int diNumber = int.Parse(str1Array[randomIDWord]) + 1;
                str1Array[randomIDWord] = diNumber.ToString();
                using (StreamWriter sw = new StreamWriter(pathToCorecctAnswerFile))
                    for (int i = 0; i < str1Array.GetLength(0); i++)
                        if (i == 0)
                            sw.Write(str1Array[i]);
                        else
                            sw.Write($"\n{str1Array[i]}");
            }
        }
        //---------------------------------------------------------------------------------------------------------
        // Метод перевірки вірності відповіді
        private void CheckCorrectAnswer()
        {
            // створення пустого рядку
            string str1 = "";
            // запис списку перекладів у рядок
            using (StreamReader sr4 = new StreamReader(pathToFileTranslate))
                str1 = sr4.ReadToEnd();
            // перетворення рядка у масив
            string[] corrAnswer = str1.Split('\n');
            // перевірка вибору відповіді
            if (radioButton1.Checked)
            {
                if (radioButton1.Text == corrAnswer[randomIDWord])
                {
                    pictureBox1.Location = new Point(radioButton1.Location.X - (pictureBox1.Size.Width + 5), radioButton1.Location.Y);
                    pictureBox1.Visible = true;
                }
                if (radioButton2.Text == corrAnswer[randomIDWord])
                {
                    pictureBox1.Location = new Point(radioButton2.Location.X - (pictureBox1.Size.Width + 5), radioButton2.Location.Y);
                    pictureBox1.Visible = true;
                }
                if (radioButton3.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton3.Location.X - (pictureBox1.Size.Width + 5), radioButton3.Location.Y);
                    pictureBox1.Visible = true;
                }

            }
            if (radioButton2.Checked)
            {
                if (radioButton1.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton1.Location.X - (pictureBox1.Size.Width + 5), radioButton1.Location.Y);
                    pictureBox1.Visible = true;
                }
                if (radioButton2.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton2.Location.X - (pictureBox1.Size.Width + 5), radioButton2.Location.Y);
                    pictureBox1.Visible = true;
                }
                if (radioButton3.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton3.Location.X - (pictureBox1.Size.Width + 5), radioButton3.Location.Y);
                    pictureBox1.Visible = true;
                }
            }
            if (radioButton3.Checked)
            {
                if (radioButton1.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton1.Location.X - (pictureBox1.Size.Width + 5), radioButton1.Location.Y);
                    pictureBox1.Visible = true;
                }
                if (radioButton2.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton2.Location.X - (pictureBox1.Size.Width + 5), radioButton2.Location.Y);
                    pictureBox1.Visible = true;
                }
                if (radioButton3.Text == corrAnswer[randomIDWord]) 
                {
                    pictureBox1.Location = new Point(radioButton3.Location.X - (pictureBox1.Size.Width + 5), radioButton3.Location.Y);
                    pictureBox1.Visible = true;
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------
        // Методи вираховування розмурів контролерів
        private void CalculateSizeControlsUp()
        {
            using (StreamReader sr6 = new StreamReader(pathToCounterFile))
                indexParam = Convert.ToInt32(sr6.ReadToEnd());

            string param = "", param2 = "";
            string[] paramArray, paramArray2;
            
            using (StreamReader sr1 = new StreamReader(pathToValueParameters))
                param = sr1.ReadToEnd();
            paramArray = param.Split('\n');
            indexParam++;
            param2 = paramArray[indexParam];
            paramArray2 = param2.Split(',');

            x = Convert.ToInt32(paramArray2[0]);
            y = Convert.ToInt32(paramArray2[1]);

            using (StreamWriter sw = new StreamWriter(pathToCounterFile))
                sw.Write(indexParam);

            //---------------------------------------------------------------------------------------------------------

            string strParamMainText = "";
            string[] strParamMainTextArray;

            using (StreamReader sr1 = new StreamReader(pathToValueParameters2))
                strParamMainText = sr1.ReadToEnd();
            strParamMainTextArray = strParamMainText.Split('\n');
            fontS = Convert.ToUInt32(strParamMainTextArray[indexParam]);

            //---------------------------------------------------------------------------------------------------------

            string strParamTextBoxX = "";
            string[] strParamTextBoxXArray;

            using (StreamReader sr1 = new StreamReader(pathToValueParameters5))
                strParamTextBoxX = sr1.ReadToEnd();
            strParamTextBoxXArray = strParamTextBoxX.Split('\n');
            sizeTextBoxX = Convert.ToInt32(strParamTextBoxXArray[indexParam]);

            //---------------------------------------------------------------------------------------------------------

            string strParamSRB = "";
            string[] strParamSRBArray;

            using (StreamReader sr1 = new StreamReader(pathToValueParameters3))
                strParamSRB = sr1.ReadToEnd();
            strParamSRBArray = strParamSRB.Split('\n');
            fontSRButton = Convert.ToUInt32(strParamSRBArray[indexParam]);

            Size = new Size(x, y);
            textBox1.Font = new Font("Microsoft Sans Serif", fontS, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Size = new Size(sizeTextBoxX, textBox1.Size.Height);
            pictureBox1.Size = new Size(pictureBox1.Size.Width + 5, pictureBox1.Size.Height + 5);
            radioButton1.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton2.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton3.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
        }
        //---------------------------------------------------------------------------------------------------------
        private void CalculateSizeControlsDown()
        {
            using (StreamReader sr6 = new StreamReader(pathToCounterFile))
                indexParam = Convert.ToInt32(sr6.ReadToEnd());

            string param = "", param2 = "";
            string[] paramArray, paramArray2;

            using (StreamReader sr1 = new StreamReader(pathToValueParameters))
                param = sr1.ReadToEnd();
            paramArray = param.Split('\n');
            if(indexParam > 0)
                indexParam--;
            if (indexParam == 0)
                indexParam = 0;
            param2 = paramArray[indexParam];
            paramArray2 = param2.Split(',');

            x = Convert.ToInt32(paramArray2[0]);
            y = Convert.ToInt32(paramArray2[1]);

            using (StreamWriter sw = new StreamWriter(pathToCounterFile))
                sw.Write(indexParam);

            //---------------------------------------------------------------------------------------------------------

            if(indexParam > 0)
            {
                string strParamMainText = "";
                string[] strParamMainTextArray;

                using (StreamReader sr1 = new StreamReader(pathToValueParameters2))
                    strParamMainText = sr1.ReadToEnd();
                strParamMainTextArray = strParamMainText.Split('\n');
                fontS = Convert.ToUInt32(strParamMainTextArray[indexParam]);

                //---------------------------------------------------------------------------------------------------------

                string strParamTextBoxX = "";
                string[] strParamTextBoxXArray;

                using (StreamReader sr1 = new StreamReader(pathToValueParameters5))
                    strParamTextBoxX = sr1.ReadToEnd();
                strParamTextBoxXArray = strParamTextBoxX.Split('\n');
                sizeTextBoxX = Convert.ToInt32(strParamTextBoxXArray[indexParam]);

                //---------------------------------------------------------------------------------------------------------

                string strParamSRB = "";
                string[] strParamSRBArray;

                using (StreamReader sr1 = new StreamReader(pathToValueParameters3))
                    strParamSRB = sr1.ReadToEnd();
                strParamSRBArray = strParamSRB.Split('\n');
                fontSRButton = Convert.ToUInt32(strParamSRBArray[indexParam]);
            }
            if (indexParam == 0)
            {
                sizeTextBoxX = 229;
                fontSRButton = 8;
                pictureBox1.Size = new Size(15, 15);
            }

            Size = new Size(x, y);
            textBox1.Font = new Font("Microsoft Sans Serif", fontS, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Size = new Size(sizeTextBoxX, textBox1.Size.Height);
            pictureBox1.Size = new Size(pictureBox1.Size.Width - 5, pictureBox1.Size.Height - 5);
            radioButton1.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton2.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
            radioButton3.Font = new Font("Microsoft Sans Serif", fontSRButton, FontStyle.Regular, GraphicsUnit.Point, 204);
        }
        //---------------------------------------------------------------------------------------------------------
        // КОНТРОЛЕРИ
        //---------------------------------------------------------------------------------------------------------
        // Кнопка відкриття меню
        private void button6_Click(object sender, EventArgs e)
        {
            button6.Focus();
            panel1.Location = new Point(0, 0);
            panel1.Visible = true;
            button6.Visible = false;
        }
        //---------------------------------------------------------------------------------------------------------
        // Кнопка закриття меню
        private void button7_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            panel1.Visible = false;
        }
        //---------------------------------------------------------------------------------------------------------
        // Кнопка відкриття налаштувань
        private void button2_Click(object sender, EventArgs e)
        {
            settingsWindow.Show();
        }

        //---------------------------------------------------------------------------------------------------------
        // Кнопка відповіді
        private void button5_Click(object sender, EventArgs e)
        {
            CheckCorrectAnswer();
            WriteNumberOfCorrectAnswers();
        }
        //---------------------------------------------------------------------------------------------------------
        // Кнопка додавання нових слів
        private void button3_Click(object sender, EventArgs e)
        {
            AddNewWordWindow.Show();
        }
        //---------------------------------------------------------------------------------------------------------
        // Кнопка оновлення
        private void button4_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            pictureBox1.Visible = false;
            Repetition();
        }
        //---------------------------------------------------------------------------------------------------------
        // Close button
        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }
        //---------------------------------------------------------------------------------------------------------
        // Close Key
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Oemplus)
            {
                int tempX = x*20/100+x;
                if (tempX < screenSize.Width)
                {
                    CalculateSizeControlsUp();
                    
                    textBox2.Text = radioButton1.Font.Size.ToString();

                    radioButton1.Location = new Point(textBox1.Location.X + textBox1.Size.Width + pictureBox1.Size.Width + 10, 3);
                    radioButton2.Location = new Point(radioButton1.Location.X, radioButton1.Location.Y + radioButton1.Size.Height + 5);
                    radioButton3.Location = new Point(radioButton1.Location.X, radioButton2.Location.Y + radioButton2.Size.Height + 5);
                    button6.Location = new Point(textBox1.Location.X, textBox1.Location.Y + textBox1.Size.Height + 5);
                    button5.Location = new Point(button6.Location.X + button6.Size.Width + 4, button6.Location.Y);
                    button4.Location = new Point(button5.Location.X + button5.Size.Width + 2, button5.Location.Y);
                    // for test
                    textBox2.Location = new Point(0, button4.Location.Y + button4.Size.Height+2);
                    MainWindowLocation();
                }

                if (tempX == screenSize.Width || tempX > screenSize.Width)
                {
                    Size = new Size(x, y);
                }
            }
            if(e.KeyValue == (char)Keys.OemMinus)
            {
                CalculateSizeControlsDown();

                textBox2.Text = radioButton1.Font.Size.ToString();
                
                radioButton1.Location = new Point(textBox1.Location.X + textBox1.Size.Width + pictureBox1.Size.Width + 10, 3);
                radioButton2.Location = new Point(radioButton1.Location.X, radioButton1.Location.Y + radioButton1.Size.Height + 5);
                radioButton3.Location = new Point(radioButton1.Location.X, radioButton2.Location.Y + radioButton2.Size.Height + 5);
                button6.Location = new Point(textBox1.Location.X, textBox1.Location.Y + textBox1.Size.Height + 5);
                button5.Location = new Point(button6.Location.X + button6.Size.Width + 4, button6.Location.Y);
                button4.Location = new Point(button5.Location.X + button5.Size.Width + 2, button5.Location.Y);
                // for test
                textBox2.Location = new Point(0, button4.Location.Y + button4.Size.Height+2);
                MainWindowLocation();
            }
            if(e.KeyValue == (char)Keys.Escape)
                Close();

        }
    }
}