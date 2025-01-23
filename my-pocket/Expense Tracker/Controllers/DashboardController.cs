using 
    MY_POCKET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MY_POCKET
{
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            // Last 7 Days Transactions
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions
            .Include(x => x.Category)
            .Where(y => y.Date >= StartDate && y.Date <= EndDate)
            .ToListAsync();

            // Calculate Total Income Last 7 Days
            int TotalIncome = await _context.Transactions
            .Include(x => x.Category)
            .Where(i => i.Category.Type == "Income")
            .SumAsync(i => i.Amount);
            ViewBag.TotalIncome = $"{TotalIncome:N2} DH";

            // Calculate Total Expense Last 7 Days
            int TotalExpense = await _context.Transactions
            .Where(i => i.Category.Type == "Expense")
            .SumAsync(i => i.Amount);
            ViewBag.TotalExpense = $"{TotalExpense:N2} DH";

            // Balance
            int Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = $"{Balance:N2} DH";


            // Recente 5 Transactions
            ViewBag.RecentTransactions = await _context.Transactions
            .Include(i => i.Category)
            .OrderByDescending(i => i.Date)
            .Take(5)
            .ToListAsync();
            // Group data for the chart: Category-wise totals
            var categoryData = await _context.Transactions
                .Include(t => t.Category)
                .GroupBy(t => t.Category.Title)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(t => t.Amount)
                }).ToListAsync();

            ViewBag.CategoryLabels = categoryData.Select(c => c.Category).ToArray(); // Chart labels
            ViewBag.CategoryTotals = categoryData.Select(c => c.Total).ToArray();

            return View();
        }
    }
}