using BeautyCenter.Common.Types.Dto.Customer;
using BeautyCenter.Data.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyCenter.BusinessDomain.Customers
{
    public class CustomerDomain
    {
        public static Customer Create(CustomerDto customerDto)
        {
            var customer = new Customer();

            customer.Firstname = customerDto.Firstname;
            customer.Lastname = customerDto.Lastname;
            customer.Email = customerDto.Email;
            customer.Telephone = customerDto.Telephone;
            customer.RegisteredDate = DateTime.Now;
            customer.ModifiedAt = DateTime.Now;
            customer.CreatedAt = DateTime.Now;            
            return customer;
        }

        public static void Update(Customer customer, CustomerDto customerDto)
        {
            customer.Firstname = customerDto.Firstname;
            customer.Lastname = customerDto.Lastname;
            customer.Email = customerDto.Email;
            customer.Telephone = customerDto.Telephone;
        }

        public static void Delete(Customer customer)
        {
            customer.IsDeleted = true;
        }
    }
}
