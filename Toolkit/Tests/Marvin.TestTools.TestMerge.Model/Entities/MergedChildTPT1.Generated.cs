﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the Marvin template for generating a DbContext and Entities. 
// If you have any questions or suggestions for improvement regarding this code, contact Thomas Fuchs. I allways need feedback to improve.
// 
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Linq;
using Marvin.Model;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Marvin.TestTools.TestMerge.Model
{

    /// <summary>
    /// There are no comments for Marvin.TestTools.TestMerge.Model.MergedChildTPT1 in the schema.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [System.Runtime.Serialization.KnownType(typeof(MergedChildTPT2))]
    public partial class MergedChildTPT1 : MergedBaseTPT, IEquatable<MergedChildTPT1>, IMergeParent, IModificationTrackedEntity    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MergedChildTPT1()
        {
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for A in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual int A
        {
            get
            {
                return _a;
            }
            set
            {
                if (_a != value)
                {
                    _a = value;
                    OnPropertyChanged("A");
                }
            }
        }
        private int _a;

    
        /// <summary>
        /// There are no comments for CombinedChildTPT in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Nullable<int> CombinedChildTPT
        {
            get
            {
                return _combinedChildTPT;
            }
            set
            {
                if (_combinedChildTPT != value)
                {
                    _combinedChildTPT = value;
                    OnPropertyChanged("CombinedChildTPT");
                }
            }
        }
        private global::System.Nullable<int> _combinedChildTPT;


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for MergedChild2s in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual ICollection<MergedChildTPT2> MergedChild2s
        {
		    get; set;
        }

        #endregion
        #region IEquatable
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return Equals(other as MergedChildTPT1); 
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The MergedChildTPT1 to compare with the current MergedChildTPT1.</param>
        /// <returns><c>true</c> if the specified MergedChildTPT1 is equal to the current MergedChildTPT1; otherwise, <c>false</c>.</returns>
        public bool Equals(MergedChildTPT1 other)
        {
            if((object)other == null)
                return false;
            
            // First look for Id, then compare references
            return (Id != 0 && Id == other.Id) || object.ReferenceEquals(this, other);
        }
     
        /// <summary>
        /// Compares two MergedChildTPT1 objects.
        /// </summary>
        /// <param name="a">The first MergedChildTPT1 to compare</param>
        /// <param name="b">The second MergedChildTPT1 to compare</param>
        /// <returns><c>true</c> if the specified objects are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(MergedChildTPT1  a, MergedChildTPT1  b)
        {
            if((object)a == null && (object)b == null)
                return true;
            return (object)a != null && a.Equals(b);
        }

        /// <summary>
        /// Compares two MergedChildTPT1 objects.
        /// </summary>
        /// <param name="a">The first MergedChildTPT1 to compare</param>
        /// <param name="b">The second MergedChildTPT1 to compare</param>
        /// <returns><c>true</c> if the specified objects are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(MergedChildTPT1  a, MergedChildTPT1 b)
        {
            return !(a == b);
        }

        #endregion
        
        /// <summary>
        /// Reference to merged child
        /// </summary>
        object IMergeParent.Child { get; set; }
    }

}