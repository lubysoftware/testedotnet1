using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TesteApi.Controllers
{
    public class HorasTrabalhadasController : ApiController
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;

        string strSQL;


        [HttpPost]
        public void Post(int desenvolvedorId, int projetoId, DateTime dtInicio, DateTime dtFim)
        {
            try
            {
                conexao = new SqlConnection("Server=DESKTOP-H6G5SVI\\SQLEXPRESS;Database=TesteApiBd;Trusted_Connection=True;");
                strSQL = "INSERT INTO[dbo].[HorasTrabalhadas] ([DtInicio],[DtFim], [ProjetoId], [DesenvolvedorId]) VALUES( @DTInicio, @DTFim, @ProjetoID, @DesenvolvedorID)";
                comando = new SqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@DTInicio", dtInicio);
                comando.Parameters.AddWithValue("@DTFim", dtFim);
                comando.Parameters.AddWithValue("@ProjetoID", projetoId);
                comando.Parameters.AddWithValue("@DesenvolvedorID", desenvolvedorId);
                conexao.Open();
                comando.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conexao.Close();
                comando.Clone();
                conexao = null;
                comando = null;

            }
        }
    }
}
