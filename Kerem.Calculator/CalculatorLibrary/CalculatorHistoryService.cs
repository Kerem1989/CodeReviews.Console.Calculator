namespace CalculatorLibrary ;

    public class CalculatorHistoryService
    {
        public void AddOperationToHistory(CalculatorHistory history)
        {
            history.AmountOfOperations++;
        }
        
        public void DisplayHistory(CalculatorHistory history)
        {
            if (history.AmountOfOperations == 0)
            {
                Console.WriteLine("No operations performed so far.");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine($"History: {history.AmountOfOperations} operations performed so far.");
                Console.WriteLine("\n");

            }
        }
        
        public void SaveLatestResult(CalculatorHistory latestResult, List <CalculatorHistory> latestCalculations)
        {
            latestCalculations.Add(latestResult);
        }
        
        public void ViewLatestResultHistory(List <CalculatorHistory> latestCalculations)
        {
            Console.WriteLine("\n");
            if (latestCalculations.Count == 0)
            {
                Console.WriteLine("No results to display.");
                Console.WriteLine("\n");

            }
            else
            {
                Console.WriteLine("Latest results:");
                int row = 1;
                foreach (var calculation in latestCalculations)
                {
                    Console.WriteLine($"{row}. {calculation.LatestResult}");
                    row++;
                }
                Console.WriteLine("\n");
            }
        }
        public void ClearHistory(List <CalculatorHistory> latestCalculations)
        {
            latestCalculations.Clear();
            Console.WriteLine("History cleared.");
            Console.WriteLine("\n");
        }
    }