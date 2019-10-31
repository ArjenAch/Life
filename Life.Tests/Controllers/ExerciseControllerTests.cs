using Life.Application.Services.Exercises.DTO;
using Life.Application.Services.Interfaces.Exercises;
using Life.Controllers;
using Life.Core.Domain.Exercises;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Life.Tests.Controllers
{
    public class ExerciseControllerTests
    {
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

        //To check -list,setdto same type test + implementation
        // komt die in de model binder?
        //modelbinder test?
        // toevoegen van een exercise met een bestaande exercise info en zonder bestaand (wordt die dan aangemaakt?)
    }
}
