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
    public class TypeActivitiesServiceTests
    {
        private readonly Mock<ITypeActivitiesRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly TypeActivitiesService _service;

        public TypeActivitiesServiceTests()
        {
            _repositoryMock = new Mock<ITypeActivitiesRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TypeActivity, TypeActivityDTO>().ReverseMap();
            });

            _mapper = config.CreateMapper();
            _service = new TypeActivitiesService(_mapper, _repositoryMock.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddTypeActivity()
        {
            // Arrange
            var typeActivityDto = new TypeActivityDTO
            {
                Id = 1,
                Name = "Спорт"
            };

            // Act
            await _service.AddAsync(typeActivityDto);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<TypeActivity>()), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnAllTypeActivities()
        {
            // Arrange
            var typeActivities = new List<TypeActivity> 
            {  
                new TypeActivity()
                 {
                     Id = 1,
                     Name = "Спорт"
                 },
                 new TypeActivity()
                 {
                     Id = 2,
                     Name = "Чтение"
                 }
            };
            _repositoryMock.Setup(repo => repo.GetAsync()).ReturnsAsync(typeActivities);

            // Act
            var result = await _service.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeActivities.Count, result.Count);
        }

        [Fact]
        public async Task GetAsync_ById_ShouldReturnTypeActivity()
        {
            // Arrange
            var typeActivity = new TypeActivity
            {
                Id = 3,
                Name = "Путешествия"
            };
            _repositoryMock.Setup(repo => repo.GetAsync(3)).ReturnsAsync(typeActivity);

            // Act
            var result = await _service.GetAsync(3);

            // Assert
            Assert.NotNull(result);
            // Add specific assertions here based on TypeActivityDTO properties
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateTypeActivity()
        {
            // Arrange
            var typeActivityDto = new TypeActivityDTO 
            {
                Id = 1,
                Name = "Спорт"
            };

            // Act
            await _service.UpdateAsync(typeActivityDto);

            // Assert
            _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<TypeActivity>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteTypeActivity()
        {
            // Arrange
            var typeActivity = new TypeActivity 
            {
                Id = 1,
                Name = "Спорт"
            };
            _repositoryMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(typeActivity);

            // Act
            await _service.DeleteAsync(1);

            // Assert
            _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<TypeActivity>()), Times.Once);
        }
    }
}

