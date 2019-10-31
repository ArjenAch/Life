using Life.Application.Services.Exercises.DTO;
using Life.Application.Services.Interfaces.Exercises;
using Life.Controllers;
using Life.Core.Domain.Exercises;
using Life.Tests.ServiceMocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Life.Tests.Controllers
{
    public class ExerciseControllerTests
    {
        #region Index
        [Fact]
        public async Task Index_ReturnAViewResult_WithAListOfExerciceDTOobjects()
        {
            // Arrange
            var exerciseService = new ExercisesServiceMocks();
            var mockService = new Mock<IExerciseService>();
            mockService.Setup(service => service.GetAllAsync())
                .ReturnsAsync(exerciseService.GetExerciseList());
            var controller = new ExercisesController(mockService.Object);

            // Act
            var result = await controller.Index();

            //Arange
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ExerciseDTO>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        #endregion

        #region create
        [Fact]
        public void Create_ReturnAViewResult()
        {
            // Arrange
            var mockService = new Mock<IExerciseService>();
            var controller = new ExercisesController(mockService.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async Task CreatePost_ReturnAViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockService = new Mock<IExerciseService>();

            var controller = new ExercisesController(mockService.Object);
            controller.ModelState.AddModelError("Invalid model", "Title contains ...");
            var exercise = new ExerciseDTO()
            {
                ExerciseType = ExerciseType.Cardio,
                Description = "",
                Title = "Spinning",
                Sets = new List<SetDTO>()
            };

            // Act
            var result = await controller.Create(exerciseDTO: exercise);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<ExerciseDTO>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public async Task CreatePost_ReturnRedirectToAction_WhenModelStateIsValid()
        {
            // Arrange
            var mockService = new Mock<IExerciseService>();
            mockService.Setup(service => service.AddAsync(It.IsAny<ExerciseDTO>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new ExercisesController(mockService.Object);
            var exercise = new ExerciseDTO()
            {
                ExerciseType = ExerciseType.Cardio,
                Description = "",
                Title = "Spinning"
            };

            // Act
            var result = await controller.Create(exercise);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockService.Verify();
        }

        #endregion

        
    }
}
