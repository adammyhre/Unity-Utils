using System;

namespace UnityUtils {
    public static class SpanExtensions {
        /// <summary>
        /// Copies a block of elements from one span to another.
        /// </summary>
        /// <param name="src">The source span.</param>
        /// <param name="srcOffset">The starting index in the source span.</param>
        /// <param name="dst">The destination span.</param>
        /// <param name="dstOffset">The starting index in the destination span.</param>
        /// <param name="count">The number of elements to copy.</param>
        /// <typeparam name="T">The type of elements in the spans.</typeparam>
        /// <exception cref="ArgumentException">Thrown when source or destination span is too small.</exception>
        public static void BlockCopy<T>(this Span<T> src, int srcOffset, Span<T> dst, int dstOffset, int count) {
            if ((uint)(srcOffset + count) > (uint)src.Length)
                throw new ArgumentException("Source span is too small");
            if ((uint)(dstOffset + count) > (uint)dst.Length)
                throw new ArgumentException("Destination span is too small");

            src.Slice(srcOffset, count).CopyTo(dst.Slice(dstOffset));
        }

        /// <summary>
        /// Copies a block of elements from one array to another.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="srcOffset">The starting index in the source array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="dstOffset">The starting index in the destination array.</param>
        /// <param name="count">The number of elements to copy.</param>
        /// <typeparam name="T">The type of elements in the arrays.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when source or destination array is null.</exception>
        public static void BlockCopy<T>(this T[] src, int srcOffset, T[] dst, int dstOffset, int count) {
            if (src == null) throw new ArgumentNullException(nameof(src));
            if (dst == null) throw new ArgumentNullException(nameof(dst));

            src.AsSpan(srcOffset, count).CopyTo(dst.AsSpan(dstOffset));
        }
    }
}