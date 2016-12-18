namespace UserAccessSystem.Models.AppModels {
    public class TerritoryViewModel {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the short name.
        /// </summary>
        /// <value>
        ///     The short name.
        /// </value>
        public string ShortName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is require special user access rights.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is require special user access rights; otherwise, <c>false</c>.
        /// </value>
        public bool IsRequireSpecialUserAccessRights { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is available for all.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is available for all; otherwise, <c>false</c>.
        /// </value>
        public bool IsAvailableForAll { get; set; }
    }
}