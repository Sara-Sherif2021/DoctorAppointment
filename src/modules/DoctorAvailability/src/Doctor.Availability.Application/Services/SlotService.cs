using Doctor.Availability.Dto.Slot;
using Doctor.Availability.Entities;
using Doctor.Availability.Share.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;


namespace Doctor.Availability.Services
{
    public class SlotService : CrudAppService<Slot, SlotDto, Guid, PagedAndSortedResultRequestDto>, IScopedDependency
    {
        private IRepository<Slot, Guid> _slotRepository { get; set; }
        public SlotService(IRepository<Slot, Guid> slotRepository) : base(slotRepository)
        {
            _slotRepository = slotRepository;
        }

        public async Task<List<SlotDto>> GetDoctorSlots(int doctorId)
        {
            List<SlotDto> result = null;
            if (doctorId > 0)
            {
                var query = await _slotRepository.GetQueryableAsync();
                var slots = query.Where(s => s.DoctorId == doctorId).ToList();
                result = ObjectMapper.Map<List<Slot>, List<SlotDto>>(slots);
            }
            return result;
        }
    }
}
