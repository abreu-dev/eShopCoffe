using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data;
using eShopCoffe.Core.Extensions;
using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Ordering.Application.Contracts;
using eShopCoffe.Ordering.Application.Parameters.Interfaces;
using eShopCoffe.Ordering.Application.Queries.Handlers;
using eShopCoffe.Ordering.Application.Queries.OrderQueries;
using eShopCoffe.Ordering.Domain.Enums;
using eShopCoffe.Ordering.Infra.Data.Entities;

namespace eShopCoffe.Ordering.Application.Tests.Queries.Handlers
{
    public class OrderQueryHandlerTests
    {
        private readonly IBaseContext _context;
        private readonly ISessionAccessor _sessionAccessor;
        private readonly OrderQueryHandler _orderQueryHandler;

        public OrderQueryHandlerTests()
        {
            _context = Substitute.For<IBaseContext>();
            _sessionAccessor = Substitute.For<ISessionAccessor>();
            _orderQueryHandler = new OrderQueryHandler(_context, _sessionAccessor);
        }

        [Fact]
        public void Handle_PagedOrdersQuery_ShouldReturnPagedList()
        {
            // Arrange
            var orderParameters = Substitute.For<IOrderParameters>();
            orderParameters.Page.Returns(0);
            orderParameters.Size.Returns(2);
            var pagedOrdersQuery = new PagedOrdersQuery(orderParameters);

            var ordersDataList = new List<OrderData>()
            {
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "1 - Cep",
                    Number = "1 - Number",
                    PaymentMethod = PaymentMethod.DebitCard,
                    CurrencyCode = "1 - CurrencyCode",
                    CurrencyValue = 10,
                    Status = OrderStatus.Pending,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Pending,
                            Date = new DateTime(2022, 10, 01)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "1 - Name",
                                ImageUrl = "1 - ImageUrl"
                            },
                            Amount = 1,
                            CurrencyCode = "1 - Code",
                            CurrencyValue = 10
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "5 - Cep",
                    Number = "5 - Number",
                    PaymentMethod = PaymentMethod.CreditCard,
                    CurrencyCode = "5 - CurrencyCode",
                    CurrencyValue = 50,
                    Status = OrderStatus.Delivered,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Delivered,
                            Date = new DateTime(2022, 10, 05)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "5 - Name",
                                ImageUrl = "5 - ImageUrl"
                            },
                            Amount = 5,
                            CurrencyCode = "5 - Code",
                            CurrencyValue = 50
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "3 - Cep",
                    Number = "3 - Number",
                    PaymentMethod = PaymentMethod.Pix,
                    CurrencyCode = "3 - CurrencyCode",
                    CurrencyValue = 30,
                    Status = OrderStatus.Canceled,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Canceled,
                            Date = new DateTime(2022, 10, 03)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "3 - Name",
                                ImageUrl = "3 - ImageUrl"
                            },
                            Amount = 3,
                            CurrencyCode = "3 - Code",
                            CurrencyValue = 30
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "2 - Cep",
                    Number = "2 - Number",
                    PaymentMethod = PaymentMethod.Cash,
                    CurrencyCode = "2 - CurrencyCode",
                    CurrencyValue = 20,
                    Status = OrderStatus.InProduction,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.InProduction,
                            Date = new DateTime(2022, 10, 02)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "2 - Name",
                                ImageUrl = "2 - ImageUrl"
                            },
                            Amount = 2,
                            CurrencyCode = "2 - Code",
                            CurrencyValue = 20
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "4 - Cep",
                    Number = "4 - Number",
                    PaymentMethod = PaymentMethod.DebitCard,
                    CurrencyCode = "4 - CurrencyCode",
                    CurrencyValue = 40,
                    Status = OrderStatus.Delivered,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Delivered,
                            Date = new DateTime(2022, 10, 04)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "4 - Name",
                                ImageUrl = "4 - ImageUrl"
                            },
                            Amount = 4,
                            CurrencyCode = "4 - Code",
                            CurrencyValue = 40
                        }
                    }
                },
            };
            _context.Query<OrderData>().Returns(ordersDataList.AsQueryable());

            // Act
            var result = _orderQueryHandler.Handle(pagedOrdersQuery).Result;

            // Assert
            result.TotalItems.Should().Be(5);
            result.Data.Should().HaveCount(2);

            result.Data.ElementAt(0).Id.Should().Be(ordersDataList.ElementAt(4).Id);
            result.Data.ElementAt(0).Address.Cep.Should().Be(ordersDataList.ElementAt(4).Cep);
            result.Data.ElementAt(0).Address.Number.Should().Be(ordersDataList.ElementAt(4).Number);
            result.Data.ElementAt(0).PaymentMethod.Should().Be(ordersDataList.ElementAt(4).PaymentMethod.GetEnumDisplayName());
            result.Data.ElementAt(0).CurrencyValue.Should().Be(ordersDataList.ElementAt(4).CurrencyValue);
            result.Data.ElementAt(0).CurrencyCode.Should().Be(ordersDataList.ElementAt(4).CurrencyCode);
            result.Data.ElementAt(0).Status.Should().Be(ordersDataList.ElementAt(4).Status.GetEnumDisplayName());
            result.Data.ElementAt(0).CreatedDate.Should().Be(ordersDataList.ElementAt(4).CreatedDate);
            result.Data.ElementAt(0).Events.ElementAt(0).Status.Should().Be(ordersDataList.ElementAt(4).Events.ElementAt(0).Status.GetEnumDisplayName());
            result.Data.ElementAt(0).Events.ElementAt(0).Date.Should().Be(ordersDataList.ElementAt(4).Events.ElementAt(0).Date);
            result.Data.ElementAt(0).Items.ElementAt(0).Name.Should().Be(ordersDataList.ElementAt(4).Items.ElementAt(0).Product.Name);
            result.Data.ElementAt(0).Items.ElementAt(0).ImageUrl.Should().Be(ordersDataList.ElementAt(4).Items.ElementAt(0).Product.ImageUrl);
            result.Data.ElementAt(0).Items.ElementAt(0).Amount.Should().Be(ordersDataList.ElementAt(4).Items.ElementAt(0).Amount);
            result.Data.ElementAt(0).Items.ElementAt(0).CurrencyCode.Should().Be(ordersDataList.ElementAt(4).Items.ElementAt(0).CurrencyCode);
            result.Data.ElementAt(0).Items.ElementAt(0).CurrencyValue.Should().Be(ordersDataList.ElementAt(4).Items.ElementAt(0).CurrencyValue);

            result.Data.ElementAt(1).Id.Should().Be(ordersDataList.ElementAt(3).Id);
            result.Data.ElementAt(1).Address.Cep.Should().Be(ordersDataList.ElementAt(3).Cep);
            result.Data.ElementAt(1).Address.Number.Should().Be(ordersDataList.ElementAt(3).Number);
            result.Data.ElementAt(1).PaymentMethod.Should().Be(ordersDataList.ElementAt(3).PaymentMethod.GetEnumDisplayName());
            result.Data.ElementAt(1).CurrencyValue.Should().Be(ordersDataList.ElementAt(3).CurrencyValue);
            result.Data.ElementAt(1).CurrencyCode.Should().Be(ordersDataList.ElementAt(3).CurrencyCode);
            result.Data.ElementAt(1).Status.Should().Be(ordersDataList.ElementAt(3).Status.GetEnumDisplayName());
            result.Data.ElementAt(1).CreatedDate.Should().Be(ordersDataList.ElementAt(3).CreatedDate);
            result.Data.ElementAt(1).Events.ElementAt(0).Status.Should().Be(ordersDataList.ElementAt(3).Events.ElementAt(0).Status.GetEnumDisplayName());
            result.Data.ElementAt(1).Events.ElementAt(0).Date.Should().Be(ordersDataList.ElementAt(3).Events.ElementAt(0).Date);
            result.Data.ElementAt(1).Items.ElementAt(0).Name.Should().Be(ordersDataList.ElementAt(3).Items.ElementAt(0).Product.Name);
            result.Data.ElementAt(1).Items.ElementAt(0).ImageUrl.Should().Be(ordersDataList.ElementAt(3).Items.ElementAt(0).Product.ImageUrl);
            result.Data.ElementAt(1).Items.ElementAt(0).Amount.Should().Be(ordersDataList.ElementAt(3).Items.ElementAt(0).Amount);
            result.Data.ElementAt(1).Items.ElementAt(0).CurrencyCode.Should().Be(ordersDataList.ElementAt(3).Items.ElementAt(0).CurrencyCode);
            result.Data.ElementAt(1).Items.ElementAt(0).CurrencyValue.Should().Be(ordersDataList.ElementAt(3).Items.ElementAt(0).CurrencyValue);
        }

        [Fact]
        public void Handle_OrderDetailQuery_WhenOrderFound_ShouldReturnSingleObject()
        {
            // Arrange
            var orderDetailQuery = new OrderDetailQuery(Guid.NewGuid());

            var ordersDataList = new List<OrderData>()
            {
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "1 - Cep",
                    Number = "1 - Number",
                    PaymentMethod = PaymentMethod.DebitCard,
                    CurrencyCode = "1 - CurrencyCode",
                    CurrencyValue = 10,
                    Status = OrderStatus.Pending,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Pending,
                            Date = new DateTime(2022, 10, 01)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "1 - Name",
                                ImageUrl = "1 - ImageUrl"
                            },
                            Amount = 1,
                            CurrencyCode = "1 - Code",
                            CurrencyValue = 10
                        }
                    }
                },
                new OrderData()
                {
                    Id = orderDetailQuery.OrderId,
                    Cep = "5 - Cep",
                    Number = "5 - Number",
                    PaymentMethod = PaymentMethod.CreditCard,
                    CurrencyCode = "5 - CurrencyCode",
                    CurrencyValue = 50,
                    Status = OrderStatus.Delivered,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Delivered,
                            Date = new DateTime(2022, 10, 05)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "5 - Name",
                                ImageUrl = "5 - ImageUrl"
                            },
                            Amount = 5,
                            CurrencyCode = "5 - Code",
                            CurrencyValue = 50
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "3 - Cep",
                    Number = "3 - Number",
                    PaymentMethod = PaymentMethod.Pix,
                    CurrencyCode = "3 - CurrencyCode",
                    CurrencyValue = 30,
                    Status = OrderStatus.Canceled,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Canceled,
                            Date = new DateTime(2022, 10, 03)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "3 - Name",
                                ImageUrl = "3 - ImageUrl"
                            },
                            Amount = 3,
                            CurrencyCode = "3 - Code",
                            CurrencyValue = 30
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "2 - Cep",
                    Number = "2 - Number",
                    PaymentMethod = PaymentMethod.Cash,
                    CurrencyCode = "2 - CurrencyCode",
                    CurrencyValue = 20,
                    Status = OrderStatus.InProduction,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.InProduction,
                            Date = new DateTime(2022, 10, 02)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "2 - Name",
                                ImageUrl = "2 - ImageUrl"
                            },
                            Amount = 2,
                            CurrencyCode = "2 - Code",
                            CurrencyValue = 20
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "4 - Cep",
                    Number = "4 - Number",
                    PaymentMethod = PaymentMethod.DebitCard,
                    CurrencyCode = "4 - CurrencyCode",
                    CurrencyValue = 40,
                    Status = OrderStatus.Delivered,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Delivered,
                            Date = new DateTime(2022, 10, 04)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "4 - Name",
                                ImageUrl = "4 - ImageUrl"
                            },
                            Amount = 4,
                            CurrencyCode = "4 - Code",
                            CurrencyValue = 40
                        }
                    }
                },
            };
            _context.Query<OrderData>().Returns(ordersDataList.AsQueryable());

            // Act
            var result = _orderQueryHandler.Handle(orderDetailQuery).Result;

            // Assert
            result.Id.Should().Be(ordersDataList.ElementAt(1).Id);
            result.Address.Cep.Should().Be(ordersDataList.ElementAt(1).Cep);
            result.Address.Number.Should().Be(ordersDataList.ElementAt(1).Number);
            result.PaymentMethod.Should().Be(ordersDataList.ElementAt(1).PaymentMethod.GetEnumDisplayName());
            result.CurrencyValue.Should().Be(ordersDataList.ElementAt(1).CurrencyValue);
            result.CurrencyCode.Should().Be(ordersDataList.ElementAt(1).CurrencyCode);
            result.Status.Should().Be(ordersDataList.ElementAt(1).Status.GetEnumDisplayName());
            result.CreatedDate.Should().Be(ordersDataList.ElementAt(1).CreatedDate);
            result.Events.ElementAt(0).Status.Should().Be(ordersDataList.ElementAt(1).Events.ElementAt(0).Status.GetEnumDisplayName());
            result.Events.ElementAt(0).Date.Should().Be(ordersDataList.ElementAt(1).Events.ElementAt(0).Date);
            result.Items.ElementAt(0).Name.Should().Be(ordersDataList.ElementAt(1).Items.ElementAt(0).Product.Name);
            result.Items.ElementAt(0).ImageUrl.Should().Be(ordersDataList.ElementAt(1).Items.ElementAt(0).Product.ImageUrl);
            result.Items.ElementAt(0).Amount.Should().Be(ordersDataList.ElementAt(1).Items.ElementAt(0).Amount);
            result.Items.ElementAt(0).CurrencyCode.Should().Be(ordersDataList.ElementAt(1).Items.ElementAt(0).CurrencyCode);
            result.Items.ElementAt(0).CurrencyValue.Should().Be(ordersDataList.ElementAt(1).Items.ElementAt(0).CurrencyValue);

        }

        [Fact]
        public void Handle_OrderDetailQuery_WhenOrderNotFound_ShouldReturnEmpty()
        {
            // Arrange
            var orderDetailQuery = new OrderDetailQuery(Guid.NewGuid());

            var ordersDataList = new List<OrderData>()
            {
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "1 - Cep",
                    Number = "1 - Number",
                    PaymentMethod = PaymentMethod.DebitCard,
                    CurrencyCode = "1 - CurrencyCode",
                    CurrencyValue = 10,
                    Status = OrderStatus.Pending,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Pending,
                            Date = new DateTime(2022, 10, 01)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "1 - Name",
                                ImageUrl = "1 - ImageUrl"
                            },
                            Amount = 1,
                            CurrencyCode = "1 - Code",
                            CurrencyValue = 10
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "5 - Cep",
                    Number = "5 - Number",
                    PaymentMethod = PaymentMethod.CreditCard,
                    CurrencyCode = "5 - CurrencyCode",
                    CurrencyValue = 50,
                    Status = OrderStatus.Delivered,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Delivered,
                            Date = new DateTime(2022, 10, 05)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "5 - Name",
                                ImageUrl = "5 - ImageUrl"
                            },
                            Amount = 5,
                            CurrencyCode = "5 - Code",
                            CurrencyValue = 50
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "3 - Cep",
                    Number = "3 - Number",
                    PaymentMethod = PaymentMethod.Pix,
                    CurrencyCode = "3 - CurrencyCode",
                    CurrencyValue = 30,
                    Status = OrderStatus.Canceled,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Canceled,
                            Date = new DateTime(2022, 10, 03)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "3 - Name",
                                ImageUrl = "3 - ImageUrl"
                            },
                            Amount = 3,
                            CurrencyCode = "3 - Code",
                            CurrencyValue = 30
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "2 - Cep",
                    Number = "2 - Number",
                    PaymentMethod = PaymentMethod.Cash,
                    CurrencyCode = "2 - CurrencyCode",
                    CurrencyValue = 20,
                    Status = OrderStatus.InProduction,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.InProduction,
                            Date = new DateTime(2022, 10, 02)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "2 - Name",
                                ImageUrl = "2 - ImageUrl"
                            },
                            Amount = 2,
                            CurrencyCode = "2 - Code",
                            CurrencyValue = 20
                        }
                    }
                },
                new OrderData()
                {
                    Id = Guid.NewGuid(),
                    Cep = "4 - Cep",
                    Number = "4 - Number",
                    PaymentMethod = PaymentMethod.DebitCard,
                    CurrencyCode = "4 - CurrencyCode",
                    CurrencyValue = 40,
                    Status = OrderStatus.Delivered,
                    Events = new List<OrderEventData>()
                    {
                        new OrderEventData()
                        {
                            Status = OrderStatus.Delivered,
                            Date = new DateTime(2022, 10, 04)
                        }
                    },
                    Items = new List<OrderItemData>()
                    {
                        new OrderItemData()
                        {
                            Product = new ProductData()
                            {
                                Name = "4 - Name",
                                ImageUrl = "4 - ImageUrl"
                            },
                            Amount = 4,
                            CurrencyCode = "4 - Code",
                            CurrencyValue = 40
                        }
                    }
                },
            };
            _context.Query<OrderData>().Returns(ordersDataList.AsQueryable());

            var empty = new OrderDto();

            // Act
            var result = _orderQueryHandler.Handle(orderDetailQuery).Result;

            // Assert
            result.Id.Should().Be(empty.Id);
            result.Address.Should().Be(empty.Address);
            result.PaymentMethod.Should().Be(empty.PaymentMethod);
            result.CurrencyValue.Should().Be(empty.CurrencyValue);
            result.CurrencyCode.Should().Be(empty.CurrencyCode);
            result.Status.Should().Be(empty.Status);
            result.CreatedDate.Should().Be(empty.CreatedDate);
            result.Events.Should().BeEquivalentTo(empty.Events);
            result.Items.Should().BeEquivalentTo(empty.Items);
        }
    }
}
