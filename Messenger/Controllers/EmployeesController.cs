using Messenger.Data;
using Messenger.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Messenger.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly ILogger<EmployeesController> _logger;
        /// <summary>
        /// Employees Controller Constructor
        /// </summary>
        /// <param name="db"></param>
        public EmployeesController(ApplicationDbContext db,
            ILogger<EmployeesController> logger
            )
        {
            this.db = db;
            _logger = logger;
        }

        /// <summary>
        /// Action for getting the all Employees
        /// </summary>
        /// <returns>Employees</returns>
        [HttpGet]
        public IAsyncEnumerable<Employee> GetAll([FromQuery] string pageOptions)
        {
            try
            {
                var pageOptionsInput = JsonSerializer.Deserialize<PageOptions>(
                    pageOptions, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                return db.Employes
                    .GetEmployeesWithPageOptions(pageOptionsInput)
                    .AsAsyncEnumerable();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error on retrieving  employees");

                return AsyncEnumerable.Empty<Employee>();
            }
        }

        /// <summary>
        /// Get the exact Employee by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Employee object</returns>
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await db.Employes
                .Include(e => e.FullName)
                .Include(e => e.WorkingPlace)
                .FirstAsync(e => e.Id == id);
        }

        /// <summary>
        /// Add a new Employee
        /// </summary>
        /// <param name="employee">Employee abject</param>
        /// <returns>Ok response</returns>
        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            try
            {
                await db.Employes.AddAsync(employee);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error on creation employee");

                return BadRequest();
            }
        }

        /// <summary>
        /// Edit an exact Employee
        /// </summary>
        /// <param name="value">Employee</param>
        [HttpPut]
        public async Task<IActionResult> Put(Employee employee)
        {
            db.Update(employee);
            await db.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Delete Employee by id
        /// </summary>
        /// <param name="id">Id</param>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            db.Employes.Remove(await db.Employes.FindAsync(id));
            await db.SaveChangesAsync();

            return Ok();
        }
    }
}
