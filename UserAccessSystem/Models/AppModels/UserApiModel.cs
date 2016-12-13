namespace UserAccessSystem.Models.AppModels {
    public class UserApiModel {
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
        ///     Gets or sets the last subscription.
        /// </summary>
        /// <value>
        ///     The last subscription.
        /// </value>
        public string LastSubscription { get; set; }

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