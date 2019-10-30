using Life.Application.Services.Interfaces.Exercise;
using Life.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
        #endregion
    }
}
