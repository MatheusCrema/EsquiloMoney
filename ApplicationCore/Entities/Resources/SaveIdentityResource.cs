
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Resources
{
    public class SaveIdentityResource
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(25)]
        public string Phone { get; set; }

    }

}
