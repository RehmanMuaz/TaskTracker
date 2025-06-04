using TaskTracker.API.Services;
using Xunit;
using System;
using System.Linq;
using TaskTracker.API.Models;
using NuGet.Frameworks;
using TaskTracker.API.Interfaces;
using Moq;

namespace TaskTracker.Tests
{
	public class TaskServiceTests
	{
		[Fact]
		public void Add_ShouldReturnTaskWithCorrectTitle()
		{
			var mock = new Mock<ITaskRepository>();
			TaskService service = new TaskService(mock.Object);
			string title = "Test";
			TodoTask task = service.Add(title);

			Assert.Equal("Test", task.Title);
			Assert.False(task.IsCompleted);
			mock.Verify(repo => repo.Add(It.Is<TodoTask>(t => t.Title == title)), Times.Once);
			mock.Verify(repo => repo.SaveChanges(), Times.Once);
		}

		[Fact]
		public void GetAll_ShouldReturnAllTasks()
		{
			var mock = new Mock<ITaskRepository>();
			List<TodoTask> expectedTasks = new List<TodoTask>
			{
				new TodoTask { Title = "Test1" },
				new TodoTask { Title = "Test2" },
			};
			mock.Setup(repo => repo.GetAll()).Returns(expectedTasks);

			TaskService service = new TaskService(mock.Object);

			IEnumerable<TodoTask> tasks = service.GetAll();

			Assert.Equal(2, tasks.Count());
			Assert.Contains(tasks, t => t.Title == "Test1");
			Assert.Contains(tasks, t => t.Title == "Test2");

		}

		[Fact]
		public void Delete_ShouldReturnTrueIfTaskExists()
		{
			var mock = new Mock<ITaskRepository>();
			Guid id = Guid.NewGuid();
			TodoTask task = new TodoTask { Id = id };
			mock.Setup(repo => repo.GetById(id)).Returns(task);
			TaskService service = new TaskService(mock.Object);

			bool result = service.Delete(id);

			Assert.True(result);
			mock.Verify(repo => repo.Delete(task), Times.Once());
			mock.Verify(repo => repo.SaveChanges(), Times.Once());
		}

		[Fact]
		public void Delete_ShouldReturnFalseIfTaskDoesNotExist()
		{
			var mock = new Mock<ITaskRepository>();
			mock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((TodoTask?)null);
			TaskService service = new TaskService(mock.Object);

			bool result = service.Delete(Guid.NewGuid());

			Assert.False(result);
			mock.Verify(repo => repo.Delete(It.IsAny<TodoTask>()), Times.Never);
			mock.Verify(repo => repo.SaveChanges(), Times.Never());
		}

		[Fact]
		public void MarkComplete_ShouldReturnTaskIfTaskExists()
		{
			var mock = new Mock<ITaskRepository>();
			Guid id = Guid.NewGuid();
			TodoTask task = new TodoTask { Id = id };
			mock.Setup(repo => repo.GetById(id)).Returns(task);
			TaskService service = new TaskService(mock.Object);

			var result = service.MarkComplete(id);

			Assert.NotNull(result);
			Assert.True(result!.IsCompleted);
			mock.Verify(repo => repo.SaveChanges(), Times.Once());
		}

		[Fact]
		public void MarkComplete_ShouldReturnNullIfTaskDoesNotExist() 
		{
			var mock = new Mock<ITaskRepository>();
			mock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((TodoTask?)null);
			TaskService service = new TaskService(mock.Object);

			var result = service.MarkComplete(Guid.NewGuid());

			Assert.Null(result);
			mock.Verify(repo => repo.SaveChanges(), Times.Never());
		}
	}
}
