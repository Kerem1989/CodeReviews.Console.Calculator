using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorHistory history = new CalculatorHistory(0);
            CalculatorHistoryService historyService = new CalculatorHistoryService();
            List<CalculatorHistory> calculatorHistories = new List<CalculatorHistory>();
            bool runSession = true;
            Calculator calculator = new Calculator();

            while (runSession)
            {
                Console.WriteLine("Welcome to the Calculator. What do you want to do?");
                Console.WriteLine(
                    "Press 1 to perform a calculation, press 2 to view the history of results, or press 3 to view the amount of operations performed so far, press 4 to clear the history and press 5 to exit.");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RunCalculationSession(calculator, history, historyService, calculatorHistories);
                        break;
                    case "2":
                        historyService.ViewLatestResultHistory(calculatorHistories);
                        break;
                    case "3":
                        historyService.DisplayHistory(history);
                        break;
                    case "4":
                        historyService.ClearHistory(calculatorHistories);
                        break;
                    case "5":
                        runSession = false;
                        calculator.Finish();
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Error: Invalid input.");
                        break;
                }
            }
        }

        private static void RunCalculationSession(Calculator calculator, CalculatorHistory history,
            CalculatorHistoryService historyService, List<CalculatorHistory> calculatorHistories)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;
            double cleanNum1 = 0;
            double cleanNum2 = 0;


            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }


            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\tr - Square Root");
            Console.WriteLine("\tp - Taking the power");
            Console.Write("Your option? ");

            string? op = Console.ReadLine();

            if (op == null || !Regex.IsMatch(op, "[a|s|m|d|r|p]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    historyService.AddOperationToHistory(history);
                    CalculatorHistory temporaryHistory = new CalculatorHistory();
                    temporaryHistory.LatestResult = result;
                    historyService.SaveLatestResult(temporaryHistory, calculatorHistories);

                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " +
                                      e.Message);
                }
            }
            Console.WriteLine("\n");
        }
    }
}