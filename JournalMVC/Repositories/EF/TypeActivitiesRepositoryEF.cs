using AutoMapper;
using JournalMVC.Database;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Repositories.EF
{
    public class TypeActivitiesRepositoryEF : ITypeActivitiesRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<TypeActivitiesRepositoryEF> _logger;

        public TypeActivitiesRepositoryEF(ApplicationContext context, ILogger<TypeActivitiesRepositoryEF> logger)
        {
            _context = context;
            _logger = logger;
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
                throw new Exception("Ошибка при добавлении элемента.", ex);
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
                throw new Exception("Ошибка при удалении элемента.", ex);
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
                throw new Exception("Ошибка при получении элемента.", ex);
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
                throw new Exception("Ошибка при получении всех элементов.", ex);
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
                throw new Exception("Ошибка при обновлении элемента.", ex);
            }
        }
    }
}
