namespace UserAccessSystem.Models.AppModels {
    /// <summary>
    /// Model for signel user API request
    /// </summary>
    public class SingleUserApiModel {
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is has access.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is has access; otherwise, <c>false</c>.
        /// </value>
        public bool IsHasAccess { get; set; }
    }
}