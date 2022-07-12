using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Threading.Tasks;
using AutoMapper;
using customeronboard.Data;
using customeronboard.Dtos;
using customeronboard.Models;
using customeronboard.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace customeronboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _repo;
        private readonly IMapper _mapper;
        private readonly string db = Path.Combine(Environment.CurrentDirectory, "States");
        private readonly CustomerDbContext _context;
        HttpClientHandler _clientHandler = new HttpClientHandler();

        public CustomerController(ICustomerRepo repo, IMapper mapper, CustomerDbContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) =>
            {
                return true;
            };
        }

        /// <summary>
        /// Gets all the customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerReadDto>> GetCustomers()
        {
            //Console.WriteLine("---> Getting Customers.....");
            var customerDetails = _repo.GetAllCustomers();
            return Ok(customerDetails);
        }


        /// <summary>
        /// Gets Each Specific customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCustomerById")]
        public ActionResult<CustomerReadDto> GetCustomerById(int id)
        {
            var customerDetails = _repo.GetCustomerById(id);
            if (customerDetails != null)
            {
                return Ok(customerDetails);
            }
            return NotFound();

        }


        /// <summary>
        /// Onboard customer by verifying their phone numbers and mapping their lga. 
        /// </summary>
        /// <param name="customerCreateDto"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public ActionResult<Customer> AddCustomer(CustomerCreateDto customerCreateDto)
        {

            var result = new Customer
            {
                Id = customerCreateDto.Id,
                Name = customerCreateDto.Name,
                PhoneNumber = customerCreateDto.PhoneNumber,
                Email = customerCreateDto.Email,
                Password = customerCreateDto.Password,
                Residence = customerCreateDto.Residence,
                LGA = customerCreateDto.LGA
            };


            
            
            OTPservice.OTPServiceExtensions(customerCreateDto.PhoneNumber);

            
                var query = _context.StateTable
                    .Where(s => s.State_Name == customerCreateDto.Residence)
                    .FirstOrDefault();
                
                var query2 = _context.LGATable
                    .Where(s => s.LGA_Name == customerCreateDto.LGA)
                    .FirstOrDefault();

                result.Residence = query.State_Name;
                result.LGA = query2.LGA_Name;
          

            

            _repo.CreateCustomer(result);
            _repo.SaveChanges();


            return CreatedAtRoute(nameof(GetCustomerById), new { id = result.Id }, result);
        }


        /// <summary>
        /// Edit Customer information
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>A</returns>
        [HttpPost("update")]
        public ActionResult<CustomerReadDto> UpdateCustomer(CustomerReadDto customer)
        {

            var result = new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Password = customer.Password,
                Residence = customer.Residence,
                LGA = customer.LGA
            };
            _repo.UpdateCustomer(result);
            _repo.SaveChanges();

            return Ok(result);
        }


        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<CustomerReadDto> DeleteCustomer(string name)
        {
            _repo.DeleteCustomerByName(name);
            _repo.SaveChanges();
            return Ok();
        }


        [HttpGet("Banks")]
        public async Task<List<Bank>> GetBanks(int id)
        {
            /*var result = new Bank
            {
                result = {"bankName: string", "bankCode: string"},
                errorMessage = "string",
                errorMessages = ["string"],
                hasError = true,
                timeGenerated = DateTime.Now,
            };*/
            var _getBanks = new List<Bank>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync(
                           "https://wema-alatdev-apimgt.developer.azure-api.net/api-details#api=alat-tech-test-api"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    _getBanks = JsonConvert.DeserializeObject<List<Bank>>(apiResponse);
                }
            }

            return _getBanks;

        }
    }
}
