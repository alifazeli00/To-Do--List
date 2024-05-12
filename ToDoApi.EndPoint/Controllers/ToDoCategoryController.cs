using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.EndPoint.Controllers
{
    [Route("api/ToDo/{ToDoId}/Categories/{CategoryId}")]
    [ApiController]
    public class ToDoCategoryController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(int ToDoId,int CategoryId)
        {
            //Set todo for category

            return Ok();    

        }

    }
}
