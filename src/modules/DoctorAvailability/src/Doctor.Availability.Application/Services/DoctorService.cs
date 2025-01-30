

using Doctor.Availability.Dto;
using Doctor.Availability.Dto.Doctor;
using Doctor.Availability.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;


namespace Doctor.Availability.Services
{
    public class DoctorService : CrudAppService<Entities.Doctor, DoctorDto, int, PagedAndSortedResultRequestDto, CreateDoctorDto>, IScopedDependency
    {
        public DoctorService(IRepository<Entities.Doctor, int> repository) : base(repository)
        {
        }
    }
}
