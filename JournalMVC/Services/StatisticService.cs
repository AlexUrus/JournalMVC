using AutoMapper;
using JournalMVC.DTO;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services.Interfaces;

namespace JournalMVC.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IActivitiesRepository _activityRepository;
        public StatisticService(IActivitiesRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<DetailsActivitiesDTO?> GetDetailsActivitiesDTOAsync(int id)
        {
            var activities = await _activityRepository.GetAsync();
            var activity = activities.FirstOrDefault(activity => activity.Id == id);

            if (activity == null)
            {
                return null;
            }

            var filteredActivities = activities.Where(a => a.TypeId == activity.TypeId);

            var totalTime = filteredActivities
                .Select(a => (a.TimeInterval.EndActivity - a.TimeInterval.StartActivity).TotalMinutes)
                .Sum();
            var averageTimePerDay = filteredActivities
                .GroupBy(a => a.DailyRecordId) 
                .Select(g => g.Sum(a => (a.TimeInterval.EndActivity - a.TimeInterval.StartActivity).TotalMinutes))
                .Average();

            var details = new DetailsActivitiesDTO()
            {
                Id = id,
                TypeActivity = activity.Type.Name,
                AverrageTimePerDay = TimeSpan.FromMinutes(averageTimePerDay),
                TotalTime = TimeSpan.FromMinutes(totalTime)
            };

            return details;
        }
    }
}
