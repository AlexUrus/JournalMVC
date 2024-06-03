using AutoMapper;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalTests
{
    public class MonthlyRecordServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMonthlyRecordRepository> _monthlyRecordRepositoryMock;
        private readonly MonthlyRecordService _monthlyRecordService;

        public MonthlyRecordServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _monthlyRecordRepositoryMock = new Mock<IMonthlyRecordRepository>();

            _monthlyRecordService = new MonthlyRecordService(
                _mapperMock.Object,
                _monthlyRecordRepositoryMock.Object);
        }

        [Fact]
        public async Task GetOrCreateMonthlyRecord_ShouldReturnExistingMonthlyRecord()
        {
            // Arrange
            var month = 5;
            var monthlyRecords = new List<MonthlyRecord>
            {
                new() { Id = 1, Month = month }
            };
                    var monthlyRecordDtos = new List<MonthlyRecordDTO>
            {
                new() { Id = 1, Month = month }
            };

            _monthlyRecordRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(monthlyRecords);
            _monthlyRecordRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(monthlyRecords.First());
            _mapperMock.Setup(mapper => mapper.Map<ICollection<MonthlyRecordDTO>>(monthlyRecords)).Returns(monthlyRecordDtos);
            _mapperMock.Setup(mapper => mapper.Map<MonthlyRecordDTO>(It.IsAny<MonthlyRecord>())).Returns((MonthlyRecord src) =>
                monthlyRecordDtos.FirstOrDefault(dto => dto.Id == src.Id));

            // Act
            var result = await _monthlyRecordService.GetOrCreateMonthlyRecord(month);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(monthlyRecordDtos.First().Id, result.Id);
            Assert.Equal(monthlyRecordDtos.First().Month, result.Month);
        }

        [Fact]
        public async Task GetOrCreateMonthlyRecord_ShouldCreateNewMonthlyRecord()
        {
            // Arrange
            var month = 5;
            var monthlyRecords = new List<MonthlyRecord>();
            var monthlyRecordDtos = new List<MonthlyRecordDTO>();
            var newMonthlyRecord = new MonthlyRecord { Id = 1, Month = month };
            var newMonthlyRecordDto = new MonthlyRecordDTO { Id = 1, Month = month };

            _monthlyRecordRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(monthlyRecords);
            _mapperMock.Setup(mapper => mapper.Map<ICollection<MonthlyRecordDTO>>(monthlyRecords)).Returns(monthlyRecordDtos);
            _monthlyRecordRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<MonthlyRecord>()))
                .Returns(Task.CompletedTask)
                .Callback<MonthlyRecord>(mr => mr.Id = 1);
            _monthlyRecordRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(newMonthlyRecord);
            _mapperMock.Setup(mapper => mapper.Map<MonthlyRecordDTO>(It.IsAny<MonthlyRecord>())).Returns(newMonthlyRecordDto);

            // Act
            var result = await _monthlyRecordService.GetOrCreateMonthlyRecord(month);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newMonthlyRecordDto.Id, result.Id);
            Assert.Equal(newMonthlyRecordDto.Month, result.Month);
        }
    }
}
