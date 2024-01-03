using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoListRazor.Data;
using TodoListRazor.Models;

namespace TodoListRazor.Pages.Todos;

public class IndexModel : PageModel
{
	public ICollection<Todo> Todos { get; set; } = new List<Todo>();
	private readonly AppDbContext _context;

	public IndexModel(AppDbContext context)
	{
		_context = context;
	}


	public void OnGet()
	{
		ViewData["Title"] =  "Tasks List...";
		Todos = _context.Todos.OrderByDescending(x => x.Date).ToList();
	}

	public IActionResult OnGetDelete(int id)
	{
		var todo = _context.Todos.Find(id);
		if(todo is null)
		{
			return NotFound();
		}
		_context.Remove(todo);
		_context.SaveChanges();
		return RedirectToPage("Index");
	}
	public IActionResult OnGetToCompleted(int id)
	{
		var todo = _context.Todos.Find(id);
		if(todo is null)
		{
			return NotFound();
		}
		todo.IsCompleted = true;
		_context.SaveChanges();
		return RedirectToPage("Index");
	}

}