using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;

namespace BusinessIntelligence.DAL
{
    public class Auxiliar
    {
        public static List<SqlParameter> GeraParametros<T>(T DadosDTO)
        {
            List<SqlParameter> LParams = new List<SqlParameter>();

            foreach (PropertyInfo pi in DadosDTO.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!pi.DeclaringType.Namespace.Contains(".DTO"))
                    continue;

                SqlParameter Param;

                if (pi.PropertyType.FullName == "System.DateTime")
                {
                    if (((DateTime)pi.GetValue(DadosDTO, null)).Year == 1)
                        Param = new SqlParameter("@" + pi.Name, DBNull.Value);
                    else
                        Param = new SqlParameter("@" + pi.Name, pi.GetValue(DadosDTO, null));
                }
                else if (pi.PropertyType.FullName == "System.Byte[]")
                {

                    if (pi.GetValue(DadosDTO, null) == null)
                        Param = new SqlParameter("@" + pi.Name, DBNull.Value);
                    else
                        Param = new SqlParameter("@" + pi.Name, pi.GetValue(DadosDTO, null));

                    Param.DbType = System.Data.DbType.Binary;
                }
                else
                {
                    if (pi.GetValue(DadosDTO, null) == null)
                        Param = new SqlParameter("@" + pi.Name, DBNull.Value);
                    else
                        Param = new SqlParameter("@" + pi.Name, pi.GetValue(DadosDTO, null));
                }

                LParams.Add(Param);
            }
            return LParams;
        }

        public static T RetornaDadosEntidade<T>(SqlDataReader Dr)
        {
            T _entidade = (T)Activator.CreateInstance(typeof(T));

            List<string> LColunas = new List<string>();

            for (int i = 0; i < Dr.FieldCount; i++)
                LColunas.Add(Dr.GetName(i));


            foreach (PropertyInfo pi in _entidade.GetType().GetProperties())
            {
                if (!LColunas.Contains(pi.Name))
                    continue;
                else if (Dr[pi.Name] == DBNull.Value)
                    pi.SetValue(_entidade, null, null);
                else
                    pi.SetValue(_entidade, Dr[pi.Name], null);
            }
            return _entidade;
        }
    }
}
