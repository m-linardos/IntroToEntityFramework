using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntroToEntityFramework {

    class Program {
        static void Main(string[] args) {

            IntroDbContext db = new IntroDbContext();
            Order[] orders = db.Orders.ToArray();

            foreach (Order order in orders) {
                string message = $"Id={order.Id}, Total={order.Total}, Cust={order.Customer.Name}, Desc={order.Description}";
                Console.WriteLine(message);
            }




            Customer[] customers = db.Customers
                    .Where(c => c.State == "OH")
                    .OrderByDescending(cust => cust.Name)
                    .ToArray();

            foreach (Customer cust in customers) {
                string message = $"Id={cust.Id}, Name={cust.Name}, City/St={cust.City}, {cust.State}";
                Console.WriteLine(message);
            }

            Customer Chris = db.Customers.Find(5);

            if (Chris == null) {
                Console.WriteLine("couldn't find Chris");
            }
            else {
                string message = $"Id={Chris.Id}, Name={Chris.Name}, City/St={Chris.City}, {Chris.State}";
                Console.WriteLine(message);
            }

            Customer[] custs = db.Customers.Where(cust => cust.State == "KY").ToArray();

            foreach (Customer cust in custs) {
                string message = $"Id={cust.Id}, Name={cust.Name}, City/St={cust.City}, {cust.State}";
                Console.WriteLine(message);
            }

            List<Customer> custs = db.Customers.Where(c => c.Name == "Ken" && c.City == "Newport").ToList();

            if (custs.Count == 0) {
                Console.WriteLine("None found");
            }
            else {
                Console.WriteLine($"Found {custs[0].Name}");
            }



            Console.ReadKey();
        }

    }

}














