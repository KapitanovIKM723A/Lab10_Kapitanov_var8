using System.Collections.Generic;
using System.Threading.Tasks;
using Lab10_Kapitanov_var8.API.Controllers;
using Lab10_Kapitanov_var8.Application.Services;
using Lab10_Kapitanov_var8.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;

namespace Lab10_Kapitanov_var8.Tests.Controllers
{
    public class MedicinesControllerTests
    {
        private readonly Mock<IMedicineService> _svcMock;
        private readonly MedicinesController _controller;

        public MedicinesControllerTests()
        {
            _svcMock = new Mock<IMedicineService>();
            _controller = new MedicinesController(_svcMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithList()
        {

            var list = new List<Medicine> { new Medicine { Id = 1, Name = "X" } };
            _svcMock.Setup(s => s.GetAllAsync()).ReturnsAsync(list);

            var actionResult = await _controller.GetAll();

            var okResult = actionResult as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(list);
        }

        [Fact]
        public async Task Get_ByInvalidId_ReturnsNotFound()
        {
            _svcMock.Setup(s => s.GetByIdAsync(99)).ReturnsAsync((Medicine?)null);

            var actionResult = await _controller.Get(99);

            actionResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtAction()
        {

            var med = new Medicine { Id = 5, Name = "New" };

            var result = await _controller.Create(med);

            var created = result as CreatedAtActionResult;
            created.Should().NotBeNull();
            created!.ActionName.Should().Be(nameof(_controller.Get));
            created.RouteValues!["id"].Should().Be(med.Id);
            created.Value.Should().Be(med);
            _svcMock.Verify(s => s.AddAsync(med), Times.Once);
        }

    }
}
