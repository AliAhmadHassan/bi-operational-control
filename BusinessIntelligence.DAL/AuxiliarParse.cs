using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DAL
{
    public class AuxiliarParse
    {
        public static List<T> RetornaDadosEntidade<T>(CellSet cst)
        {
            List<T> lista = (List<T>)Activator.CreateInstance(typeof(List<T>));


            int QtdColunas = cst.Axes[0].Positions.Count;
            int QtdLinhas = cst.Axes[1].Positions.Count;

            for (int iLinha = 0; iLinha < QtdLinhas; iLinha++)
            {
                T _entidade = (T)Activator.CreateInstance(typeof(T));

                #region Atribui os Rotulos de Linhas
                for (int iColuna = 0; iColuna < cst.Axes[1].Positions[0].Members.Count; iColuna++)
                {
                    foreach (PropertyInfo pi in _entidade.GetType().GetProperties())
                    {
                        Atributos atributo = RetornaAtributo<T>(pi);
                        if ((atributo.Row) && (atributo.RowOrder.Equals(iColuna)))
                        {
                            object valor = cst.Axes[1].Positions[iLinha].Members[iColuna].Caption;
                            switch (pi.PropertyType.Name)
                            {
                                case "Int32":
                                    pi.SetValue(_entidade, Convert.ToInt32(valor), null);
                                    break;

                                case "Decimal":
                                    pi.SetValue(_entidade, Convert.ToDecimal(valor), null);
                                    break;

                                case "Double":
                                    pi.SetValue(_entidade, Convert.ToDouble(valor), null);
                                    break;

                                case "String":
                                    pi.SetValue(_entidade, Convert.ToString(valor), null);
                                    break;

                                default:
                                    throw new Exception("Tipo Não Encontrado");
                            }
                            break;
                        }
                    }
                }
                #endregion


                #region Atribui os Valores
                for (int iColuna = 0; iColuna < QtdColunas; iColuna++)
                {
                    foreach (PropertyInfo pi in _entidade.GetType().GetProperties())
                    {
                        Atributos atributo = RetornaAtributo<T>(pi);
                        if (!atributo.Row && atributo.ColumnName.Equals(cst.Axes[0].Positions[iColuna].Members[0].Caption))
                        {
                            object valor = cst.Cells[(iLinha) * QtdColunas + (iColuna)].Value;

                            switch (pi.PropertyType.Name)
                            {
                                case "Int32":
                                    pi.SetValue(_entidade, Convert.ToInt32(valor), null);
                                    break;

                                case "Decimal":
                                    pi.SetValue(_entidade, Convert.ToDecimal(valor), null);
                                    break;

                                case "Double":
                                    pi.SetValue(_entidade, Convert.ToDouble(valor), null);
                                    break;

                                default:
                                    throw new Exception("Tipo Não Encontrado");
                            }

                            pi.SetValue(_entidade, valor, null);
                            break;
                        }
                    }

                }
                #endregion
                lista.Add(_entidade);
            }
            return lista;
        }

        private static Atributos RetornaAtributo<T>(PropertyInfo pi)
        {
            Atributos atributo = null;
            object[] Obj = typeof(T).GetProperty(pi.Name).GetCustomAttributes(true);

            if (Obj.Length > 0)
                foreach (object objAux in Obj)
                    if (objAux.GetType().Name == "AtributoBind")
                    {
                        atributo = new Atributos();
                        atributo.Row = ((DTO.Base.AtributoBind)objAux).Row;
                        atributo.RowOrder = ((DTO.Base.AtributoBind)objAux).RowOrder;
                        atributo.ColumnName = ((DTO.Base.AtributoBind)objAux).ColumnName;
                        break;
                    }

            return atributo;
        }
        
        public class Atributos
        {
            public bool Row { get; set; }

            public int RowOrder { get; set; }

            public string ColumnName { get; set; }
        }
    }
}
