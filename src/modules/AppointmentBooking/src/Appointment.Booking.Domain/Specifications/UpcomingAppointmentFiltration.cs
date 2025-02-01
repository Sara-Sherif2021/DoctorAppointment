
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace Appointment.Booking.Specifications;
public class UpcomingAppointmentFiltration : Specification<Entities.Appointment>
{
    #region Member Variables
    private readonly List<Guid> _slotIds;
    #endregion

    #region Constructors
    public UpcomingAppointmentFiltration(List<Guid> slotIds)
    {
        _slotIds = slotIds;
    }
    #endregion

    #region Public Methods
    public override Expression<Func<Entities.Appointment, bool>> ToExpression()
    {
        return app => _slotIds.Contains(app.SlotId) && app.AppointmentStatus == null;
    }
    #endregion
}
