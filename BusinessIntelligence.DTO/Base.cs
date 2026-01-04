using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessIntelligence.DTO
{
    public abstract class Base
    {
        public sealed class AtributoBind : System.Attribute
        {
            public AtributoBind(string columnName)
            {
                this.Row = false;
                this.RowOrder = 0;
                this.ColumnName = columnName;
            }

            public AtributoBind(bool row, int rowOrder)
            {
                this.Row = true;
                this.RowOrder = rowOrder;
                this.ColumnName = "";
            }

            public bool Row { get; set; }

            public int RowOrder { get; set; }

            public string ColumnName { get; set; }
        }
    }
}
