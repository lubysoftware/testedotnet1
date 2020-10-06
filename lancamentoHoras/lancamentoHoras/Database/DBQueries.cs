using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lancamentoHoras.Database
{
    public static class DBQueries
    {
        private static async Task<string> DefaultOutput(string _query)
        {
            DataTable res = new DataTable();
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    await conn.OpenAsync();
                    MySqlDataAdapter query = new MySqlDataAdapter(_query, conn);
                    await query.FillAsync(res);
                }

                string result = JsonConvert.SerializeObject(res);

                return result;
            }catch (Exception exp)
            {
                return exp.Message;
            }
        }

        private static async Task<string> DefaultInput(string _command)
        {
            int res;
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    await conn.OpenAsync();
                    MySqlCommand command = new MySqlCommand(_command, conn);
                    res = await command.ExecuteNonQueryAsync();
                }

                return res.ToString();
            }catch(Exception exp)
            {
                return exp.Message;
            }
        }

        public static async Task<string> GetDevelopers()
        {
            string query = "SELECT des_id AS Id, des_nome AS Nome FROM desenvolvedores;";

            return await DefaultOutput(query);
        }

        public static async Task<string> GetDeveloper(int dev_id)
        {
            string query = "SELECT des_nome AS Nome FROM desenvolvedores WHERE des_id = {0};";
            query = string.Format(query, dev_id);

            return await DefaultOutput(query);
        }

        public static async Task<string> NewDeveloper(string dev_name)
        {
            string command = "INSERT INTO desenvolvedores(des_nome) VALUES('{0}');";
            command = string.Format(command, dev_name);

            return await DefaultInput(command);
        }

        public static async Task<string> UpdateDeveloper(int dev_id, string dev_name)
        {
            string command = "UPDATE desenvolvedores SET des_nome='{0}' WHERE des_id={1};";
            command = string.Format(command, dev_name, dev_id);

            return await DefaultInput(command);
        }

        public static async Task<string> DeleteDeveloper(int dev_id)
        {
            string command = "DELETE FROM desenvolvedores WHERE des_id={0};";
            command = string.Format(command, dev_id);

            return await DefaultInput(command);
        }

        public static async Task<string> GetProjects()
        {
            string query = "SELECT pro_id AS Id, pro_nome AS Nome, des_nome AS Desenvolvedor FROM projetos p INNER JOIN desenvolvedores d ON p.pro_responsavel = d.des_id;";

            return await DefaultOutput(query);
        }

        public static async Task<string> GetProject(int pro_id)
        {
            string query = "SELECT pro_nome AS Nome, des_nome AS Desenvolvedor FROM projetos p INNER JOIN desenvolvedores d ON p.pro_responsavel = d.des_id WHERE pro_id={0};";
            query = string.Format(query, pro_id);

            return await DefaultOutput(query);
        }

        public static async Task<string> NewProject(string pro_name, int pro_res)
        {
            string command = "INSERT INTO projetos(pro_nome, pro_responsavel) VALUES('{0}', {1});";
            command = string.Format(command, pro_name, pro_res);

            return await DefaultInput(command);
        }

        public static async Task<string> UpdateProject(int pro_id, string pro_name = null, int? pro_res = null)
        {
            if (pro_name == null && pro_res == null) return "Nothing to update";

            string command = "UPDATE projetos SET ";
            if (pro_name != null)
                command += "pro_nome='" + pro_name + "'";
            if (pro_name != null && pro_res != null)
                command += ", ";
            if (pro_res != null)
                command += "pro_responsavel=" + pro_res;

            command += " WHERE pro_id=" + pro_id + ";";

            return await DefaultInput(command);
        }

        public static async Task<string> DeleteProject(int pro_id)
        {
            string command = "DELETE FROM projetos WHERE pro_id={0}";
            command = string.Format(command, pro_id);

            return await DefaultInput(command);
        }

        public static async Task<string> NewHourEntry(DateTime start, DateTime end, int dev_id)
        {
            string command = "INSERT INTO lancamentos(lan_inicio, lan_fim, lan_desenvolvedor) VALUES('{0}', '{1}', {2});";
            command = string.Format(command, start.ToString("yyyy-MM-dd hh:mm:ss"), end.ToString("yyyy-MM-dd hh:mm:ss"), dev_id);

            return await DefaultInput(command);
        }

        public static async Task<string> GetRanking()
        {
            int dayOfWeek = (int)DateTime.UtcNow.DayOfWeek;
            string query = "SELECT des_nome AS Desenvolvedor, AVG(TIMESTAMPDIFF(hour, lan_inicio, lan_fim)) AS Media FROM lancamentos l INNER JOIN desenvolvedores d ON l.lan_desenvolvedor = d.des_id WHERE lan_inicio > '{0}' GROUP BY lan_desenvolvedor ORDER BY Media desc LIMIT 5;";
            query = string.Format(query, DateTime.UtcNow.AddDays(-dayOfWeek).ToString("yyyy-MM-dd"));

            return await DefaultOutput(query);
        }
    }
}
