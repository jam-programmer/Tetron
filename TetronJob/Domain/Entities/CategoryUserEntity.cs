namespace Domain.Entities
{
    public class CategoryUserEntity : BaseEntity
    {
        public Guid UserId { set; get; }
        public UserEntity? User { set; get; }
        public Guid CategoryId { set; get; }
        public CategoryEntity? Category { set; get; }

    }
}
