/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Newtonsoft.Json;

namespace Karamem0.SampleApplication.Common.Entities
{
    /// <summary>
    /// Represents the User entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class User : IGuidIdentifier, IUniqueKey
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the User Principal Name.
        /// </summary>
        [JsonProperty("userPrincipalName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? UserPrincipalName { get; set; }

        /// <summary>
        /// Gets or sets the Display Name.
        /// </summary>
        [JsonProperty("displayName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? DisplayName { get; set; }

        /// <summary>
        /// Gets the list of property names that represent the unique key.
        /// </summary>
        public string[] UniqueKeyProperties => new string[] { nameof(Id) };

        /// <summary>
        /// Creates the <see cref="UniqueKey"/>.
        /// </summary>
        /// <returns>The <see cref="Beef.Entities.UniqueKey"/>.</returns>
        /// <param name="id">The <see cref="Id"/>.</param>
        public static UniqueKey CreateUniqueKey(Guid id) => new UniqueKey(id);

        /// <summary>
        /// Gets the <see cref="UniqueKey"/> (consists of the following property(s): <see cref="Id"/>).
        /// </summary>
        public UniqueKey UniqueKey => CreateUniqueKey(Id);
    }

    /// <summary>
    /// Represents the <see cref="User"/> collection.
    /// </summary>
    public partial class UserCollection : List<User> { }

    /// <summary>
    /// Represents the <see cref="User"/> collection result.
    /// </summary>
    public class UserCollectionResult : CollectionResult<UserCollection, User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserCollectionResult"/> class.
        /// </summary>
        public UserCollectionResult() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCollectionResult"/> class with <paramref name="paging"/>.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public UserCollectionResult(PagingArgs? paging) : base(paging) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCollectionResult"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public UserCollectionResult(IEnumerable<User> collection, PagingArgs? paging = null) : base(paging) => Result.AddRange(collection);
    }
}

#pragma warning restore
#nullable restore
