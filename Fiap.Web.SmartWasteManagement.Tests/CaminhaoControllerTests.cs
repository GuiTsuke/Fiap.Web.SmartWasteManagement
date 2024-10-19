using System.Collections.Generic;
using AutoMapper;
using Fiap.Web.SmartWasteManagement.Controllers;
using Fiap.Web.SmartWasteManagement.Models;
using Fiap.Web.SmartWasteManagement.Services;
using Fiap.Web.SmartWasteManagement.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Web.SmartWasteManagement.Tests.Controllers
{
    public class CaminhaoControllerTests
    {
        private readonly Mock<ICaminhaoService> _caminhaoServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CaminhaoController _controller;

        public CaminhaoControllerTests()
        {
            _caminhaoServiceMock = new Mock<ICaminhaoService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new CaminhaoController(_mapperMock.Object, _caminhaoServiceMock.Object);
        }

        [Fact]
        public void Index_ReturnsViewWithCaminhoes()
        {
            // Arrange
            var caminhaoModels = new List<CaminhaoModel>
            {
                new CaminhaoModel { Codigo = 1 },
                new CaminhaoModel { Codigo = 2 }
            };
            var caminhaoViewModels = new List<CaminhaoViewModel>
            {
                new CaminhaoViewModel { Codigo = 1 },
                new CaminhaoViewModel { Codigo = 2 }
            };

            _caminhaoServiceMock.Setup(s => s.ListarCaminhoesSemPage()).Returns(caminhaoModels);
            _mapperMock.Setup(m => m.Map<IEnumerable<CaminhaoViewModel>>(It.IsAny<IEnumerable<CaminhaoModel>>())).Returns(caminhaoViewModels);
       
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result!.ViewData.Model.Should().BeEquivalentTo(caminhaoViewModels);
        }

        [Fact]
        public void Create_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var caminhaoViewModel = new CaminhaoViewModel { Codigo = 1 };
            var caminhaoModel = new CaminhaoModel { Codigo = 1 };

            _mapperMock.Setup(m => m.Map<CaminhaoModel>(caminhaoViewModel)).Returns(caminhaoModel);
            _controller.ModelState.Clear(); // Simula um modelo válido

            // Act
            var result = _controller.Create(caminhaoViewModel) as RedirectToActionResult;

            // Assert
            _caminhaoServiceMock.Verify(s => s.CriarCaminhao(caminhaoModel), Times.Once);
            result.Should().NotBeNull();
            result!.ActionName.Should().Be("Index");
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenCaminhaoDoesNotExist()
        {
            // Arrange
            int caminhaoId = 1;
            _caminhaoServiceMock.Setup(s => s.ObterCaminhaoPorId(caminhaoId)).Returns((CaminhaoModel) new CaminhaoModel());

            // Act
            var result = _controller.Details(caminhaoId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void Edit_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var caminhaoViewModel = new CaminhaoViewModel { Codigo = 1 };
            var caminhaoModel = new CaminhaoModel { Codigo = 1 };

            _mapperMock.Setup(m => m.Map<CaminhaoModel>(caminhaoViewModel)).Returns(caminhaoModel);
            _controller.ModelState.Clear(); // Simula um modelo válido

            // Act
            var result = _controller.Edit(caminhaoViewModel) as RedirectToActionResult;

            // Assert
            _caminhaoServiceMock.Verify(s => s.AtualizarCaminhao(caminhaoModel), Times.Once);
            result.Should().NotBeNull();
            result!.ActionName.Should().Be("Index");
        }

        [Fact]
        public void DeleteConfirmed_DeletesCaminhaoAndRedirectsToIndex()
        {
            // Arrange
            int caminhaoId = 1;
            _caminhaoServiceMock.Setup(s => s.ObterCaminhaoPorId(caminhaoId)).Returns(new CaminhaoModel());

            // Act
            var result = _controller.DeleteConfirmed(caminhaoId) as RedirectToActionResult;

            // Assert
            _caminhaoServiceMock.Verify(s => s.DeletarCaminhao(caminhaoId), Times.Once);
            result.Should().NotBeNull();
            result!.ActionName.Should().Be("Index");
        }
    }
}
