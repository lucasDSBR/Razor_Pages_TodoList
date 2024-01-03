using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoListRazor.Data;
using TodoListRazor.Models;

namespace TodoListRazor.Pages.Todos;

[BindProperties]
public class CreateModel : PageModel
{
	public Todo Todo { get; set; } = null!;
	private readonly AppDbContext _context;

	public CreateModel(AppDbContext context)
	{
		_context = context;
	}


	public void OnGet()
	{
		ViewData["Title"] =  "Register Task";
	}

	public IActionResult OnPost()
	{
		_context.Add(Todo);
		_context.SaveChanges();
		return RedirectToPage("Index");
	}
}