using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace NuevoDiplomas.Clases
{
    internal class Consultas
    {
        public static DataTable Consultar(string query, Dictionary<string, object> parametros = null)
        {
            using (SqlConnection cn = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                if (parametros != null)
                {
                    foreach (var p in parametros)
                    {
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                    }
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static int Ejecutar(string query, Dictionary<string, object> parametros = null)
        {
            using (SqlConnection cn = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                if (parametros != null)
                {
                    foreach (var p in parametros)
                    {
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                    }
                }

                return cmd.ExecuteNonQuery();
            }
        }

        public static object EjecutarEscalar(string query, Dictionary<string, object> parametros = null)
        {
            using (SqlConnection cn = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                if (parametros != null)
                {
                    foreach (var p in parametros)
                    {
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                    }
                }

                return cmd.ExecuteScalar();
            }
        }
    }
}