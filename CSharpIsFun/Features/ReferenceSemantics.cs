using System;

namespace CSharpIsFun.Features
{
    public static class ReferenceSemantics
    {
        public static int OrMaybe(this ref int x, ref int y)
        {
            x++;
            y--;

            return x;
        }

        public static int OrMaybeIn(this ref int x, in int y)
        {
            x++;
            //y--; // not permitted due to 'in' keyword
            //y++; // not permitted due to 'in' keyword

            return x;
        }

        public static int OrMaybeInWorking(this ref int x, in int y)
        {
            x = y;

            return x;
        }

        public static ref int OrMaybeRef(this ref int x, in int y)
        {
            x++;

            return ref x;
        }

        public static ref readonly int ReadonlyRef(this in int x, in int y)
        {
            return ref x;
        }

        //public static ref readonly Guid ReadonlyRef()
        //{
        //    return Guid.NewGuid();
        //}

        //struct ImmutableArray<T>
        //{
        //    private readonly T[] array;

        //    public ref readonly T ItemRef(int i)
        //    {
        //        // returning a readonly reference to an array element
        //        return ref this.r1;
        //    }
        //}
    }
}