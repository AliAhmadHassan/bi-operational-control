using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BITotalIP.DAL
{
    public static class AuxConsultas<T>
    {
        public static List<T> Lista(string NomeProcedure, string Strcon, params SqlParameter[] parametros)
        {
            return Lista(NomeProcedure, Strcon, System.Data.CommandType.StoredProcedure, parametros);
        }

        public static List<T> Lista(string query, string Strcon, System.Data.CommandType commandType, params SqlParameter[] parametros)
        {
            List<T> LObjeto = new List<T>();

            using (SqlConnection Conn = new SqlConnection(Strcon))
            {
                using (SqlCommand cmd = new SqlCommand(query, Conn))
                {
                    try
                    {
                        cmd.CommandType = commandType;
                        cmd.CommandTimeout = 9999;
                        cmd.Parameters.Clear();

                        if (parametros != null)
                            foreach (SqlParameter parametro in parametros)
                                cmd.Parameters.Add(parametro);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                            while (Dr.Read())
                                LObjeto.Add(Auxiliar.RetornaDadosEntidade<T>(Dr));
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return LObjeto;
        }

        public static T Entidade(string NomeProcedure, string Strcon, params SqlParameter[] parametros)
        {
            return Entidade(NomeProcedure, Strcon, System.Data.CommandType.StoredProcedure, parametros);
        }

        public static T Entidade(string query, string Strcon, System.Data.CommandType commandType, params SqlParameter[] parametros)
        {
            T Objeto = (T)Activator.CreateInstance(typeof(T));

            using (SqlConnection Conn = new SqlConnection(Strcon))
            {
                using (SqlCommand cmd = new SqlCommand(query, Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        foreach (SqlParameter parametro in parametros)
                            cmd.Parameters.Add(parametro);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
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

        public static T Scalar(string NomeProcedure, string Strcon, params SqlParameter[] parametros)
        {
            return Scalar(NomeProcedure, Strcon, System.Data.CommandType.StoredProcedure, parametros);
        }

        public static T Scalar(string query, string Strcon, System.Data.CommandType commandType, params SqlParameter[] parametros)
        {
            T Objeto = (T)Activator.CreateInstance(typeof(T));

            using (SqlConnection Conn = new SqlConnection(Strcon))
            {
                using (SqlCommand cmd = new SqlCommand(query, Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parametros != null)
                            foreach (SqlParameter parametro in parametros)
                            cmd.Parameters.Add(parametro);

                        Conn.Open();
                        object value = cmd.ExecuteScalar();
                        if (value != null)
                            Objeto = (T)value;
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

