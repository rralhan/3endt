using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _3EndTDataLayer
{
    public class ManageProductPrice
    {
        public DataTable GetTierPriceForExcelExport(string ConnectionString, int TierID)
        {
            DataTable DtProductPrice = new DataTable();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetProductPriceDataForExportIntoExcel", myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TierID", TierID);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(DtProductPrice);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return DtProductPrice;
        }

        public int TruncateTemptableforProductPriceViaExcel(string ConnectionString)
        {
            int Cnt = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DeleteTempTierProductPriceTable", myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        myConnection.Open();
                        Cnt = cmd.ExecuteNonQuery();
                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return Cnt;
        }

        public int UpdateProductPriceViaExcel(string ConnectionString, int TierID)
        {
            int Cnt = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateTierProductPriceViaExcel", myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TierID", TierID);
                        myConnection.Open();
                        Cnt = cmd.ExecuteNonQuery();
                        myConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return Cnt;
        }

    }
}
