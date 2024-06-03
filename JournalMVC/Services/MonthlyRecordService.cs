using AutoMapper;
using Humanizer;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services.Interfaces;

namespace JournalMVC.Services
{
    public class MonthlyRecordService : IMonthlyRecordService
    {
        private readonly IMapper _mapper;
        private readonly IMonthlyRecordRepository _monthlyRecordRepository;

        public MonthlyRecordService(IMapper mapper, IMonthlyRecordRepository monthlyRecordRepository)
        {
            _monthlyRecordRepository = monthlyRecordRepository;
            _mapper = mapper;
        }

        public async Task<MonthlyRecordDTO> GetOrCreateMonthlyRecord(int month)
        {
            var monthlyRecords = await _monthlyRecordRepository.GetAsync();
            var monthlyRecordDtos = _mapper.Map<ICollection<MonthlyRecordDTO>>(monthlyRecords);
            var currMonthlyRecordDto = monthlyRecordDtos.FirstOrDefault(m => m.Month == month);

            if (currMonthlyRecordDto == null)
            {
                var newMonthlyRecord = new MonthlyRecord { Month = month };
                await _monthlyRecordRepository.AddAsync(newMonthlyRecord);
                newMonthlyRecord = await _monthlyRecordRepository.GetAsync(newMonthlyRecord.Id);
                currMonthlyRecordDto = _mapper.Map<MonthlyRecordDTO>(newMonthlyRecord);
            }

            return currMonthlyRecordDto;
        }

    }
}
