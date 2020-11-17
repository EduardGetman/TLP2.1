using System.IO;


namespace TLP2._1
{
    static class FileManager
    {
        static public string LoadFile(string pathFile)
        {
            string str;
            if (File.Exists(pathFile))
            {
                StreamReader sr = new StreamReader(pathFile);

                str = sr.ReadToEnd();
                sr.Close();
                return str;
            }
            else
                return "";
        }

        static public bool SaveFile(string pathFile, string saveString, bool replace = false)
        {
            StreamWriter sw = new StreamWriter(pathFile, true);
            sw.WriteLine(saveString);
            sw.Close();
            return true;
        }
    }
}
