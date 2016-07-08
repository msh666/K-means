using Accord.MachineLearning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            // Declare some observations
            double[][] observations = pr.ReadFromFile("input.txt");

            // Create a new K-Means algorithm with 3 clusters 
            KMeans kmeans = new KMeans(3);

            // Compute the algorithm, retrieving an integer array
            //  containing the labels for each of the observations
            int[] labels = kmeans.Compute(observations);
            pr.Write(labels);
        }

        public double[][] ReadFromFile(string FileName)
        {
            int rows = 0;
            string tmp;
            char[] sep = { ' ' };
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                rows++;
            }
            double[][] array = new double[rows - 1][];
            fs.Seek(0, SeekOrigin.Begin);
            sr.ReadLine();
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

        public void Write(int [] lables)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("output.txt", false))
            {
                int i = 1;
                while (i != lables.Length)
                {
                    file.WriteLine(i + " element contains in " + lables[i - 1] + " cluster.");
                    i++;
                }
            }
        }
    }
}
