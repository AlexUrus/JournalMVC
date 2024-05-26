using JournalMVC.Database;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Repositories.EF
{
    public class MonthlyRecordRepositoryEF : IMonthlyRecordRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<MonthlyRecordRepositoryEF> _logger;

        public MonthlyRecordRepositoryEF(ApplicationContext context, ILogger<MonthlyRecordRepositoryEF> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(MonthlyRecord model)
        {
            try
            {
                await _context.MonthlyRecords.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при добавлении элемента.", ex);
            }
        }

        public async Task<MonthlyRecord?> GetAsync(int id)
        {
            try
            {
                var obj = await _context.MonthlyRecords.Include(d => d.DailyRecords).FirstOrDefaultAsync();

                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при получении всех элементов.", ex);
            }
        }

        public async Task<ICollection<MonthlyRecord>> GetAsync()
        {
            try
            {
                var listObjects = await _context.MonthlyRecords.Include(d => d.DailyRecords).ToListAsync();

                return listObjects;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при получении всех элементов.", ex);
            }
        }
    }
}
