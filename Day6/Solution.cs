namespace Day6
{
    internal class Solution
    {
        private const string guard = "^";
        List<List<string>> lines = [];
        int steps = 0;
        int x = 0, y = 0;
        List<string> positions = new();
        
        public int FindSteps()
        {

            List<string> input = [.. File.ReadAllLines("input.txt")];
            lines = input.Select(x =>
            {
                var charArray = x.ToCharArray().ToList();
                return charArray.Select(x => x.ToString()).ToList();
            }).ToList();


            int i = 0;
            while (i < lines.Count)
            {

                if (lines[i].Contains(guard))
                {
                    int guardPosition = lines[i].IndexOf(guard);
                    y = i; x = guardPosition;
                    break;

                }

                i++;
            }

            GoUp();
      
            return positions.Distinct().Count();
        }

        void GoUp()
        {
            for (int row = y-1; row >= 0; row--)
            {
                if (lines[row][x].Contains('#'))
                {
                    this.y = row + 1;
                    GoEast();
                    break;
                }
                else
                {
                    positions.Add($"{row}&{x}");
                    this.steps++;
                }


            }
        }

        void GoEast()
        {
            for (int column = x+1; column < lines[y].Count() ; column++)
            {
                if (lines[y][column].Contains('#'))
                {
                    this.x = column - 1;
                    GoDown();
                    break;
                }
                else
                {
                    this.steps++;
                    positions.Add($"{y}&{column}");
                }


            }
        }

        void GoDown()
        {
            for (int row = y+1; row < lines.Count(); row++)
            {
                if (lines[row][x].Contains('#'))
                {
                    this.y = row - 1;
                    GoWest();
                    break;
                }
                else
                {
                    this.steps++;
                    positions.Add($"{row}&{x}");
                }


            }
        }

        void GoWest()
        {
            for (int column = x-1; column >= 0; column--)
            {
                if (lines[y][column].Contains('#'))
                {
                    this.x = column + 1;
                    GoUp();
                    break;
                }
                else
                {
                    this.steps++;
                    positions.Add($"{y}&{column}");
                }


            }
        }

    }
}
