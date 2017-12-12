using System;
using System.Collections.Generic;

namespace Qss.Base.Models
{
    public class GridResponseModel<T>
    {
        public int total { get; set; }
        public int page { get; set; }
        public int records { get; set; }
        public IEnumerable<T> rows { get; set; }

        public GridResponseModel()
        {
        }

        public GridResponseModel(int page, int rows, int count)
        {
            total = (int)Math.Ceiling((float)count / rows);
            this.page = page;
            records = count;
        }

        public GridResponseModel(int page, int rows, int count, IEnumerable<T> records)
            : this(page, rows, count)
        {
            this.rows = records;
        }

        public GridResponseModel(GridRequestModel gridParam, int count)
            : this(gridParam.Page, gridParam.Rows, count)
        {
        }

        public GridResponseModel(GridRequestModel gridParam, int count, IEnumerable<T> records)
            : this(gridParam.Page, gridParam.Rows, count)
        {
            rows = records;
        }
    }
}