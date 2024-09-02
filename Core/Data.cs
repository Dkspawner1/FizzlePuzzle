
using System;

namespace FizzlePuzzle.Core;

public record Data
{
    public record Window
    {
        public static int Width { get; set; } = 1600;
        public static int Height { get; set; } = 900;
        public static bool Exit { get; set; } = false;

    }
    [Flags()]
    public enum SCENES : sbyte
    {
        MENU = 0x1,
        GAME = 0x2,
        SETTINGS = 0x4,
        NONE = 0x8,
        TRANSITION = 0x10,
    }
}
