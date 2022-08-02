using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service.Implements;

namespace Service.Tests
{
    [TestClass]
    public class PointServiceTest
    {
        private Task<IEnumerable<Point>> GetTestPoints()
        {
            var notes = new List<Point>
            {
                new()
                {
                    Id = 1, x_Axis = 2, y_Axis = 3, Radius = 13, Color = "red"
                },
                new()
                {
                    Id = 2, x_Axis = -2, y_Axis = 13, Radius = 7, Color = "blue"
                },
                new()
                {
                    Id = 3, x_Axis = 4, y_Axis = 5, Radius = 4, Color = "green"
                },
            };

            return Task.FromResult<IEnumerable<Point>>(notes);
        }

        private Task<IEnumerable<Point>> GetTestEmptyPoints()
        {
            var notes = new List<Point>
            {
                Capacity = 0
            };

            return Task.FromResult<IEnumerable<Point>>(notes);
        }

        private Task<IEnumerable<Point>> GetTestNull()
        {
            return Task.FromResult<IEnumerable<Point>>(null);
        }

        [TestMethod]
        public void Insert_Point_ReturnsId()
        {
            // arrange
            var mock = new Mock<IPointRepo>();
            var note = new Point
            {
                Id = 2,
                x_Axis = -2,
                y_Axis = 13,
                Radius = 7,
                Color = "blue"
            };
            mock.Setup(repo => repo.InsertAsync(note)).Returns(Task.FromResult(2));

            var service = new PointService(mock.Object);

            // act
            var result = service.InsertPointAsync(note);

            // assert
            Assert.AreEqual(note.Id, result.Result);
        }

        [TestMethod]
        public void Get_Points_ReturnsCount()
        {
            // arrange
            var mock = new Mock<IPointRepo>();
            mock.Setup(repo => repo.GetAllAsync()).Returns(GetTestPoints());
            var service = new PointService(mock.Object);

            // act
            var result = service.GetPointsAsync();

            // assert
            Assert.AreEqual(GetTestPoints().Result.Count(), result.Result.Count());
        }

        [TestMethod]
        public void Get_Points_ReturnsEmpty()
        {
            // arrange
            var mock = new Mock<IPointRepo>();
            mock.Setup(repo => repo.GetAllAsync()).Returns(GetTestNull());
            var service = new PointService(mock.Object);

            // act
            var result = service.GetPointsAsync();

            // assert
            Assert.AreEqual(GetTestEmptyPoints().Result.Count(), result.Result.Count());
        }

        [TestMethod]
        public void Delete_Point_ReturnsTrue()
        {
            // arrange
            var mock = new Mock<IPointRepo>();
            var order = new Point
            {
                Id = 2,
                x_Axis = -2,
                y_Axis = 13,
                Radius = 7,
                Color = "blue"
            };
            mock.Setup(repo => repo.InsertAsync(order));
            mock.Setup(repo => repo.DeleteAsync(2)).Returns(Task.FromResult(true));

            var service = new PointService(mock.Object);

            // act
            var resultDelete = service.DeletePointAsync(2);

            // assert
            Assert.AreEqual(true, resultDelete.Result);
        }

        [TestMethod]
        public void Delete_Point_ReturnsFalse()
        {
            // arrange
            var mock = new Mock<IPointRepo>();
            var order = new Point()
            {
                Id = 2,
                x_Axis = -2,
                y_Axis = 13,
                Radius = 7,
                Color = "blue"
            };
            mock.Setup(repo => repo.InsertAsync(order));
            mock.Setup(repo => repo.DeleteAsync(2)).Returns(Task.FromResult(true));

            var service = new PointService(mock.Object);

            // act
            var resultDelete = service.DeletePointAsync(1);

            // assert
            Assert.AreEqual(false, resultDelete.Result);
        }

        [TestMethod]
        public void Update_Point_ReturnId()
        {
            // arrange
            var mock = new Mock<IPointRepo>();
            var order = new Point()
            {
                Id = 2,
                x_Axis = -2,
                y_Axis = 13,
                Radius = 7,
                Color = "blue"
            };
            mock.Setup(repo => repo.InsertAsync(order));
            mock.Setup(repo => repo.UpdateAsync(order)).Returns(Task.FromResult(2));

            var service = new PointService(mock.Object);

            // act
            var result = service.UpdatePointAsync(order);

            // assert
            Assert.AreEqual(order.Id, result.Result);
        }
    }
}
