using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class SubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IRouteRepository _routeRepository;

        public SubscriptionService(
            ISubscriptionRepository subscriptionRepository,
            IRouteRepository routeRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _routeRepository = routeRepository;
        }

        public async Task SubscribeAsync(CreateSubscriptionDto dto)
        {
            var exists = await _subscriptionRepository
                .ExistsAsync(dto.StudentId, dto.RouteId);

            if (exists)
                throw new Exception("Student already subscribed to this route");

            var subscription = new Subscription(
                dto.StudentId,
                dto.RouteId,
                DateTime.UtcNow
            );

            await _subscriptionRepository.AddAsync(subscription);
        }
    }
}
