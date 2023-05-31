using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System.Collections.Generic;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

app.MapGet("/api/v1/data", () =>
{
    List<MyObject> result = new List<MyObject>();

    string address = "localhost";
    string db = "teste-product";
    string user = "postgres";
    string password = "root";

    string connectionString = $"Host={address};Database={db};Username={user};Password={password}";

    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
    {
        connection.Open();

        string sql = "SELECT SUBSTRING(pm.data_integracao::text, 0, 8) AS data, " +
            "SUM(pd.quant::numeric) AS quantidade, pd.produto " +
            "FROM pedido_detalhe_produto_integracao_bling pd " +
            "INNER JOIN pedido_master_produto_integracao_bling pm " +
            "ON pd.pedido_integracao = pm.pedido_integracao " +
            "GROUP BY SUBSTRING(pm.data_integracao::text, 0, 8), pd.produto " +
            "LIMIT 10";

        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MyObject obj = new MyObject();
                    obj.Data = reader.GetString("data");
                    obj.Quantidade = reader.GetDouble("quantidade");
                    obj.Produto = reader.GetString("produto");
                    result.Add(obj);
                }
            }
        }
    }

    return app.Response.WriteAsJsonAsync(result);
});

app.Run();

public class MyObject
{
    public string Data { get; set; }
    public double Quantidade { get; set; }
    public string Produto { get; set; }
}
