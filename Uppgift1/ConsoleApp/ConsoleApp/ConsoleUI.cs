using ConsoleApp.Services;

namespace ConsoleApp;

internal class ConsoleUI
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public ConsoleUI(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }


    public void ShowMenu_UI()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("------ MAIN MENU ------\n");

            Console.WriteLine("1. Create Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Create Customer");
            Console.WriteLine("6. Update Customer");
            Console.WriteLine("7. View Customers");
            Console.WriteLine("8. Delete Customer");
            Console.WriteLine("9. Exit");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateProduct_UI();
                    break;
                case "2":
                    UpdateProduct_UI();
                    break;
                case "3":
                    GetProducts_UI();
                    break;
                case "4":
                    DeleteProduct_UI();
                    break;
                case "5":
                    CreateCustomer_UI();
                    break;
                case "6":
                    UpdateCustomer_UI();
                    break;
                case "7":
                    GetCustomers_UI();
                    break;
                case "8":
                    DeleteCustomer_UI();
                    break;
                case "9":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
        }



    }
    public void CreateProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("---- Create Product ----");

        Console.Write("Product Title: ");
        var title = Console.ReadLine()!;

        Console.Write("Product Price: ");
        var price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Product Category: ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateProduct(title, price, categoryName);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product was created");
            Console.ReadKey();
            
        }
    }

    public void GetProducts_UI()
    {
        Console.Clear();
        var products = _productService.GetProducts();
        Console.WriteLine("---- PRODUCTS ----");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} - {product.Price} SEK");
        }

        Console.ReadKey();
        
    }

    public void UpdateProduct_UI()
    {
        Console.Clear();
        Console.Write("Enter Product Id: ");
        var productId = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(productId);
        if (product != null)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
            Console.WriteLine();

            Console.WriteLine("Choose attribute to update:");
            Console.WriteLine("1. Product Title");
            Console.WriteLine("2. Product Price");
            Console.WriteLine("3. Product Category");

            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("New Product Title: ");
                    product.Title = Console.ReadLine()!;
                    break;
                case "2":
                    Console.Write("New Product Price: ");
                    product.Price = decimal.Parse(Console.ReadLine()!);
                    break;
                case "3":
                    Console.Write("New Product Category: ");
                    product.Category.CategoryName = Console.ReadLine()!;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    return;
            }

            var updatedProduct = _productService.UpdateProduct(product);
            Console.WriteLine($"{updatedProduct.Title} - {updatedProduct.Category.CategoryName} ({updatedProduct.Price} SEK) updated successfully.");
        }
        else
        {
            Console.WriteLine("No product found.");
        }

        Console.ReadKey();
    }

    public void DeleteProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("--- DELETE PRODUCT ---\n");
        Console.Write("Enter Product Id: ");
        var productId = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(productId);

        if (product != null)
        {
            _productService.DeleteProduct(productId);
            Console.WriteLine("Product was successfully removed!");
            
        }
        else
        {
            Console.WriteLine("Product not found!");
        }

        Console.ReadKey();
    }

    public void CreateCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("---- Create Product ----");

        Console.Write("Firstname: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Lastname: ");
        var lastName = Console.ReadLine()!;

        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Streetname: ");
        var streetname = Console.ReadLine()!;

        Console.Write("Postalcode: ");
        var postalcode = Console.ReadLine()!;


        Console.Write("City: ");
        var city = Console.ReadLine()!;

        Console.Write("Rolename: ");
        var rolename = Console.ReadLine()!;


        var result = _customerService.CreateCustomer(firstName, lastName, email, rolename, streetname, postalcode, city);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Customer was added");            

        }
        else
        {
            Console.WriteLine("Customer was not added. Please try again!");
        }
        Console.ReadKey();
    }

    public void GetCustomers_UI() 
    { 
        Console.Clear() ;
        Console.WriteLine("---- CUSTOMERS ----\n");

        var customers = _customerService.GetCustomers();

        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} - {customer.LastName} - {customer.Email} - {customer.Role.RoleName} - {customer.Address.StreetName} - {customer.Address.PostalCode} - {customer.Address.City}");
        }

        Console.ReadKey();
    }

    public void UpdateCustomer_UI()
    {
        Console.Clear();
        Console.Write("Enter Customer Id: ");
        var customerId = int.Parse(Console.ReadLine()!);

        var customer = _customerService.GetCustomerById(customerId);
        if (customer != null)
        {
            Console.WriteLine($"{customer.FirstName} - {customer.LastName} - {customer.Email} - {customer.Role.RoleName} - {customer.Address.StreetName} - {customer.Address.PostalCode} - {customer.Address.City}");
            Console.WriteLine();

            Console.WriteLine("Choose attribute to update:\n");
            Console.WriteLine("1. Customer Firstname");
            Console.WriteLine("2. Customer Lastname");
            Console.WriteLine("3. Customer Email");
            Console.WriteLine("4. Customer Rolename");
            Console.WriteLine("5. Customer Streetname");
            Console.WriteLine("6. Customer Postalcode");
            Console.WriteLine("7. Customer City\n");

            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new Firstname : ");
                    customer.FirstName = Console.ReadLine()!;
                    break;
                case "2":
                    Console.Write("Enter new last name: ");
                    customer.LastName =  Console.ReadLine()!;
                    break;
                case "3":
                    Console.Write("Enter new Email: ");
                    customer.Email = Console.ReadLine()!;
                    break;
                case "4":
                    Console.Write("Enter new role: ");
                    customer.Role.RoleName = Console.ReadLine()!;
                    break;
                case "5":
                    Console.Write("Enter new streetname: ");
                    customer.Address.StreetName = Console.ReadLine()!;
                    break;
                case "6":
                    Console.Write("Enter new postalcode: ");
                    customer.Address.PostalCode = Console.ReadLine()!;
                    break;
                case "7":
                    Console.Write("Enter new city: ");
                    customer.Address.City = Console.ReadLine()!;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    return;
            }

            var updatedCustomer = _customerService.UpdateCustomer(customer); 
            Console.WriteLine($"{updatedCustomer.FirstName} - {updatedCustomer.LastName} - {updatedCustomer.Email} - {updatedCustomer.Role.RoleName} - {updatedCustomer.Address.StreetName} - {updatedCustomer.Address.PostalCode} - {updatedCustomer.Address.City}  updated successfully.");
        }
        else
        {
            Console.WriteLine("No customer found.");
        }

        Console.ReadKey();
    }

    public void DeleteCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("--- DELETE CUSTOMER ---\n");


        Console.WriteLine("Delete by entering: \n");
        Console.WriteLine("1. Customer Email");
        Console.WriteLine("2. Customer ID");

       
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter Email");
                var customerEmail = Console.ReadLine()!;

                var customerByEmail = _customerService.GetCustomerByEmail(customerEmail);

                if (customerByEmail != null)
                {
                    _customerService.DeleteCustomer(customerByEmail.Id);
                    Console.WriteLine("Customer was successfully deleted");
                }
                else
                {
                    Console.WriteLine("Email not found!");
                }

                break;
            case "2":
                Console.Write("Enter ID: ");
                var customerId = int.Parse(Console.ReadLine()!);

                var customerById = _customerService.GetCustomerById(customerId);

                if (customerById != null)
                {
                    _customerService.DeleteCustomer(customerId);
                    Console.WriteLine("Customer was successfully deleted");
                }
                else
                {
                    Console.WriteLine("Id not found!");
                }
                break;
           
            default:
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
                return;
        }

        



        Console.ReadKey();

    }
}
