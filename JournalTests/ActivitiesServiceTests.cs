using AutoMapper;
using JournalMVC.DTO;
using JournalMVC.Models;
using JournalMVC.Repositories.Interfaces;
using JournalMVC.Services;
using JournalMVC.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace JournalTests
{
    public class ActivitiesServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IActivitiesRepository> _activityRepositoryMock;
        private readonly Mock<IDailyRecordService> _dailyRecordServiceMock;
        private readonly Mock<IMonthlyRecordService> _monthlyRecordServiceMock;
        private readonly ActivitiesService _activitiesService;

        public ActivitiesServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _activityRepositoryMock = new Mock<IActivitiesRepository>();
            _dailyRecordServiceMock = new Mock<IDailyRecordService>();
            _monthlyRecordServiceMock = new Mock<IMonthlyRecordService>();

            _activitiesService = new ActivitiesService(
                _mapperMock.Object,
                _activityRepositoryMock.Object,
                _dailyRecordServiceMock.Object,
                _monthlyRecordServiceMock.Object);
        }

        [Fact]
        public async Task CreateActivity_ShouldCallDependenciesCorrectly()
        {
            // Arrange
            var activityDto = new ActivityDTO();
            var month = 5;
            var day = 15;
            var monthlyRecord = new MonthlyRecordDTO { Id = 1 };
            var dailyRecord = new DailyRecordDTO { Id = 1 };

            _monthlyRecordServiceMock.Setup(m => m.GetOrCreateMonthlyRecord(month)).ReturnsAsync(monthlyRecord);
            _dailyRecordServiceMock.Setup(m => m.GetOrCreateDailyRecord(monthlyRecord.Id, day)).ReturnsAsync(dailyRecord);

            // Act
            await _activitiesService.CreateActivity(activityDto, month, day);

            // Assert
            _monthlyRecordServiceMock.Verify(m => m.GetOrCreateMonthlyRecord(month), Times.Once);
            _dailyRecordServiceMock.Verify(m => m.GetOrCreateDailyRecord(monthlyRecord.Id, day), Times.Once);
            _activityRepositoryMock.Verify(a => a.AddAsync(It.IsAny<Activity>()), Times.Once);
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var activityDto = new ActivityDTO();
            var activity = new Activity();

            _mapperMock.Setup(m => m.Map<Activity>(activityDto)).Returns(activity);

            // Act
            await _activitiesService.AddAsync(activityDto);

            // Assert
            _activityRepositoryMock.Verify(a => a.AddAsync(activity), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnActivityDtos()
        {
            // Arrange
            var activities = new List<Activity> { new Activity() };
            var activityDtos = new List<ActivityDTO> { new ActivityDTO() };

            _activityRepositoryMock.Setup(a => a.GetAsync()).ReturnsAsync(activities);
            _mapperMock.Setup(m => m.Map<ICollection<ActivityDTO>>(activities)).Returns(activityDtos);

            // Act
            var result = await _activitiesService.GetAsync();

            // Assert
            Assert.Equal(activityDtos, result);
        }

        [Fact]
        public async Task GetAsync_ById_ShouldReturnActivityDto()
        {
            // Arrange
            var activity = new Activity();
            var activityDto = new ActivityDTO();
            var id = 1;

            _activityRepositoryMock.Setup(a => a.GetAsync(id)).ReturnsAsync(activity);
            _mapperMock.Setup(m => m.Map<ActivityDTO>(activity)).Returns(activityDto);

            // Act
            var result = await _activitiesService.GetAsync(id);

            // Assert
            Assert.Equal(activityDto, result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync()
        {
            // Arrange
            var activity = new Activity();
            var id = 1;

            _activityRepositoryMock.Setup(a => a.GetAsync(id)).ReturnsAsync(activity);

            // Act
            await _activitiesService.DeleteAsync(id);

            // Assert
            _activityRepositoryMock.Verify(a => a.DeleteAsync(activity), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepositoryUpdateAsync()
        {
            // Arrange
            var activityDto = new ActivityDTO();
            var activity = new Activity();

            _mapperMock.Setup(m => m.Map<Activity>(activityDto)).Returns(activity);

            // Act
            await _activitiesService.UpdateAsync(activityDto);

            // Assert
            _activityRepositoryMock.Verify(a => a.UpdateAsync(activity), Times.Once);
        }

        [Fact]
        public async Task InitializeCurrentMonthAndDay_ShouldCallDependenciesCorrectly()
        {
            // Arrange
            var currentMonth = DateTime.Now.Month;
            var currentDay = DateTime.Now.Day;
            var monthlyRecord = new MonthlyRecordDTO { Id = 1 };

            _monthlyRecordServiceMock.Setup(m => m.GetOrCreateMonthlyRecord(currentMonth)).ReturnsAsync(monthlyRecord);
            _dailyRecordServiceMock.Setup(m => m.GetOrCreateDailyRecord(monthlyRecord.Id, currentDay)).ReturnsAsync(new DailyRecordDTO());

            // Act
            await _activitiesService.InitializeCurrentMonthAndDay();

            // Assert
            _monthlyRecordServiceMock.Verify(m => m.GetOrCreateMonthlyRecord(currentMonth), Times.Once);
            _dailyRecordServiceMock.Verify(m => m.GetOrCreateDailyRecord(monthlyRecord.Id, currentDay), Times.Once);
        }

        [Fact]
        public async Task GetActivitiesByDateAsync_ShouldReturnActivitiesByDate()
        {
            // Arrange
            var date = new DateTime(2024, 5, 27);
            var month = date.Month;
            var day = date.Day;
            var monthlyRecord = new MonthlyRecordDTO { Id = 1 };
            var dailyRecord = new DailyRecordDTO { Id = 1, Activities = new List<ActivityDTO>() };

            _monthlyRecordServiceMock.Setup(m => m.GetOrCreateMonthlyRecord(month)).ReturnsAsync(monthlyRecord);
            _dailyRecordServiceMock.Setup(m => m.GetOrCreateDailyRecord(monthlyRecord.Id, day)).ReturnsAsync(dailyRecord);

            // Act
            var result = await _activitiesService.GetActivitiesByDateAsync(date);

            // Assert
            Assert.Equal(dailyRecord.Activities, result);
        }
    }
}
