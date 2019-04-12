using BeautyCenter.Common.Infra.DataLayer;
using BeautyCenter.Data.Context.UnitOfWork;
using BeautyCenter.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Data.DataService.Operations
{

    public interface IOperationsDataService
    {
        Task<List<Operation>> GetCustomerOperations(int? customerId);
        Task<List<OperationDetail>> GetCustomerOperationsDetail(int? customerOperationId);
    }

    public class OperationsDataService : BaseDataService, IOperationsDataService
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

        public OperationsDataService(IRepository repository, IReadOnlyRepository readOnlyRepository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Operation>> GetCustomerOperations(int? customerId)
        {
            return await readOnlyRepository.GetQueryable<Operation>()
                .Include(s => s.Service)
                .Include(d => d.OperationDetails)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<OperationDetail>> GetCustomerOperationsDetail(int? customerOperationId)
        {
             return await readOnlyRepository.GetQueryable<OperationDetail>()
                .Include(d => d.Operation)                
                .Where(d => d.OperationId == customerOperationId)
                .ToListAsync();
        }
    }
}
