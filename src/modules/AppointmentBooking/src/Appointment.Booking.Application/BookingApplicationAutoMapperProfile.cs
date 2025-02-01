using AutoMapper;
using Doctor.Availability.Share.Dto;
using Appointment.Booking.Dto;
using Appointment.Booking.Share.Dto;
namespace Appointment.Booking;

public class BookingApplicationAutoMapperProfile : Profile
{
    public BookingApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<AvailableSlotResultDto, DoctorAvailableSlotsDto>();

        CreateMap<Entities.Appointment, AppointmentDto>();
        CreateMap<Entities.Appointment, UpcomingAppointmentDto>();

    }
}
