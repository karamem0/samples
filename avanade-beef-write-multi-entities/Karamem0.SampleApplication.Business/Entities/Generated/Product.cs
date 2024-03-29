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
    /// Represents the Product entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class Product : EntityBase, IUniqueKey, IChangeLog, IEquatable<Product>
    {
        #region Privates

        private Guid _productId;
        private string? _productName;
        private decimal _price;
        private ChangeLog? _changeLog;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Product Id.
        /// </summary>
        [JsonProperty("productId", DefaultValueHandling = DefaultValueHandling.Include)]
        [Display(Name="Product")]
        public Guid ProductId
        {
            get => _productId;
            set => SetValue(ref _productId, value, false, false, nameof(ProductId));
        }

        /// <summary>
        /// Gets or sets the Product Name.
        /// </summary>
        [JsonProperty("productName", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Product Name")]
        public string? ProductName
        {
            get => _productName;
            set => SetValue(ref _productName, value, false, StringTrim.UseDefault, StringTransform.UseDefault, nameof(ProductName));
        }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        [JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Price")]
        public decimal Price
        {
            get => _price;
            set => SetValue(ref _price, value, false, false, nameof(Price));
        }

        /// <summary>
        /// Gets or sets the Change Log (see <see cref="Beef.Entities.ChangeLog"/>).
        /// </summary>
        [JsonProperty("changeLog", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Change Log")]
        public ChangeLog? ChangeLog
        {
            get => _changeLog;
            set => SetValue(ref _changeLog, value, false, true, nameof(ChangeLog));
        }

        #endregion

        #region IChangeTracking

        /// <summary>
        /// Resets the entity state to unchanged by accepting the changes (resets <see cref="EntityBase.ChangeTracking"/>).
        /// </summary>
        /// <remarks>Ends and commits the entity changes (see <see cref="EntityBase.EndEdit"/>).</remarks>
        public override void AcceptChanges()
        {
            ChangeLog?.AcceptChanges();
            base.AcceptChanges();
        }

        /// <summary>
        /// Determines that until <see cref="AcceptChanges"/> is invoked property changes are to be logged (see <see cref="EntityBase.ChangeTracking"/>).
        /// </summary>
        public override void TrackChanges()
        {
            ChangeLog?.TrackChanges();
            base.TrackChanges();
        }

        #endregion

        #region IUniqueKey

        /// <summary>
        /// Gets the list of property names that represent the unique key.
        /// </summary>
        public string[] UniqueKeyProperties => new string[] { nameof(ProductId) };

        /// <summary>
        /// Creates the <see cref="UniqueKey"/>.
        /// </summary>
        /// <returns>The <see cref="Beef.Entities.UniqueKey"/>.</returns>
        /// <param name="productId">The <see cref="ProductId"/>.</param>
        public static UniqueKey CreateUniqueKey(Guid productId) => new UniqueKey(productId);

        /// <summary>
        /// Gets the <see cref="UniqueKey"/> (consists of the following property(s): <see cref="ProductId"/>).
        /// </summary>
        public UniqueKey UniqueKey => CreateUniqueKey(ProductId);

        #endregion

        #region IEquatable

        /// <summary>
        /// Determines whether the specified object is equal to the current object by comparing the values of all the properties.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj) => obj is Product val && Equals(val);

        /// <summary>
        /// Determines whether the specified <see cref="Product"/> is equal to the current <see cref="Product"/> by comparing the values of all the properties.
        /// </summary>
        /// <param name="value">The <see cref="Product"/> to compare with the current <see cref="Product"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Product"/> is equal to the current <see cref="Product"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Product? value)
        {
            if (value == null)
                return false;
            else if (ReferenceEquals(value, this))
                return true;

            return base.Equals((object)value)
                && Equals(ProductId, value.ProductId)
                && Equals(ProductName, value.ProductName)
                && Equals(Price, value.Price)
                && Equals(ChangeLog, value.ChangeLog);
        }

        /// <summary>
        /// Compares two <see cref="Product"/> types for equality.
        /// </summary>
        /// <param name="a"><see cref="Product"/> A.</param>
        /// <param name="b"><see cref="Product"/> B.</param>
        /// <returns><c>true</c> indicates equal; otherwise, <c>false</c> for not equal.</returns>
        public static bool operator == (Product? a, Product? b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="Product"/> types for non-equality.
        /// </summary>
        /// <param name="a"><see cref="Product"/> A.</param>
        /// <param name="b"><see cref="Product"/> B.</param>
        /// <returns><c>true</c> indicates not equal; otherwise, <c>false</c> for equal.</returns>
        public static bool operator != (Product? a, Product? b) => !Equals(a, b);

        /// <summary>
        /// Returns the hash code for the <see cref="Product"/>.
        /// </summary>
        /// <returns>The hash code for the <see cref="Product"/>.</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(ProductId);
            hash.Add(ProductName);
            hash.Add(Price);
            hash.Add(ChangeLog);
            return base.GetHashCode() ^ hash.ToHashCode();
        }

        #endregion

        #region ICopyFrom

        /// <summary>
        /// Performs a copy from another <see cref="Product"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Product"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<Product>(from);
            CopyFrom(fval);
        }

        /// <summary>
        /// Performs a copy from another <see cref="Product"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="Product"/> to copy from.</param>
        public void CopyFrom(Product from)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            CopyFrom((EntityBase)from);
            ProductId = from.ProductId;
            ProductName = from.ProductName;
            Price = from.Price;
            ChangeLog = CopyOrClone(from.ChangeLog, ChangeLog);

            OnAfterCopyFrom(from);
        }

        #endregion

        #region ICloneable

        /// <summary>
        /// Creates a deep copy of the <see cref="Product"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="Product"/>.</returns>
        public override object Clone()
        {
            var clone = new Product();
            clone.CopyFrom(this);
            return clone;
        }

        #endregion

        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="Product"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            ProductId = Cleaner.Clean(ProductId);
            ProductName = Cleaner.Clean(ProductName, StringTrim.UseDefault, StringTransform.UseDefault);
            Price = Cleaner.Clean(Price);
            ChangeLog = Cleaner.Clean(ChangeLog);

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
                return Cleaner.IsInitial(ProductId)
                    && Cleaner.IsInitial(ProductName)
                    && Cleaner.IsInitial(Price)
                    && Cleaner.IsInitial(ChangeLog);
            }
        }

        #endregion

        #region PartialMethods

        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(Product from);

        #endregion
    }

    #region Collection

    /// <summary>
    /// Represents the <see cref="Product"/> collection.
    /// </summary>
    public partial class ProductCollection : EntityBaseCollection<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollection"/> class.
        /// </summary>
        public ProductCollection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollection"/> class with an entities range.
        /// </summary>
        /// <param name="entities">The <see cref="Product"/> entities.</param>
        public ProductCollection(IEnumerable<Product> entities) => AddRange(entities);

        /// <summary>
        /// Creates a deep copy of the <see cref="ProductCollection"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="ProductCollection"/>.</returns>
        public override object Clone()
        {
            var clone = new ProductCollection();
            foreach (var item in this)
            {
                clone.Add((Product)item.Clone());
            }

            return clone;
        }

        /// <summary>
        /// An implicit cast from the <see cref="ProductCollectionResult"/> to a corresponding <see cref="ProductCollection"/>.
        /// </summary>
        /// <param name="result">The <see cref="ProductCollectionResult"/>.</param>
        /// <returns>The corresponding <see cref="ProductCollection"/>.</returns>
        public static implicit operator ProductCollection(ProductCollectionResult result) => result?.Result!;
    }

    #endregion

    #region CollectionResult

    /// <summary>
    /// Represents the <see cref="Product"/> collection result.
    /// </summary>
    public class ProductCollectionResult : EntityCollectionResult<ProductCollection, Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionResult"/> class.
        /// </summary>
        public ProductCollectionResult() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionResult"/> class with <paramref name="paging"/>.
        /// </summary>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public ProductCollectionResult(PagingArgs? paging) : base(paging) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionResult"/> class with a <paramref name="collection"/> of items to add.
        /// </summary>
        /// <param name="collection">A collection containing items to add.</param>
        /// <param name="paging">The <see cref="PagingArgs"/>.</param>
        public ProductCollectionResult(IEnumerable<Product> collection, PagingArgs? paging = null) : base(paging) => Result.AddRange(collection);

        /// <summary>
        /// Creates a deep copy of the <see cref="ProductCollectionResult"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="ProductCollectionResult"/>.</returns>
        public override object Clone()
        {
            var clone = new ProductCollectionResult();
            clone.CopyFrom(this);
            return clone;
        }
    }

    #endregion
}

#pragma warning restore
#nullable restore
