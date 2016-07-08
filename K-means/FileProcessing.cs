using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means
{
    class FileProcessing
    {
        private string inputName;
        private string outputName;

        public string InputName
        {
            get { return inputName; }
            set { inputName = value; }
        }

        public string OutputName
        {
            get { return outputName; }
            set { outputName = value; }
        }

        public double[][] ReadFromFile(out int clusterNum)
        {
            int rows = 0;
            string tmp;
            char[] sep = { ' ' };
            FileStream fs = new FileStream(inputName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                rows++;
            }
            double[][] array = new double[rows - 1][];
            fs.Seek(0, SeekOrigin.Begin);
            clusterNum = int.Parse(sr.ReadLine());
            int i = 0;
            while (!sr.EndOfStream)
            {
                tmp = sr.ReadLine();
                string[] s = tmp.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                array[i] = new double[] { double.Parse(s[0]), double.Parse(s[1]), double.Parse(s[2]) };
                i++;
            }
            sr.Close();
            fs.Close();
            return array;
        }

        public void Write(int[] lables)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputName, false))
            {
                int i = 0;
                while (i != lables.Length)
                {
                    file.WriteLine((i + 1) + " element contains in " + lables[i] + " cluster.");
                    i++;
                }
            }
        }
    }
}
