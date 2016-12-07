using System;

namespace UserAccessSystem.Models.Models {
    public class UserApiModel {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LastSubscription { get; set; }

        public bool IsActiveAccount { get; set; }

        public bool IsSuperUser { get; set; }
    }
}