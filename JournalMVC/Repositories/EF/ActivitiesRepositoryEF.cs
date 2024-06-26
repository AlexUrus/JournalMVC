﻿using AutoMapper;
using JournalMVC.Database;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Repositories.EF
{
    public class ActivitiesRepositoryEF : IActivitiesRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ActivitiesRepositoryEF> _logger;

        public ActivitiesRepositoryEF(ApplicationContext context, ILogger<ActivitiesRepositoryEF> logger)
        {
            _context = context;
            _logger = logger;
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
                throw new Exception("Ошибка при добавлении элемента.", ex);
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
                throw new Exception("Ошибка при удалении элемента.", ex);
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
                throw new Exception("Ошибка при получении всех элементов.", ex);
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
                throw new Exception("Ошибка при получении элемента.", ex);
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
                throw new Exception("Ошибка при обновлении элемента.", ex);
            }
        }
    }
}
