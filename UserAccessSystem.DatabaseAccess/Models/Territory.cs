using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserAccessSystem.DatabaseAccess.Models {
    /// <summary>
    ///     Territory class
    /// </summary>
    public class Territory {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
        [Required]
        public bool IsRequireSpecialUserAccessRights { get; set; }
        [Required]
        public bool IsAvailableForAll { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}