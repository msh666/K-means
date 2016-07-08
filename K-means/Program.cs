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
            Calculation calc = new Calculation();
            FileProcessing fp = new FileProcessing();
            fp.InputName = "input.txt";
            fp.OutputName = "output.txt";
            int clusterNum;
            double[][] observations = fp.ReadFromFile(out clusterNum);
            int[] labels = calc.CalculateKMeans(clusterNum, observations);
            fp.Write(labels);      
        }       
    }
}
