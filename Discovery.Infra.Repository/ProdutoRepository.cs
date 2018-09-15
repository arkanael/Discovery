using Dapper;
using Discovery.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Discovery.Infra.Repository
{
    public class ProdutoRepository
    {
        private IConfiguration configuration;

        private readonly string ConnectionString;

        public ProdutoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = "Discovery";
        }

        public void Insert(Produto produto)
        {
            string query = "INSERT INTO Produto(Nome, Preco, Quantidade) values(@Nome, @Preco, @Quantidade)";

            using (var conn = new SqlConnection(configuration.GetConnectionString(ConnectionString)))
            {
                conn.Execute(query, produto);
            }
        }

        public void Update(Produto produto)
        {
            string query = "UPDATE Produto SET Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade where Id = @Id";

            using (var conn = new SqlConnection(configuration.GetConnectionString(ConnectionString)))
            {
                conn.Execute(query, produto);
            }
        }

        public void Delete(Guid id)
        {
            string query = "DELETE FROM where Id = @id";

            using (var conn = new SqlConnection(configuration.GetConnectionString(ConnectionString)))
            {
                conn.Execute(query, new { Id = id });
            }
        }

        public List<Produto> FindAll()
        {
            string query = "SELECT * FROM Produto";

            using (var conn = new SqlConnection(configuration.GetConnectionString(ConnectionString)))
            {
                return conn.Query<Produto>(query).ToList();
            }

        }
        public Produto FindById(Guid IdProduto)
        {
            string query = "SELECT * FROM Produto where Id = @Id";

            using (var conn = new SqlConnection(configuration.GetConnectionString(ConnectionString)))
            {
                return conn.Query<Produto>(query, new { Id = IdProduto }).FirstOrDefault();
            }
        }
    }
}