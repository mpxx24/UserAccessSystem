using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UserAccessSystem.Models.AppModels.CustomControlsModels {
    [Serializable]
    public class UsersGridModel {
        /// <summary>
        ///     Gets or sets the current.
        /// </summary>
        /// <value>
        ///     The current.
        /// </value>
        [JsonProperty(PropertyName = "current")]
        public int Current { get; set; }

        /// <summary>
        ///     Gets or sets the row count.
        /// </summary>
        /// <value>
        ///     The row count.
        /// </value>
        [JsonProperty(PropertyName = "rowCount")]
        public int RowCount { get; set; }

        /// <summary>
        ///     Gets or sets the rows.
        /// </summary>
        /// <value>
        ///     The rows.
        /// </value>
        [JsonProperty(PropertyName = "rows")]
        public List<UserViewModel> Rows { get; set; }

        /// <summary>
        ///     Gets or sets the total.
        /// </summary>
        /// <value>
        ///     The total.
        /// </value>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }
}