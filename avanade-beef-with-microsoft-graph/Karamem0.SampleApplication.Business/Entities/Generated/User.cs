/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData;
using Newtonsoft.Json;
using RefDataNamespace = Karamem0.SampleApplication.Business.Entities;

namespace Karamem0.SampleApplication.Business.Entities
{
    /// <summary>
    /// Represents the User entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class User : EntityBase, IGuidIdentifier, IUniqueKey, IEquatable<User>
    {
        #region Privates

        private Guid _id;
        private string? _userPrincipalName;
        private string? _displayName;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Include)]
        [Display(Name = "Identifier")]
        public Guid Id
        {
            get => _id;
            set => SetValue(ref _id, value, false, false, nameof(Id));
        }

        /// <summary>
        /// Gets or sets the User Principal Name.
        /// </summary>
        [JsonProperty("userPrincipalName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name = "User Principal Name")]
        public string? UserPrincipalName
        {
            get => _userPrincipalName;
            set => SetValue(ref _userPrincipalName, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(UserPrincipalName));
        }

        /// <summary>
        /// Gets or sets the Display Name.
        /// </summary>
        [JsonProperty("displayName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name = "Display Name")]
        public string? DisplayName
        {
            get => _displayName;
            set => SetValue(ref _displayName, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(DisplayName));
        }

        #endregion

        #region IUniqueKey

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

        #endregion

        #region IEquatable

        /// <summary>
        /// Determines whether the specified object is equal to the current object by comparing the values of all the properties.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj) => obj is User val && Equals(val);

        /// <summary>
        /// Determines whether the specified <see cref="User"/> is equal to the current <see cref="User"/> by comparing the values of all the properties.
        /// </summary>
        /// <param name="value">The <see cref="User"/> to compare with the current <see cref="User"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="User"/> is equal to the current <see cref="User"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(User? value)
        {
            if (value == null)
                return false;
            else if (ReferenceEquals(value, this))
                return true;

            return base.Equals((object)value)
                && Equals(Id, value.Id)
                && Equals(UserPrincipalName, value.UserPrincipalName)
                && Equals(DisplayName, value.DisplayName);
        }

        /// <summary>
        /// Compares two <see cref="User"/> types for equality.
        /// </summary>
        /// <param name="a"><see cref="User"/> A.</param>
        /// <param name="b"><see cref="User"/> B.</param>
        /// <returns><c>true</c> indicates equal; otherwise, <c>false</c> for not equal.</returns>
        public static bool operator ==(User? a, User? b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="User"/> types for non-equality.
        /// </summary>
        /// <param name="a"><see cref="User"/> A.</param>
        /// <param name="b"><see cref="User"/> B.</param>
        /// <returns><c>true</c> indicates not equal; otherwise, <c>false</c> for equal.</returns>
        public static bool operator !=(User? a, User? b) => !Equals(a, b);

        /// <summary>
        /// Returns the hash code for the <see cref="User"/>.
        /// </summary>
        /// <returns>The hash code for the <see cref="User"/>.</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(UserPrincipalName);
            hash.Add(DisplayName);
            return base.GetHashCode() ^ hash.ToHashCode();
        }

        #endregion

        #region ICopyFrom

        /// <summary>
        /// Performs a copy from another <see cref="User"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="User"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<User>(from);
            CopyFrom(fval);
        }

        /// <summary>
        /// Performs a copy from another <see cref="User"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="User"/> to copy from.</param>
        public void CopyFrom(User from)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            CopyFrom((EntityBase)from);
            Id = from.Id;
            UserPrincipalName = from.UserPrincipalName;
            DisplayName = from.DisplayName;

            OnAfterCopyFrom(from);
        }

        #endregion

        #region ICloneable

        /// <summary>
        /// Creates a deep copy of the <see cref="User"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="User"/>.</returns>
        public override object Clone()
        {
            var clone = new User();
            clone.CopyFrom(this);
            return clone;
        }

        #endregion

        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="User"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            Id = Cleaner.Clean(Id);
            UserPrincipalName = Cleaner.Clean(UserPrincipalName, StringTrim.UseDefault, StringTransform.UseDefault);
            DisplayName = Cleaner.Clean(DisplayName, StringTrim.UseDefault, StringTransform.UseDefault);

            OnAfterCleanUp();
        }

        /// <summary>
        /// Indicates whether considered initial; i.e. all properties have their initial value.
        /// </summary>
        /// <returns><c>true</c> indicates is initial; otherwise, <c>false</c>.</returns>
        public override bool IsInitial
        {
            get
            {
                return Cleaner.IsInitial(Id)
                    && Cleaner.IsInitial(UserPrincipalName)
                    && Cleaner.IsInitial(DisplayName);
            }
        }

        #endregion

        #region PartialMethods

        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(User from);

        #endregion
    }

    #region Collection

    /// <summary>
    /// Represents the <see cref="User"/> collection.
    /// </summary>
    public partial class UserCollection : EntityBaseCollection<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserCollection"/> class.
        /// </summary>
        public UserCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCollection"/> class with an entities range.
        /// </summary>
        /// <param name="entities">The <see cref="User"/> entities.</param>
        public UserCollection(IEnumerable<User> entities) => AddRange(entities);

        /// <summary>
        /// Creates a deep copy of the <see cref="UserCollection"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="UserCollection"/>.</returns>
        public override object Clone()
        {
            var clone = new UserCollection();
            foreach (var item in this)
            {
                clone.Add((User)item.Clone());
            }

            return clone;
        }

        /// <summary>
        /// An implicit cast from the <see cref="UserCollectionResult"/> to a corresponding <see cref="UserCollection"/>.
        /// </summary>
        /// <param name="result">The <see cref="UserCollectionResult"/>.</param>
        /// <returns>The corresponding <see cref="UserCollection"/>.</returns>
        public static implicit operator UserCollection(UserCollectionResult result) => result?.Result!;
    }

    #endregion

    #region CollectionResult

    /// <summary>
    /// Represents the <see cref="User"/> collection result.
    /// </summary>
    public class UserCollectionResult : EntityCollectionResult<UserCollection, User>
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

        /// <summary>
        /// Creates a deep copy of the <see cref="UserCollectionResult"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="UserCollectionResult"/>.</returns>
        public override object Clone()
        {
            var clone = new UserCollectionResult();
            clone.CopyFrom(this);
            return clone;
        }
    }

    #endregion
}

#pragma warning restore
#nullable restore
