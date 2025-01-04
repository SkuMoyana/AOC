using System.Text;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            string input = File.ReadAllText("input.txt");
            List<string> commandsStartLines = input.Split("mul(").ToList();
            foreach (string command in commandsStartLines)
            {

              total = total +  ValidateCommand(command);
            }

            Console.WriteLine(total);
        }

        static int ValidateCommand(string command)
        {
            int firstNumber, secondNumber;
            int product = 0;

            var firstInt = command.Split(",")[0];
            if(firstInt.Contains(" ")) {
                return product;
            }
            if (int.TryParse(firstInt, out firstNumber))
            {
                var firstIntRemainder = command.Split(",")[1];
                var secondInt = firstIntRemainder.Split(")")[0];
                if(secondInt != null)
                {
                    if(secondInt.Contains(" "))
                    {
                        return product;
                    }

                    if(int.TryParse(secondInt, out secondNumber))
                    {
                        product = firstNumber * secondNumber;
                    }
                }
            }
            return product;
        }
    }
}
