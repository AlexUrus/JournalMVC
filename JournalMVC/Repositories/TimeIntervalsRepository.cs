using AutoMapper;
using JournalMVC.CustomException;
using JournalMVC.Database;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Repositories
{
    public class TimeIntervalsRepository : ITimeIntervalsRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<TimeIntervalsRepository> _logger;

        public TimeIntervalsRepository(ApplicationContext context, ILogger<TimeIntervalsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(TimeInterval model)
        {
            try
            {
                _context.TimeIntervals.Add(model);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.", ex);
            }
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
                throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public void Delete(TimeInterval model)
        {
            try
            {
                _context.TimeIntervals.Remove(model);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при удалении элемента.", ex);
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
                throw new ActivitiesRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public ICollection<TimeInterval> Get()
        {
            try
            {
                var listModels = _context.TimeIntervals.ToList();

                return listModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при получении всех элементов.", ex);
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
                throw new ActivitiesRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }

        public TimeInterval? Get(int id)
        {
            try
            {
                var obj = _context.TimeIntervals.Find(id);

                if (obj != null)
                    return obj;
                else
                    return null;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при получении элемента.", ex);
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
                throw new ActivitiesRepositoryException("Ошибка при получении элемента.", ex);
            }
        }

        public void Update(TimeInterval model)
        {
            try
            {
                _context.TimeIntervals.Update(model);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при обновлении элемента.", ex);
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
                throw new ActivitiesRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }
    }
}
