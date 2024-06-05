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
            ViewBag.itemsleft = model.ListToDos.Where(d => d.Done == false).Count();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(string Text)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
                //   return View(nameof(Index));
            }
            AddTodoDto aa = new AddTodoDto();
            aa.Text = Text;
            CreateToDooCommand x = new CreateToDooCommand(aa);
            var res = mediator.Send(x).Result;
            return Json(res);

        }
        //  [HttpPost]
        public IActionResult ComplateToDo(int Id, bool Done)
        {


            ComplateToDooCommand x = new ComplateToDooCommand(Id, Done);
            var res = mediator.Send(x).Result;
            return Json(res);

        }

        public IActionResult DeleteToDo(int Id)
        {
            DeleteToDooCommand x = new DeleteToDooCommand(Id);
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

        public IActionResult Test()
        {

            return View();
        }


    }
}
