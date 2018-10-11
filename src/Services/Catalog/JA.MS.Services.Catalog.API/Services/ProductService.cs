using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace JA.MS.Services.Catalog.API.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IServiceProvider serviceProvider)
        {
            _productRepository = serviceProvider
                .GetRequiredService<IProductRepository>();
            _logger = serviceProvider
                          .GetService<ILogger<ProductService>>() ??
                      NullLogger<ProductService>.Instance;
        }

        internal IProductRepository ProductRepository => _productRepository;
    }
}
