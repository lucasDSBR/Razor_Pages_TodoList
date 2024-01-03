namespace TodoListRazor.Models;

public class Todo
{
	public int Id {get; set; }
	public string Title {get; set; } = string.Empty;
	public DateTime Date {get; set; }
	public bool IsCompleted {get; set; }

}