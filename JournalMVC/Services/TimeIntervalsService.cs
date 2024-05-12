using AutoMapper;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services.Interfaces;

namespace JournalMVC.Services
{
    public class TimeIntervalsService : ITimeIntervalsService
    {
        private readonly IMapper _mapper;
        private readonly ITimeIntervalsRepository _timeIntervalsRepository;

        public TimeIntervalsService(IMapper mapper, ITimeIntervalsRepository timeIntervalsRepository)
        {
            _timeIntervalsRepository = timeIntervalsRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(TimeIntervalDTO dTO)
        {
            var obj = _mapper.Map<TimeInterval>(dTO);
            await _timeIntervalsRepository.AddAsync(obj);
        }

        public async Task<ICollection<TimeIntervalDTO>> GetAsync()
        {
            var obj = await _timeIntervalsRepository.GetAsync();
            return _mapper.Map<ICollection<TimeIntervalDTO>>(obj);
        }

        public async Task<TimeIntervalDTO> GetAsync(int id)
        {
            var obj = await _timeIntervalsRepository.GetAsync(id);
            return _mapper.Map<TimeIntervalDTO>(obj);
        }

        public async Task DeleteAsync(TimeIntervalDTO dTO)
        {
            var obj = _mapper.Map<TimeInterval>(dTO);
            await _timeIntervalsRepository.DeleteAsync(obj);
        }

        public async Task UpdateAsync(TimeIntervalDTO dTO)
        {
            var obj = _mapper.Map<TimeInterval>(dTO);
            await _timeIntervalsRepository.UpdateAsync(obj);
        }

        public void Add(TimeIntervalDTO dTO)
        {
            var obj = _mapper.Map<TimeInterval>(dTO);
            _timeIntervalsRepository.Add(obj);
        }

        public ICollection<TimeIntervalDTO> Get()
        {
            var obj = _timeIntervalsRepository.Get();
            return _mapper.Map<ICollection<TimeIntervalDTO>>(obj);
        }

        public TimeIntervalDTO Get(int id)
        {
            var obj = _timeIntervalsRepository.Get(id);
            return _mapper.Map<TimeIntervalDTO>(obj);
        }

        public void Delete(TimeIntervalDTO dTO)
        {
            var obj = _mapper.Map<TimeInterval>(dTO);
            _timeIntervalsRepository.Delete(obj);
        }

        public void Update(TimeIntervalDTO dTO)
        {
            var obj = _mapper.Map<TimeInterval>(dTO);
            _timeIntervalsRepository.Update(obj);
        }
    }

}
