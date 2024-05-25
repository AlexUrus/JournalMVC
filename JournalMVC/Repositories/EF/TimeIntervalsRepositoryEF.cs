using AutoMapper;
using JournalMVC.Database;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Repositories.EF
{
    public class TimeIntervalsRepositoryEF : ITimeIntervalsRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<TimeIntervalsRepositoryEF> _logger;

        public TimeIntervalsRepositoryEF(ApplicationContext context, ILogger<TimeIntervalsRepositoryEF> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(TimeInterval model)
        {
            try
            {
                await _context.TimeIntervals.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при добавлении элемента.", ex);
            }
        }

        public async Task DeleteAsync(TimeInterval model)
        {
            try
            {
                _context.TimeIntervals.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при удалении элемента.", ex);
            }
        }

        public async Task<ICollection<TimeInterval>> GetAsync()
        {
            try
            {
                var listModels = await _context.TimeIntervals.ToListAsync();

                return listModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при получении всех элементов.", ex);
            }
        }

        public async Task<TimeInterval?> GetAsync(int id)
        {
            try
            {
                var obj = await _context.TimeIntervals.FindAsync(id);

                if (obj != null)
                    return obj;
                else
                    return null;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при получении элемента.", ex);
            }
        }

        public async Task UpdateAsync(TimeInterval model)
        {
            try
            {
                _context.TimeIntervals.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Ошибка при обновлении элемента.", ex);
            }
        }
    }
}
