namespace Qss.Base.Models
{
    public struct LatLng
    {
        public double lat { get; set; }

        public double lng { get; set; }

        public LatLng(double lat, double lng)
            : this()
        {
            this.lat = lat;
            this.lng = lng;
        }
    }
}