namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> leftList = new();
           List<int> rigthList = new();

           List<string> input = [.. File.ReadAllLines("input.txt")];
           foreach(string line in input)
            {
                string leftItem = line.Split("   ")[0];
                leftList.Add(int.Parse(leftItem));

                string rigthItem = line.Split("   ")[1];
                rigthList.Add(int.Parse(rigthItem));
            }

           leftList.Sort();
           rigthList.Sort();

            int total = 0;

            for (int i = 0; i < leftList.Count; i++)
            {
                var distance = Math.Abs(leftList[i] - rigthList[i]);
                total += distance;
            }

            Console.WriteLine(total.ToString());


        }
    }
}
