﻿using Dungeon.Physics;
using Dungeon.Types;
using Dungeon12.Abilities;
using Dungeon12.Abilities.Enums;
using Dungeon12.Abilities.Scaling;
using Dungeon12.Entities.Alive;
using Dungeon12.Map;
using Dungeon12.Map.Objects;
using Dungeon12.Noone.Talants;

namespace Dungeon12.Noone.Abilities
{
    public class ShockWave : Ability<Noone, AbsorbingTalants>
    {
        public override bool Hold => false;

        public override double Spend => 3;

        public override int Position => 1;
        
        public override long Value => 1;

        public override string Name => "Ударная волна";

        public override ScaleRate<Noone> Scale => new ScaleRate<Noone>(x => x.AttackDamage * 2.5d, x => x.Stamina * 1.7);

        public override AbilityPosition AbilityPosition => AbilityPosition.Q;

        protected override bool CanUse(Noone @class) => @class.Actions >= 3;

        protected override void Use(GameMap gameMap, Avatar avatar, Noone @class)
        {
            @class.Actions -= 3;
            var value = this.ScaledValue(@class, Value);

            @class.InParry = true;
            Global.AudioPlayer.Effect("attack".NooneSoundPath());

            var rangeObject = new MapObject()
            {
                Position = new Dungeon.Physics.PhysicalPosition
                {
                    X = avatar.Position.X,
                    Y = avatar.Position.Y
                },
                Size = new PhysicalSize()
                {
                    Height = 32,
                    Width = 32
                }
            };

            switch (avatar.VisionDirection)
            {
                case Direction.Up:
                    rangeObject.Position.Y -= 3;
                    rangeObject.Size.Height *= 3;
                    break;
                case Direction.Down:
                    rangeObject.Position.Y += 3;
                    rangeObject.Size.Height *= 3;
                    break;
                case Direction.UpLeft:
                case Direction.DownLeft:
                case Direction.Left:
                    rangeObject.Position.X -= 3;
                    rangeObject.Size.Width *= 3;
                    break;
                case Direction.DownRight:
                case Direction.UpRight:
                case Direction.Right:
                    rangeObject.Position.X += 3;
                    rangeObject.Size.Width *= 3;
                    break;
                default:
                    break;
            }

            var enemies = gameMap.Enemies(rangeObject);

            foreach (var enemy in enemies)
            {
                enemy.Entity.Damage(@class, new Damage()
                {
                    Amount = value,
                    Type = DamageType.Physical
                });
            };

            @class.InParry = false;
        }

        protected override void Dispose(GameMap gameMap, Avatar avatar, Noone @class)
        {
            //TODO elapsed buf
        }

        public override AbilityActionAttribute ActionType => AbilityActionAttribute.EffectOfTime;

        public override AbilityCastType CastType => AbilityCastType.Active;

        public override Location CastLocation => Location.Alltime;

        public override AbilityTargetType TargetType => AbilityTargetType.SelfTarget;

        public override string Description => $"Выпускает ударную волну которая наносит урон всем собой на три шага.";

    }
}