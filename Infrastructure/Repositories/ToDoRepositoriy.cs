using Application.Abstractions;
using Application.Dtos;
using Application.Dtos.Todo;
using Application.Exceptions;
using Common;
using Domain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ToDoRepositoriy : IToDoRepository
    {
        private readonly DataBaceContext contex;
        public ToDoRepositoriy(DataBaceContext DataBaceContext)
        {
            this.contex = DataBaceContext;

        }
        public async Task <bool> Add(AddTodoDto AddTodoDto)
        {
            ToDo newTodo=new ToDo()
            {
                InsertTime = DateTime.Now,
                Text = AddTodoDto.Text,
                IsDeleted = false,


            };
            //foreach (var item in AddTodoDto.Categores)
            //{
            //    var categoray = contex.Categoryes.SingleOrDefault(p => p.Id == item);
            //    newTodo.Category.Add(categoray);
            //}
            contex.Add(newTodo);
            contex.SaveChanges();
            return true;



           
        }

        //public void Delete(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool>  Edit(EditToDoDto editToDoDto)
        {
        
           var todo=contex.ToDos.SingleOrDefault(p=>p.Id == editToDoDto.Id);
       
            if (todo == null)

               //mohalef ghavanin rest!
            throw new NotFundException(nameof(todo),editToDoDto.Id);
                
            todo.Text = editToDoDto.Text;
          
            return  true;


        }

        public async Task<List<TodoDto>> GetAll(PageDto PageDto)
        {
            int rowCount = 0;
          
            var query = contex.ToDos.Select(a => new TodoDto
            {
                Id = a.Id,
                IsDeleted = a.IsDeleted,
                InsertTime = a.InsertTime,
                Text = a.Text,
            }).PagedResult(PageDto.pageIndex,PageDto.pageSize,out rowCount).AsQueryable();

            if (query == null)
                //                throw new NotFundException(nameof(query));
                throw new Exception();     

            if (!string.IsNullOrEmpty(PageDto.SearchKey))
            {
                query = query.Where(p => p.Text.Contains(PageDto.SearchKey) );
            }
            return query.ToList();

         //   page, pageSize, out totalCount
           //var resd = query.PagedResult(PageDto.pageIndex, PageDto.pageSize, out rowCount);







            //int totalCount = 0;
            //// in ja pagedressult  bas mishe ke  hamshon  namaish pida naknnn yejoraii bas filtering mishe
            //var res = context.CatalogType.Where(p => p.ParentCatalogTypeId == parentId).
            //    PagedResult(page, pageSize, out totalCount).Select(d => new CatalogGetType
            //    // page result karay tedad ro migirie va filtering ro rosh anjam mide ke masan begim in 3 
            //    // item  be che sorat namaish bedim hamash  ya yek done ye done

            //    {

            //        //       ParentCatalogTypeId = d.ParentCatalogTypeId,
            //        Id = d.Id,
            //        Type = d.Type,
            //        ChildTypeCount = d.Childs.Count()
            //    }

            //).ToList();


            //return new BaseDto<CatalogGetType>(page, pageSize, totalCount) { Count = totalCount, Data = res, PageSize = pageSize, PageIndex = page };

        }
    }
}
