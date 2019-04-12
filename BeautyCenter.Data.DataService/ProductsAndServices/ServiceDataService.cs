using BeautyCenter.Common.Infra.DataLayer;
using BeautyCenter.Data.Context.UnitOfWork;
using BeautyCenter.Data.Entities.ProductsAndServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Data.DataService.ProductsAndServices
{
    public interface IServiceDataService
    {
        Task<Service> AddAsync(Service service);
        Task<Service> GetServiceById(int? serviceId);
        Task<Service> Update(Service customer);
        Task<List<Service>> GetAllServices();
    }

    public class ServiceDataService : BaseDataService, IServiceDataService
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

        public ServiceDataService(IUnitOfWork unitOfWork, IRepository repository, IReadOnlyRepository readOnlyRepository)
        {
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Service> AddAsync(Service service)
        {
            repository.Create(service);
            await SaveChanges();
            return service;
        }

        public async Task<List<Service>> GetAllServices()
        {
            return await readOnlyRepository.GetQueryable<Service>().Where(c => c.IsDeleted == false).ToListAsync();
        }

        public async Task<Service> GetServiceById(int? serviceId)
        {
            return await readOnlyRepository.GetQueryable<Service>().FirstOrDefaultAsync(p => p.Id == serviceId && p.IsDeleted == false);
        }

        public async Task<Service> Update(Service service)
        {
            repository.Update(service);
            await SaveChanges();
            return service;
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }
    }
}
