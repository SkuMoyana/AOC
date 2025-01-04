using System.Globalization;
using System.Text;

namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = [.. File.ReadAllLines("input.txt")];
            
            int i = 0;
            while (i< input.Count())
            {
                int testValue = int.Parse(input[i].Split(":")[0]);
                List<int> numbers = (input[i].Split(":")[1]).Split(" ").Where(x=>x != "").Select(x=>int.Parse(x)).ToList();
                int postions = numbers.Count -1;
                double totalOutcomes = Math.Pow(2, postions);
                List<string> possibleSequences = new(); 
               
                for (int j = 0; j < totalOutcomes; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int k = 0; k < postions; k++)
                    {
                        string operatorSymbol = ((i >> (numbers.Count - 2 - k)) & 1) == 0 ? "+" : "*";
                        sb.Append($" {operatorSymbol}");
                    }
                    possibleSequences.Add(sb.ToString());
                }

                i++;
            }


           
        }
    }
}
