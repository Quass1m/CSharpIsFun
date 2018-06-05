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
    }
}