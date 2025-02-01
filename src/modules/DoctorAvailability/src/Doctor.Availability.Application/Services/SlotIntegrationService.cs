using Doctor.Availability.Entities;
using Doctor.Availability.Share.Dto;
using Doctor.Availability.Share.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;


namespace Doctor.Availability.Services
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [IntegrationService]
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
                if (availableSlots != null && availableSlots.Count() > 0)
                {
                    result = ObjectMapper.Map<List<Slot>, List<AvailableSlotResultDto>>(availableSlots);
                }
            }
            return result;
        }
        public async Task<List<UpcomingSlotResultDto>> GetDoctorUpcomingSlots(int doctorId)
        {
            List<UpcomingSlotResultDto> result = null;
            if (doctorId > 0)
            {
                var query = await _repository.GetQueryableAsync();
                var sots = query.Where(s => s.DoctorId == doctorId && s.SlotTime > DateTime.Now && s.IsReserved).ToList();
                if (sots != null && sots.Count() > 0)
                {
                    result = ObjectMapper.Map<List<Slot>, List<UpcomingSlotResultDto>>(sots);
                }
            }
            return result;
        }
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
