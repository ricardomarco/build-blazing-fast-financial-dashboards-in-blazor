namespace FinDashboardBlazor.Models
{
    public class FinancialData
    {
        public int TransactionID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty; // "Income" or "Expense"
        public string Year => Date.Year.ToString();
        public string Month => Date.ToString("MMMM");
        public string Quarter => $"Q{((Date.Month - 1) / 3) + 1}";
        public string Department { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public decimal Variance => Budget - Amount;
        public string Priority { get; set; } = string.Empty;
    }
}
