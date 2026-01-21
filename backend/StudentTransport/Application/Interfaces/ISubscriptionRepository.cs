using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ISubscriptionRepository : IGenericRepository<Subscription>
    {
        Task<bool> ExistsAsync(int studentId, int routeId);
    }
}
