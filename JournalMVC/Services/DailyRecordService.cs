using AutoMapper;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services.Interfaces;

namespace JournalMVC.Services
{
    public class DailyRecordService : IDailyRecordService
    {
        private readonly IMapper _mapper;
        private readonly IDailyRecordRepository _dailyRecordRepository;

        public DailyRecordService(IMapper mapper, IDailyRecordRepository dailyRecordRepository)
        {
            _dailyRecordRepository = dailyRecordRepository;
            _mapper = mapper;

        }

        public async Task<ICollection<DailyRecordDTO>> GetAsync()
        {
            var obj = await _dailyRecordRepository.GetAsync();

            return _mapper.Map<ICollection<DailyRecordDTO>>(obj);
        }

        public async Task<DailyRecordDTO> GetOrCreateDailyRecord(int monthlyRecordId, int day)
        {
            var dailyRecords = await _dailyRecordRepository.GetAsync();
            var dailyRecordDtos = _mapper.Map<ICollection<DailyRecordDTO>>(dailyRecords);
            var currDailyRecordDto = dailyRecordDtos.FirstOrDefault(d => d.Day == day && d.MonthlyRecordId == monthlyRecordId);

            if (currDailyRecordDto == null)
            {
                var newDailyRecord = new DailyRecord
                {
                    Day = day,
                    MonthlyRecordId = monthlyRecordId
                };
                await _dailyRecordRepository.AddAsync(newDailyRecord);
                newDailyRecord = await _dailyRecordRepository.GetAsync(newDailyRecord.Id);
                currDailyRecordDto = _mapper.Map<DailyRecordDTO>(newDailyRecord);
            }

            return currDailyRecordDto;
        }
    }
}
