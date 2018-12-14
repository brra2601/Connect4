namespace Connect4
{
    public static class Connect4Constants
    {
        public static class Dimensions
        {
            public const short rows = 6;
            public const short cols = 7;
        }
        public static class Masks
        {
            public const ulong fullColumn = 0x810204081;
            public const ulong horizontal4 = 0xF;
            public const ulong vertical4 = 0x204081;
            public const ulong diagonalTopRight = 0x208208;
            public const ulong diagonalTopLeft = 0x10101;
        }
    }
}
