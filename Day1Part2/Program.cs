namespace Day1Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> leftList = new();
            List<int> rigthList = new();

            List<string> input = [.. File.ReadAllLines("input.txt")];
            foreach (string line in input)
            {
                string leftItem = line.Split("   ")[0];
                leftList.Add(int.Parse(leftItem));

                string rigthItem = line.Split("   ")[1];
                rigthList.Add(int.Parse(rigthItem));
            }

            int total = 0;
            for (int i = 0; i < leftList.Count; i++)
            {
                var occurrence = rigthList.Where(x=>x == leftList[i]).Select(x=>x).Count();
                var similarity = leftList[i] * occurrence;
                total += similarity;
            }

            Console.WriteLine(total);
        }
    }
}
