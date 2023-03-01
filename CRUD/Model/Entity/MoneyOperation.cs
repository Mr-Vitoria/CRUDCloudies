namespace CRUD.Model.Entity
{
    public class MoneyOperation
    {
        public int Id { get; set; }
        public int OperationID { get; set; }
        public int CompanyId { get; set; }
        public int Price { get; set; }
        public string? Correspondence { get; set; }
        public string? DateOperation { get; set; }

        public override string? ToString()
        {
            return $"{Id} - {OperationID} - {CompanyId} - {Price} - {Correspondence} - {DateOperation}";
        }
    }
}
