using AutoMapper;
using Doctor.Availability.Dto.Doctor;
using Doctor.Availability.Dto.Slot;
using Doctor.Availability.Entities;
using Doctor.Availability.Share.Dto;

namespace Doctor.Availability;

public class AvailabilityApplicationAutoMapperProfile : Profile
{
    public AvailabilityApplicationAutoMapperProfile()
    {
        CreateMap<Slot, SlotDto>();
        CreateMap<SlotDto, Slot>();
        CreateMap<Slot, AvailableSlotResultDto>()
            .ForMember(d => d.DoctorName, s => s.MapFrom(l => l.Doctor.Name))
            .ForMember(d => d.DoctorEmail, s => s.MapFrom(l => l.Doctor.Email));
        CreateMap<Slot, UpcomingSlotResultDto>();

        CreateMap<CreateDoctorDto, Entities.Doctor>();
        CreateMap<DoctorDto, Entities.Doctor>();
        CreateMap<Entities.Doctor, DoctorDto>();
    }
}
