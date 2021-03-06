﻿namespace Schema.NET
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// A grocery store.
    /// </summary>
    public partial interface IGroceryStore : IStore
    {
    }

    /// <summary>
    /// A grocery store.
    /// </summary>
    [DataContract]
    public partial class GroceryStore : Store, IGroceryStore, IEquatable<GroceryStore>
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "GroceryStore";

        /// <inheritdoc/>
        public bool Equals(GroceryStore other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Type == other.Type &&
                base.Equals(other);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this.Equals(obj as GroceryStore);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Of(this.Type)
            .And(base.GetHashCode());
    }
}
