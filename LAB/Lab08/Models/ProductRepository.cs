using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InventoryManagement.Models
{
    public class ProductRepository
    {
        private readonly string _connStr =
            ConfigurationManager.ConnectionStrings["InventoryConn"].ConnectionString;

        // READ ALL
        public List<Product> GetAllProducts()
        {
            var list = new List<Product>();
            using (SqlConnection con = new SqlConnection(_connStr))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT ProductId, ProductName, Category, Price, Quantity, Description, CreatedAt FROM Products ORDER BY ProductId DESC", con))
            {
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Product
                        {
                            ProductId = Convert.ToInt32(dr["ProductId"]),
                            ProductName = dr["ProductName"].ToString(),
                            Category = dr["Category"].ToString(),
                            Price = Convert.ToDecimal(dr["Price"]),
                            Quantity = Convert.ToInt32(dr["Quantity"]),
                            Description = dr["Description"] == DBNull.Value ? "" : dr["Description"].ToString(),
                            CreatedAt = dr["CreatedAt"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["CreatedAt"])
                        });
                    }
                }
            }
            return list;
        }

        // READ BY ID
        public Product GetProductById(int id)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT ProductId, ProductName, Category, Price, Quantity, Description, CreatedAt FROM Products WHERE ProductId = @ProductId", con))
            {
                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Product
                        {
                            ProductId = Convert.ToInt32(dr["ProductId"]),
                            ProductName = dr["ProductName"].ToString(),
                            Category = dr["Category"].ToString(),
                            Price = Convert.ToDecimal(dr["Price"]),
                            Quantity = Convert.ToInt32(dr["Quantity"]),
                            Description = dr["Description"] == DBNull.Value ? "" : dr["Description"].ToString(),
                            CreatedAt = dr["CreatedAt"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["CreatedAt"])
                        };
                    }
                }
            }
            return null;
        }

        // CREATE
        public void AddProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Products (ProductName, Category, Price, Quantity, Description) VALUES (@ProductName, @Category, @Price, @Quantity, @Description)", con))
            {
                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 150).Value = product.ProductName.Trim();
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 100).Value = product.Category.Trim();
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = product.Price;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.Quantity;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value =
                    string.IsNullOrWhiteSpace(product.Description) ? (object)DBNull.Value : product.Description.Trim();

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE
        public void UpdateProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Products SET ProductName = @ProductName, Category = @Category, Price = @Price, Quantity = @Quantity, Description = @Description WHERE ProductId = @ProductId", con))
            {
                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = product.ProductId;
                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 150).Value = product.ProductName.Trim();
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 100).Value = product.Category.Trim();
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = product.Price;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.Quantity;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500).Value =
                    string.IsNullOrWhiteSpace(product.Description) ? (object)DBNull.Value : product.Description.Trim();

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteProduct(int id)
        {
            using (SqlConnection con = new SqlConnection(_connStr))
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Products WHERE ProductId = @ProductId", con))
            {
                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}