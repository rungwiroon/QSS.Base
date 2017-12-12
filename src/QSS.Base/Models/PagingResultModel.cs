using System.Collections.Generic;

namespace Qss.Base.Models
{
    public class PagingResultModel<T>
    {
        public int RowCount { get; set; }
        public IEnumerable<T> Rows { get; set; }

        public PagingResultModel(IEnumerable<T> rows, int rowCount)
        {
            RowCount = rowCount;
            Rows = rows;
        }
    }
}