using Microsoft.Data.SqlClient;
using Microsoft.PowerOData.Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PowerOData.Service
{
    public class ProductService : IRepoService<ProductModel>
    {

        public ProductService(SqlConnection connection)
        {
            SQLConn = connection;
        }

        private SqlConnection _conn;

        private SqlConnection SQLConn
        {
            get
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                return _conn;
            }
            set
            {
                _conn = value;
            }
        }

        public async Task<IList<ProductModel>> GetData()
        {
            using var command = new SqlCommand("SELECT  * FROM [SalesLT].[Product]", SQLConn) { CommandType = CommandType.Text};
            return await Getvalues(await command.ExecuteReaderAsync());
        }

        private async Task<List<ProductModel>> Getvalues(SqlDataReader reader)
        {

            var retVal = new List<ProductModel>();

            if (reader.HasRows)
                while (await reader.ReadAsync())
                    retVal.Add(Convert(reader));

            await reader.CloseAsync();

            return retVal;
        }

        private ProductModel Convert(SqlDataReader reader)
        {
            return new ProductModel() { 
                ProductID = int.Parse(reader["ProductID"].ToString()),
                Name = reader["Name"].ToString(),
                Color = reader["Color"].ToString(),
                ListPrice = reader["ListPrice"].ToString(),
                ProductNumber = reader["ProductNumber"].ToString(),
                StandardCost = reader["StandardCost"].ToString(),
                Size = reader["Size"].ToString(),
                Weight = reader["Weight"].ToString(),
                ProductCategoryID = reader["ProductCategoryID"].ToString(),
                ProductModelID = reader["ProductModelID"].ToString(),
                SellStartDate = reader["SellStartDate"].ToString(),
                SellEndDate = reader["SellEndDate"].ToString(),
                DiscontinuedDate = reader["DiscontinuedDate"].ToString(),
                ThumbnailPhotoFileName = reader["ThumbnailPhotoFileName"].ToString(),
                Rowguid = reader["rowguid"].ToString(),
                ModifiedDate = reader["ModifiedDate"].ToString(),
            };
        }

        public IQueryable<ProductModel> GetDataAsQueryable()
        {
            throw new NotImplementedException();
        }
    }
}
