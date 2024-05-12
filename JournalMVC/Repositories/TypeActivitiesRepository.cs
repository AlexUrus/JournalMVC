using AutoMapper;
using JournalMVC.CustomException;
using JournalMVC.Database;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Repositories
{
    public class TypeActivitiesRepository : ITypeActivitiesRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<TypeActivitiesRepository> _logger;

        public TypeActivitiesRepository(ApplicationContext context, ILogger<TypeActivitiesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(TypeActivity model)
        {
            try
            {
                _context.TypeActivities.Add(model);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public async Task AddAsync(TypeActivity model)
        {
            try
            {
                await _context.TypeActivities.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public void Delete(TypeActivity model)
        {
            try
            {
                _context.TypeActivities.Remove(model);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public async Task DeleteAsync(TypeActivity model)
        {
            try
            {
                _context.TypeActivities.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public TypeActivity? Get(int id)
        {
            try
            {
                var obj = _context.TypeActivities.Find(id);

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
        public async Task<TypeActivity?> GetAsync(int id)
        {
            try
            {
                var obj = await _context.TypeActivities.FindAsync(id);

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

        public ICollection<TypeActivity> Get()
        {
            try
            {
                var listModels = _context.TypeActivities.ToList();

                return listModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }
        public async Task<ICollection<TypeActivity>> GetAsync()
        {
            try
            {
                var listModels = await _context.TypeActivities.ToListAsync();

                return listModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при получении всех элементов.", ex);
            }
        }

        public void Update(TypeActivity model)
        {
            try
            {
                _context.TypeActivities.Update(model);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }

        public async Task UpdateAsync(TypeActivity model)
        {
            try
            {
                _context.TypeActivities.Update(model);
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
