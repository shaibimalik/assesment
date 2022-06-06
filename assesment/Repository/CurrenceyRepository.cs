using assesment.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace assesment.Repository
{
    public class CurrenceyRepository:ICurrenceyRepository
    {

        private IConfiguration _Configuration;

        public CurrenceyRepository(IConfiguration configuration)
        {

            _Configuration = configuration;
        }

        public RepoResponse CurrencyUpdateValue()
        {


            string ConnectionString = _Configuration.GetConnectionString("constr");

            RepoResponse repoResponse = new RepoResponse();


            return repoResponse;
        }





        public RepoResponse CurrencyGetValue() {
            string ConnectionString = _Configuration.GetConnectionString("constr");
            RepoResponse response = new RepoResponse();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("[PRC_CURRENCY_GET]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                Add_Output_Parameters(cmd);
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                try
                {


                    da.Fill(ds);
                    response.Data = ds;
                    response.Code = getPCode(cmd);
                    response.Desc = getPDesc(cmd);

                }
                catch (Exception ex)
                {

                    response.Code = "99";
                    response.Desc = ex.Message;

                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
    
          
            return response;


        }
        public static void Add_Output_Parameters(SqlCommand cmd)
        {
            try
            {
                cmd.Parameters.Add("PCODE", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PDESC", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PMSG", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
            }
            catch (Exception) { }
        }

        public static string getPCode(SqlCommand cmd)
        {
            return cmd.Parameters["PCODE"].Value.ToString();
        }

        public static string getPDesc(SqlCommand cmd)
        {
            return cmd.Parameters["PDESC"].Value.ToString();
        }



    }
}
