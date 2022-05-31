using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private DataContext context = new DataContext();
        private UserRepository<User> userRepository;
        private FlowerRepository<Flower> flowerRepository;
        private OrderRepository<Order> orderRepository; 

        public UserRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository<User>(context);
                }
                return userRepository;
            }
        }

        public FlowerRepository<Flower> FlowerRepository
        {
            get
            {
                if (this.flowerRepository == null)
                {
                    this.flowerRepository = new FlowerRepository<Flower>(context);
                }
                return flowerRepository;
            }
        }
        public OrderRepository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new OrderRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
