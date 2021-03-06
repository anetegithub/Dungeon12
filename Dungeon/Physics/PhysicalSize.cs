﻿namespace Dungeon.Physics
{
    public class PhysicalSize
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public PhysicalSize Copy() => new PhysicalSize()
        {
            Height = this.Height,
            Width = this.Width
        };
    }
}