using AutoMapper;
using MLA.ClientOrder.Application.View_Models;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Linq;
using System.Reflection;

namespace MLA.ClientOrder.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssemblyFrom(Assembly.GetExecutingAssembly());
            ApplyMappingsFromAssemblyTo(Assembly.GetExecutingAssembly());
            MapOrder();
        }

        private void ApplyMappingsFromAssemblyFrom(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });

            }
        }

        private void ApplyMappingsFromAssemblyTo(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                    ?? type.GetInterface("IMapTo`1").GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });

            }
        }

        private void MapOrder()
        {
            CreateMap<Orders, OrderViewModel>()
              .ForMember(x => x.LeadLayer, opt => opt.Ignore())
              .ForMember(x => x.LawFirmInvolved, opt => opt.Ignore())
              .ForMember(x => x.OtherLayers, opt => opt.Ignore())
              .ForMember(x => x.CrossJudiciaries, opt => opt.Ignore())
              .ForMember(x => x.CompletedDate, opt => opt.MapFrom(x => x.CompletedDate.ToShortDateString()))
              .ForMember(x => x.StartedDate, opt => opt.MapFrom(x => x.StartedDate.ToShortDateString()));
        }
    }
}
