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
    public class NoteServiceTest
    {
        private Task<IEnumerable<Note>> GetTestNotes()
        {
            var notes = new List<Note>
            {
                new()
                {
                    Id = 1, Comment = "qwe", Color = "#ff000", PointId = 1
                },
                new()
                {
                    Id = 2, Comment = "asd", Color = "#af123", PointId = 2
                },
                new()
                {
                    Id = 3, Comment = "zxc", Color = "#cc321", PointId = 1
                },
            };

            return Task.FromResult<IEnumerable<Note>>(notes);
        }

        private Task<IEnumerable<Note>> GetTestEmptyNotes()
        {
            var notes = new List<Note>
            {
                Capacity = 0
            };

            return Task.FromResult<IEnumerable<Note>>(notes);
        }

        private Task<IEnumerable<Note>> GetTestNull()
        {
            return Task.FromResult<IEnumerable<Note>>(null);
        }

        [TestMethod]
        public void Insert_Note_ReturnsId()
        {
            // arrange
            var mock = new Mock<INoteRepo>();
            var note = new Note
            {
                Id = 2,
                Comment = "qwe",
                Color = "#ff000",
                PointId = 1
            };
            mock.Setup(repo => repo.InsertAsync(note)).Returns(Task.FromResult(2));

            var service = new NoteService(mock.Object);

            // act
            var result = service.InsertNoteAsync(note);

            // assert
            Assert.AreEqual(note.Id, result.Result);
        }

        [TestMethod]
        public void Get_Notes_ReturnsCount()
        {
            // arrange
            var mock = new Mock<INoteRepo>();
            mock.Setup(repo => repo.GetAllAsync()).Returns(GetTestNotes());
            var service = new NoteService(mock.Object);

            // act
            var result = service.GetNotesAsync();

            // assert
            Assert.AreEqual(GetTestNotes().Result.Count(), result.Result.Count());
        }

        [TestMethod]
        public void Get_Notes_ReturnsEmpty()
        {
            // arrange
            var mock = new Mock<INoteRepo>();
            mock.Setup(repo => repo.GetAllAsync()).Returns(GetTestNull());
            var service = new NoteService(mock.Object);

            // act
            var result = service.GetNotesAsync();

            // assert
            Assert.AreEqual(GetTestEmptyNotes().Result.Count(), result.Result.Count());
        }

        [TestMethod]
        public void Delete_Note_ReturnsTrue()
        {
            // arrange
            var mock = new Mock<INoteRepo>();
            var order = new Note
            {
                Id = 2,
                Comment = "qwe",
                Color = "#ff000",
                PointId = 1
            };
            mock.Setup(repo => repo.InsertAsync(order));
            mock.Setup(repo => repo.DeleteAsync(2)).Returns(Task.FromResult(true));

            var service = new NoteService(mock.Object);

            // act
            var resultDelete = service.DeleteNoteAsync(2);

            // assert
            Assert.AreEqual(true, resultDelete.Result);
        }

        [TestMethod]
        public void Delete_Note_ReturnsFalse()
        {
            // arrange
            var mock = new Mock<INoteRepo>();
            var order = new Note()
            {
                Id = 2,
                Comment = "qwe",
                Color = "#ff000",
                PointId = 1
            };
            mock.Setup(repo => repo.InsertAsync(order));
            mock.Setup(repo => repo.DeleteAsync(2)).Returns(Task.FromResult(true));

            var service = new NoteService(mock.Object);

            // act
            var resultDelete = service.DeleteNoteAsync(1);

            // assert
            Assert.AreEqual(false, resultDelete.Result);
        }

        [TestMethod]
        public void Update_Note_ReturnId()
        {
            // arrange
            var mock = new Mock<INoteRepo>();
            var order = new Note()
            {
                Id = 2,
                Comment = "qwe",
                Color = "#ff000",
                PointId = 1
            };
            mock.Setup(repo => repo.InsertAsync(order));
            mock.Setup(repo => repo.UpdateAsync(order)).Returns(Task.FromResult(2));

            var service = new NoteService(mock.Object);

            // act
            var result = service.UpdateNoteAsync(order);

            // assert
            Assert.AreEqual(order.Id, result.Result);
        }
    }
}
