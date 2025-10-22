using System;
using System.Collections.Generic;

namespace Project1
{
    class InventoryManager
    {
        struct stProduct
        {
            public string Name;
            public float Price;
            public int StockQuantity;
        }

        static List<stProduct> products = new List<stProduct>();
        static List<bool> ProductAvalability = new List<bool>();

        static void AddProduct()
        {
            Console.WriteLine("Enter New Product Details :");

            stProduct NewProduct = new stProduct();

            Console.Write("Enter Product Name : ");
            NewProduct.Name = Console.ReadLine();

            Console.Write("Enter Product Price : ");
            if (!float.TryParse(Console.ReadLine(), out float price))
            {
                Console.WriteLine("Invalid price. Operation cancelled.\n");
                return;
            }
            NewProduct.Price = price;

            Console.Write("Enter Product Quantity : ");
            if (!int.TryParse(Console.ReadLine(), out int Quant))
            {
                Console.WriteLine("Invalid quantity. Operation cancelled.\n");
                return;
            }
            NewProduct.StockQuantity = Quant;

            products.Add(NewProduct);

            ProductAvalability.Add(NewProduct.StockQuantity > 0);

            Console.WriteLine("Product Added Successfully.\n");
        }
        static void UpdateProductStock()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No Products To Update!\n");
                return;
            }

            Console.Write("Enter Product Number To Update: ");
            if (!int.TryParse(Console.ReadLine(), out int ProductNumber))
            {
                Console.WriteLine("Invalid number.\n");
                return;
            }

            if (ProductNumber > 0 && ProductNumber <= products.Count)
            {
                Console.Write("Enter New Stock Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int NewQuantitiy))
                {
                    Console.WriteLine("Invalid quantity.\n");
                    return;
                }

                stProduct UpdatedProduct = products[ProductNumber - 1];
                UpdatedProduct.StockQuantity = NewQuantitiy;
                products[ProductNumber - 1] = UpdatedProduct;

                ProductAvalability[ProductNumber - 1] = UpdatedProduct.StockQuantity > 0;

                Console.WriteLine("Product Updated Successfully\n");
            }
            else
            {
                Console.WriteLine("Invalid Product Number!\n");
            }
        }

        static void RemoveProduct()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No Products To Remove!\n");
                return;
            }

            Console.Write("Enter Product Number To Remove: ");
            if (!int.TryParse(Console.ReadLine(), out int ProductNumber))
            {
                Console.WriteLine("Invalid number.\n");
                return;
            }

            if (ProductNumber > 0 && ProductNumber <= products.Count)
            {
                products.RemoveAt(ProductNumber - 1);
                ProductAvalability.RemoveAt(ProductNumber - 1);

                Console.WriteLine("Product Removed Successfully\n");
            }
            else
            {
                Console.WriteLine("Invalid Product Number!\n");
            }
        }

        static void ViewAllProduct()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No Available Products\n");
                return;
            }

            Console.WriteLine("\nProduct List:");
            Console.WriteLine("-------------------------");

            for (int i = 0; i < products.Count; i++)
            {
                string status = ProductAvalability[i] ? "Available" : "Sold Out";

                Console.WriteLine($"{i + 1}. {products[i].Name} " +
                    $"(Price: {products[i].Price}, " +
                    $"Quantity: {products[i].StockQuantity}) " +
                    $"- {status}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string Answer;
            
            do
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Inventory Manager:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. View All Products");
                Console.WriteLine("5. Exit");
                Console.WriteLine("-----------------------------");

                Console.Write("Enter Your Choice: ");
                string Choise = Console.ReadLine();

                switch (Choise)
                {
                    case "1": AddProduct(); break;
                    case "2": UpdateProductStock(); break;
                    case "3": RemoveProduct(); break;
                    case "4": ViewAllProduct(); break;
                    case "5": Environment.Exit(0); break;
                    default: Console.WriteLine("Invalid Choice\n"); break;
                }

                Console.WriteLine("Are You Need Another Operation? (Y , N ) ");
                Answer = Console.ReadLine();

            } while (Answer.ToUpper() == "Y");
        }
    }
}
