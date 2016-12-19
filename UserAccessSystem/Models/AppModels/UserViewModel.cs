using System;

namespace UserAccessSystem.Models.AppModels {
    public class UserViewModel {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [full name].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [full name]; otherwise, <c>false</c>.
        /// </value>
        public string FullName => $"{this.FirstName} {this.LastName}";

        /// <summary>
        ///     Gets or sets the last subscription.
        /// </summary>
        /// <value>
        ///     The last subscription.
        /// </value>
        public DateTime LastSubscription { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active account.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active account; otherwise, <c>false</c>.
        /// </value>
        public bool IsActiveAccount { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is super user.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is super user; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuperUser { get; set; }
    }
}