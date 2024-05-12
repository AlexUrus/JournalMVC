using AutoMapper;
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

        public ActivitiesService(IMapper mapper, IActivitiesRepository activityRepository)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public void Add(ActivityDTO dTO)
        {
            var obj = _mapper.Map<Activity>(dTO);
            _activityRepository.Add(obj);
        }

        public ICollection<ActivityDTO> Get()
        {
            var obj = _activityRepository.Get();
            return _mapper.Map<ICollection<ActivityDTO>>(obj);
        }

        public ActivityDTO Get(int id)
        {
            var obj = _activityRepository.Get(id);
            return _mapper.Map<ActivityDTO>(obj);
        }

        public void Delete(ActivityDTO dTO)
        {
            var obj = _mapper.Map<Activity>(dTO);
            _activityRepository.Delete(obj);
        }

        public void Update(ActivityDTO dTO)
        {
            var obj = _mapper.Map<Activity>(dTO);
            _activityRepository.Update(obj);
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

        public async Task DeleteAsync(ActivityDTO dTO)
        {
            var obj = _mapper.Map<Activity>(dTO);

            await _activityRepository.DeleteAsync(obj);
        }

        public async Task UpdateAsync(ActivityDTO dTO)
        {
            var obj = _mapper.Map<Activity>(dTO);

            await _activityRepository.UpdateAsync(obj);
        }

    }
}
