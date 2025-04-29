using Bank.API.Models;
using Bank.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/bank/{bankId}/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Models.Employee>> GetAll(int bankId)
        {
            var bank = BankDataStore.Current.Banks.FirstOrDefault(x => x.Id == bankId);

            if (bank == null)
            {
               return NotFound("el banco solicitado no existe");
            }

            if (!bank.Employees.Any())
            {
                return NotFound($"No se encontraron empleados en el banco {bankId}");
            }

            return Ok(bank.Employees);
        }

        [HttpGet("{employeeId}")]
        public ActionResult<Models.Employee> GetById(int bankId, int employeeId)
        {
            var bank = BankDataStore.Current.Banks.FirstOrDefault(x => x.Id == bankId);

            if (bank == null)
            {
               return NotFound("el banco solicitado no existe");
            }

            var employee = bank.Employees.FirstOrDefault(e => e.Id == employeeId);

            if(employee == null)
            {
                return NotFound("El empleado solicitado no existe");
            }

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Models.Employee> Create(int bankId, EmployeeRequest employeeRequest)
        {
            var bank = BankDataStore.Current.Banks.FirstOrDefault(x => x.Id == bankId);

            if (bank == null)
            {
               return NotFound("el banco solicitado no existe");
            }

            int max = bank.Employees.Max(x => x.Id);

            var newEmployee = new Models.Employee
            {
                Id = max + 1,
                Name = employeeRequest.Name,
                Age = employeeRequest.Age
            };

            bank.Employees.Add(newEmployee);

            return CreatedAtAction(nameof(GetById),
                new
                {
                    bankId = bankId,
                    employeeId = newEmployee.Id
                },
                newEmployee
            );
        }

        [HttpPut("{employeeId}")]
        public ActionResult<Models.Employee> Update(int bankId, int employeeId, EmployeeRequest employeeRequest)
        {
            var bank = BankDataStore.Current.Banks.FirstOrDefault(x => x.Id == bankId);

            if (bank == null)
            {
               return NotFound("el banco solicitado no existe");
            }

            var employee = bank.Employees.FirstOrDefault(e => e.Id == employeeId);

            if(employee == null)
            {
                return NotFound("El empleado solicitado no existe");
            }

            employee.Name = employeeRequest.Name;
            employee.Age = employeeRequest.Age;

            return NoContent();

        }

        [HttpDelete("{employeeId}")]
        public ActionResult<Models.Employee> Delete(int bankId, int employeeId)
        {
            var bank = BankDataStore.Current.Banks.FirstOrDefault(x => x.Id == bankId);

            if (bank == null)
            {
               return NotFound("el banco solicitado no existe");
            }

            var employee = bank.Employees.FirstOrDefault(e => e.Id == employeeId);

            if(employee == null)
            {
                return NotFound("El empleado solicitado no existe");
            }

            bank.Employees.Remove(employee);

            return NoContent();
        }
    }
}
