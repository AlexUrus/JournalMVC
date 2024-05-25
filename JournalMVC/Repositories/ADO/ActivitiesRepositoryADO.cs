using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace JournalMVC.Repositories.ADO
{
    public class ActivitiesRepositoryADO : BaseRepository, IActivitiesRepository
    {
        private readonly ILogger<ActivitiesRepositoryADO> _logger;

        public ActivitiesRepositoryADO(ILogger<ActivitiesRepositoryADO> logger)
            : base()
        {
            _logger = logger;
        }
        public async Task AddAsync(Activity model)
        {
            string cmdText = $"INSERT INTO Activities (TypeId, TimeIntervalId, Description) VALUES ({model.TypeId}, {model.TimeIntervalId}, '{model.Description.Replace("'", "''")}')";

            if (!await ExecuteNonQueryAsync(cmdText))
            {
                var ex = new Exception("Ошибка при добавлении элемента.");
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task DeleteAsync(Activity model)
        {
            string cmdText = $"DELETE FROM Activities WHERE Id = {model.Id}";

            if (!await ExecuteNonQueryAsync(cmdText))
            {
                var ex = new Exception("Ошибка при удалении элемента.");
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
        public async Task<ICollection<Activity>> GetAsync()
        {
            string cmdText = @"
        SELECT 
            Activities.Id, 
            Activities.TypeId, 
            Type.Name AS TypeName, 
            Activities.TimeIntervalId, 
            Time.StartActivity, 
            Time.EndActivity, 
            Activities.Description 
        FROM 
            Activities
        JOIN 
            TypeActivities AS Type ON Activities.TypeId = Type.Id
        JOIN 
            TimeIntervals AS Time ON Activities.TimeIntervalId = Time.Id";

            var table = await ExecuteQueryAsync(cmdText);

            if (table == null)
            {
                var ex = new Exception("Ошибка при получении всех элементов.");
                _logger.LogError(ex.Message);
                throw ex;
            }

            var activities = new List<Activity>();
            foreach (DataRow row in table.Rows)
            {
                var activity = new Activity
                {
                    Id = (int)row["Id"],
                    TypeId = (int)row["TypeId"],
                    Type = new TypeActivity() { Id = (int)row["TypeId"], Name = (string)row["TypeName"] },
                    TimeIntervalId = (int)row["TimeIntervalId"],
                    TimeInterval = new TimeInterval() { Id = (int)row["TimeIntervalId"], StartActivity = (TimeSpan)row["StartActivity"], EndActivity = (TimeSpan)row["EndActivity"] },
                    Description = row["Description"].ToString()
                };
                activities.Add(activity);
            }

            return activities;
        }

        public async Task<Activity?> GetAsync(int id)
        {
            string cmdText = @$"
        SELECT 
            Activities.Id, 
            Activities.TypeId, 
            Type.Name AS TypeName, 
            Activities.TimeIntervalId, 
            Time.StartActivity, 
            Time.EndActivity, 
            Activities.Description 
        FROM 
            Activities
        JOIN 
            TypeActivities AS Type ON Activities.TypeId = Type.Id
        JOIN 
            TimeIntervals AS Time ON Activities.TimeIntervalId = Time.Id
        WHERE 
            Id = {id}";
            var table = await ExecuteQueryAsync(cmdText);

            if (table == null || table.Rows.Count == 0)
            {
                var ex = new Exception("Ошибка при получении элемента.");
                _logger.LogError(ex.Message);
                throw ex;
            }

            DataRow row = table.Rows[0];
            var activity = new Activity
            {
                Id = (int)row["Id"],
                TypeId = (int)row["TypeId"],
                Type = new TypeActivity() { Id = (int)row["TypeId"], Name = (string)row["TypeName"] },
                TimeIntervalId = (int)row["TimeIntervalId"],
                TimeInterval = new TimeInterval() { Id = (int)row["TimeIntervalId"], StartActivity = (TimeSpan)row["StartActivity"], EndActivity = (TimeSpan)row["EndActivity"] },
                Description = row["Description"].ToString()
            };

            return activity;
        }

        public async Task UpdateAsync(Activity model)
        {
            string cmdText = $"UPDATE Activities SET TypeId = {model.TypeId}, TimeIntervalId = {model.TimeIntervalId}, Description = '{model.Description.Replace("'", "''")}' WHERE Id = {model.Id}";

            if (!await ExecuteNonQueryAsync(cmdText))
            {
                var ex = new Exception("Ошибка при обновлении элемента.");
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
