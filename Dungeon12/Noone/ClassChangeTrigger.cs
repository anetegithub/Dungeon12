﻿using Dungeon;
using Dungeon12.Abilities;
using Dungeon12.Classes;
using Dungeon12.Conversations;
using Dungeon.Drawing;
using Dungeon12.Drawing.SceneObjects.Map;
using Dungeon.Events;
using Dungeon12.Map;
using Dungeon.View.Interfaces;
using System.Linq;
using Dungeon12.Events;
using Dungeon.Resources;
using Dungeon.Data;

namespace Dungeon12
{
    public class ClassChangeTrigger : ConversationTrigger
    {
        public override bool Storable => false;

        protected override IDrawText Trigger(PlayerSceneObject PlayerSceneObject, GameMap Gamemap, string[] args)
        {
            var SceneObject = PlayerSceneObject;

            Character from = SceneObject.Avatar.Character;

            var newClass = args[0];
            var newClassAssembly = args[1];

            // создаём новый экземпляр класса
            var to = new Instance(newClass).Value<Character>(true);

            //отключаем все пассивные способности
            from.PropertiesOfType<Ability>()
                .Where(a => a.CastType == Dungeon12.Abilities.Enums.AbilityCastType.Passive)
                .ToList()
                .ForEach(a => a.Release(Gamemap, SceneObject.Avatar));

            // убираем все перки которые имеют отношение к классу
            from.RemoveAll(p => p.ClassDependent);

            to.Backpack = from.Backpack;
            to.Clothes = from.Clothes;
            to.EXP = from.EXP;
            to.Gold = from.Gold;
            to.HitPoints = from.HitPoints;
            to.MaxHitPoints = from.MaxHitPoints;
            to.AbilityPower = from.AbilityPower;
            to.AttackDamage = from.AttackDamage;
            to.Barrier = from.Barrier;
            to.Defence = from.Defence;
            to.Idle = from.Idle;
            to.MinDMG = from.MinDMG;
            to.MaxDMG = from.MaxDMG;
            to.Origin = from.Origin;

            to.Race = from.Race;
            to.Name = from.Name;
            to.Level = from.Level;

            to.Recalculate();

            SceneObject.Avatar.Character = to;
            SceneObject.Avatar.ReEntity(to);
            SceneObject.Avatar.Character.SetView(SceneObject);

            Global.Events.Raise(new ClassChangeEvent()
            {
                PlayerSceneObject = SceneObject,
                GameMap = Gamemap,
                Character = SceneObject.Avatar.Character
            });

            Global.GameState.Equipment.Reset();

            return new DrawText("Класс поменяли");
        }
    }
}