using BeautyCenter.Common.Infra.DataLayer;
using BeautyCenter.Common.Types.Dto.Customer;
using BeautyCenter.Data.Context.UnitOfWork;
using BeautyCenter.Data.Entities.Appointments;
using BeautyCenter.Data.Entities.Customers;
using BeautyCenter.Data.Entities.Operations;
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
        Task<List<Customer>> GetCustomersByText(string text);
        Task<bool> IsCustomerExistsWithEmail(string email);
        Task<CustomerDetailDto> GetCustomerDetail(int? customerId);
        Task<List<Appointment>> GetCustomerAppointments(int? customerId);
        Task<List<Operation>> GetCustomerOperations(int? customerId);
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
            return await readOnlyRepository.GetQueryable<Customer>().FirstOrDefaultAsync(p => p.Id == CustomerId && p.IsDeleted == false);
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

        public async Task<List<Customer>> GetCustomersByText(string text)
        {
            return await readOnlyRepository.GetQueryable<Customer>().Where(c => c.Firstname.Contains(text) && c.IsDeleted == false).ToListAsync();
        }

        public async Task<bool> IsCustomerExistsWithEmail(string email)
        {
            return await readOnlyRepository.GetQueryable<Customer>().Where(c => c.Email == email && c.IsDeleted == false).AnyAsync();
        }

        public async Task<CustomerDetailDto> GetCustomerDetail(int? customerId)
        {
            var result = await readOnlyRepository.GetQueryable<Customer>()
                .Include(c=>c.Operations)
                .Where(p => p.Id == customerId && p.IsDeleted == false)
                .FirstOrDefaultAsync(p => p.Id == customerId && p.IsDeleted == false);

            CustomerDetailDto customerDetail = new CustomerDetailDto();

            customerDetail.Id = result.Id;
            customerDetail.Fullname = result.Firstname + " " + result.Lastname;
            customerDetail.Email = result.Email;
            customerDetail.Telephone = result.Telephone;
            customerDetail.TotalOperationPrice = result.Operations.Sum(s => s.Amount);
            customerDetail.TotalPaid = result.Operations.Where(s => s.IsPaid == true).Sum(s => s.Amount);
            customerDetail.TotalUnpaid = result.Operations.Where(s => s.IsPaid == false).Sum(s => s.Amount);
                
            return customerDetail;
        }

        public async Task<List<Appointment>> GetCustomerAppointments(int? customerId)
        {
            return await readOnlyRepository.GetQueryable<Appointment>()
                .Include(s => s.Service)
                .Where(a => a.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Operation>> GetCustomerOperations(int? customerId)
        {
            return await readOnlyRepository.GetQueryable<Operation>()
                .Include(s => s.Service)
                .Include(d=>d.OperationDetails)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }

    }
}
