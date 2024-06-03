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
    public class DailyRecordServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IDailyRecordRepository> _dailyRecordRepositoryMock;
        private readonly DailyRecordService _dailyRecordService;

        public DailyRecordServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _dailyRecordRepositoryMock = new Mock<IDailyRecordRepository>();

            _dailyRecordService = new DailyRecordService(
                _mapperMock.Object,
                _dailyRecordRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnDailyRecordDtos()
        {
            // Arrange
            var dailyRecords = new List<DailyRecord> { new DailyRecord() };
            var dailyRecordDtos = new List<DailyRecordDTO> { new DailyRecordDTO() };

            _dailyRecordRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(dailyRecords);
            _mapperMock.Setup(mapper => mapper.Map<ICollection<DailyRecordDTO>>(dailyRecords)).Returns(dailyRecordDtos);

            // Act
            var result = await _dailyRecordService.GetAsync();

            // Assert
            Assert.Equal(dailyRecordDtos, result);
        }

        [Fact]
        public async Task GetOrCreateDailyRecord_ShouldReturnExistingDailyRecord()
        {
            // Arrange
            var monthlyRecordId = 1;
            var day = 15;
            var dailyRecords = new List<DailyRecord>
            {
                new DailyRecord { Id = 1, Day = day, MonthlyRecordId = monthlyRecordId }
            };
                    var dailyRecordDtos = new List<DailyRecordDTO>
            {
                new DailyRecordDTO { Id = 1, Day = day, MonthlyRecordId = monthlyRecordId }
            };

            _dailyRecordRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(dailyRecords);
            _mapperMock.Setup(mapper => mapper.Map<ICollection<DailyRecordDTO>>(dailyRecords)).Returns(dailyRecordDtos);

            // Act
            var result = await _dailyRecordService.GetOrCreateDailyRecord(monthlyRecordId, day);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dailyRecordDtos.First().Id, result.Id);
            Assert.Equal(dailyRecordDtos.First().Day, result.Day);
            Assert.Equal(dailyRecordDtos.First().MonthlyRecordId, result.MonthlyRecordId);
        }

        [Fact]
        public async Task GetOrCreateDailyRecord_ShouldCreateNewDailyRecord()
        {
            // Arrange
            var monthlyRecordId = 1;
            var day = 15;
            var dailyRecords = new List<DailyRecord>();
            var dailyRecordDtos = new List<DailyRecordDTO>();
            var newDailyRecord = new DailyRecord { Id = 1, Day = day, MonthlyRecordId = monthlyRecordId };
            var newDailyRecordDto = new DailyRecordDTO { Id = 1, Day = day, MonthlyRecordId = monthlyRecordId };

            _dailyRecordRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(dailyRecords);
            _mapperMock.Setup(mapper => mapper.Map<ICollection<DailyRecordDTO>>(dailyRecords)).Returns(dailyRecordDtos);
            _dailyRecordRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<DailyRecord>()))
                .Returns(Task.CompletedTask)
                .Callback<DailyRecord>(dr => dr.Id = 1);
            _dailyRecordRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(newDailyRecord);
            _mapperMock.Setup(mapper => mapper.Map<DailyRecordDTO>(newDailyRecord)).Returns(newDailyRecordDto);

            // Act
            var result = await _dailyRecordService.GetOrCreateDailyRecord(monthlyRecordId, day);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newDailyRecordDto.Id, result.Id);
            Assert.Equal(newDailyRecordDto.Day, result.Day);
            Assert.Equal(newDailyRecordDto.MonthlyRecordId, result.MonthlyRecordId);
        }
    }
}
