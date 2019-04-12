using BeautyCenter.Common.Infra.DataLayer;
using BeautyCenter.Data.Context.UnitOfWork;
using BeautyCenter.Data.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Data.DataService.Payments
{

    public interface IPaymentDataService
    {
        Task<List<Payment>> GetCustomerPayments(int? customerId);
    }

    public class PaymentDataService : BaseDataService, IPaymentDataService
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

        public PaymentDataService(IRepository repository, IReadOnlyRepository readOnlyRepository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Payment>> GetCustomerPayments(int? customerId)
        {
            return await readOnlyRepository.GetQueryable<Payment>()
                         .Include(i => i.Customer)
                         .Where(c => c.CustomerId == customerId && c.Customer.IsDeleted == false)
                         .ToListAsync();
        }
    }
}
