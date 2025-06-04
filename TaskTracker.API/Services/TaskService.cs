using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker.API.Interfaces;
using TaskTracker.API.Models;

namespace TaskTracker.API.Services
{
	public class TaskService : ITaskService
	{
		private readonly ITaskRepository _repo;

		public TaskService(ITaskRepository repo)
		{
			_repo = repo;
		}

		// Gets all Tasks
		public IEnumerable<TodoTask> GetAll()
		{
			return _repo.GetAll();
		}

		// Adds task using title
		public TodoTask Add(string title)
		{
			TodoTask task = new TodoTask { Title = title };
			_repo.Add(task);
			_repo.SaveChanges();
			return task;
		}

		// Deletes Task using Id
		public bool Delete(Guid id)
		{
			var task = _repo.GetById(id);
			if (task == null)
			{
				return false;
			}
			_repo.Delete(task);
			_repo.SaveChanges();
			return true;
        }

		// Check if Task exists and mark as complete if successful. Returns task.
		public TodoTask? MarkComplete(Guid id)
		{
			var task = _repo.GetById(id);
			if (task == null)
			{
				return null;
			}
			task.IsCompleted = true;
			_repo.SaveChanges();
			return task;
		}

	}
}
