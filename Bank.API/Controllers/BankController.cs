using Bank.API.Models;
using Bank.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Models.Bank>> GetAll(){
            return Ok(BankDataStore.Current.Banks);
        }

        [HttpGet("{Id}")]
        public ActionResult<Models.Bank> GetById(int id){
            var bank = BankDataStore.Current.Banks.FirstOrDefault(x => x.Id == id);
            if(bank == null){
                return NotFound("El banco solicitado no existe.");
            }

            return Ok(bank);
        }

        [HttpPost]
        public ActionResult<Models.Bank> Create(BankRequest bankRequest){
            int max = BankDataStore.Current.Banks.Max(x => x.Id);

            var newBank = new Models.Bank
            {
                Id = max + 1,
                Name = bankRequest.Name,
                Country = bankRequest.Country,
                SwiftCode = "ABCD",
                EstablishedYear = 0,
                IsActive = false,
                Employees = new List<Employee>()
            };

            BankDataStore.Current.Banks.Add(newBank);

            return CreatedAtAction(nameof(GetById),
                new
                {
                    Id = newBank.Id
                },
                newBank
            );

            
        }

        [HttpPut("{id}")]
        public ActionResult<Models.Bank> Update(int id, BankRequest bankRequest)
        {
            var bank = BankDataStore.Current.Banks.FirstOrDefault(x => x.Id == id);
            if(bank == null){
                return NotFound("El banco solicitado no existe.");
            }

            bank.Name = bankRequest.Name;
            bank.Country = bankRequest.Country;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Models.Bank> Delete(int id){
            var bank = BankDataStore.Current.Banks.FirstOrDefault(x => x.Id == id);
            if(bank == null){
                return NotFound("El banco solicitado no existe.");
            }

            BankDataStore.Current.Banks.Remove(bank);

            return NoContent();
        }
    }
}
