using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Feachuers.Orders.Queries.GetOrderList
{
   public class GetOrderListQuery:IRequest<List<OrderVM>>
    {
        public string  UserName { get; set; }

        public GetOrderListQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
