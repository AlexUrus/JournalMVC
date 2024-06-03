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
    public class TimeIntervalsServiceTests
    {
        private readonly Mock<ITimeIntervalsRepository> _timeIntervalsRepositoryMock;
        private readonly IMapper _mapper;
        private readonly TimeIntervalsService _timeIntervalsService;

        public TimeIntervalsServiceTests()
        {
            _timeIntervalsRepositoryMock = new Mock<ITimeIntervalsRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TimeInterval, TimeIntervalDTO>()
                    .ForMember(dest => dest.StartActivity, opt => opt.MapFrom(src => DateTime.Today.Add(src.StartActivity)))
                    .ForMember(dest => dest.EndActivity, opt => opt.MapFrom(src => DateTime.Today.Add(src.EndActivity)));

                cfg.CreateMap<TimeIntervalDTO, TimeInterval>()
                   .ForMember(dest => dest.StartActivity, opt => opt.MapFrom(src => src.StartActivity.TimeOfDay))
                   .ForMember(dest => dest.EndActivity, opt => opt.MapFrom(src => src.EndActivity.TimeOfDay));
            });

            _mapper = config.CreateMapper();
            _timeIntervalsService = new TimeIntervalsService(_mapper, _timeIntervalsRepositoryMock.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddTimeInterval()
        {
            // Arrange
            var timeIntervalDto = new TimeIntervalDTO
            {
                StartActivity = DateTime.Now,
                EndActivity = DateTime.Now.AddHours(1)
            };

            // Act
            await _timeIntervalsService.AddAsync(timeIntervalDto);

            // Assert
            _timeIntervalsRepositoryMock.Verify(repo => repo.AddAsync(It.Is<TimeInterval>(t =>
                t.StartActivity.Minutes == timeIntervalDto.StartActivity.Minute &&
                t.EndActivity.Minutes == timeIntervalDto.EndActivity.Minute)), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnAllTimeIntervals()
        {
            // Arrange
            var timeIntervals = new List<TimeInterval>
        {
            new TimeInterval { Id = 1, StartActivity = new TimeSpan(8, 0, 0), EndActivity = new TimeSpan(9, 0, 0) },
            new TimeInterval { Id = 2, StartActivity = new TimeSpan(10, 0, 0), EndActivity = new TimeSpan(11, 0, 0) }
        };

            _timeIntervalsRepositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(timeIntervals);

            // Act
            var result = await _timeIntervalsService.GetAsync();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetAsync_ById_ShouldReturnTimeInterval()
        {
            // Arrange
            var timeInterval = new TimeInterval { Id = 1, StartActivity = new TimeSpan(10, 0, 0), EndActivity = new TimeSpan(11, 0, 0) };

            _timeIntervalsRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(timeInterval);

            // Act
            var result = await _timeIntervalsService.GetAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateTimeInterval()
        {
            // Arrange
            var timeIntervalDto = new TimeIntervalDTO
            {
                Id = 1,
                StartActivity = DateTime.Now,
                EndActivity = DateTime.Now.AddHours(1)
            };

            // Act
            await _timeIntervalsService.UpdateAsync(timeIntervalDto);

            // Assert
            _timeIntervalsRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<TimeInterval>(t =>
                t.Id == timeIntervalDto.Id &&
                t.StartActivity.Minutes == timeIntervalDto.StartActivity.Minute &&
                t.EndActivity.Minutes == timeIntervalDto.EndActivity.Minute)), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteTimeInterval()
        {
            // Arrange
            var timeInterval = new TimeInterval { Id = 1, StartActivity = new TimeSpan(10, 0, 0), EndActivity = new TimeSpan(11, 0, 0) };

            _timeIntervalsRepositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(timeInterval);

            // Act
            await _timeIntervalsService.DeleteAsync(1);

            // Assert
            _timeIntervalsRepositoryMock.Verify(repo => repo.DeleteAsync(It.Is<TimeInterval>(t => t.Id == 1)), Times.Once);
        }
    }
}
