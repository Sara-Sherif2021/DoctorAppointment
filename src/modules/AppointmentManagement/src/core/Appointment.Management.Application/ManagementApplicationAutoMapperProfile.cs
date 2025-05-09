using Appointment.Management.Dto;
using AutoMapper;

namespace Appointment.Management;

public class ManagementApplicationAutoMapperProfile : Profile
{
    public ManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Entities.Appointment, UpcomingAppointmentDto>();
    }
}
