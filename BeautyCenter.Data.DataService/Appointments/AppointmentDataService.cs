using BeautyCenter.Common.Infra.DataLayer;
using BeautyCenter.Data.Context.UnitOfWork;
using BeautyCenter.Data.Entities.Appointments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Data.DataService.Appointments
{
    public interface IAppointmentDataService
    {
        Task<Appointment> Add(Appointment appointment);
        Task<List<Appointment>> GetAllAppointments();
    }

    public class AppointmentDataService : BaseDataService, IAppointmentDataService
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

        public AppointmentDataService(IUnitOfWork unitOfWork, IRepository repository, IReadOnlyRepository readOnlyRepository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
        }

        public async Task<Appointment> Add(Appointment appointment)
        {

            repository.Create(appointment);
            await SaveChanges();
            return appointment;
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await readOnlyRepository.GetQueryable<Appointment>().Include(ap => ap.Service).
                Where(c => c.IsDeleted == false).ToListAsync();
        }

        public Task<int> SaveChanges()
        {
            unitOfWork.SaveChanges();
            return Task.FromResult(0);
        }

    }
}
