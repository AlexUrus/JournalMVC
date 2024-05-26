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
                currMonthlyRecordDto = new MonthlyRecordDTO { Month = month };
                await _monthlyRecordRepository.AddAsync(_mapper.Map<MonthlyRecord>(currMonthlyRecordDto));
                currMonthlyRecordDto = await GetOrCreateMonthlyRecord(month);
            }

            return _mapper.Map<MonthlyRecordDTO>(await _monthlyRecordRepository.GetAsync(currMonthlyRecordDto.Id));
        }

    }
}
