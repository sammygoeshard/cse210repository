using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal total = 0m;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // One-time shipping cost based on location
        decimal shippingCost;
        if (_customer.LivesInUSA()) 
        {
            shippingCost =5m;
        }
        else
        {
            shippingCost = 35m;
        }

        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        // Packing label lists product name + product id for each product
        string label = "PACKING LABEL\n";

        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return label.TrimEnd(); 
    }

    public string GetShippingLabel()
    {
        // Shipping label lists customer name + full address
        return "SHIPPING LABEL\n" + _customer.GetShippingLabelText();
    }
}
