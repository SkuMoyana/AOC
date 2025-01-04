namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int safetyCount = 0;
            List<string> input = [.. File.ReadAllLines("input.txt")];
            foreach (var line in input)
            {
                var formattedLine = line.Split(" ");

                List<int> level = formattedLine.Select(x => { return int.Parse(x.ToString()); }).ToList();
                var isSafe = CheckForSafety(level);
                if (isSafe)
                {
                    safetyCount++;
                }
            }

            Console.WriteLine(safetyCount);
        }

        static bool CheckForSafety( List<int> level)
        {
            var result = CheckGradualChange(level) & IsAllDecreasingOrIncreasing(level);
            return result;
        }

        static bool CheckGradualChange(List<int> level)
        {
            bool result = true;
            for (int i = 1; i < level.Count; i++)
            {
                var adjacentDifference = Math.Abs(level[i] - level[i - 1]);
                if (  adjacentDifference > 3)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        static bool IsAllDecreasingOrIncreasing(List<int> level)
        {
            var result = false;
            for (int i = 1; i < level.Count; i++)
            {
                if (level[i] == level[i - 1])
                {
                    continue;
                }else if(level[i] < level[i - 1])
                {
                    result = CheckForDecreasingness(level);
                    break;
                }
                else
                {
                   result = CheckForIncreasingness(level);
                    break;
                }
            }
            return result;

        }

        static bool CheckForIncreasingness(List<int> level)
        {
            bool isAllDecreasing = true;
            for (int i = 1; i < level.Count; i++)
            {
                if (!(level[i] > level[i - 1]))
                {
                    isAllDecreasing = false;
                    break;
                }
            }
          return isAllDecreasing;
        }

        static bool CheckForDecreasingness(List<int> level)
        {
            bool isAllIncreasing = true;
            for (int i = 1; i < level.Count; i++)
            {
                if (!(level[i] < level[i - 1]))
                {
                    isAllIncreasing = false;
                    break;
                }
            }
            return isAllIncreasing;

        }
    }
}
