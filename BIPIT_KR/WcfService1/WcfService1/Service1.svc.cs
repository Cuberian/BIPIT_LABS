using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data.SqlClient;
using System.Text;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        static string connectionString = @"workstation id=kontrab.mssql.somee.com;packet size=4096;user id=LeToy_SQLLogin_1;pwd=zsyiszpoic;data source=kontrab.mssql.somee.com;persist security info=False;initial catalog=kontrab";
        static SqlConnection cnn = new SqlConnection(connectionString);
        public Supplier[] GetSuppliers()
        {
            cnn.Open();

            SqlCommand getSuppliersCommand = new SqlCommand("SELECT * FROM[Suppliers]", cnn);
            SqlDataReader reader = getSuppliersCommand.ExecuteReader();

            List<Supplier> suppliers = new List<Supplier>();

            while (reader.Read())
            {
                Supplier supplier = new Supplier
                {
                    SupplierCode = int.Parse(reader["supplier_code"].ToString()),
                    SupplierName = reader["supplier_name"].ToString(),
                };

                suppliers.Add(supplier);
            }

            reader.Close();
            cnn.Close();
            return suppliers.ToArray();
        }

        public Waybill[] GetWaybilles()
        {
            cnn.Open();

            SqlCommand getWaybillesCommand = new SqlCommand("SELECT * FROM[Waybill]", cnn);
            SqlDataReader reader = getWaybillesCommand.ExecuteReader();

            List<Waybill> waybilles = new List<Waybill>();

            while (reader.Read())
            {
                Waybill waybill = new Waybill
                {
                    SupplierCode = int.Parse(reader["supplier_code"].ToString()),
                    WaybillDate = DateTime.Parse(reader["date"].ToString()),
                    WaybillSum = int.Parse(reader["sum"].ToString()),
                };

                waybilles.Add(waybill);
            }

            reader.Close();
            cnn.Close();

            return waybilles.ToArray();
        }

        public void InsertSupplier(string name)
        {
            cnn.Open();

            SqlCommand createWaybill = new SqlCommand("INSERT INTO[Suppliers] (supplier_name) VALUES (@supplier_name)", cnn);
            createWaybill.Parameters.AddWithValue("supplier_name", name);
            createWaybill.ExecuteNonQuery();

            cnn.Close();
        }

        public void InsertWaybill(DateTime date, int sum, int supplier_code)
        {
            cnn.Open();

            SqlCommand createWaybill = new SqlCommand("INSERT INTO[Waybill] (date, supplier_code, sum) VALUES (@date, @supplier_code, @sum)", cnn);
            createWaybill.Parameters.AddWithValue("sum", sum);
            createWaybill.Parameters.AddWithValue("supplier_code", supplier_code);
            string format = "yyyy-MM-dd";
            createWaybill.Parameters.AddWithValue("date", date.ToString(format));
            createWaybill.ExecuteNonQuery();

            cnn.Close();
        }
    }
}

