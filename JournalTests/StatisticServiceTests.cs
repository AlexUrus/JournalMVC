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
    public class StatisticServiceTests
    {
        private readonly Mock<IActivitiesRepository> _activityRepositoryMock;
        private readonly StatisticService _statisticService;

        public StatisticServiceTests()
        {
            _activityRepositoryMock = new Mock<IActivitiesRepository>();
            _statisticService = new StatisticService(_activityRepositoryMock.Object);
        }

        [Fact]
        public async Task GetDetailsActivitiesDTOAsync_ShouldReturnDetailsForExistingActivity()
        {
            // Arrange
            var activityId = 1;
            var activityType = new TypeActivity { Id = 1, Name = "Running" };
            var activities = new List<Activity>
        {
            new Activity
            {
                Id = activityId,
                TypeId = activityType.Id,
                Type = activityType,
                DailyRecordId = 1,
                TimeInterval = new TimeInterval
                {
                    StartActivity = new TimeSpan(8, 0, 0),
                     EndActivity = new TimeSpan(9, 0, 0)
                }
            },
            new Activity
            {
                Id = 2,
                TypeId = activityType.Id,
                Type = activityType,
                DailyRecordId = 2,
                TimeInterval = new TimeInterval
                {
                    StartActivity = new TimeSpan(9, 0, 0),
                     EndActivity = new TimeSpan(10, 0, 0)
                }
            }
        };

            _activityRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(activities);

            // Act
            var result = await _statisticService.GetDetailsActivitiesDTOAsync(activityId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(activityId, result.Id);
            Assert.Equal("Running", result.TypeActivity);
            Assert.Equal(TimeSpan.FromMinutes(120), result.TotalTime);
            Assert.Equal(TimeSpan.FromMinutes(60), result.AverrageTimePerDay);
        }

        [Fact]
        public async Task GetDetailsActivitiesDTOAsync_ShouldReturnNullForNonExistentActivity()
        {
            // Arrange
            var activities = new List<Activity>();
            _activityRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(activities);

            // Act
            var result = await _statisticService.GetDetailsActivitiesDTOAsync(1);

            // Assert
            Assert.Null(result);
        }
    }
}
