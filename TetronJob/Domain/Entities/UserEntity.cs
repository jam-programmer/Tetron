using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string? Avatar { set; get; }
        public string? Birthday { set; get; }
        public string? FullName { set; get; }




        #region  ForeginKey
        public Guid? AddressId { set; get; }
        public virtual UserAddressEntity? Address { set; get; }
        public ICollection<CategoryUserEntity>? UserCategories { set; get; }

        #endregion

    }
}
