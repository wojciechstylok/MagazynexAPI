using MagazynexAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarcodeController : ControllerBase
    {
        private static readonly Barcode[] Barcodes = new[]
        {
            new Barcode("007001", "Woda mineralna gazowana", 6, "szt", "2021/05/10"),
            new Barcode("007002", "Woda mineralna niegazowana", 6, "szt", "2021/05/09"),
            new Barcode("007003", "Tyskie, czteropak", 4, "szt", "2021LA03"),
            new Barcode("007004", "Papier toaletowy", 36, "paczka", "D99UP-01A"),
            new Barcode("007005", "Prince Polo", 54, "pudełko", "SDA091L")
        };

        private readonly ILogger<BarcodeController> _logger;

        public BarcodeController(ILogger<BarcodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getInfo/{code}")]
        public Barcode GetProductInfo([FromRoute]string code)
        {
            Barcode barcode = null;
            foreach (var bc in Barcodes)
            {
                if (bc.Code == code)
                {
                    barcode = bc;
                }
            }
            return barcode;
        }
    }
}
