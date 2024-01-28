using System.Collections.Generic;
using ToDo2.Dtos;
using ToDo2.Parameters;

namespace ToDo2.Interfaces
{
    public interface ITodoListService
    {
        List<TodoListSelectDtos> GetData(TodoSelectParameter value);
    }
}
