using JournalMVC.Database;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Repositories.EF
{
    public class DailyRecordRepositoryEF : IDailyRecordRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<DailyRecordRepositoryEF> _logger;

        public DailyRecordRepositoryEF(ApplicationContext context, ILogger<DailyRecordRepositoryEF> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(DailyRecord model)
        {
            try
            {
                await _context.DailyRecords.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при добавлении элемента.", ex);
            }
        }

        public async Task<DailyRecord?> GetAsync(int id)
        {
            try
            {
                var obj = await _context.DailyRecords
                    .Include(d => d.Activities)
                        .ThenInclude(a => a.Type)
                    .Include(d => d.Activities)
                        .ThenInclude(a => a.TimeInterval)
                    .Include(d => d.MonthlyRecord)
                    .Where(d => d.Id == id)
                    .FirstOrDefaultAsync();

                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при получении всех элементов.", ex);
            }
        }

        public async Task<ICollection<DailyRecord>> GetAsync()
        {
            try
            {
                var listObjects = await _context.DailyRecords
                    .Include(d => d.Activities)
                        .ThenInclude(a => a.Type)
                    .Include(d => d.Activities)
                        .ThenInclude(a => a.TimeInterval)
                    .Include(d => d.MonthlyRecord)
                    .ToListAsync();

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
