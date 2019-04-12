using BeautyCenter.Common.Infra.DataLayer;
using BeautyCenter.Data.Context.UnitOfWork;
using BeautyCenter.Data.Entities.Installments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Data.DataService.Installments
{

    public interface IInstallmentDataService
    {
        Task<List<Installment>> GetCustomerInstallments(int? customerId);
    }

    public class InstallmentDataService : IInstallmentDataService
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

        public InstallmentDataService(IRepository repository, IReadOnlyRepository readOnlyRepository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Installment>> GetCustomerInstallments(int? customerId)
        {
            return await readOnlyRepository.GetQueryable<Installment>()
                .Include(i => i.Customer)
                .Include(d=>d.InstallmentDetails)
                .Where(c => c.CustomerId == customerId && c.Customer.IsDeleted == false)
                .ToListAsync();                
        }
    }
}
