using Application.Dtos;
using Application.Dtos.Todo;
using Application.ToDo.Commands;
using Application.ToDo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoWebApp.Models.TodoViewModel;

namespace ToDoWebApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IMediator mediator;

        public ToDoController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        public IActionResult Index(PageDto PageDto)
        {
            GetToDooQuery x = new GetToDooQuery(PageDto);
            var res = mediator.Send(x).Result;

            ToDoViewModel model = new ToDoViewModel()
            {
                ListToDos = res,
                PageDto = PageDto,
                PaginatedItemsDto = new PaginatedItemsDto(PageDto.pageIndex, PageDto.pageSize, PageDto.RowCount) { },

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(string Text)
        {

            AddTodoDto aa = new AddTodoDto();
            aa.Text = Text;
            CreateToDooCommand x = new CreateToDooCommand(aa);
            var res = mediator.Send(x).Result;
            return Json(res);

        }

        public IActionResult GetAll(PageDto PageDto)
        {
            AddTodoDto aa = new AddTodoDto();
           
            GetToDooQuery x = new GetToDooQuery(PageDto);
            var res = mediator.Send(x).Result;
            return View();

        }

        public IActionResult Edit(int Id)
        {
            EditToDoDto InsertId = new EditToDoDto() { Id = Id };
            return View(InsertId);
        }
        [HttpPost]

        public IActionResult Edit(EditToDoDto EditToDoDto)
        {

            EditToDooCommand x = new EditToDooCommand(EditToDoDto);
            var res = mediator.Send(x).Result;
            return RedirectToAction(nameof(Index));
        }

    }
}
