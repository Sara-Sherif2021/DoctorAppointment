

using Doctor.Availability.Dto;
using Doctor.Availability.Dto.Slot;
using Doctor.Availability.Entities;
using Doctor.Availability.Share.Dto;
using Doctor.Availability.Share.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;


namespace Doctor.Availability.Services
{
    [IntegrationService]
    public class SlotIntegrationService : AvailabilityAppService, IScopedDependency, ISlotIntegration
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
                var availableSlots = query.Where(s => s.DoctorId == doctorId && s.SlotTime > DateTime.Now && !s.IsReserved).ToList();
                result = ObjectMapper.Map<List<Slot>, List<AvailableSlotResultDto>>(availableSlots);
            }
            return result;
        }
        public async Task<bool> IsSlotAvailable(Guid slotId)
        {
            var isSlotAvailable = false;
            if (slotId != Guid.Empty)
            {
                isSlotAvailable = await _repository.AnyAsync(s => s.Id == slotId && !s.IsReserved && s.SlotTime > DateTime.Now);
            }
            return isSlotAvailable;

        }
    }
}
