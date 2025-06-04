using TaskTracker.API.Models;

namespace TaskTracker.API.Interfaces
{
	public interface ITaskRepository
	{
		IEnumerable<TodoTask> GetAll();
		TodoTask? GetById(Guid id);
		void Add(TodoTask task);
		void Delete(TodoTask task);
		void SaveChanges();
	}
}
