namespace Qss.Base.Models
{
    public class GridRequestModel : IPagingModel
    {
        public int Page { get; set; }
        public int Rows { get; set; }

        public int Offset
        {
            get
            {
                return Rows * (Page - 1);
            }
        }

        public bool IsHasSort { get { return !string.IsNullOrWhiteSpace(Sidx); } }

        public string Sidx { get; set; }
        public string Sord { get; set; }

        public bool IsSortAsending { get { return Sord == "asc"; } }

        public GridRequestModel()
        {
            Page = 1;
            Rows = 20;
            Sord = "asc";
        }

        public GridRequestModel(int page, int rows, string sidx, string sord)
        {
            Page = page;
            Rows = rows;

            //Search = search;

            Sidx = sidx;
            Sord = sord;
        }

        public void SetDefaultSortColumn(string column)
        {
            if (string.IsNullOrEmpty(Sidx)) Sidx = column;
            if (string.IsNullOrEmpty(Sord)) Sord = "asc";
        }
    }
}