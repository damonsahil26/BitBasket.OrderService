using BitBasket.OrderService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.OrderService.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order?>> GetOrdersAsync();
        Task<IEnumerable<Order?>> GetOrdersByConditionAsync(Expression<Func<Order, bool>> condition);
        Task<Order?> GetOrderByConditionAsync(Expression<Func<Order, bool>> condition);
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrder(Guid orderId);  
    }
}
