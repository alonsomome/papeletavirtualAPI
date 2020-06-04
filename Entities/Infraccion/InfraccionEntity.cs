namespace papeletavirtualapp.Entities.Infraccion
{
    public class InfraccionEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public decimal? Price { get; set; }
        public string Details { get; set; }
    }
}