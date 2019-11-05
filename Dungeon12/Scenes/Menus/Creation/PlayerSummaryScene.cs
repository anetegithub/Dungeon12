﻿namespace Dungeon12.Scenes.Menus.Creation
{
    using Dungeon;
    using Dungeon.Control.Keys;
    using Dungeon.Drawing;
    using Dungeon.Drawing.SceneObjects;
    using Dungeon.Scenes;
    using Dungeon.Scenes.Manager;
    using Dungeon12.Scenes.Game;
    using System;

    public class PlayerSummaryScene : GameScene<Main,PlayerOriginScene>
    {
        public PlayerSummaryScene(SceneManager sceneManager) : base(sceneManager)
        {
        }

        public override bool Destroyable => true;

        public override void Init()
        {
            this.AddObject(new Prologue());
        }

        private class Prologue : ColoredRectangle
        {
            public override bool AbsolutePosition => true;

            public override bool CacheAvailable => false;

            public Prologue()
            {
                this.Width = 40;
                this.Height = 22.5;

                var txt = new DrawText("Предтечи", ConsoleColor.White).Triforce();
                txt.Size = 72;

                this.Opacity = 1;
                this.Color = ConsoleColor.Black;
                this.Fill = true;

                this.AddTextCenter(txt);

                var enter = this.AddTextCenter(new DrawText("(Нажмите Enter что бы продолжить)").Montserrat());
                enter.Top += 2;
            }
        }

        protected override void KeyPress(Key keyPressed, KeyModifiers keyModifiers, bool hold)
        {
            if (!hold)
            {
                this.Switch<Main>();
            }
        }
    }
}