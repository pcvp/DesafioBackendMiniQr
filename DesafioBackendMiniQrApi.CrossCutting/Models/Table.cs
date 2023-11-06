namespace DesafioBackendMiniQrApi.CrossCutting.Models
{
    public class Table
    {
        public string Name { get; set; }
        public string Schema { get; set; }

        public Table(string name, string schema)
        {
            Name = name;
            Schema = schema;
        }

        public static Table Charge { get; } = new Table("Charges", "MiniQr");
    }
}
