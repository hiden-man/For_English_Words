using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_English_Words
{
    internal class SettingsClass
    {
        string configPath = "C:\\WordMem\\Config",
            pathLocationMF = "Switch_location.sl",
            pathToLanguageSetting = "Switch language.sl";
        public byte SwitcherLanguageSettings()
        {
            byte sLS = 0;
            using (StreamReader sr = new StreamReader($"{configPath}\\{pathToLanguageSetting}"))
            {
                sLS = Convert.ToByte(sr.ReadToEnd());
            }
            return sLS;
        }

        public byte SwitcherLocationMainForm()
        {
            byte sLMF = 0;
            using (StreamReader sr = new StreamReader($"{configPath}\\{pathLocationMF}"))
            {
                sLMF = Convert.ToByte(sr.ReadToEnd());
            }
            return sLMF;
        }
    }
}
