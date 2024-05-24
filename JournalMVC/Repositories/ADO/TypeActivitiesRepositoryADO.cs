using JournalMVC.CustomException;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace JournalMVC.Repositories.ADO
{
    public class TypeActivitiesRepositoryADO : BaseRepository, ITypeActivitiesRepository
    {
        private readonly ILogger<TypeActivitiesRepositoryADO> _logger;

        public TypeActivitiesRepositoryADO(ILogger<TypeActivitiesRepositoryADO> logger) : base()
        {
            _logger = logger;
        }

        public void Add(TypeActivity model)
        {
            try
            {
                string cmdText = $"INSERT INTO TypeActivities (Name) VALUES ('{model.Name}')";

                if (!ExecuteNonQuery(cmdText))
                {
                    throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public async Task AddAsync(TypeActivity model)
        {
            try
            {
                string cmdText = $"INSERT INTO TypeActivities (Name) VALUES ('{model.Name}')";

                if (!await ExecuteNonQueryAsync(cmdText))
                {
                    throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при добавлении элемента.", ex);
            }
        }

        public void Delete(TypeActivity model)
        {
            try
            {
                string cmdText = $"DELETE FROM TypeActivities WHERE Id = {model.Id}";

                if (!ExecuteNonQuery(cmdText))
                {
                    throw new ActivitiesRepositoryException("Ошибка при удалении элемента.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public async Task DeleteAsync(TypeActivity model)
        {
            try
            {
                string cmdText = $"DELETE FROM TypeActivities WHERE Id = {model.Id}";

                if (!await ExecuteNonQueryAsync(cmdText))
                {
                    throw new ActivitiesRepositoryException("Ошибка при удалении элемента.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при удалении элемента.", ex);
            }
        }

        public TypeActivity? Get(int id)
        {
            try
            {
                string cmdText = $"SELECT Id, Name FROM TypeActivities WHERE Id = {id}";
                var table = ExecuteQuery(cmdText);

                if (table != null && table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    return new TypeActivity
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"].ToString()
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при получении элемента.", ex);
            }
        }

        public async Task<TypeActivity?> GetAsync(int id)
        {
            try
            {
                string cmdText = $"SELECT Id, Name FROM TypeActivities WHERE Id = {id}";
                var table = await ExecuteQueryAsync(cmdText);

                if (table != null && table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    return new TypeActivity
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"].ToString()
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при получении элемента.", ex);
            }
        }

        public ICollection<TypeActivity> Get()
        {
            try
            {
                string cmdText = "SELECT Id, Name FROM TypeActivities";
                var table = ExecuteQuery(cmdText);

                var typeActivities = new List<TypeActivity>();
                foreach (DataRow row in table.Rows)
                {
                    typeActivities.Add(new TypeActivity
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"].ToString()
                    });
                }

                return typeActivities;
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
                string cmdText = "SELECT Id, Name FROM TypeActivities";
                var table = await ExecuteQueryAsync(cmdText);

                var typeActivities = new List<TypeActivity>();
                foreach (DataRow row in table.Rows)
                {
                    typeActivities.Add(new TypeActivity
                    {
                        Id = (int)row["Id"],
                        Name = row["Name"].ToString()
                    });
                }

                return typeActivities;
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
                string cmdText = $"UPDATE TypeActivities SET Name = '{model.Name}' WHERE Id = {model.Id}";

                if (!ExecuteNonQuery(cmdText))
                {
                    throw new ActivitiesRepositoryException("Ошибка при обновлении элемента.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }

        public async Task UpdateAsync(TypeActivity model)
        {
            try
            {
                string cmdText = $"UPDATE TypeActivities SET Name = '{model.Name}' WHERE Id = {model.Id}";

                if (!await ExecuteNonQueryAsync(cmdText))
                {
                    throw new ActivitiesRepositoryException("Ошибка при обновлении элемента.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ActivitiesRepositoryException("Ошибка при обновлении элемента.", ex);
            }
        }
    }
}
