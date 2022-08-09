namespace OrcamentoFamiliar.API.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime AlteretedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
