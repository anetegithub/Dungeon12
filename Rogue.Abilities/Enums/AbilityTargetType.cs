﻿namespace Rogue.Abilities.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum AbilityTargetType
    {
        [Display(Name = "Требуется цель")]
        Target=0,
        [Display(Name = "Цель не требуется")]
        NonTarget = 1,
        [Display(Name = "Требуется несколько целей")]
        TwoTargets =2,
        [Display(Name = "Цель может не требоваться")]
        TargetAndNonTarget = 3,
    }
}