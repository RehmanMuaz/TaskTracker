﻿namespace TaskTracker.API.Models
{
	public class TodoTask
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Title { get; set; } = string.Empty;
		public bool IsCompleted { get; set; } = false;
	}
}
