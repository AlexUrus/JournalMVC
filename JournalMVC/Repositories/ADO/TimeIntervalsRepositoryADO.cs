using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using System.Data;

namespace JournalMVC.Repositories.ADO
{
    public class TimeIntervalsRepositoryADO : BaseRepository, ITimeIntervalsRepository
    {
        private readonly ILogger<TimeIntervalsRepositoryADO> _logger;

        public TimeIntervalsRepositoryADO(ILogger<TimeIntervalsRepositoryADO> logger)
            : base()
        {
            _logger = logger;
        }

        public async Task AddAsync(TimeInterval model)
        {
            string cmdText = $"INSERT INTO TimeIntervals (StartActivity, EndActivity) VALUES ('{model.StartActivity}', '{model.EndActivity}')";

            if (!await ExecuteNonQueryAsync(cmdText))
            {
                var ex = new Exception("Ошибка при добавлении элемента.");
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task DeleteAsync(TimeInterval model)
        {
            string cmdText = $"DELETE FROM TimeIntervals WHERE Id = {model.Id}";

            if (!await ExecuteNonQueryAsync(cmdText))
            {
                var ex = new Exception("Ошибка при удалении элемента.");
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<ICollection<TimeInterval>> GetAsync()
        {
            string cmdText = "SELECT Id, StartActivity, EndActivity FROM TimeIntervals";
            var table = await ExecuteQueryAsync(cmdText);

            if (table == null)
            {
                var ex = new Exception("Ошибка при получении всех элементов.");
                _logger.LogError(ex.Message);
                throw ex;
            }

            var timeIntervals = new List<TimeInterval>();
            foreach (DataRow row in table.Rows)
            {
                var timeInterval = new TimeInterval
                {
                    Id = (int)row["Id"],
                    StartActivity = (TimeSpan)row["StartActivity"],
                    EndActivity = (TimeSpan)row["EndActivity"]
                };
                timeIntervals.Add(timeInterval);
            }

            return timeIntervals;
        }

        public async Task<TimeInterval?> GetAsync(int id)
        {
            string cmdText = $"SELECT Id, StartActivity, EndActivity FROM TimeIntervals WHERE Id = {id}";
            var table = await ExecuteQueryAsync(cmdText);

            if (table == null || table.Rows.Count == 0)
            {
                var ex = new Exception("Ошибка при получении элемента.");
                _logger.LogError(ex.Message);
                throw ex;
            }

            DataRow row = table.Rows[0];
            var timeInterval = new TimeInterval
            {
                Id = (int)row["Id"],
                StartActivity = (TimeSpan)row["StartActivity"],
                EndActivity = (TimeSpan)row["EndActivity"]
            };

            return timeInterval;
        }

        public async Task UpdateAsync(TimeInterval model)
        {
            string cmdText = $"UPDATE TimeIntervals SET StartActivity = '{model.StartActivity}', EndActivity = '{model.EndActivity}' WHERE Id = {model.Id}";

            if (!await ExecuteNonQueryAsync(cmdText))
            {
                var ex = new Exception("Ошибка при обновлении элемента.");
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
