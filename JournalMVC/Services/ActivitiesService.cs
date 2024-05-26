using AutoMapper;
using Humanizer;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services.Interfaces;

namespace JournalMVC.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activityRepository;
        private readonly IDailyRecordService _dailyRecordService;
        private readonly IMonthlyRecordService _montlyRecordService;

        public ActivitiesService(IMapper mapper, IActivitiesRepository activityRepository,
            IDailyRecordService dailyRecordRepository, IMonthlyRecordService montlyRecordRepository)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
            _dailyRecordService = dailyRecordRepository;
            _montlyRecordService = montlyRecordRepository;
        }

        public async Task CreateActivity(ActivityDTO dTO, int month, int day)
        {
            var currMonthlyRecord = await _montlyRecordService.GetOrCreateMonthlyRecord(month);
            var currDailyRecord = await _dailyRecordService.GetOrCreateDailyRecord(currMonthlyRecord.Id, day);

            dTO.DailyRecordId = currDailyRecord.Id;
            await AddAsync(dTO);
        }

        public async Task AddAsync(ActivityDTO dTO)
        {
            var obj = _mapper.Map<Activity>(dTO);

            await _activityRepository.AddAsync(obj);
        }

        public async Task<ICollection<ActivityDTO>> GetAsync() 
        { 
            var obj = await _activityRepository.GetAsync();

            return _mapper.Map<ICollection<ActivityDTO>>(obj);
        }

        public async Task<ActivityDTO> GetAsync(int id)
        {
            var obj = await _activityRepository.GetAsync(id);

            return _mapper.Map<ActivityDTO>(obj);
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await _activityRepository.GetAsync(id);
            await _activityRepository.DeleteAsync(obj);
        }

        public async Task UpdateAsync(ActivityDTO dTO)
        {
            var obj = _mapper.Map<Activity>(dTO);

            await _activityRepository.UpdateAsync(obj);
        }

        public async Task InitializeCurrentMonthAndDay()
        {
            var currentMonth = DateTime.Now.Month;
            var currentDay = DateTime.Now.Day;

            var currMonthlyRecord = await _montlyRecordService.GetOrCreateMonthlyRecord(currentMonth);
            await _dailyRecordService.GetOrCreateDailyRecord(currMonthlyRecord.Id, currentDay);
        }

        public async Task<ICollection<ActivityDTO>> GetActivitiesByDateAsync(DateTime date)
        {
            var currentMonth = date.Month;
            var currentDay = date.Day;

            var currMonthlyRecord = await _montlyRecordService.GetOrCreateMonthlyRecord(currentMonth);
            var currDailyRecord = await _dailyRecordService.GetOrCreateDailyRecord(currMonthlyRecord.Id, currentDay);

            return currDailyRecord.Activities;
        }

    }
}
