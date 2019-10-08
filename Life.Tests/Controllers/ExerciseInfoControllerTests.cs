using Life.Application.Services.Exercise.DTO;
using Life.Application.Services.Interfaces.Exercise;
using Life.Controllers;
using Life.Core.Domain.Exercise;
using Life.Tests.ServiceMocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Life.Tests.Controllers
{
    public class ExerciseInfoControllerTests
    {
        [Fact]
        public async Task Index_ReturnAViewResult_WithAListOfExersiceInfoDTOobjects()
        {
            // Arrange
            var exerciseService = new ExerciseServiceMocks();
            var mockService = new Mock<IExerciseService>();
            mockService.Setup(service => service.GetAllAsync())
                .ReturnsAsync(exerciseService.GetExerciseInfoList());
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Index();

            //Arange
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ExerciseInfoDTO>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task Details_ReturnAViewResult_WithAExerciseInfoDTobject_WhenValidIDisGiven()
        {
            // Arrange
            var id = 1;
            var exerciseService = new ExerciseServiceMocks();
            var mockService = new Mock<IExerciseService>();
            mockService.Setup(service => service.GetByIdAsync(id))
                .ReturnsAsync(exerciseService.GetByIdAsync(id));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Details(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ExerciseInfoDTO>(
                viewResult.ViewData.Model);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async Task Details_ReturnNotFound__WhenInValidIDisGiven()
        {
            // Arrange
            var id = 100;
            var exerciseService = new ExerciseServiceMocks();
            var mockService = new Mock<IExerciseService>();
            mockService.Setup(service => service.GetByIdAsync(id))
                .ReturnsAsync(exerciseService.GetByIdAsync(id));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Details(id);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Details_ReturnNotFound__WhenNullisGiven()
        {
            // Arrange
            var mockService = new Mock<IExerciseService>();
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Details(null);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnAViewResult()
        {
            // Arrange
            var mockService = new Mock<IExerciseService>();
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task CreatePost_ReturnAViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var exerciseService = new ExerciseServiceMocks();
            var mockService = new Mock<IExerciseService>();

            var controller = new ExercisesInfoController(mockService.Object);
            controller.ModelState.AddModelError("Invalid model", "Title contains ...");
            var exerciseInfo = new ExerciseInfoDTO()
            {
                ExerciseType = ExerciseType.Cardio,
                Description = "",
                Title = "Spinning"
            };
            // Act
            var result = await controller.Create(exerciseInfo: exerciseInfo);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ExerciseInfoDTO>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public async Task CreatePost_ReturnRedirectToAction_WhenModelStateIsValid()
        {
            // Arrange

            var exerciseService = new ExerciseServiceMocks();
            var mockService = new Mock<IExerciseService>();
            mockService.Setup(service => service.AddAsync(It.IsAny<ExerciseInfoDTO>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new ExercisesInfoController(mockService.Object);
            var exerciseInfo = new ExerciseInfoDTO()
            {
                ExerciseType = ExerciseType.Cardio,
                Description = "",
                Title = "Spinning"
            };

            // Act
            var result = await controller.Create(exerciseInfo);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockService.Verify();
        }

        [Fact]
        public async Task Edit_ReturnAViewResult_WithAExerciseInfoDTobject_WhenValidIDisGiven()
        {
            // Arrange
            var id = 2;
            var exerciseService = new ExerciseServiceMocks();
            var mockService = new Mock<IExerciseService>();
            mockService.Setup(service => service.GetByIdAsync(id))
                .ReturnsAsync(exerciseService.GetByIdAsync(id));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Edit(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ExerciseInfoDTO>(
                viewResult.ViewData.Model);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async Task Edit_ReturnNotFound__WhenInValidIDisGiven()
        {
            // Arrange
            var id = 100;
            var exerciseService = new ExerciseServiceMocks();
            var mockService = new Mock<IExerciseService>();
            mockService.Setup(service => service.GetByIdAsync(id))
                .ReturnsAsync(exerciseService.GetByIdAsync(id));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Details(id);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Edit_ReturnNotFound__WhenNullisGiven()
        {
            // Arrange
            var mockService = new Mock<IExerciseService>();
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Edit(null);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditPost_ReturnNotFound_WhenRouteIdDoesNotMatchModelId()
        {
            // Arrange
            var exerciseService = new ExerciseServiceMocks();
            var mockService = new Mock<IExerciseService>();
            var controller = new ExercisesInfoController(mockService.Object);
            int routId = 1;
            var exerciseInfo = new ExerciseInfoDTO()
            {
                ExerciseType = ExerciseType.Cardio,
                Description = "",
                Title = "Spinning",
                Id = 100
            };

            // Act
            var result = await controller.Edit(routId, exerciseInfo);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditPost_ReturnAViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var exerciseService = new ExerciseServiceMocks();
            var mockService = new Mock<IExerciseService>();

            var controller = new ExercisesInfoController(mockService.Object);
            controller.ModelState.AddModelError("Invalid model", "Title contains ...");
            int routeId = 1;
            var exerciseInfo = new ExerciseInfoDTO()
            {
                ExerciseType = ExerciseType.Cardio,
                Description = "",
                Title = "Spinning",
                Id = 1
            };
            // Act
            var result = await controller.Edit(routeId, exerciseInfo);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ExerciseInfoDTO>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public async Task EditPost_ReturnARedirectToAction_WhenModelStateIsValid()
        {
            // Arrange
            var mockService = new Mock<IExerciseService>();
            mockService.Setup(service => service.Update(It.IsAny<ExerciseInfoDTO>()))
                .Verifiable();
            var controller = new ExercisesInfoController(mockService.Object);
            int routeId = 1;
            var exerciseInfo = new ExerciseInfoDTO()
            {
                ExerciseType = ExerciseType.Cardio,
                Description = "",
                Title = "Spinning",
                Id =1
            };

            // Act
            var result = await controller.Edit(routeId,exerciseInfo);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockService.Verify();
        }

    }
}
