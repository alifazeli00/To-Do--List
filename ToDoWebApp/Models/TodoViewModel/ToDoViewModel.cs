using Application.Dtos;
using Application.Dtos.Todo;
using System.ComponentModel.DataAnnotations;

namespace ToDoWebApp.Models.TodoViewModel
{
    public class ToDoViewModel
    {
        public List<TodoDto> ListToDos { get; set; }
        public PageDto PageDto { get; set; }
        public PaginatedItemsDto PaginatedItemsDto { get; set; }

    }

}
