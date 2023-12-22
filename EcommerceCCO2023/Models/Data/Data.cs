using System;
using System.Data.SqlClient;

namespace EcommerceCCO2023.Models.Data
{
    public class Data
    {

        //conexão usando autenticação do windows
        private static string stringConexao =
            @"data source = BOOK-QBT8MS5KSI\MSSQLSERVER09;
            initial catalog = lanches_lp_cco2023;
            integrated security = true;";

        // conexão usando autenticação do SQL Server

        /*private static string stringConexao =
            @"data source = localhost; 
            initial catalog = lanches_lp_cco2023; 
            user id = computacao; 
            password = aa11++--;";
        */

        // declaração do objeto conexaoBD e inicializando
        // com null
        private static SqlConnection conexaoBD = null;

        // implementando um método para fazer a conwxão
        // com o Banco de Dados
        public static SqlConnection ConectarBancoDados()
        {
            conexaoBD = new SqlConnection(stringConexao);

            try
            {
                Console.WriteLine($"Estado antes de abrir: {conexaoBD.State}");
                conexaoBD.Open();
                Console.WriteLine("Conexão OK");
                Console.WriteLine($"Estado após abrir: {conexaoBD.State}");
            }
            catch (SqlException erro)
            {
                conexaoBD = null;
                Console.WriteLine("Conexão Error :" + erro);
            }

            return conexaoBD;
        }


        public static void fecharConexaoBancoDados()
        {
            if (conexaoBD != null && conexaoBD.State == System.Data.ConnectionState.Open)
            {
                conexaoBD.Close();
            }
        }
    }
}
