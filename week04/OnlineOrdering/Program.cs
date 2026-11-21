using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("           ONLINE ORDERING SYSTEM                 ");
        Console.WriteLine("==================================================\n");

        // ------------------------------------------------------------------
        // Order 1: Domestic Customer (USA)
        // ------------------------------------------------------------------
        Address address1 = new Address("452 Center Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Emily Johnson", address1);
        Order order1 = new Order(customer1);

        Product product1A = new Product("Ergonomic Wireless Mouse", "WM-101", 24.99, 2);
        Product product1B = new Product("Mechanical Gaming Keyboard", "KB-204", 79.50, 1);
        Product product1C = new Product("USB-C Braided Cable 6ft", "CB-305", 9.99, 3);

        order1.AddProduct(product1A);
        order1.AddProduct(product1B);
        order1.AddProduct(product1C);

        // ------------------------------------------------------------------
        // Order 2: International Customer (Canada)
        // ------------------------------------------------------------------
        Address address2 = new Address("789 Maple Leaf Avenue", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Liam Tremblay", address2);
        Order order2 = new Order(customer2);

        Product product2A = new Product("Noise Cancelling Headphones", "NC-401", 149.99, 1);
        Product product2B = new Product("Headphone Stand Aluminum", "HS-502", 29.95, 1);
        Product product2C = new Product("Audio Jack Adapter", "AJ-603", 12.50, 2);

        order2.AddProduct(product2A);
        order2.AddProduct(product2B);
        order2.AddProduct(product2C);

        // ------------------------------------------------------------------
        // Order 3: International Customer (United Kingdom)
        // ------------------------------------------------------------------
        Address address3 = new Address("12 Victoria Road", "London", "Greater London", "United Kingdom");
        Customer customer3 = new Customer("Sophie Taylor", address3);
        Order order3 = new Order(customer3);

        Product product3A = new Product("Ultra-Wide Curved Monitor 34-inch", "MN-701", 399.00, 1);
        Product product3B = new Product("Heavy Duty Monitor Arm", "MA-802", 45.00, 1);

        order3.AddProduct(product3A);
        order3.AddProduct(product3B);

        // Store all orders in a list to iterate and display
        List<Order> orders = new List<Order> { order1, order2, order3 };

        for (int i = 0; i < orders.Count; i++)
        {
            Order order = orders[i];
            Console.WriteLine($"******************* ORDER #{i + 1} *******************");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Order Price (including shipping): ${order.CalculateTotalCost():F2}");
            Console.WriteLine("***************************************************\n");
        }
    }
}
