﻿namespace PrimePaper.API.DataContract.Cart
{
    public class CartResponse
    {
        public int CartEntityId { get; set; }
        public int ProductEntityId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

    }
}
