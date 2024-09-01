using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace UnityUtils {
    public static class UQueryBuilderExtensions {
        /// <summary>
        /// Sorts the elements of a sequence in ascending order according 
        /// to a key and returns an ordered sequence.
        /// </summary>
        /// <param name="query">The elements to be sorted.</param>
        /// <param name="keySelector">A function to extract a sort key from an element.</param>
        /// <param name="default">The Comparer to compare keys.</param>
        public static IEnumerable<T> OrderBy<T, TKey>(this UQueryBuilder<T> query, Func<T, TKey> keySelector,
            Comparer<TKey> @default)
            where T : VisualElement {
            return query.ToList().OrderBy(keySelector, @default);
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according 
        /// to a numeric key and returns an ordered sequence.
        /// </summary>
        /// <param name="query">The elements to be sorted.</param>
        /// <param name="keySelector">A function to extract a numeric key from an element.</param>
        public static IEnumerable<T> SortByNumericValue<T>(this UQueryBuilder<T> query, Func<T, float> keySelector)
            where T : VisualElement {
            return query.OrderBy(keySelector, Comparer<float>.Default);
        }


        /// <summary>
        /// Returns the first element of a sequence, or a default value if no element is found.
        /// </summary>
        /// <param name="query">The elements to search in.</param>
        public static T FirstOrDefault<T>(this UQueryBuilder<T> query)
            where T : VisualElement {
            return query.ToList().FirstOrDefault();
        }

        /// <summary>
        /// Counts the number of elements in the sequence that satisfy the condition specified by the predicate function.
        /// </summary>
        /// <param name="query">The sequence of elements to be processed.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        public static int CountWhere<T>(this UQueryBuilder<T> query, Func<T, bool> predicate)
            where T : VisualElement {
            return query.ToList().Count(predicate);
        }
    }
}
