using System;
using System.Collections.Generic;
using TaskTracker.API.Models;

namespace TaskTracker.API.Interfaces
{
	public interface ITaskService
	{
		IEnumerable<TodoTask> GetAll();
		TodoTask Add(string title);
		bool Delete(Guid id);
		TodoTask? MarkComplete(Guid id);
	}
}
