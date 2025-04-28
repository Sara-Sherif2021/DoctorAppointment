
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace Appointment.Management.Specifications;
public class AppointmentListFiltration : Specification<Entities.Appointment>
{
    #region Member Variables
    private readonly List<Guid> _appointmentListIds;
    #endregion

    #region Constructors
    public AppointmentListFiltration(List<Guid> appointmentListIds)
    {
        _appointmentListIds = appointmentListIds;
    }
    #endregion

    #region Public Methods
    public override Expression<Func<Entities.Appointment, bool>> ToExpression()
    {
        return app => _appointmentListIds.Contains(app.Id);
    }
    #endregion
}
