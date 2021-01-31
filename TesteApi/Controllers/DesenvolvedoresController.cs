using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteApi.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Web.Http.Results;
using Microsoft.Extensions.Logging;

namespace TesteApi.Controllers
{
    public class DesenvolvedoresController : ApiController
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;

        string strSQL;

        private static List<Desenvolvedor> desenvolvedores = new List<Desenvolvedor>();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var conexao = new SqlConnection("Server=DESKTOP-H6G5SVI\\SQLEXPRESS;Database=TesteApiBd;Trusted_Connection=True;");
                strSQL = "SELECT* FROM[TesteApiBd].[dbo].Desenvolvedores";

                //comando = new SqlCommand (strSQL, conexao);
                DataSet ds = new DataSet();
                da = new SqlDataAdapter(strSQL, conexao);
                conexao.Open();
                da.Fill(ds);
                return Ok(ds.Tables[0]);


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }


        [HttpPost]
        public void Post(string nome)
        {
            try
            {
                conexao = new SqlConnection("Server=DESKTOP-H6G5SVI\\SQLEXPRESS;Database=TesteApiBd;Trusted_Connection=True;");

                if (!string.IsNullOrEmpty(nome))
                {

                    strSQL = "INSERT INTO [dbo].[Desenvolvedores] ([Nome]) VALUES (@Nome);";

                    comando = new SqlCommand(strSQL, conexao);
                    comando.Parameters.AddWithValue("@Nome", nome);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
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

        public void DeleteId(string id)
        {
            //desenvolvedores.RemoveAt(desenvolvedores.IndexOf(desenvolvedores.First(e => e.Nome.Equals(nome))));

            try
            {
                conexao = new SqlConnection("Server=DESKTOP-H6G5SVI\\SQLEXPRESS;Database=TesteApiBd;Trusted_Connection=True;");

                if (!string.IsNullOrEmpty(id))
                {

                    strSQL = "DELETE TesteApiBd.dbo.Desenvolvedores WHERE ID = @Id";

                    comando = new SqlCommand(strSQL, conexao);
                    comando.Parameters.AddWithValue("@Id", id);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
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