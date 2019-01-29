using POSApi.Models;
using POSApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POSApi.App_Data
{
    
    public class CustomerController : ApiController
    {
        
        GenericRepository<Customer> repository = new GenericRepository<Customer>(new dofactoryEntities());
        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            return repository.GetAll();
        }

        // GET: api/Customer/5
        public Customer Get(int id)
        {
            return repository.GetById(id);
        }

        // POST: api/Customer
        public void Post([FromBody]Customer customer)
        {
            
            repository.Insert(customer);
            repository.Save();
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]Customer customer)
        {
            repository.Update(customer);
            repository.Save();
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
