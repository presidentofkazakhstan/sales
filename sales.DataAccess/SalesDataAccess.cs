using sales.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.DataAccess
{
    public class SalesDataAccess
    {

        private readonly string _connectionString;
        private readonly string _providerName;
        private readonly DbProviderFactory _providerFactory;

        public SalesDataAccess()
        {

            _connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;

            _providerName = ConfigurationManager.ConnectionStrings["appConnection"].ProviderName;

            _providerFactory = DbProviderFactories.GetFactory(_providerName);
        }

        public List<Seller> GetAllSellers()
        {
            var data = new List<Seller>();

            using (var connection = _providerFactory.CreateConnection())

            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();
                    command.CommandText = "select * from Seller";

                    var DataReader = command.ExecuteReader();

                    while (DataReader.Read())
                    {
                        int _id = (int)DataReader["Id"];
                        string _name = DataReader["Name"].ToString();
                        string _surname= DataReader["Surname"].ToString();
                        
                        data.Add(new Seller
                        {
                            Id = _id,
                            Name = _name,
                            Surname = _surname
                        });
                    }
                    DataReader.Close();
                }
                catch (DbException exception)
                {
                    throw;
                }

            }
            return data;
        }


        public List<Shopper> GetAllShoppers()
        {
            var data = new List<Shopper>();

            using (var connection = _providerFactory.CreateConnection())

            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();
                    command.CommandText = "select * from Shopper";

                    var DataReader = command.ExecuteReader();

                    while (DataReader.Read())
                    {
                        int _id = (int)DataReader["Id"];
                        string _name = DataReader["Name"].ToString();
                        string _surname = DataReader["Surname"].ToString();

                        data.Add(new Shopper
                        {
                            Id = _id,
                            Name = _name,
                            Surname = _surname
                        });
                    }
                    DataReader.Close();
                }
                catch (DbException exception)
                {
                    throw;
                }

            }
            return data;
        }

        public List<Sales> GetAllSales()
        {
            var data = new List<Sales>();

            using (var connection = _providerFactory.CreateConnection())

            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();
                    command.CommandText = "select * from Sales";

                    var DataReader = command.ExecuteReader();

                    while (DataReader.Read())
                    {
                        int _id = (int)DataReader["Id"];
                        int _sellerId = (int)DataReader["Seller_Id"];
                        int _shopperId = (int)DataReader["Shopper_Id"];
                        int _salesSum = (int)DataReader["SalesSumm"];
                        DateTime _salesDate =Convert.ToDateTime(DataReader["SalesDate"]);

                        data.Add(new Sales
                        {
                            Id = _id,
                            Seller_Id = _sellerId,
                            Shopper_Id = _shopperId,
                            SalesSumm = _salesSum,
                            SalesDate = _salesDate
                        });
                    }
                    DataReader.Close();
                }
                catch (DbException exception)
                {
                    throw;
                }

            }
            return data;
        }
    }
}
