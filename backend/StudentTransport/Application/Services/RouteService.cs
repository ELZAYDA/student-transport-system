using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class RouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task CreateRouteAsync(AuthResponse dto)
        {
            var route = new Route(
                dto.DriverId,
                dto.Name,
                dto.StartPoint,
                dto.EndPoint,
                dto.DepartureTime,
                dto.Capacity
            );

            await _routeRepository.AddAsync(route);
        }

        public async Task<IReadOnlyList<RouteDto>> GetActiveRoutesAsync()
        {
            var routes = await _routeRepository.GetActiveRoutesAsync();

            return routes.Select(r => new RouteDto
            {
                Id = r.Id,
                Name = r.Name,
                StartPoint = r.StartPoint,
                EndPoint = r.EndPoint,
                Capacity = r.Capacity,
                CurrentOccupancy = r.CurrentOccupancy
            }).ToList();
        }
    }
}
