﻿using System.Threading.Tasks;

namespace Doctor.Appointment.Share.Services
{
    public interface IEventService<T> where T : class
    {
        Task PublishEventAsync(T eventData);
    }
}