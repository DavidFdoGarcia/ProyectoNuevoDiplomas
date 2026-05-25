using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NuevoDiplomas.Clases
{
    internal class Ini
    {
        string path;

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(
            string section,
            string key,
            string def,
            StringBuilder retVal,
            int size,
            string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string section,
            string key,
            string value,
            string filePath);

        public Ini(string iniPath)
        {
            path = iniPath;
        }

        public string Leer(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);

            GetPrivateProfileString(
                section,
                key,
                "",
                temp,
                255,
                path);

            return temp.ToString();
        }

        public void Escribir(string section, string key, string value)
        {
            WritePrivateProfileString(
                section,
                key,
                value,
                path);
        }
    }
}
