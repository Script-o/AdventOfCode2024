using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class NumberCode : IEquatable<NumberCode>, IComparable<NumberCode>
    {
        public int ObjectNumber { get; set; }

        public int PartId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            NumberCode objForComparison = obj as NumberCode;
            if (objForComparison == null) return false;
            else return Equals(objForComparison);
        }

        // Default comparer for NumberCode.
        public int CompareTo(NumberCode comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;

            else
                return this.ObjectNumber.CompareTo(comparePart.ObjectNumber);
        }
        public bool Equals(NumberCode other)
        {
            if (other == null) return false;
            return (this.ObjectNumber.Equals(other.ObjectNumber));
        }
    }
}
