namespace CRUD.Model.Entity
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DateOpening { get; set; }

        public override string? ToString()
        {
            return $"{Id} - {Name} - {DateOpening}";
        }
    }
}
