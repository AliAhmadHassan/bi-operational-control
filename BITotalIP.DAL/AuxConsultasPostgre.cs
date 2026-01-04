using System;
using System.Collections.Generic;
using Npgsql;

namespace BITotalIP.DAL
{
    public static class AuxConsultasPostgre<T>
    {
        public static List<T> Lista(string NomeProcedure, string Strcon, params NpgsqlParameter[] parametros)
        {
            return Lista(NomeProcedure, Strcon, System.Data.CommandType.StoredProcedure, parametros);
        }

        public static List<T> Lista(string query, string Strcon, System.Data.CommandType commandType, params NpgsqlParameter[] parametros)
        {
            List<T> LObjeto = new List<T>();

            using (NpgsqlConnection Conn = new NpgsqlConnection(Strcon))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Conn))
                {
                    try
                    {
                        cmd.CommandType = commandType;
                        cmd.CommandTimeout = 9999;
                        cmd.Parameters.Clear();

                        if (parametros != null)
                            foreach (NpgsqlParameter parametro in parametros)
                                cmd.Parameters.Add(parametro);

                        Conn.Open();
                        using (NpgsqlDataReader Dr = cmd.ExecuteReader())
                            while (Dr.Read())
                                LObjeto.Add(Auxiliar.RetornaDadosEntidade<T>(Dr));
                    }
                    catch
                    {
                        throw ;
                    }
                }
            }
            return LObjeto;
        }

        public static T Entidade(string NomeProcedure, string Strcon, params NpgsqlParameter[] parametros)
        {
            return Entidade(NomeProcedure, Strcon, System.Data.CommandType.StoredProcedure, parametros);
        }

        public static T Entidade(string query, string Strcon, System.Data.CommandType commandType, params NpgsqlParameter[] parametros)
        {
            T Objeto = (T)Activator.CreateInstance(typeof(T));

            using (NpgsqlConnection Conn = new NpgsqlConnection(Strcon))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        foreach (NpgsqlParameter parametro in parametros)
                            cmd.Parameters.Add(parametro);

                        Conn.Open();
                        using (NpgsqlDataReader Dr = cmd.ExecuteReader())
                            if (Dr.Read())
                                Objeto = Auxiliar.RetornaDadosEntidade<T>(Dr);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return Objeto;
        }
    }
}

