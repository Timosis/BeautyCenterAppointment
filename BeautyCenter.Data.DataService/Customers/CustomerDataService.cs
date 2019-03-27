using BeautyCenter.Common.Infra.DataLayer;
using BeautyCenter.Data.Context.UnitOfWork;
using BeautyCenter.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Data.DataService.Customers
{

    public interface ICustomerDataService
    {
        Task<Customer> Add(Customer customer);
        Task<Customer> GetCustomerById(int? customerId);
        Task<Customer> Update(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<bool> IsCustomerExistsWithEmail(string email);

    }

    public class CustomerDataService : BaseDataService, ICustomerDataService
    {
        private readonly IRepository repository;
        private readonly IReadOnlyRepository readOnlyRepository;
        IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public CustomerDataService(IUnitOfWork unitOfWork,IRepository repository,IReadOnlyRepository readOnlyRepository)
        {
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Customer> Add(Customer customer)
        {
            repository.Create(customer);            
            await SaveChanges();
            return customer;            
        }
   
        public async Task<Customer> GetCustomerById(int? CustomerId)
        {
            return await readOnlyRepository.GetQueryable<Customer>().FirstOrDefaultAsync(p => p.Id == CustomerId && !p.IsDeleted);
        }

        public async Task<Customer> Update(Customer customer)
        {
            repository.Update(customer);
            await SaveChanges();
            return customer;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await readOnlyRepository.GetQueryable<Customer>().Where(c => c.IsDeleted == false).ToListAsync();
        }

        public async Task<bool> IsCustomerExistsWithEmail(string email)
        {
            return await readOnlyRepository.GetQueryable<Customer>().Where(c => c.Email == email && c.IsDeleted == false).AnyAsync();
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }

    }
}
