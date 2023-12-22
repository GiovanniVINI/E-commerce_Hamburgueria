using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceCCO2023.Models.Data
{
    // CRUD DO PRODUTO
    public class ClienteData
    {
        // método create para cadastrar novos produtos
        // no banco de dados
        public bool Create(Cliente cliente)
        {
            bool sucesso = false;

            // criar a string SQL para fazer o cadastro
            // de novos produtos
            string insert = "exec sp_CadCliente '" +
                cliente.Nome + "', '" +
                cliente.Foto + "', '" +
                cliente.Email + "', '" +
                cliente.Senha + "', " +
                cliente.statusCli;

            try
            {
                // criar um objeto para conectar com o BD
                SqlConnection conexaoBD = Data.ConectarBancoDados();
                // criar um objeto para executar o comando SQL
                SqlCommand cmd = new SqlCommand(insert, conexaoBD);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    Data.fecharConexaoBancoDados();
                    sucesso = true;
                }
            }
            catch (SqlException erro)
            {
                Console.WriteLine("\n\n Erro de cadastro do Cliente " + erro);
            }
            return sucesso;
        }

        // método read para consultar todos os produtos 
        public List<Cliente> Read()
        {
            List<Cliente> lista = null;

            string select = "select * from v_Cliente";
            
            try
            {                
                // Conexão com  o BD
                SqlConnection conexaoBD = Data.ConectarBancoDados();
                // Comando que executa o SQL no BD
                SqlCommand cmd = new SqlCommand(select, conexaoBD);
                // Execução do select
                SqlDataReader reader = cmd.ExecuteReader();

                // instancão a lista
                lista = new List<Cliente>();

                while (reader.Read())
                {                                      
                    Cliente cli = new Cliente();
                    cli.IdCliente = (int)reader["IdCliente"];
                    cli.Nome = reader["NomeCli"].ToString();
                    cli.Email = reader["Email"].ToString();
                    cli.Senha = reader["Senha"].ToString();
                    if (!reader.IsDBNull(5))
                    {
                        cli.Foto = reader["Foto"].ToString();
                    }
                    lista.Add(cli);
                }
            } 
            catch (SqlException erro)
            {
                Console.WriteLine("\n\n\n Erro Cliente " + erro + "\n\n\n");
            }
          
            return lista;
        }



        // método read para consultar o produto pelo seu id
        public Cliente Read(int id)
        {
            // declarar a string SQL para fazer a consulta
            // dos dados do Produto pelo seu id
            string select = "select * from v_Cliente " +
                "where idCliente = " + id;
            // Conexão com  o BD
            SqlConnection conexaoBD = Data.ConectarBancoDados();
            // Comando que executa o SQL no BD
            SqlCommand cmd = new SqlCommand(select, conexaoBD);
            // Execução do select
            SqlDataReader reader = cmd.ExecuteReader();
            Cliente cli = null;
            if(reader.Read())
            {
                cli = new Cliente();
                cli.IdCliente = (int)reader["IdCliente"];
                cli.Nome = reader["NomeCli"].ToString();
                cli.Email = reader["Email"].ToString();
                cli.Senha = reader["Senha"].ToString();
                if (!reader.IsDBNull(5))
                {
                    cli.Foto = reader["Foto"].ToString();
                }
            }
            return cli;
        }

        // método update para atualizar dados do produto
        // no banco de dados
        public bool Update(Cliente cliente)
        {
            bool sucesso = false;

            // criar a string SQL para fazer o update
            // de produto
            string update = "exec sp_UpCliente  " +
                cliente.IdCliente + ", '" +
                cliente.Nome + "', '" +
                cliente.Foto + "', '" +
                cliente.Email + "', '" +
                cliente.Senha + "', " +
                cliente.statusCli;
                
            try
            {
                // criar um objeto para conectar com o BD
                SqlConnection conexaoBD = Data.ConectarBancoDados();
                // criar um objeto para executar o comando SQL
                SqlCommand cmd = new SqlCommand(update, conexaoBD);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    Data.fecharConexaoBancoDados();
                    sucesso = true;
                }
            }
            catch (SqlException erro)
            {
                Console.WriteLine("\n\n Erro de atualização do Cliente " + erro);
            }
            return sucesso;
        }

        // método delete para excluir um produto pelo id
        public bool Delete(int id)
        {
            bool sucesso = false;
            // declarar a string SQL para fazer a consulta
            // dos dados do Produto pelo seu id
            string delete = "delete from Clientes " +
                "where idCliente = " + id;
            // Conexão com  o BD
            SqlConnection conexaoBD = Data.ConectarBancoDados();
            // Comando que executa o SQL no BD
            SqlCommand cmd = new SqlCommand(delete, conexaoBD);
            
            if (cmd.ExecuteNonQuery() == 1)
            {
                Data.fecharConexaoBancoDados();
                sucesso = true;
            }
            return sucesso;
        }

        public Cliente Read(string email)
        {
            string select = "SELECT * FROM Clientes WHERE Email = " + "'" + email + "'";
            Cliente cliente = null;

            try
            {
                SqlConnection conexaoBD = Data.ConectarBancoDados();
                SqlCommand cmd = new SqlCommand(select, conexaoBD);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new Cliente();        
                    cliente.Email = reader["Email"].ToString();
                    cliente.Senha = reader["Senha"].ToString();
                }
            }
            catch (SqlException erro)
            {
                Console.WriteLine("\n\n Erro na consulta do Cliente por Email " + erro);
            }
            Data.fecharConexaoBancoDados();
            return cliente;
        }
    }
}
