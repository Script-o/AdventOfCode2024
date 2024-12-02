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

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + ObjectNumber;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            NumberCode objAsPart = obj as NumberCode;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public int SortByNameAscending(string name1, string name2)
        {

            return name1.CompareTo(name2);
        }

        // Default comparer for Part type.
        public int CompareTo(NumberCode comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;

            else
                return this.ObjectNumber.CompareTo(comparePart.ObjectNumber);
        }
        public override int GetHashCode()
        {
            return PartId;
        }
        public bool Equals(NumberCode other)
        {
            if (other == null) return false;
            return (this.ObjectNumber.Equals(other.ObjectNumber));
        }
        // Should also override == and != operators.
    }
    public class Example
    {
        public static void Test()
        {
            // Create a list of parts.
            List<NumberCode> parts = new List<NumberCode>();

            // Add parts to the list.
            parts.Add(new NumberCode() { ObjectNumber = 1, PartId = 1434 });
            parts.Add(new NumberCode() { ObjectNumber = 3, PartId = 1234 });
            parts.Add(new NumberCode() { ObjectNumber = 2, PartId = 1634 }); ;
            // Name intentionally left null.
            parts.Add(new NumberCode() { PartId = 1334 });
            parts.Add(new NumberCode() { ObjectNumber = 4, PartId = 1444 });
            parts.Add(new NumberCode() { ObjectNumber = 6, PartId = 1534 });

            // Write out the parts in the list. This will call the overridden
            // ToString method in the Part class.
            Console.WriteLine("\nBefore sort:");
            foreach (NumberCode aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            // Call Sort on the list. This will use the
            // default comparer, which is the Compare method
            // implemented on Part.
            parts.Sort();

            Console.WriteLine("\nAfter sort by part number:");
            foreach (NumberCode aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            // This shows calling the Sort(Comparison(T) overload using
            // an anonymous method for the Comparison delegate.
            // This method treats null as the lesser of two values.
            parts.Sort(delegate (NumberCode x, NumberCode y)
            {
                if (x.ObjectNumber == null && y.ObjectNumber == null) return 0;
                else if (x.ObjectNumber == null) return -1;
                else if (y.ObjectNumber == null) return 1;
                else return x.ObjectNumber.CompareTo(y.ObjectNumber);
            });

            Console.WriteLine("\nAfter sort by name:");
            foreach (NumberCode aPart in parts)
            {
                Console.WriteLine(aPart);
            }
        }
    }
}
