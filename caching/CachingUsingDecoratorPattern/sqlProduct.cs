using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caching
{
    class sqlProduct : IRepo
    {
        private SqlConnection con;
        public List<Product> GetAllProducts()
        {
            
            string constr = @"Data Source=TAVDESK042;Initial Catalog=cachedb;User Id=sa;Password=test123!@#";
            con = new SqlConnection(constr);

            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM carProduct";
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["name"]),
                        Price = (float)Convert.ToDouble(dr["price"])
                    }
                );

            }
            return productList;
        }

        public Product GetProductById(int id)
        {
            string constr = @"Data Source=TAVDESK042;Initial Catalog=cachedb;User Id=sa;Password=test123!@#";
            con = new SqlConnection(constr);
            
            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM carProduct where id=" + id;
            SqlCommand command = new SqlCommand(query, con)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["name"]),
                        Price = (float)Convert.ToDouble(dr["price"])
                    }
                );

            }
            return productList[0];
        }
    }
}
