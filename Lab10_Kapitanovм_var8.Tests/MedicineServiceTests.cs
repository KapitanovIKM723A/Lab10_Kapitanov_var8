using System.Collections.Generic;
using System.Threading.Tasks;
using Lab10_Kapitanov_var8.Application.Services;
using Lab10_Kapitanov_var8.Domain.Entities;
using Lab10_Kapitanov_var8.Domain.Interfaces;
using Moq;
using Xunit;
using FluentAssertions;

namespace Lab10_Kapitanov_var8.Tests.Services
{
    public class MedicineServiceTests
    {
        private readonly Mock<IMedicineRepository> _repoMock;
        private readonly MedicineService _service;

        public MedicineServiceTests()
        {
            _repoMock = new Mock<IMedicineRepository>();
            _service = new MedicineService(_repoMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_Returns_AllMedicines()
        {
            var medicines = new List<Medicine>
            {
                new Medicine { Id = 1, Name = "A", Price = 10 },
                new Medicine { Id = 2, Name = "B", Price = 20 }
            };
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(medicines);

            var result = await _service.GetAllAsync();

            result.Should().BeEquivalentTo(medicines);
            _repoMock.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task AddAsync_Calls_RepositoryAdd()
        {
            var med = new Medicine { Id = 3, Name = "C", Price = 30 };

            await _service.AddAsync(med);

            _repoMock.Verify(r => r.AddAsync(med), Times.Once);
        }

    }
}
