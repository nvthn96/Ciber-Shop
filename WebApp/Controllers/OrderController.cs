using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Extension.Pagging;
using WebApp.Models.Request.Shoping;
using WebApp.Models.Response.Shoping;
using WebApp.Services.Interface;

namespace WebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        public OrderController(ILogger<OrderController> logger, IOrderService orderService, IProductService productService, ICustomerService customerService)
        {
            _logger = logger;
            _orderService = orderService;
            _productService = productService;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = new ViewPagging<ViewOrderResponse>();
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> GetPartialViewOrder(ViewPagging<ViewOrderResponse> request)
        {
            var cts = new CancellationTokenSource();
            var items = await _orderService.GetPaggingAsync(request, cts.Token);
            return PartialView("_ViewOrder", items);
        }

        public async Task<ActionResult> Create()
        {
            var cts = new CancellationTokenSource();
            var products = await _productService.GetAllAsync(cts.Token);
            var customers = await _customerService.GetAllAsync(cts.Token);

            ViewBag.Products = products
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();

            ViewBag.Customers = customers
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try {
                var newItem = new OrderRequest() {
                    Id = Guid.NewGuid(),
                    Amount = Convert.ToInt32(collection["Amount"]),
                    CustomerId = Guid.Parse(collection["CustomerId"]),
                    ProductId = Guid.Parse(collection["ProductId"]),
                    OrderDate = DateTime.Parse(collection["OrderDate"]),
                };

                var cts = new CancellationTokenSource();
                var result = await _orderService.CreateAsync(newItem, cts.Token);

                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

    }
}
