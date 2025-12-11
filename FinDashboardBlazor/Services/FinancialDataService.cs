using FinDashboardBlazor.Models;

namespace FinDashboardBlazor.Services
{
    public class FinancialDataService
    {
        private readonly List<FinancialData> _transactions;

        public FinancialDataService()
        {
            _transactions = GenerateFinancialData();
        }

        public List<FinancialData> GetFinancialData()
        {
            return _transactions;
        }

        private List<FinancialData> GenerateFinancialData()
        {
            var data = new List<FinancialData>();
            var random = new Random();
            var categories = new[] { "Software", "Hardware", "Marketing", "Travel", "Office", "Training", "Sales", "Operations" };
            var departments = new[] { "IT", "Marketing", "Sales", "HR", "Finance", "Operations", "R&D" };
            var regions = new[] { "North America", "Europe", "Asia Pacific", "Latin America", "Africa" };
            var statuses = new[] { "Approved", "Pending", "Rejected", "Processing" };
            var priorities = new[] { "High", "Medium", "Low", "Critical" };
            var descriptions = new[]
            {
        "Office supplies", "Software license", "Marketing campaign", "Business travel",
        "Equipment purchase", "Training session", "Consulting fees", "Maintenance",
        "Client meeting", "Product development", "Research", "Infrastructure"
    };

            for (int i = 1; i <= 100; i++)
            {
                var isIncome = random.Next(0, 10) < 3; // 30% chance of income
                var baseAmount = isIncome ? random.Next(5000, 50000) : random.Next(100, 5000);
                var budgetVariance = random.Next(80, 120) / 100.0m; // ±20% variance

                data.Add(new FinancialData
                {
                    TransactionID = i,
                    Date = DateTime.Now.AddDays(-random.Next(1, 730)), // 2 years of data
                    Description = descriptions[random.Next(descriptions.Length)],
                    Category = categories[random.Next(categories.Length)],
                    Department = departments[random.Next(departments.Length)],
                    Region = regions[random.Next(regions.Length)],
                    Status = statuses[random.Next(statuses.Length)],
                    Priority = priorities[random.Next(priorities.Length)],
                    Amount = baseAmount,
                    Budget = baseAmount * budgetVariance,
                    Type = isIncome ? "Income" : "Expense"
                });
            }

            return data.OrderByDescending(d => d.Date).ToList();
        }

    }
}
