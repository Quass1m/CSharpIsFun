using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CSharpIsFun.Features
{
    public class SpanType
    {
        public static void TestSpan()
        {
            Console.WriteLine(nameof(TestSpan));

            const int count = 10;
            int[] array = new int[count];

            // Create Span from unpopulated array
            Span<int> span = array.AsSpan();
            Span<int> slice = span.Slice(3, 5);

            for (int i = 0; i < count; i++)
                array[i] = i;

            Console.WriteLine("Print array:");
            foreach (int v in array)
                Console.WriteLine(v);

            // Span holds a reference to the array
            Console.WriteLine("Print span:");
            foreach (int v in span)
                Console.WriteLine(v);

            Console.WriteLine("Print slice of span:");
            foreach (int v in slice)
                Console.WriteLine(v);

            for (int i = 0; i < count; i++)
                span[i] += 10;

            Console.WriteLine("Print incremented span:");
            foreach (int v in span)
                Console.WriteLine(v);

            Console.WriteLine("Print array again:");
            foreach (int v in array)
                Console.WriteLine(v);

            ReadOnlySpan<int> readOnlySpan = array.AsSpan();

            Console.WriteLine("Print read only span:");
            foreach (int v in readOnlySpan)
                Console.WriteLine(v);

            for (int i = 0; i < count; i++)
            {
                //readOnlySpan[i] += 10; // won't compile
            }


        }

        public static void TestReadOnlySpan()
        {
            Console.WriteLine(nameof(TestReadOnlySpan));

            const int count = 10;
            int[] array = new int[count];
            
            for (int i = 0; i < count; i++)
                array[i] = i;

            Console.WriteLine("Print array:");
            foreach (int v in array)
                Console.WriteLine(v);

            ReadOnlySpan<int> readOnlySpan = array.AsSpan();

            Console.WriteLine("Print read only span:");
            foreach (int v in readOnlySpan)
                Console.WriteLine(v);

            for (int i = 0; i < count; i++)
            {
                //readOnlySpan[i] += 10; // won't compile
            }
        }

        public static void TestSpanStackAlloc()
        {
            Console.WriteLine(nameof(TestSpanStackAlloc));
            const int count = 10;

            Span<int> span = stackalloc int[count];
            ReadOnlySpan<int> readOnlySpan = span.Slice(3, 5);

            for (int i = 0; i < count; i++)
                span[i] = i;

            Console.WriteLine("Print span:");
            foreach (int v in span)
                Console.WriteLine(v);

            Console.WriteLine("Print read only span:");
            foreach (int v in readOnlySpan)
                Console.WriteLine(v);
        }

        /// <summary>
        /// Span Marshal.AllocHGlobal example
        /// </summary>
        /// <see cref="https://msdn.microsoft.com/en-us/magazine/mt814808.aspx?f=255&MSPPError=-2147217396"/>
        public static void TestSpanUnmanagedMemory()
        {
            IntPtr ptr = Marshal.AllocHGlobal(1);
            try
            {
                Span<byte> bytes;

                unsafe
                {
                    bytes = new Span<byte>((byte*)ptr, 1);
                }

                bytes[0] = 42;

                if (bytes[0] != 42)
                    throw new Exception();

                if (bytes[0] != Marshal.ReadByte(ptr))
                    throw new Exception();

                //bytes[1] = 43; // Throws IndexOutOfRangeException
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Memory example
        /// Memory can be stored on the heap, unlike Span. It is thus useful in async scenarios.
        /// <returns>Addition checksum. Should be equal to 45.</returns>
        public static int TestMemoryType()
        {
            const int count = 10;
            int[] array = new int[count];

            for (int i = 0; i < count; i++)
                array[i] = i;

            byte[] buffer = new byte[count];
            byte[] byteArray = new byte[count];
            for (byte i = 0; i < count; i++)
                byteArray[i] = i;

            Memory<byte> memory = new Memory<byte>(byteArray);
            Stream stream = new MemoryStream(byteArray);

            return ChecksumReadAsync(memory, stream).GetAwaiter().GetResult();
        }

        /// <summary>
        /// ChecksumReadAsync
        /// </summary>
        /// <see cref="https://msdn.microsoft.com/en-us/magazine/mt814808.aspx?f=255&MSPPError=-2147217396"/>
        /// <see cref="https://github.com/dotnet/corefxlab/blob/master/docs/specs/memory.md"/>
        public static async Task<int> ChecksumReadAsync(Memory<byte> buffer, Stream stream)
        {
            int bytesRead = await stream.ReadAsync(buffer);

            // both are correct            
            return Checksum(buffer.Slice(0, bytesRead).Span);
            //return Checksum(buffer.Span.Slice(0, bytesRead));
        }

        /// <summary>
        /// Simple addition checksum
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Checksum</returns>
        private static int Checksum(Span<byte> data)
        {
            long longSum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                longSum += data[i];
            }

            return unchecked((byte)longSum);
        }
    }
}