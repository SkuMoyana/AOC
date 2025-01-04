namespace Day5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> input = [.. File.ReadAllLines("input.txt")];

            List<string> rules = new();
            List<string> updates = new();


            foreach (string line in input)
            {
                if (line.Contains("|"))
                {
                    rules.Add(line);
                }
                else if (line.Contains(","))
                {
                    updates.Add(line);
                }
            }

            int validUpdatesCount = 0;
            List<string> validUpdates = new();

            foreach (string update in updates)
            {
                if (IsUpdateValid(rules, update))
                {
                    Console.WriteLine(update);
                    validUpdatesCount++;
                    validUpdates.Add(update);
                }

               
            }

            int total = 0;
            foreach (string update in validUpdates)
            {
                int[] pages = update.Split(',').Select(x=> { return int.Parse(x); }).ToArray();
                int midIndex = (pages.Length + 1)/2;
                total += pages[midIndex - 1];
            }



            Console.WriteLine(validUpdatesCount.ToString());
            Console.WriteLine(total.ToString());

        }

        static bool IsUpdateValid(List<string> rules, string update)
        {
            var response = true;

            List<int> pages = update.Split(",").Select(x => int.Parse(x)).ToList();

            int i = 0;
            int pageCount = pages.Count();
            while (i  < pages.Count())
            {
                var applicableRules = rules.Where(x => x.Contains(pages[i].ToString())).Select(x => x).ToList();

                var pagesBeforeCurrentPage = pages.TakeWhile((value, index) => index < i).ToList();
                var pagesAfterCurrentPage = pages.Where((value, index) => index > i).ToList();

                var currentPage = pages[i];

                foreach (var rule in applicableRules)
                {
                    var startingPage = rule.Split("|")[0];
                    var successivePage = rule.Split("|")[1];

                    if (currentPage == int.Parse(startingPage))
                    {
                        if (pagesBeforeCurrentPage.Contains(int.Parse(successivePage)))
                        {
                            return false;
                        }
                    }

                    else if (currentPage == int.Parse(successivePage))
                    {
                        if (pagesAfterCurrentPage.Contains(int.Parse(successivePage)))
                         {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }

                i++;
            }

            return response;


        }
    }
}
