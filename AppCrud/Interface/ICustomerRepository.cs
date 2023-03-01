using System.Collections.Generic;
using System;
using AppCrud.Models;

namespace AppCrud.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetList();
        List<Customer> GetListLike(string Name);
        Customer GetById(int Id);
        String Add(Customer Customer);
        String Update(int Id, Customer Customer);
        String Delete(int Id);
    }
}
