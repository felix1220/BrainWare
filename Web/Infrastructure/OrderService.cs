using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure
{
    using System.Data;
    using Models;

    public class OrderService
    {
        public List<Ledger> GetOrdersForCompany(int CompanyId)
        {

            var database = new Database();

            /////////////////////////////////New Way////////////////////////////////////
            List<Ledger> orderStatment = new List<Ledger>();
            var sql = "SELECT c.name, o.description, o.order_id, op.price, op.quantity, p.name FROM company c INNER JOIN[order] o on c.company_id = o.company_id Right Outer Join[orderproduct] op on o.order_id = op.order_id Inner Join[product] p on op.product_id = p.product_id";
            var reader = database.ExecuteReader(sql);

            while (reader.Read())
            {
                var record = (IDataRecord)reader;
                var company = record.GetString(0).Trim();
                var companyOrder = orderStatment.FirstOrDefault(f => f.CompanyName == company);
                if (companyOrder == null)
                {
                  
                    var ledger = new Ledger
                    {
                        CompanyName = company,
                        Orders = new List<OrderDetails>
                            {
                                 new OrderDetails
                                    {
                                        Description = record.GetString(1).Trim(),
                                        OrderId = record.GetInt32(2),
                                        Price = record.GetDecimal(3),
                                        Quantity = record.GetInt32(4),
                                        ProductName = record.GetString(5).Trim(),
                                        ItemTotal = record.GetInt32(4) * record.GetDecimal(3)
                                    }
                            }
                    };
                    ledger.OrderTotal = ledger.Orders[0].ItemTotal;
                    orderStatment.Add(ledger);
                }
                else
                {
                        companyOrder.Orders.Add(
                                    new OrderDetails
                                    {
                                        Description = record.GetString(1).Trim(),
                                        OrderId = record.GetInt32(2),
                                        Price = record.GetDecimal(3),
                                        Quantity = record.GetInt32(4),
                                        ProductName = record.GetString(5).Trim(),
                                        ItemTotal = record.GetInt32(4) * record.GetDecimal(3)
                                    }
                            );

                        companyOrder.OrderTotal = companyOrder.Orders.Sum(f => f.ItemTotal);
                }
            }
            reader.Close();
            database.CLoseConnection();
            return orderStatment;


        }
    }
}