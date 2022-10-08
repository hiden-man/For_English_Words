using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace For_English_Words
{
    internal class CreaterSomeFiles
    {
        public CreaterSomeFiles(string path, string name, string data)
        {
            if (!File.Exists($"{path}\\{name}"))
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                    sw.Write(data);
        }
        public CreaterSomeFiles(string path, string name)
        {
            if (!File.Exists($"{path}\\{name}"))
                using (FileStream sw = new FileStream($"{path}\\{name}", FileMode.Create)){}
        }
        public CreaterSomeFiles(string path, string name, string data, sbyte mode)
        {
            if (!File.Exists($"{path}\\{name}"))
            {
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                {
                    if(mode == 0)
                        sw.Write($"{data},{data}");
                    if(mode == 1)
                        sw.Write($"{data}\n{data}");
                }
            }
        }
        public CreaterSomeFiles(string path, string name, string data, int size, sbyte mode)
        {
            if (!File.Exists($"{path}\\{name}"))
            {
                using (StreamWriter sw = new StreamWriter($"{path}\\{name}"))
                {
                    if (mode == 0)
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
        }
    }
}
