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
        private IRepository<Slot, Guid> _repository { get; set; }
        public SlotService(IRepository<Slot, Guid> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<SlotDto>> GetDoctorSlots(int doctorId)
        {
            List<SlotDto> result = null;
            if (doctorId > 0)
            {
                var query = await _repository.GetQueryableAsync();
                var slots = query.Where(s => s.DoctorId == doctorId).ToList();
                result = ObjectMapper.Map<List<Slot>, List<SlotDto>>(slots);
            }
            return result;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<SlotDto> UpdateAsync(Guid id, SlotDto input)
        {
            return base.UpdateAsync(id, input);
        }
    }
}
