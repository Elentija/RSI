namespace WcfServiceContract.Models
{
    class Forecast
    {
        public double timepoint { get; set; }

        public double cloudcover { get; set; }
        public double seeing { get; set; }
        public double transparency { get; set; }
        public double lifted_index { get; set; }
        public double rh2m { get; set; }
        public double wind10m { get; set; }
    }
}
