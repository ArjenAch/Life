using Life.Application.Mapping.DTO;
using Life.Application.Services.Exercises.DTO;
using Life.Application.Services.Interfaces.Exercises;
using Life.Controllers;
using Life.Core.Domain.Exercises;
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
        #region Index

        [Fact]
        public async Task Index_ReturnAViewResult_WithAListOfExersiceInfoDTOobjects()
        {
            // Arrange
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
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

        #endregion
        #region Details

        [Fact]
        public async Task Details_ReturnAViewResult_WithAExerciseInfoDTobject_WhenValidIDisGiven()
        {
            // Arrange
            var id = 1;
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
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
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
            mockService.Setup(service => service.GetByIdAsync(id))
                .ReturnsAsync(exerciseService.GetByIdAsync(id));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Details_ReturnNotFound__WhenNullisGiven()
        {
            // Arrange
            var mockService = new Mock<IExerciseInfoService>();
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion
        #region Create

        [Fact]
        public void Create_ReturnAViewResult()
        {
            // Arrange
            var mockService = new Mock<IExerciseInfoService>();
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task CreatePost_ReturnAViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockService = new Mock<IExerciseInfoService>();

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
            Assert.IsAssignableFrom<ExerciseInfoDTO>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public async Task CreatePost_ReturnRedirectToAction_WhenModelStateIsValid()
        {
            // Arrange
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
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
        #endregion
        #region Edit

        [Fact]
        public async Task Edit_ReturnAViewResult_WithAExerciseInfoDTobject_WhenValidIDisGiven()
        {
            // Arrange
            var id = 2;
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
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
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
            mockService.Setup(service => service.GetByIdAsync(id))
                .ReturnsAsync(exerciseService.GetByIdAsync(id));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Edit_ReturnNotFound__WhenNullisGiven()
        {
            // Arrange
            var mockService = new Mock<IExerciseInfoService>();
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Edit(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditPost_ReturnNotFound_WhenRouteIdDoesNotMatchModelId()
        {
            // Arrange
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
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
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditPost_ReturnAViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockService = new Mock<IExerciseInfoService>();

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
            Assert.IsAssignableFrom<ExerciseInfoDTO>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public async Task EditPost_ReturnARedirectToAction_WhenModelStateIsValid()
        {
            // Arrange
            var mockService = new Mock<IExerciseInfoService>();
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
        #endregion
        #region Delete

        [Fact]
        public async Task Delete_ReturnAViewResult_WithAExerciseInfoDTobject_WhenValidIDisGiven()
        {
            // Arrange
            var id = 1;
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
            mockService.Setup(service => service.GetByIdAsync(id))
                .ReturnsAsync(exerciseService.GetByIdAsync(id));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Delete(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ExerciseInfoDTO>(
                viewResult.ViewData.Model);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async Task Delete_ReturnNotFound__WhenInValidIDisGiven()
        {
            // Arrange
            var id = 100;
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
            mockService.Setup(service => service.GetByIdAsync(id))
                .ReturnsAsync(exerciseService.GetByIdAsync(id));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Details(id);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task Delete_ReturnNotFound_WhenIdIsNull()
        {
            // Arrange
            var mockService = new Mock<IExerciseInfoService>();
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.Delete(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteConfirmed_ReturnRedirectAction()
        {
            // Arrange
            int id = 1;
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
            mockService.Setup(service => service.RemoveAsync(id))
                .Returns(Task.CompletedTask)
                .Verifiable();
            mockService.Setup(service => service.SaveAsync())
                .ReturnsAsync(new OperationResponse(true, ""));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.DeleteConfirmed(id);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockService.Verify();
        }

        [Fact]
        public async Task DeleteConfirmed_ReturnRedirectActionDelete_WhenSavingFailed()
        {
            // Arrange
            int id = 1;
            var exerciseService = new ExerciseInfoServiceMocks();
            var mockService = new Mock<IExerciseInfoService>();
            mockService.Setup(service => service.RemoveAsync(id))
                .Returns(Task.CompletedTask)
                .Verifiable();
            mockService.Setup(service => service.SaveAsync())
                .ReturnsAsync(new OperationResponse(false, ""));
            var controller = new ExercisesInfoController(mockService.Object);

            // Act
            var result = await controller.DeleteConfirmed(id);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Delete", redirectToActionResult.ActionName);
            mockService.Verify();
        }

        #endregion
    }
}
