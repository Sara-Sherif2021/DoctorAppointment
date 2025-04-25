using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Doctor.Availability.Entities;


namespace Doctor.Availability.DataSeed
{
    public class DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private IRepository<Slot, Guid> _slotRepository { get; set; }
        private IRepository<Entities.Doctor, int> _doctorRepository { get; set; }

        public DataSeedContributor(IRepository<Slot, Guid> slotRepository, IRepository<Entities.Doctor, int> doctorRepository = null)
        {
            _slotRepository = slotRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _doctorRepository.InsertAsync(new Entities.Doctor(1, "doc1", "doc1@gmail.com", null));
            await _doctorRepository.InsertAsync(new Entities.Doctor(2, "doc2", "doc2@gmail.com", null));

            await _slotRepository.InsertAsync(new Slot(new Guid(), DateTime.Now, 1, true, 100));
            await _slotRepository.InsertAsync(new Slot(new Guid(), DateTime.Now.AddDays(-1), 1, false, 100));
            await _slotRepository.InsertAsync(new Slot(new Guid(), DateTime.Now.AddDays(1), 1, false, 100));
            await _slotRepository.InsertAsync(new Slot(new Guid(), DateTime.Now, 2, true, 200));
            await _slotRepository.InsertAsync(new Slot(new Guid(), DateTime.Now, 2, false, 200));

        }
    }
}
