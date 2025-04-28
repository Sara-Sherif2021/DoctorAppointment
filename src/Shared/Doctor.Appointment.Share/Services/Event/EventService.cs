using Doctor.Appointment.Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;

namespace Doctor.Appointment.Share.Services
{
    public class EventService<T> : ShareAppService, IEventService<T> where T : class
    {

        private readonly IDistributedEventBus _distributedEventBus;

        public EventService(IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }

        public async Task PublishEventAsync(T eventData)
        {
           
                await _distributedEventBus.PublishAsync<T>(eventData, true);
            
        }
    }
}
