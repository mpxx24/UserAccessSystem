using System;
using System.ComponentModel.DataAnnotations;

namespace UserAccessSystem.DatabaseAccess.Models {
    /// <summary>
    ///     User class
    /// </summary>
    public class User {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        [Required]
        public DateTime LastSubscription { get; set; }
        [Required]
        public bool IsActiveAccount { get; set; }
        [Required]
        public bool IsSuperUser { get; set; }
    }
}