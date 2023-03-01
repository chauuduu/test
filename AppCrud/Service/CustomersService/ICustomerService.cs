using AppCrud.Models;
using System.Collections.Generic;

namespace AppCrud.Service.CustomersService
{
    public interface ICustomerService
    {
        List<Customer> GetList();
        List<Customer> GetListLike(string Name);
        Customer GetById(int Id);

        string Add(Customer Customer);
        string Update(int Id, Customer Customer);
        string Delete(int Id);
    }
}