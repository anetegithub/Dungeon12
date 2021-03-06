﻿using Dungeon.Data;
using Dungeon12.Entities.Fractions;

namespace Dungeon12.Database.Fractions
{
    public class FractionData : Persist
    {
        public string Name { get; set; }

        /// <summary>
        /// Признак репутации которая может быть использована игроком
        /// </summary>
        public bool Playable { get; set; }

        public string[] Enemies { get; set; }


        public FractionLevel DefaultLevel { get; set; }

        public int DefaultValue { get; set; }
    }
}