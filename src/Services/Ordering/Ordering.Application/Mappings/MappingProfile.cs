using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ordering.Application.Feachuers.Orders.Commands.CheckOutOrder;
using Ordering.Application.Feachuers.Orders.Queries;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings
{
   public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<Order, CheckOutOrderCommand>().ReverseMap();
        }
    }
}
