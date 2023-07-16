using System.Data.SqlClient;
using WebApplicationtest.Models;

namespace WebApplicationtest.Services
{
    public class ProductService : IProductService
    {
        //private static string db_source = "softrendzsqlserver.database.windows.net";
        //private static string db_user = "softrendzadmin";
        //private static string db_password = "Admin@123";
        //private static string db_database = "webappsoftrendzdb";

        private readonly IConfiguration _configuration;
        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            //var _builder =new SqlConnectionStringBuilder();
            //_builder.DataSource= db_source;
            //_builder.UserID= db_user;
            //_builder.Password= db_password;
            //_builder.InitialCatalog= db_database;
            //return new SqlConnection(_builder.ConnectionString);
            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public List<Product> GetProducts()
        {
            SqlConnection con = GetConnection();
            List<Product> _productList = new List<Product>();
            string statement = "Select * from Products";
            con.Open();
            SqlCommand cmd = new SqlCommand(statement, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    _productList.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    });
                }
            }
            con.Close();
            return _productList;
        }

    }
}
