using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ANW.ComposerApp.Controllers;
using ANW.ComposerApp.Models;
using ANW.ComposerModels;
using ANW.ComposerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ANW.ComposerTests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult viewResult = controller.Index();

            //Assert
            Assert.IsNotNull(viewResult);
        }

        [TestMethod]
        public void Index_Should_Return_All_Composers()
        {
            //Arrange
            List<ComposerModel> composers = new List<ComposerModel>
            {
                new ComposerModel{ Id = 1, Awards = "Grammy", Title = "Mr."},
                new ComposerModel{ Id = 2, Awards = "American Music Awards", Title = "Miss."},
                new ComposerModel{ Id = 3, Awards = "Grammy", Title = "Miss."},
                new ComposerModel{ Id = 4, Awards = "Billboard Music Awards", Title = "Miss."}
            };

            //Create fake IComposerService object
            var mockService = new Mock<IComposerService>();

            //Setup the service in order to return exactly what we expect
            mockService.Setup(service => service.GetAllComposers()).Returns(composers);

            HomeController controller = new HomeController(mockService.Object);

            //Act
            var getAllComposers = controller.Index();

            //Assert
            Assert.IsNotNull(getAllComposers);
            Assert.IsTrue(getAllComposers!=null);
        }

        [TestMethod]
        public void Index_Should_Return_FirstLastName_All_Composers()
        {
            //Arrange
            List<ComposerModel> composers = new List<ComposerModel>
            {
                new ComposerModel{ Id = 1, FullName = "Ed Sheeren", Awards = "Grammy", Title = "Mr."},
                new ComposerModel{ Id = 2, FullName = "Rita Ora", Awards = "American Music Awards", Title = "Miss."},
                new ComposerModel{ Id = 3, FullName = "Perrie Edwards", Awards = "Grammy", Title = "Miss."},
                new ComposerModel{ Id = 4, FullName = "Taylor Swift", Awards = "Billboard Music Awards", Title = "Miss."}
            };

            //Create fake IComposerService object
            var mockService = new Mock<IComposerService>();

            //Setup the service in order to return exactly what we expect
            mockService.Setup(service => service.GetAllComposers()).Returns(composers);

            HomeController controller = new HomeController(mockService.Object);

            //Act
            var getAllComposers = controller.Index();

            //Assert
            Assert.IsNotNull(getAllComposers);
            Assert.IsTrue(getAllComposers != null);
            Assert.IsTrue(composers[0].FullName == "Ed Sheeren");
        }

        [TestMethod]
        public void Index_Should_Return_TotalNumber_All_Composers()
        {
            //Arrange
            List<ComposerModel> composers = new List<ComposerModel>
            {
                new ComposerModel{ Id = 1, Awards = "Grammy", Title = "Mr."},
                new ComposerModel{ Id = 2, Awards = "American Music Awards", Title = "Miss."},
                new ComposerModel{ Id = 3, Awards = "Grammy", Title = "Miss."},
                new ComposerModel{ Id = 4, Awards = "Billboard Music Awards", Title = "Miss."}
            };

            //Create fake IComposerService object
            var mockService = new Mock<IComposerService>();

            //Setup the service in order to return exactly what we expect
            mockService.Setup(service => service.GetAllComposers()).Returns(composers);

            var controller = new HomeController(mockService.Object);

            //Act
            var viewResult = controller.Index();
            var model = viewResult.Model as IEnumerable<Composer>;

            //Assert
            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.AreEqual(4, model.Count());
        }

        [TestMethod]
        public void Detail_Should_Navigate_To_View_Composer_Details()
        {
            //Arrange
            var composer = new ComposerModel
            {
                Id = 1,
                FullName = "Ed Sheeren",
                Awards = "Grammy",
                Title = "Mr."
            };

            //Create fake IComposerService object
            var mockService = new Mock<IComposerService>();

            //Setup the service in order to receive what we expect
            mockService.Setup(service => service.GetComposerById(1)).Returns(composer);

            //Setup controller
            var controller = new HomeController(mockService.Object);

            //Act
            var viewResult = controller.Details(1);
            var model = viewResult.Model as Composer;

            //Assert
            Assert.IsNotNull(model);
            Assert.IsTrue(model.Value == composer.FullName);
            Assert.IsTrue(model.Title==composer.Title);
            Assert.IsTrue(model.Awards==composer.Awards);
        }
    }
}