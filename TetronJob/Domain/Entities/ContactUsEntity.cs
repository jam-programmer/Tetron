
namespace Domain.Entities
{
    public class ContactUsEntity:BaseEntity
    {
        public string? FullName { set; get; }
        public string? Title { set; get; }
        public string? PhoneNumber { set; get; }
        public string? Message { set; get; }

    }
}
