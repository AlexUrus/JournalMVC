using AutoMapper;
using JournalMVC.CustomException;
using JournalMVC.Database;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Repositories
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ActivitiesRepository> _logger;

        public ActivitiesRepository(ApplicationContext context, ILogger<ActivitiesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Activity model)
        {
            try
            {
                _context.Activities.Add(model);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public async Task AddAsync(Activity model)
        {
            try
            {
                await _context.Activities.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public void Delete(Activity model)
        {
            try
            {
                _context.Activities.Remove(model);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public async Task DeleteAsync(Activity model)
        {
            try
            {
                _context.Activities.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public ICollection<Activity> Get()
        {
            try
            {
                var listObjects = _context.Activities.Include(d => d.TimeInterval)
                                                       .Include(d => d.Type)
                                                       .ToList();
                
                return listObjects;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }

        public async Task<ICollection<Activity>> GetAsync()
        {
            try
            {
                var listObjects = await _context.Activities.Include(d => d.TimeInterval)
                                                       .Include(d => d.Type)
                                                       .ToListAsync();

                return listObjects;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }

        public Activity? Get(int id)
        {
            try
            {
                var obj = _context.Activities.Find(id);

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

        public async Task<Activity?> GetAsync(int id)
        {
            try
            {
                var obj = await _context.Activities.FindAsync(id);

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

        public void Update(Activity model)
        {
            try
            {
                _context.Activities.Update(model);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }

        public async Task UpdateAsync(Activity model)
        {
            try
            {
                _context.Activities.Update(model);
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
