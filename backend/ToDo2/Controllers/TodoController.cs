using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ToDo2.Dtos;
using ToDo2.Filters;
using ToDo2.Models;
using ToDo2.Parameters;
using ToDo2.Services;
using ToDo2.Utils;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly TodoContext _todoContext;

        // service we created to demo dependency injection
        private readonly TodoListService _todoListService;

        // upload file to a directory
        private readonly IWebHostEnvironment _env;

        public ToDoController(TodoContext todoContext, TodoListService todoListService, IWebHostEnvironment env)
        {
            _todoContext = todoContext;
            _todoListService = todoListService;

            _env = env;
        }

        // GET: api/<ToDoController>
        //[HttpGet]
        //Attempt 1: Try GET with using DTOS to edit attribute
        //public IEnumerable<TodoListSelectDtos> Get()
        //{
        //    var result = _todoContext.TodoLists.Include(a => a.UpdateEmployee).Include(a => a.InsertEmployee)
        //        .Select(a => new TodoListSelectDtos
        //        {
        //            Enable = a.Enable,
        //            InsertEmployeeName = a.InsertEmployee.Name,
        //            InsertTime=a.InsertTime,
        //            Name=a.Name,
        //            Orders=a.Orders,
        //            TodoId=a.TodoId,
        //            UpdateEmployeeName=a.UpdateEmployee.Name,
        //            UpdateTime=a.UpdateTime
        //        });

        //    return result;
        //}

        //Attempt 2: Try GET with using DTOS to edit attribute, return status code
        //public IActionResult Get()
        //{
        //    var result = _todoContext.TodoLists.Include(a => a.UpdateEmployee).Include(a => a.InsertEmployee)
        //        .Select(a => new TodoListSelectDtos
        //        {
        //            Enable = a.Enable,
        //            InsertEmployeeName = a.InsertEmployee.Name,
        //            InsertTime = a.InsertTime,
        //            Name = a.Name,
        //            Orders = a.Orders,
        //            TodoId = a.TodoId,
        //            UpdateEmployeeName = a.UpdateEmployee.Name,
        //            UpdateTime = a.UpdateTime
        //        });

        //    if (result == null || result.Count() == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}

        //Attempt 3: Try GET with using DTOS to edit attribute, return status code, with taking 3 params{name, enable, InsertTime}
        //public IEnumerable<TodoListSelectDtos> Get(string name, bool? enable, DateTime? InsertTime)
        //{
        //    var result = _todoContext.TodoLists
        //        .Select(a => new TodoListSelectDtos
        //        {
        //            Enable = a.Enable,
        //            InsertEmployeeName = a.InsertEmployee.Name,
        //            InsertTime = a.InsertTime,
        //            Name = a.Name,
        //            Orders = a.Orders,
        //            TodoId = a.TodoId,
        //            UpdateEmployeeName = a.UpdateEmployee.Name,
        //            UpdateTime = a.UpdateTime
        //        });

        //    if (!string.IsNullOrWhiteSpace(name))
        //    {
        //        result = result.Where(a => a.Name.Contains(name));
        //    }

        //    if (enable != null)
        //    {
        //        result = result.Where(a => a.Enable == enable);
        //    }

        //    if (InsertTime != null)
        //    {
        //        result = result.Where(a => a.InsertTime.Date == InsertTime);
        //    }

        //    return result;
        //}

        /*
         * Attempt 4: Try GET with using DTOS to edit attribute, return status code, with taking 3 params{name, enable, InsertTime},
         *            create a parameter class to minimize code, use [FromQuery]
         *            URL: https://localhost:44396/api/Todo?minOrder=3&maxOrder=4
         * **/
        //public IEnumerable<TodoListSelectDtos> Get([FromQuery] TodoSelectParameter value)
        //{
        //    var result = _todoContext.TodoLists
        //        .Select(a => new TodoListSelectDtos
        //        {
        //            Enable = a.Enable,
        //            InsertEmployeeName = a.InsertEmployee.Name,
        //            InsertTime = a.InsertTime,
        //            Name = a.Name,
        //            Orders = a.Orders,
        //            TodoId = a.TodoId,
        //            UpdateEmployeeName = a.UpdateEmployee.Name,
        //            UpdateTime = a.UpdateTime
        //        });

        //    if (!string.IsNullOrWhiteSpace(value.name))
        //    {
        //        result = result.Where(a => a.Name.Contains(value.name));
        //    }

        //    if (value.enable != null)
        //    {
        //        result = result.Where(a => a.Enable == value.enable);
        //    }

        //    if (value.InsertTime != null)
        //    {
        //        result = result.Where(a => a.InsertTime.Date == value.InsertTime);
        //    }

        //    if (value.minOrder != null && value.maxOrder != null)
        //    {
        //        result = result.Where(a => a.Orders >= value.minOrder && a.Orders <= value.maxOrder);
        //    }
        //    return result;
        //}

        /*
         * Attempt 5: Try GET with using DTOS to edit attribute, return status code, with taking 3 params{name, enable, InsertTime},
         *            create a parameter class to minimize code, use [FromQuery].
         *            URl range code minimization by doing regrex.
         *            URL: https://localhost:44396/api/Todo?Order=1-4
         *            create a method which create a new TodoListSelectDtos class
         * **/
        //public IEnumerable<TodoListSelectDtos> Get([FromQuery] TodoSelectParameter value)
        //{
        //    var result = _todoContext.TodoLists
        //        .Include(a => a.UpdateEmployee)
        //        .Include(a => a.InsertEmployee)
        //        .Include(a => a.UploadFiles)
        //        .Select(a => a);

        //    if (!string.IsNullOrWhiteSpace(value.name))
        //    {
        //        result = result.Where(a => a.Name.Contains(value.name));
        //    }

        //    if (value.enable != null)
        //    {
        //        result = result.Where(a => a.Enable == value.enable);
        //    }

        //    if (value.InsertTime != null)
        //    {
        //        result = result.Where(a => a.InsertTime.Date == value.InsertTime);
        //    }

        //    if (value.minOrder != null && value.maxOrder != null)
        //    {
        //        result = result.Where(a => a.Orders >= value.minOrder && a.Orders <= value.maxOrder);
        //    }
        //    return result.ToList().Select(a => ItemToDto(a));
        //}

        /*
         * Attempt 6: Try GET with using DTOS to edit attribute, return status code, with taking 3 params{name, enable, InsertTime},
         *            create a parameter class to minimize code, use [FromQuery].
         *            URl range code minimization by doing regrex.
         *            URL: https://localhost:44396/api/Todo?Order=1-4
         *            create a method which create a new TodoListSelectDtos class
         *            change the return type to ActionResult, to return result with status code
         * **/
        //public IActionResult Get([FromQuery] TodoSelectParameter value)
        //{
        //    var result = _todoContext.TodoLists
        //        .Include(a => a.UpdateEmployee)
        //        .Include(a => a.InsertEmployee)
        //        .Include(a => a.UploadFiles)
        //        .Select(a => a);

        //    if (!string.IsNullOrWhiteSpace(value.name))
        //    {
        //        result = result.Where(a => a.Name.Contains(value.name));
        //    }

        //    if (value.enable != null)
        //    {
        //        result = result.Where(a => a.Enable == value.enable);
        //    }

        //    if (value.InsertTime != null)
        //    {
        //        result = result.Where(a => a.InsertTime.Date == value.InsertTime);
        //    }

        //    if (value.minOrder != null && value.maxOrder != null)
        //    {
        //        result = result.Where(a => a.Orders >= value.minOrder && a.Orders <= value.maxOrder);
        //    }

        //    if(result==null || result.Count() <= 0)
        //    {
        //        return NotFound("No resource found");
        //    }
        //    return Ok(result.ToList().Select(a => ItemToDto(a)));
        //}

        /*
         * Attempt 7: Try GET with using DTOS to edit attribute, return status code, with taking 3 params{name, enable, InsertTime},
         *            create a parameter class to minimize code, use [FromQuery].
         *            URl range code minimization by doing regrex.
         *            URL: https://localhost:44396/api/Todo?Order=1-4
         *            create a method which create a new TodoListSelectDtos class
         *            change the return type to ActionResult, to return result with status code
         *            Using Services we created, this demo "dependency injection", which make code cleaner
         *            Only selected role can access this API
         * **/
        [HttpGet]
        //[Authorize(Roles = "select")]
        //[TypeFilter(typeof(TodoAuthorizationFilter))]  // demo authorization filter
        //[TodoAuthorizationFilter]
        //[TodoAuthorizationFilter2(Roles="aaa")]
        public IActionResult Get([FromQuery] TodoSelectParameter value)
        {
            var result = _todoListService.GetData(value);

            if (result == null || result.Count() <= 0)
            {
                return NotFound("No resource found");
            }
            return Ok(result);
        }

        // GET api/<ToDoController>/5

        //[HttpGet("{id}")]
        /*
         * Attempt 1: matching the input todo id with the one in database
         *            .Include will auto join matching id and return the data
         * **/
        //public TodoListSelectDtos Get(Guid id)
        //{
        //    var result = _todoContext.TodoLists
        //        .Where(a => a.TodoId == id)
        //        .Include(a => a.UpdateEmployee)
        //        .Include(a => a.InsertEmployee)
        //        .Select(a => ItemToDto(a)).SingleOrDefault();

        //    return result;
        //}
        /*
         * Attempt 2: matching the input todo id with the one in database
         *            using linkq to do sql join
         * **/
        //public TodoListSelectDtos Get(Guid id)
        //{
        //    var result = (from a in _todoContext.TodoLists
        //                  where a.TodoId == id
        //                  select new TodoListSelectDtos
        //                  {
        //                      Enable = a.Enable,
        //                      InsertEmployeeName = a.InsertEmployee.Name,
        //                      InsertTime = a.InsertTime,
        //                      Name = a.Name,
        //                      Orders = a.Orders,
        //                      TodoId = a.TodoId,
        //                      UpdateEmployeeName = a.UpdateEmployee.Name,
        //                      UpdateTime = a.UpdateTime,
        //                      UploadFiles = (from b in _todoContext.UploadFiles
        //                                     where a.TodoId == b.TodoId
        //                                     select new UploadFileDtos
        //                                     {
        //                                         Name = b.Name,
        //                                         Src = b.Src,
        //                                         TodoId = b.TodoId,
        //                                         UploadFileId = b.UploadFileId
        //                                     }).ToList()
        //                  })
        //                  .SingleOrDefault();

        //    return result;
        //}

        /*
         * Attempt 3: matching the input todo id with the one in database
         *            .Include will auto join matching id and return the data
         *            Edit it to return result with status code
         * **/
        //[HttpGet("{TodoId}")]
        //public ActionResult<TodoListSelectDtos> GetOne(Guid TodoId)
        //{
        //    var result = (from a in _todoContext.TodoLists
        //                    where a.TodoId == TodoId
        //                    select a)
        //        .Include(a => a.UpdateEmployee)
        //        .Include(a => a.InsertEmployee)
        //        .Include(a => a.UploadFiles)
        //        .SingleOrDefault();

        //    if(result == null)
        //    {
        //        return NotFound("Cannot find id: " + TodoId + " data");
        //    }

        //    return ItemToDto(result);
        //}

        /*
         * Attempt 4: matching the input todo id with the one in database
         *            .Include will auto join matching id and return the data
         *            Edit it to return result with status code
         *            Using Services we created, this demo "dependency injection", which make code cleaner
         *            
         * **/
        [HttpGet("{TodoId}")]
        
        public ActionResult<TodoListSelectDtos> GetOne(Guid TodoId)
        {
            var result = _todoListService.GetOneData(TodoId);

            if (result == null)
            {
                return NotFound("Cannot find id: " + TodoId + " data");
            }

            return result;
        }

        [HttpGet("GetSQL")]
        public IEnumerable<TodoList> GetSQL(string name)
        {
            string sql = "select * from todolist where 1=1";

            if (!string.IsNullOrWhiteSpace(name))
            {
                sql = sql + "and name like N'%" + name + "%'";
            }

            var result = _todoContext.TodoLists.FromSqlRaw(sql);

            return result;
        }

        /*
         * Attempt 1: adding parent and child data at the same time, auto generate time data
         * Note: Guid will be auto generated
         * **/
        // POST api/Todo
        //[HttpPost]
        //public void Post([FromBody] TodoList value)
        //{
        //    TodoList insert = new TodoList
        //    {
        //        //Insert parent by user
        //        Name = value.Name,
        //        Enable = value.Enable,
        //        Orders = value.Orders,
        //        //Auto generate by system
        //        InsertTime = DateTime.Now,
        //        UpdateTime = DateTime.Now,
        //        InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        //        UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),

        //        //Insert child by user
        //        UploadFiles = value.UploadFiles
        //    };
        //    _todoContext.TodoLists.Add(insert);
        //    _todoContext.SaveChanges();

        //}

        /*
         * Attempt 2: adding parent and child data at the same time, auto generate time data
         *            using dto without exposing uncessary paramter to user
         * Note: Guid will be auto generated
         * **/
        // POST api/Todo
        //[HttpPost]
        //public void Post([FromBody] TodoListPostDtos value)
        //{
        //    List<UploadFile> up1 = new List<UploadFile>(); 

        //    foreach(var temp in value.UploadFiles) {
        //        UploadFile up = new UploadFile
        //        {
        //            Name = temp.Name,
        //            Src = temp.Src
        //        };
        //        up1.Add(up);
        //    }
        //    TodoList insert = new TodoList
        //    {
        //        //Insert parent by user
        //        Name = value.Name,
        //        Enable = value.Enable,
        //        Orders = value.Orders,
        //        //Auto generate by system
        //        InsertTime = DateTime.Now,
        //        UpdateTime = DateTime.Now,
        //        InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        //        UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),

        //        //Insert child by user
        //        UploadFiles = up1
        //    };
        //    _todoContext.TodoLists.Add(insert);
        //    _todoContext.SaveChanges();

        //}

        /*
         * Attempt 3: adding parent and child data at the same time, auto generate time data
         *            using dto without exposing uncessary paramter to user
         *            use in built "SetValue()" method to map user input with the attribute to reduce repeat code 
         *            
         * Note: Guid will be auto generated
         * **/
        // POST api/Todo
        //[HttpPost]
        //public void Post([FromBody] TodoListPostDtos value)
        //{

        //    TodoList insert = new TodoList
        //    {
        //        //Auto generate by system
        //        InsertTime = DateTime.Now,
        //        UpdateTime = DateTime.Now,
        //        InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        //        UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        //    };
        //    _todoContext.TodoLists.Add(insert).CurrentValues.SetValues(value);
        //    _todoContext.SaveChanges();

        //    foreach (var temp in value.UploadFiles)
        //    {
        //        _todoContext.UploadFiles.Add(new UploadFile()
        //        {
        //            TodoId=insert.TodoId
        //        }).CurrentValues.SetValues(temp);
        //    }

        //    _todoContext.SaveChanges();
        //}

        /*
         * Attempt 4: adding parent and child data at the same time, auto generate time data
         *            using dto without exposing uncessary paramter to user
         *            use in built "SetValue()" method to map user input with the attribute to reduce repeat code 
         *            return IAction result to show message to user once it is done
         *            
         * Note: Guid will be auto generated
         * **/
        // POST api/Todo
        //[HttpPost]
        //public IActionResult Post([FromBody] TodoListPostDtos value)
        //{

        //    TodoList insert = new TodoList
        //    {
        //        //Auto generate by system
        //        InsertTime = DateTime.Now,
        //        UpdateTime = DateTime.Now,
        //        InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        //        UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        //    };
        //    _todoContext.TodoLists.Add(insert).CurrentValues.SetValues(value);
        //    _todoContext.SaveChanges();

        //    foreach (var temp in value.UploadFiles)
        //    {
        //        _todoContext.UploadFiles.Add(new UploadFile()
        //        {
        //            TodoId = insert.TodoId
        //        }).CurrentValues.SetValues(temp);
        //    }

        //    _todoContext.SaveChanges();

        //    return CreatedAtAction(nameof(GetOne), new { TodoId = insert.TodoId }, insert); 
        //}

        /*
         * Attempt 5: adding parent and child data at the same time, auto generate time data
         *            using dto without exposing uncessary paramter to user
         *            use in built "SetValue()" method to map user input with the attribute to reduce repeat code 
         *            return IAction result to show message to user once it is done
         *            Using Services we created, this demo "dependency injection", which make code cleaner
         *            
         * Note: Guid will be auto generated
         * **/
        // POST api/Todo
        [HttpPost]
        public IActionResult Post([FromBody] TodoListPostDtos value)
        {

            var insert = _todoListService.AddNewData(value);

            return CreatedAtAction(nameof(GetOne), new { TodoId = insert.TodoId }, insert);
        }

        /*
         * Attempt 1: adding data using SQL, basically use SQL command to insert new data into database
         *            When using SQL need to be careful with SQL injection
         * Note: Guid will be auto generated
         * **/
        // POST api/Todo
        //[HttpPost("postSQL")]
        //public void PostSQL([FromBody] TodoListPostDtos value)
        //{
        //    string sql = @"INSERT INTO [dbo].[TodoList]
        //    ([Name]
        //    ,[InsertTime]
        //    ,[UpdateTime]
        //    ,[Enable]
        //    ,[Orders]
        //    ,[InsertEmployeeId]
        //    ,[UpdateEmployeeId])
        //VALUES
        //    ('"+value.Name+"','"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"','"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"+value.Enable+"',"+value.Orders+ ",'00000000-0000-0000-0000-000000000001','00000000-0000-0000-0000-000000000001')";
        //    _todoContext.Database.ExecuteSqlRaw(sql);
        //}

        /*
         * Attempt 2: adding data using SQL, basically use SQL command to insert new data into database
         *            When using SQL need to be careful with SQL injection
         *            Use SQLparameter() to prevent SQL injection
         * Note: Guid will be auto generated
         * **/
        // POST api/Todo
        [HttpPost("postSQL")]
        public void PostSQL([FromBody] TodoListPostDtos value)
        {
            var name = new SqlParameter("name", value.Name);

            string sql = @"INSERT INTO [dbo].[TodoList]
            ([Name]
            ,[InsertTime]
            ,[UpdateTime]
            ,[Enable]
            ,[Orders]
            ,[InsertEmployeeId]
            ,[UpdateEmployeeId])
        VALUES
            (@name,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + value.Enable + "'," + value.Orders + ",'00000000-0000-0000-0000-000000000001','00000000-0000-0000-0000-000000000001')";
            _todoContext.Database.ExecuteSqlRaw(sql, name);
        }


        /*
          * Attempt 1: adding parent and child data together, in step1 must do "SaveChanges()" so it will auto-generate id
          * Condition: No foreign key linking in the database
          * **/
        // POST api/Todo/nofk
        //[HttpPost("nofk")]
        //public void Postnofk([FromBody] TodoList value)
        //{
        //    // Step 1: Add parent data
        //    TodoList insert = new TodoList
        //    {
        //        //Insert parent by user
        //        Name = value.Name,
        //        Enable = value.Enable,
        //        Orders = value.Orders,
        //        //Auto generate by system
        //        InsertTime = DateTime.Now,
        //        UpdateTime = DateTime.Now,
        //        InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        //        UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
        //    };
        //    _todoContext.TodoLists.Add(insert);
        //    _todoContext.SaveChanges();

        //    // Step 2: Add child datas
        //    foreach(var temp in value.UploadFiles)
        //    {
        //       UploadFile insert2 = new UploadFile
        //       {
        //            Name = temp.Name,
        //            Src = temp.Src,
        //            TodoId = insert.TodoId        
        //       };
        //        _todoContext.UploadFiles.Add(insert2);
        //    }

        //    _todoContext.SaveChanges();
        //}

        /*
        * Attempt 2: adding parent and child data together, in step1 must do "SaveChanges()" so it will auto-generate id
        *            use DTO to prevent uncessary parameter exposed to user
        * Condition: No foreign key linking in the database
        * **/
        // POST api/Todo/nofk
        [HttpPost("nofk")]
        public void Postnofk([FromBody] TodoListPostDtos value)
        {
            // Step 1: Add parent data
            TodoList insert = new TodoList
            {
                //Insert parent by user
                Name = value.Name,
                Enable = value.Enable,
                Orders = value.Orders,
                //Auto generate by system
                InsertTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            };
            _todoContext.TodoLists.Add(insert);
            _todoContext.SaveChanges();

            // Step 2: Add child datas
            foreach (var temp in value.UploadFiles)
            {
                UploadFile insert2 = new UploadFile
                {
                    Name = temp.Name,
                    Src = temp.Src,
                    TodoId = insert.TodoId
                };
                _todoContext.UploadFiles.Add(insert2);
            }

            _todoContext.SaveChanges();
        }

        [HttpPost("up")]
        /*
         * api/Todo/up
         * 
         * Attempt 1: send todoitem and upload file at the same time
         *            FromForm data is only a string, we need to deserialize the string for it to recognize json
         * **/
        //public void PostUp([FromForm] string value, [FromForm] IFormFileCollection files)
        //{
        //    TodoList aa = JsonSerializer.Deserialize<TodoList>(value);
        //}

        /*
         * api/Todo/up
         * 
         * Attempt 2: send todoitem and upload file at the same time
         *            FromForm data is only a string, we need to deserialize the string for it to recognize json
         *            Use ModelBinding to convert string to target class
         * **/
        //public void PostUp([FromForm][ModelBinder(BinderType =typeof(FormDataJsonBinder))] TodoListPostDtos value, [FromForm] IFormFileCollection files)
        //{

        //}

        /*
         * api/Todo/up
         * 
         * Attempt 3: send todoitem and upload file at the same time
         *            FromForm data is only a string, we need to deserialize the string for it to recognize json
         *            Use ModelBinding to convert string to target class
         *            Refactor the paramater, because too long
         *            Upload Data get data id
         *            Upload file with data id as path
         * **/
        public void PostUp([FromForm] TodoListPostUpDtos value)
        {
            // Part1 Upload Data get data id
            TodoList insert = new TodoList
            {
                //Auto generate by system
                InsertTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            };

            _todoContext.TodoLists.Add(insert).CurrentValues.SetValues(value.TodoList);
            _todoContext.SaveChanges();

            // Part2 Upload file with data id as path
            string rootRoot = _env.ContentRootPath + @"\wwwroot\UploadFiles\" + insert.TodoId + "\\";

            if (!Directory.Exists(rootRoot))
            {
                // Check whether path exist, if not create one
                Directory.CreateDirectory(rootRoot);
            }

            foreach (var file in value.files)
            {
                var fileName = file.FileName;

                using (var stream = System.IO.File.Create(rootRoot + fileName))
                {
                    file.CopyTo(stream);
                }

                var insert2 = new UploadFile
                {
                    Name = fileName,
                    Src = "/UploadFiles/" + insert.TodoId + "/" + fileName,
                    TodoId = insert.TodoId
                };

                _todoContext.Add(insert2);
            }

            _todoContext.SaveChanges();
        }



        /*
         * Attempt 1: simple update data
         * **/
        // PUT api/Todo/{id}
        //[httpput("{id}")]
        //public void put(guid id, [frombody] todolist value)
        //{
        //    _todocontext.todolists.update(value);
        //    _todocontext.savechanges();
        //}

        /*
         * Attempt 2: update data using primary key
         *            without exposing uncessary parameter for user
         * **/
        // PUT api/Todo/{id}
        //[HttpPut("{id}")]
        //public void Put(Guid id, [FromBody] TodoListPutDtos value)
        //{

        //    // var update = _todoContext.TodoLists.Find(id); // another way search primary key

        //    // search primary key
        //    var update = (from a in _todoContext.TodoLists
        //                  where a.TodoId == id
        //                  select a).SingleOrDefault();

        //    if (update != null)
        //    {
        //        //Auto generate by system
        //        update.UpdateTime = DateTime.Now;
        //        update.UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001");

        //        //Input by user
        //        update.Name = value.Name;
        //        update.Orders = value.Orders;
        //        update.Enable = value.Enable;

        //        _todoContext.SaveChanges();
        //    }
        //}

        /*
         * Attempt 3: update data using primary key
         *            without exposing uncessary parameter for user
         *            use "SetValue" to reduce code
         * **/
        // PUT api/Todo/{id}
        //[HttpPut("{id}")]
        //public void Put(Guid id, [FromBody] TodoListPutDtos value)
        //{

        //    // var update = _todoContext.TodoLists.Find(id); // another way search primary key

        //    // search primary key
        //    var update = (from a in _todoContext.TodoLists
        //                  where a.TodoId == id
        //                  select a).SingleOrDefault();

        //    if (update != null)
        //    {
        //        //Auto generate by system
        //        update.UpdateTime = DateTime.Now;
        //        update.UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001");

        //        //Input by user
        //        _todoContext.TodoLists.Update(update).CurrentValues.SetValues(value);

        //        _todoContext.SaveChanges();
        //    }
        //}

        /*
         * Attempt 4: update data using primary key
         *            without exposing uncessary parameter for user
         *            use "SetValue" to reduce code
         *            Adding response message
         * **/
        // PUT api/Todo/{id}
        //[HttpPut("{id}")]
        //public IActionResult Put(Guid id, [FromBody] TodoListPutDtos value)
        //{
        //    if (id != value.TodoId)
        //    {
        //        return BadRequest();
        //    }

        //    // search primary key
        //    var update = (from a in _todoContext.TodoLists
        //                  where a.TodoId == id
        //                  select a).SingleOrDefault();

        //    if (update != null)
        //    {
        //        //Auto generate by system
        //        update.UpdateTime = DateTime.Now;
        //        update.UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001");

        //        //Input by user
        //        _todoContext.TodoLists.Update(update).CurrentValues.SetValues(value);

        //        _todoContext.SaveChanges();
        //    }
        //    else { 
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        // PUT api/Todo/   [[no id in url]]
        // attempt 1: no id in url
        //[HttpPut]
        //public void Put([FromBody] TodoListPutDtos value)
        //{

        //    // var update = _todoContext.TodoLists.Find(id); // another way search primary key

        //    // search primary key
        //    var update = (from a in _todoContext.TodoLists
        //                  where a.TodoId == value.TodoId
        //                  select a).SingleOrDefault();

        //    if (update != null)
        //    {
        //        //Auto generate by system
        //        update.InsertTime = DateTime.Now;
        //        update.UpdateTime = DateTime.Now;
        //        update.InsertEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        //        update.UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001");

        //        //Input by user
        //        update.Name = value.Name;
        //        update.Orders = value.Orders;
        //        update.Enable = value.Enable;

        //        _todoContext.SaveChanges();
        //    }
        //}

        /*
         * Attempt 1: basic patch a section of the data
         * **/
        // PATCH api/Todo/{id}
        [HttpPatch("{id}")]
        public void Patch(Guid id, [FromBody] JsonPatchDocument value)
        {
            // search primary key
            var update = (from a in _todoContext.TodoLists
                          where a.TodoId == id
                          select a).SingleOrDefault();

            if (update != null)
            {
                //Auto generate by system
                update.UpdateTime = DateTime.Now;
                update.UpdateEmployeeId = Guid.Parse("00000000-0000-0000-0000-000000000001");

                value.ApplyTo(update);

                _todoContext.SaveChanges();
            }
        }

        /*
         * Attempt 1: Delete data with id
         *            Delete parent must delete its child first
         * **/
        // DELETE api/Todo/{id}
        //[HttpDelete("{id}")]
        //public void Delete(Guid id)
        //{
        //    var delete = (from a in _todoContext.TodoLists
        //                  where a.TodoId == id 
        //                  select a).Include(c=>c.UploadFiles).SingleOrDefault();

        //    if(delete != null)
        //    {
        //        _todoContext.TodoLists.Remove(delete);
        //        _todoContext.SaveChanges();
        //    }
        //}

        /*
         * Attempt 2: Delete data with id
         *            Delete parent must delete its child first
         * **/
        // DELETE api/Todo/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var delete = (from a in _todoContext.TodoLists
                          where a.TodoId == id
                          select a).Include(c => c.UploadFiles).SingleOrDefault();

            if (delete == null)
            {
                return NotFound("Cannot found resource to delete");
            }
            
            _todoContext.TodoLists.Remove(delete);
            _todoContext.SaveChanges();

            return NoContent();
        }

        /*
         * Attempt 1: Delete data with id
         *            Delete both parent and child
         *            works when No foreign key link in database
         * **/
        // DELETE api/Todo/nofk/{id}
        [HttpDelete("nofk/{id}")]
        public void NofkDelete(Guid id)
        {
            // delete child
            var child = from a in _todoContext.UploadFiles
                        where a.TodoId == id     // we do this because there's a parent id in child
                        select a;

            _todoContext.UploadFiles.RemoveRange(child); // remove array of data
            _todoContext.SaveChanges();

            // delete parent
            var delete = (from a in _todoContext.TodoLists
                          where a.TodoId == id
                          select a).SingleOrDefault();

            if (delete != null)
            {
                _todoContext.TodoLists.Remove(delete);
                _todoContext.SaveChanges();
            }
        }

        /*
         * Attempt 1: Delete multiple data
         *            deserialize the string and convert it list of string
         * **/
        // DELETE api/Todo/item/["id1", "id2", "id3", ....]
        [HttpDelete("list/{ids}")]
        public void Delete(string ids)
        {
            // convert a string to a list of Guid
            List<Guid> deleteList = JsonSerializer.Deserialize<List<Guid>>(ids);

            var delete = (from a in _todoContext.TodoLists
                          where deleteList.Contains(a.TodoId)
                          select a).Include(c => c.UploadFiles);

            _todoContext.TodoLists.RemoveRange(delete); // RemoveRange(): remove multiple
            _todoContext.SaveChanges();
            
        }

        private static TodoListSelectDtos ItemToDto(TodoList a)
        {
            List<UploadFileDtos> updto = new List<UploadFileDtos>();

            foreach(var temp in a.UploadFiles)
            {
                UploadFileDtos up = new UploadFileDtos { 
                    Name = temp.Name,
                    Src = temp.Src,
                    TodoId = temp.TodoId,
                    UploadFileId = temp.UploadFileId
                };
                updto.Add(up);
            }
            return new TodoListSelectDtos
            {
                Enable = a.Enable,
                InsertEmployeeName = a.InsertEmployee?.Name,
                InsertTime = a.InsertTime,
                Name = a.Name,
                Orders = a.Orders,
                TodoId = a.TodoId,
                UpdateEmployeeName = a.UpdateEmployee?.Name,
                UpdateTime = a.UpdateTime,
                UploadFiles=updto
            };
        }
    }
}
