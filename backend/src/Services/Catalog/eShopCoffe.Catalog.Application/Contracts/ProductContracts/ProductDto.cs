﻿namespace eShopCoffe.Catalog.Application.Contracts.ProductContracts
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string QuantityAvailable { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}
