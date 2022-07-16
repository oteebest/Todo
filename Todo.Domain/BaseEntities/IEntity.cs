namespace Todo.Domain.BaseEntities
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
