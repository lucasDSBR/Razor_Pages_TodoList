using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoListRazor.Data;
using TodoListRazor.Models;

namespace TodoListRazor.Pages.Todos;

[BindProperties]
public class EditModel : PageModel
{
	public Todo Todo { get; set; } = null!;
	private readonly AppDbContext _context;

	public EditModel(AppDbContext context)
	{
		_context = context;
	}


	public IActionResult OnGet(int id)
	{
		ViewData["Title"] =  "Edit Task";
		var todo = _context.Todos.Find(id);
		if(todo is null){
			return NotFound();
		}
		Todo = todo;
		return Page();
	}

	public IActionResult OnPost(int id)
	{
		var todo = _context.Todos.Find(id);
		if(todo is null){
			return NotFound();
		}
		todo.Title = Todo.Title;
		todo.Date = Todo.Date;

		_context.SaveChanges();
		return RedirectToPage("Index");
	}
}