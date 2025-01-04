namespace Day2Part2
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
                var isSafe = CheckForSafety(level, level);
                if (isSafe)
                {
                    safetyCount++;
                }
            }

            Console.WriteLine(safetyCount);
        }

        static bool CheckForSafety(List<int> level, List<int> level2)
        {
         

            var gradualChangeResult = CheckGradualChange(level, out int? problemIndex1);
            var isAllDecreasingOrIncreasingResult = IsAllDecreasingOrIncreasing(level, out int? problemIndex2);

            if (!gradualChangeResult)
            {
                var index = problemIndex1.HasValue ? problemIndex1.Value : 0;
                level.RemoveAt(index);
                gradualChangeResult = CheckGradualChange(level, out int? problemIndex3);
               

                if (!gradualChangeResult)
                {
                 level2.RemoveAt(0);
                 gradualChangeResult = CheckGradualChange(level2, out int? problemIndex6);
                }
                
            }

          else  if (!isAllDecreasingOrIncreasingResult)
            {
                try
                {
                    var index = problemIndex2.HasValue ? problemIndex2.Value : 0;
                    level.RemoveAt(index);
                    isAllDecreasingOrIncreasingResult = IsAllDecreasingOrIncreasing(level, out int? problemIndex4);
                    if (!isAllDecreasingOrIncreasingResult)
                    {
                        level2.RemoveAt(0);
                        isAllDecreasingOrIncreasingResult = IsAllDecreasingOrIncreasing(level2, out int? problemIndex5);
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
               
            }



            return gradualChangeResult & isAllDecreasingOrIncreasingResult;

        }

        static bool CheckGradualChange(List<int> level, out int? problemIndex)
        {
            bool result = true;
            problemIndex = 0;
            for (int i = 1; i < level.Count; i++)
            {
                var adjacentDifference = Math.Abs(level[i] - level[i - 1]);
                if (adjacentDifference > 3)
                {
                    problemIndex = i;
                    result = false;
                    break;
                }
            }
            return result;
        }

        static bool IsAllDecreasingOrIncreasing(List<int> level, out int? problemIndex)
        {
            var result = false;
            problemIndex = 0;
            for (int i = 1; i < level.Count; i++)
            {
                if (level[i] == level[i - 1])
                {
                    continue;
                }
                else if (level[i] < level[i - 1])
                {
                    result = CheckForDecreasingness(level, out int? problemIndex1);
                    problemIndex = problemIndex1;
                    break;
                }
                else
                {
                    result = CheckForIncreasingness(level, out int? problemIndex2);
                    problemIndex = problemIndex2;
                    break;
                }
            }
            return result;

        }

        static bool CheckForIncreasingness(List<int> level, out int? problemIndex)
        {
            bool isAllDecreasing = true;
            problemIndex = 0;
            for (int i = 1; i < level.Count; i++)
            {
                if (!(level[i] > level[i - 1]))
                {
                    isAllDecreasing = false;
                    problemIndex = i;
                    break;
                }
            }
            return isAllDecreasing;
        }

        static bool CheckForDecreasingness(List<int> level, out int? problemIndex)
        {
            bool isAllIncreasing = true;
            problemIndex = 0;
            for (int i = 1; i < level.Count; i++)
            {
                if (!(level[i] < level[i - 1]))
                {
                    isAllIncreasing = false;
                    problemIndex = i;
                    break;
                }
            }
            return isAllIncreasing;

        }
    }
}
