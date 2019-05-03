﻿namespace Rogue.View.Interfaces
{
    using Rogue.Types;
    using System;
    using System.Collections.Generic;

    public interface ISceneObject
    {
        /// <summary>
        /// Can be cached or have animation
        /// </summary>
        bool CacheAvailable { get; }

        /// <summary>
        /// Is this object can be batched
        /// </summary>
        bool IsBatch { get; }

        /// <summary>
        /// is this object need to re cached
        /// </summary>
        bool Expired { get; }

        /// <summary>
        /// Must exists
        /// </summary>
        Rectangle Position { get; }

        /// <summary>
        /// Position with parent
        /// </summary>
        Rectangle ComputedPosition { get; }

        string Image { get; }

        Rectangle ImageRegion { get; }

        IDrawText Text { get; }

        IDrawablePath Path { get; }

        ISceneObject Parent { get; }

        ICollection<ISceneObject> Children { get; }

        bool AbsolutePosition { get; }

        string Uid { get; }

        /// <summary>
        /// Вызвать уничтожение объекта. КОМУ НАДО ТОТ УНИЧТОЖИТ ЁПТА
        /// </summary>
        Action Destroy { get; set; }
    }
}