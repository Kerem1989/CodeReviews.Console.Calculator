namespace CalculatorLibrary ;

    public class CalculatorHistory
    {

        private double _latestResult;
        private int _amountOfOperations;
        
        public int AmountOfOperations { get; set; }
        
        public double LatestResult { get; set; }
        
        public CalculatorHistory()
        {
            
        }
        
        public CalculatorHistory(int amountOfOperations, int latestResult)
        {
            this._amountOfOperations = amountOfOperations;
        }

        public CalculatorHistory(double latestresult)
        {
            this._latestResult = latestresult;
        }
    }