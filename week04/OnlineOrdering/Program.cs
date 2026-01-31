using System;

using System;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Welcome to Online Ordering Program!");

        // ORDER 1 (American customer)
        
        Address addr1 = new Address(
            "Sesame street",
            "Stockton",
            "CA",
            "USA"
        );

        Customer cust1 = new Customer("Chloe Park", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Wireless Headphones", "WH-1001", 18.99m, 2));
        order1.AddProduct(new Product("HDMI Cable", "HC-2040", 7.50m, 3));
        order1.AddProduct(new Product("Display Arm", "DA-7288", 25.00m, 1));

    
        // ORDER 2 (International customer)
    
        Address addr2 = new Address(
            "22 Rue de la Kasbah",
            "Marrakech",
            "Marrakech-Safi",
            "Morocco"
        );

        Customer cust2 = new Customer("Amina Kussur", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Notebook", "NB-3321", 3.25m, 10));
        order2.AddProduct(new Product("Pen Pack", "PP-9090", 5.75m, 2));


        //ORDER 3 (INTERNATION CUSTOMER)
        Address addr3 = new Address(

            "Via de Fori Imperiali, 12",
            "rome",
            "RM",
            "Italy"
        );

        Customer cust3 = new Customer("Giuseppe Rossi", addr3);

        Order order3 = new Order(cust3);
        order3.AddProduct(new Product("PowerBank", "PB-5421", 15.8m, 2));
        order3.AddProduct(new Product("Iphone Case", "CC-2016", 54.31m, 1));


        // DISPLAY RESULTS
        
        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
        Console.WriteLine();
        DisplayOrder(order3);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("====================================");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("------------------------------------");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"TOTAL PRICE: ${order.CalculateTotalCost():0.00}");
        Console.WriteLine("====================================");
    }
}
