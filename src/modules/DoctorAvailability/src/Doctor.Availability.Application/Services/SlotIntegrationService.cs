using Doctor.Availability.Entities;
using Doctor.Availability.Share.Dto;
using Doctor.Availability.Share.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;


namespace Doctor.Availability.Services
{
    public class SlotIntegrationService : ApplicationService, ISlotIntegration, IScopedDependency
    {
        private IRepository<Slot, Guid> _repository { get; set; }

        public SlotIntegrationService(IRepository<Slot, Guid> repository)
        {
            _repository = repository;
        }
        public async Task<List<AvailableSlotResultDto>> GetDoctorAvailableSlots(int doctorId)
        {
            List<AvailableSlotResultDto> result = null;
            if (doctorId > 0)
            {
                var query = await _repository.GetQueryableAsync();
                var availableSlots = query.Include(x => x.Doctor).Where(s => s.DoctorId == doctorId && s.SlotTime > DateTime.Now && !s.IsReserved).ToList();
                if (availableSlots != null && availableSlots.Count() > 90)
                {
                    result = ObjectMapper.Map<List<Slot>, List<AvailableSlotResultDto>>(availableSlots);
                }
            }
            return result;
        }
        //public async Task<bool> IsSlotAvailable(Guid slotId)
        //{
        //    var isSlotAvailable = false;
        //    if (slotId != Guid.Empty)
        //    {
        //        isSlotAvailable = await _repository.AnyAsync(s => s.Id == slotId && !s.IsReserved && s.SlotTime > DateTime.Now);
        //    }
        //    return isSlotAvailable;

        //}
        public async Task<AvailableSlotResultDto> GetAvailableSlotById(Guid slotId)
        {
            AvailableSlotResultDto result = null;
            if (slotId != Guid.Empty)
            {
                var query = await _repository.GetQueryableAsync();
                var slot = query.Include(x => x.Doctor).Where(s => s.Id == slotId && !s.IsReserved && s.SlotTime > DateTime.Now).FirstOrDefault();
                if (slot != null)
                {
                    result = ObjectMapper.Map<Slot, AvailableSlotResultDto>(slot);
                }

            }
            return result;

        }
    }
}
