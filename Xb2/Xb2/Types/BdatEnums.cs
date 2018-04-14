﻿// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

using System;

namespace Xb2.Types
{
    public enum ConditionType
    {
        Scenario = 1,
        Quest,
        Environment,
        Flag,
        Item,
        Party,
        Idea,
        Level,
        Achievement,
        FieldSkill
    }

    public enum PartyConditionType
    {
        InParty = 0, // In total party, not in merc
        InActiveParty, // In active party of 5
        IsLeader,
        BattleParty, // In battle party of 3
        IsMercTeamLeader,
        InPartyOrMerc,
        DriverInParty,
        IsReleased,
        T8
    }

    public enum BladeActiveType
    {
        ActivateUnuse,
        ActivateParty,
        ActivateMercenaryTeam
    }

    public enum TaskType
    {
        Battle = 1,
        T2,
        Collect,
        UseItem,
        ReachPlace,
        Talk,
        T7,
        Gimmick,
        Mercenary,
        QuestCondition,
        UseFieldSkill,
        StatCount
    }

    public enum IdeaCategory
    {
        Bravery,
        Truth,
        Compassion,
        Justice
    }

    [Flags]
    public enum IdeaCategoryBits
    {
        Bravery = 1 << 0,
        Truth = 1 << 1,
        Compassion = 1 << 2,
        Justice = 1 << 3
    }

    [Flags]
    public enum FieldSkillCategory
    {
        Collection = 1 << 0,
        Elemental = 1 << 1,
        Mercenary = 1 << 2,
        Rare = 1 << 3
    }

    public enum ButtonType
    {
        A = 1,
        B,
        X,
        Y,
        Random
    }

    public enum LandmarkType
    {
        Landmark,
        SecretArea,
        Location
    }

    public enum ShopType
    {
        Normal,
        Exchange,
        Inn,
        AuxCore
    }

    public enum ItemType
    {
        PcWpnChip = 1,
        PcEquip = 2,
        EquipOrb = 3,
        PcWpn = 4,
        Salvage = 5,
        Precious = 6,
        CollectionList = 7,
        Tresure = 8,
        EmptyOrb = 9,
        Favorite = 10,
        CrystalList = 11,
        Booster = 12,
        HealPot = 13,
        Info = 14,
        Event = 15,
        HanaRole = 16,
        HanaAtr = 17,
        HanaArtsEnh = 18,
        HanaNArtsSet = 19,
        HanaAssist = 20
    }

    public enum Weather
    {
        Overcast = 1,
        Lightning,
        Rain,
        Thunderstorm,
        Storm,
        Fog,
        Snow,
        Sandstorm,
        CrystalSquall,
        SurfaceHeat,
        NightIncense,
        Overcast2,
        Aurora,
        CloudSeaMist
    }

    [Flags]
    public enum WeatherBits
    {
        Overcast = 1 << 0,
        Lightning = 1 << 1,
        Rain = 1 << 2,
        Thunderstorm = 1 << 3,
        Storm = 1 << 4,
        Fog = 1 << 5,
        Snow = 1 << 6,
        Sandstorm = 1 << 7,
        CrystalSquall = 1 << 8,
        SurfaceHeat = 1 << 9,
        NightIncense = 1 << 10,
        Overcast2 = 1 << 11,
        Aurora = 1 << 12,
        CloudSeaMist = 1 << 13
    }

    [Flags]
    public enum TimeRange
    {
        Morning = 1 << 0,
        Noontime = 1 << 1,
        Afternoon = 1 << 2,
        Evening = 1 << 3,
        LateNight = 1 << 4,
        Dawn = 1 << 5,
        Daytime = 1 << 6,
        Nighttime = 1 << 7,
        Any = 1 << 8,
        Evening_ = 1 << 15,
    }

    public enum RecipeType
    {
        Rarity,
        Category,
        Specific
    }

    public enum ArtType
    {
        Physical = 1,
        Ether,
        Recovery,
        Type4,
        Type5,
        Type6,
        Type7,
        Summon,
        Reinforcements,
        Type10,
        Defensive = 11,
        Type12
    }

    public enum ArtRangeType
    {
        OneTarget = 0,
        CircleBullet = 1,
        Ahead = 2,
        CircleUser = 5
    }

    public enum ChangeType
    {
        scenario = 1,
        quest_entry,
        quest_comp,
        Change4,
        Change5,
        town8,
        Change7,
        Change8,
        town4,
        Change10,
        Change11,
        town1,
        Change13,
        sys8,
        Change15,
        Change16,
        sys4,
        Change18,
        Change19,
        sys1,
        Change21,
        hanyou,
        Change23,
        Change24,
        kizuna,
        Change26,
        Change27,
        meet,
        system_msg,
        quest_entry_disp,
        quest_result_disp,
        next_event,
        cancel,
        hide_npc,
        Change35,
        hide_npc_route,
        Change37,
        hide_mapobj,
        Change39,
        hide_eff_lv,
        Change41,
        hide_se,
        Change43,
        hide_lod,
        Change45,
        anim_lod,
        Change47,
        Change48,
        reward_item,
        parts_off,
        Change51,
        parts_on,
        Change53,
        money,
        trustpoint,
        Change56,
        mercenaries,
        mercenaries_fin,
        ext_param,
        Change60,
        Change61,
        field_env,
        wpn_parts_off,
        Change64,
        wpn_parts_on,
        Change66,
        rinne_gold
    }
}
