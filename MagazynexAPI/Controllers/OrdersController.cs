using AutoMapper;
using MagazynexAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace MagazynexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly Order[] Orders = new[]
        {
            new Order("ZK/2021/0001", 1),
            new Order("ZK/2021/0002", 2),
            new Order("ZK/2021/0003", 1),
            new Order("ZK/2021/0004", 3),
            new Order("ZK/2021/0005", 3)
        };

        private static readonly OrderItem[] OrderItems = new[]
        {
            new OrderItem(Orders[0].Number, BarcodeController.Barcodes[0], 2),
            new OrderItem(Orders[0].Number, BarcodeController.Barcodes[2], 1),
            new OrderItem(Orders[0].Number, BarcodeController.Barcodes[3], 4),
            new OrderItem(Orders[1].Number, BarcodeController.Barcodes[4], 1),
            new OrderItem(Orders[1].Number, BarcodeController.Barcodes[2], 1),
            new OrderItem(Orders[2].Number, BarcodeController.Barcodes[0], 3),
            new OrderItem(Orders[2].Number, BarcodeController.Barcodes[2], 2),
            new OrderItem(Orders[2].Number, BarcodeController.Barcodes[4], 1),
            new OrderItem(Orders[2].Number, BarcodeController.Barcodes[1], 6),
            new OrderItem(Orders[2].Number, BarcodeController.Barcodes[3], 1),
            new OrderItem(Orders[3].Number, BarcodeController.Barcodes[3], 3)
        };

        private readonly ILogger<BarcodeController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(ILogger<BarcodeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        // .../orders/all
        public IActionResult GetUnrealizedOrders()
        {
            var result = new List<Order>();
            foreach (var order in Orders)
            {
                if (!order.IsRealized)
                {
                    result.Add(order);
                }
            }

            if (result.Count > 0)
            {
                return Ok(JsonSerializer.Serialize(result));
            }

            return NotFound("No unrealized orders");
        }

        [HttpPut]
        [Route("reset")]
        // .../orders/reset
        public IActionResult ResetOrders()
        {
            foreach (var order in Orders)
            {
                order.IsRealized = false;
            }

            return Ok();
        }

        [HttpGet]
        [Route("order")]
        // .../orders/order?orderNumber=ZK/2021/0001
        public IActionResult GetOrderItems([FromQuery] string orderNumber)
        {
            var result = new List<OrderItem>();
            foreach(var item in OrderItems)
            {
                if(item.OrderNumber == orderNumber)
                {
                    result.Add(item);
                }
            }

            if(result.Count > 0)
            {
                return Ok(JsonSerializer.Serialize(result));
            }

            return NotFound("No items for this order");
        }

        [HttpPut]
        [Route("realize")]
        // .../orders/realize?orderNumber=ZK/2021/0001
        public IActionResult RealizeOrder([FromQuery] string orderNumber)
        {
            foreach (var order in Orders)
            {
                if(order.Number == orderNumber)
                {
                    order.IsRealized = true;
                    return Ok("Order " + orderNumber + " is realized");
                }
            }

            return NotFound("Order not found");
        }
    }
}
