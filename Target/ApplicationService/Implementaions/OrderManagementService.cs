using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementaions
{
    internal class OrderManagementService
    {
        public List<OrderDTO> Get()
        {
            List<OrderDTO> ordersDto = new List<OrderDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.OrderRepository.Get())
                {

                    ordersDto.Add(new OrderDTO
                    {
                        Id = item.Id,
                        UserId = item.UserId,
                    });

                }
            }
            return ordersDto;
        }
        public OrderDTO GetById(int id)
        {
            OrderDTO ordersDTO = new OrderDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Order order = unitOfWork.OrderRepository.GetByID(id);
                if (order != null)
                {ordersDTO = new OrderDTO
                {
                        Id = order.Id,
                        UserId = order.UserId,
                };
                }
            }

            return ordersDTO;
        }
        public bool Save(OrderDTO ordersDTO)
        {
            Order order = new Order()
            {
                UserId = ordersDTO.UserId,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.OrderRepository.Insert(order);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Order orders = unitOfWork.OrderRepository.GetByID(id);
                    unitOfWork.OrderRepository.Delete(orders);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(OrderDTO orderDto)
        {
            Order order = new Order()
            {
                Id = orderDto.Id,
                UserId=orderDto.UserId,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.OrderRepository.Update(order);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
