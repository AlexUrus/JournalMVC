using AutoMapper;
using JournalMVC.DTO;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services.Interfaces;

namespace JournalMVC.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activityRepository;
        private readonly ITimeIntervalsRepository _timeIntervalsRepository;
        private readonly ITypeActivitiesRepository _typeActivitiesRepository;

        public StatisticService(IMapper mapper, IActivitiesRepository activityRepository, ITimeIntervalsRepository timeIntervalsRepository, 
            ITypeActivitiesRepository typeActivitiesRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
            _timeIntervalsRepository = timeIntervalsRepository;
            _typeActivitiesRepository = typeActivitiesRepository;
        }

        public async Task<DetailsActivitiesDTO?> GetDetailsActivitiesDTOAsync(int id)
        {
            var activities = await _activityRepository.GetAsync();
            var activity = activities.FirstOrDefault(activity => activity.Id == id);

            if (activity == null)
            {
                // Handle the case where the activity with the given ID is not found
                return null;
            }

            var filteredActivities = activities.Where(a => a.TypeId == activity.TypeId);

            var averageTimePerDay = filteredActivities
                .Select(a => (a.TimeInterval.EndActivity - a.TimeInterval.StartActivity).TotalMinutes)
                .Average();

            var details = new DetailsActivitiesDTO()
            {
                Id = id,
                TypeActivity = activity.Type.Name,
                AverrageTimePerDay = TimeSpan.FromMinutes(averageTimePerDay)
            };

            return details;
        }
    }
}
