using BitBasket.OrderService.DataAccess.Entities;
using BitBasket.OrderService.DataAccess.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace BitBasket.OrderService.DataAccess.Repositoris
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<Order> _orders;
        private readonly string _collectionName = "orders";

        public OrderRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            _orders = _mongoDatabase.GetCollection<Order>(_collectionName);
        }

        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                order.OrderId = Guid.NewGuid();
                await _orders.InsertOneAsync(order);
                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            try
            {
                var orderFromDb = await _orders.FindOneAndDeleteAsync(options => options.OrderId == orderId);

                if (orderFromDb == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order?> GetOrderByConditionAsync(Expression<Func<Order, bool>> condition)
        {
            return await (await _orders.FindAsync(condition)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order?>> GetOrdersAsync()
        {
            return await (await _orders.FindAsync(Builders<Order>.Filter.Empty))
                .ToListAsync();
        }

        public async Task<IEnumerable<Order?>> GetOrdersByConditionAsync(Expression<Func<Order, bool>> condition)
        {
            return await (await _orders.FindAsync(condition)).ToListAsync();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var orderFromDb = await _orders.ReplaceOneAsync(x=>x.OrderId == order.OrderId, order);

            return order;
        }
    }
}
