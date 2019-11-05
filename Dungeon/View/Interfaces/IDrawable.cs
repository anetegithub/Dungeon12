﻿using Dungeon.Types;

namespace Dungeon.View.Interfaces
{
    public interface IDrawable : IDrawContext
    {
        string Uid { get; }

        string Icon { get; }

        string Name { get; }

        string Tileset { get; }

        Rectangle TileSetRegion { get; }

        /// <summary>
        /// Контейнер для рисования
        /// </summary>
        bool Container { get; }
    }
}