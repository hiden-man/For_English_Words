using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace For_English_Words
{
    internal class CreaterSomeFiles
    {
        Size screenSize = Screen.PrimaryScreen.Bounds.Size;
        private int numberOfNumber = 0, numberOfIter = 0;
        public CreaterSomeFiles(string path, string name, string data)
        {
            if (!File.Exists($"{path}\\{name}"))
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                    sw.Write(data);
        }
        public CreaterSomeFiles(string path, string name)
        {
            if (!File.Exists($"{path}\\{name}"))
                using (FileStream sw = new FileStream($"{path}\\{name}", FileMode.Create)) { }
        }
        public CreaterSomeFiles(string path, string name, string data, sbyte mode)
        {
            if (!File.Exists($"{path}\\{name}"))
            {
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                {
                    if (mode == 0)
                        sw.Write($"{data},{data}");
                    if (mode == 1)
                        sw.Write($"{data}\n{data}");
                }
            }
        }
        public CreaterSomeFiles(string path, string name, int data, int size)
        {
            if (!File.Exists($"{path}\\{name}"))
            {
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (i == 0)
                            sw.Write(data);
                        else
                            sw.Write($"\n{data}");
                    }
                }
            }
        }
        public CreaterSomeFiles(string[] strArray, string path, string name)
        {
            if (!File.Exists($"{path}\\{name}"))
            {
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                {
                    foreach (string someWords in strArray)
                    {
                        if (numberOfNumber == 0)
                            sw.Write($"{someWords.ToLower()}");
                        else
                            sw.Write($"\n{someWords.ToLower()}");
                        numberOfNumber++;
                    }
                }
            }
        }
        public int GetNumberOfNumber() { return numberOfNumber; }
        public CreaterSomeFiles(string path, string name, int x, int y, byte perCent)
        {
            if (!File.Exists($"{path}\\{name}"))
            {
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                {
                    bool boolChecker = true;
                    for (int i = 0; boolChecker;)
                    {
                        int tempXY = x * perCent / 100 + x;
                        if (tempXY < screenSize.Width)
                        {
                            if (i == 0)
                                sw.Write($"{x},{y}");
                            else
                            {
                                x = x * perCent / 100 + x;
                                y = y * perCent / 100 + y;
                                sw.Write($"\n{x},{y}");
                            }
                            i++;
                        }
                        if (tempXY == screenSize.Width || tempXY > screenSize.Width)
                            boolChecker = false;
                        numberOfIter = i;
                    }
                }
            }
        }
        public int GetNumberOfIter() { return numberOfIter; }
        public CreaterSomeFiles(string path, string name, uint someData, int numberOI, byte perCent, byte mode)
        {
            if (!File.Exists($"{path}\\{name}"))
            {
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                {
                    if (mode == 0)
                    {
                        for (int i = 0; i < numberOI; i++)
                        {
                            if (i == 0)
                                sw.Write(someData);
                            else
                            {
                                someData = someData * perCent / 100 + someData;
                                sw.Write($"\n{someData}");
                            }
                        }
                    }
                    if (mode == 1)
                    {
                        for (int i = 0; i < numberOI; i++)
                        {
                            if (i == 0)
                                sw.Write(someData);
                            else
                            {
                                someData = someData  + 5;
                                sw.Write($"\n{someData}");
                            }
                        }
                    }
                }
            }
        }
        public CreaterSomeFiles(string path, string name, int x, int y, int numberOI, byte perCent)
        {
            if (!File.Exists($"{path}\\{name}"))
            {
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                {
                    for (int i = 0; i < numberOI; i++)
                    {
                        if (i == 0)
                            sw.Write($"{x},{y}");
                        else
                        {
                            x = x * perCent / 100 + x;
                            y = y * perCent / 100 + y;
                            sw.Write($"\n{x},{y}");
                        }
                    }
                }
            }
        }
    }
}
