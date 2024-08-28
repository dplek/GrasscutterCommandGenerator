﻿
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

using System.Collections.Generic;

namespace GrasscutterTools.Game.Inventory
{
    /// <summary>
    /// 材料类型
    /// </summary>
    internal enum MaterialType
    {
        MATERIAL_NONE = 0,
        MATERIAL_FOOD = 1,
        MATERIAL_QUEST = 2,
        MATERIAL_EXCHANGE = 4,
        MATERIAL_CONSUME = 5,
        MATERIAL_EXP_FRUIT = 6,
        MATERIAL_AVATAR = 7,
        MATERIAL_ADSORBATE = 8,
        MATERIAL_CRICKET = 9,
        MATERIAL_ELEM_CRYSTAL = 10,
        MATERIAL_WEAPON_EXP_STONE = 11,
        MATERIAL_CHEST = 12,
        MATERIAL_RELIQUARY_MATERIAL = 13,
        MATERIAL_AVATAR_MATERIAL = 14,
        MATERIAL_NOTICE_ADD_HP = 15,
        MATERIAL_SEA_LAMP = 16,
        MATERIAL_SELECTABLE_CHEST = 17,
        MATERIAL_FLYCLOAK = 18,
        MATERIAL_NAMECARD = 19,
        MATERIAL_TALENT = 20,
        MATERIAL_WIDGET = 21,
        MATERIAL_CHEST_BATCH_USE = 22,
        MATERIAL_FAKE_ABSORBATE = 23,
        MATERIAL_CONSUME_BATCH_USE = 24,
        MATERIAL_WOOD = 25,
        MATERIAL_FURNITURE_FORMULA = 27,
        MATERIAL_CHANNELLER_SLAB_BUFF = 28,
        MATERIAL_FURNITURE_SUITE_FORMULA = 29,
        MATERIAL_COSTUME = 30,
        MATERIAL_HOME_SEED = 31,
        MATERIAL_FISH_BAIT = 32,
        MATERIAL_FISH_ROD = 33,
        MATERIAL_SUMO_BUFF = 34, // sumo 活动道具，never appear
        MATERIAL_FIREWORKS = 35,
        MATERIAL_BGM = 36,
        MATERIAL_SPICE_FOOD = 37,
        MATERIAL_ACTIVITY_ROBOT = 38,
        MATERIAL_ACTIVITY_GEAR = 39,
        MATERIAL_ACTIVITY_JIGSAW = 40,
        MATERIAL_ARANARA = 41,
        MATERIAL_GCG_CARD = 42,
        MATERIAL_GCG_CARD_FACE = 43, // 影幻卡面
        MATERIAL_GCG_CARD_BACK = 44,
        MATERIAL_GCG_FIELD = 45,
        MATERIAL_DESHRET_MANUAL = 46,
        MATERIAL_RENAME_ITEM = 47,
        MATERIAL_GCG_EXCHANGE_ITEM = 48,
        MATERIAL_QUEST_EVENT_BOOK = 49,
        MATERIAL_PROFILE_PICTURE = 50,
        MATERIAL_RAINBOW_PRINCE_HAND_BOOK = 51,
        MATERIAL_PHOTO_DISPLAY_BOOK = 52,
        MATERIAL_REMUS_MUSIC_BOX = 53,
        MATERIAL_GREATEFESTIVALV2_INVITE = 54,
        MATERIAL_PHOTOGRAPH_POSE = 55,
        MATERIAL_FIRE_MASTER_AVATAR_TALENT_ITEM = 56,
        MATERIAL_PHOTOV5_HAND_BOOK = 57,
        MATERIAL_AVATAR_TRACE = 58,
    }

    internal static class MaterialTypeExtension
    {
        private static readonly Dictionary<MaterialType, string> TextMapCHS = new Dictionary<MaterialType, string>
        {
            [MaterialType.MATERIAL_NONE] = "空",
            [MaterialType.MATERIAL_FOOD] = "食物",
            [MaterialType.MATERIAL_QUEST] = "任务",
            [MaterialType.MATERIAL_EXCHANGE] = "收集物",
            [MaterialType.MATERIAL_CONSUME] = "消耗品",
            [MaterialType.MATERIAL_EXP_FRUIT] = "经验书",
            [MaterialType.MATERIAL_AVATAR] = "角色",
            [MaterialType.MATERIAL_ADSORBATE] = "能量球",
            [MaterialType.MATERIAL_CRICKET] = "蛐蛐",
            [MaterialType.MATERIAL_ELEM_CRYSTAL] = "神瞳",
            [MaterialType.MATERIAL_WEAPON_EXP_STONE] = "武器锻造矿",
            [MaterialType.MATERIAL_CHEST] = "宝箱",
            [MaterialType.MATERIAL_RELIQUARY_MATERIAL] = "圣遗物经验瓶",
            [MaterialType.MATERIAL_AVATAR_MATERIAL] = "角色天赋材料",
            [MaterialType.MATERIAL_NOTICE_ADD_HP] = "回血食物",
            [MaterialType.MATERIAL_SEA_LAMP] = "海灯节",
            [MaterialType.MATERIAL_SELECTABLE_CHEST] = "自选礼包",
            [MaterialType.MATERIAL_FLYCLOAK] = "风之翼",
            [MaterialType.MATERIAL_NAMECARD] = "名片卡",
            [MaterialType.MATERIAL_TALENT] = "天赋材料",
            [MaterialType.MATERIAL_WIDGET] = "装饰物",
            [MaterialType.MATERIAL_CHEST_BATCH_USE] = "礼包",
            [MaterialType.MATERIAL_FAKE_ABSORBATE] = "MATERIAL_FAKE_ABSORBATE",
            [MaterialType.MATERIAL_CONSUME_BATCH_USE] = "树脂",
            [MaterialType.MATERIAL_WOOD] = "树木",
            [MaterialType.MATERIAL_FURNITURE_FORMULA] = "尘歌壶室内摆设",
            [MaterialType.MATERIAL_CHANNELLER_SLAB_BUFF] = "增益Buff",
            [MaterialType.MATERIAL_FURNITURE_SUITE_FORMULA] = "尘歌壶摆设套装",
            [MaterialType.MATERIAL_COSTUME] = "皮肤",
            [MaterialType.MATERIAL_HOME_SEED] = "种子",
            [MaterialType.MATERIAL_FISH_BAIT] = "鱼饵",
            [MaterialType.MATERIAL_FISH_ROD] = "鱼竿",
            [MaterialType.MATERIAL_SUMO_BUFF] = "MATERIAL_SUMO_BUFF",
            [MaterialType.MATERIAL_FIREWORKS] = "烟花",
            [MaterialType.MATERIAL_BGM] = "旋曜玉帛",
            [MaterialType.MATERIAL_SPICE_FOOD] = "香气四溢的食物",
            [MaterialType.MATERIAL_ACTIVITY_ROBOT] = "活动-兑换券",
            [MaterialType.MATERIAL_ACTIVITY_GEAR] = "活动-齿轮",
            [MaterialType.MATERIAL_ACTIVITY_JIGSAW] = "活动-部件",
            [MaterialType.MATERIAL_ARANARA] = "兰纳罗",
            [MaterialType.MATERIAL_GCG_CARD] = "七圣召唤-卡片",
            [MaterialType.MATERIAL_GCG_CARD_FACE] = "七圣召唤-卡片-正面",
            [MaterialType.MATERIAL_GCG_CARD_BACK] = "七圣召唤-卡片-背面",
            [MaterialType.MATERIAL_GCG_FIELD] = "七圣召唤-卡片-场地",
            [MaterialType.MATERIAL_DESHRET_MANUAL] = "沙漠书",
            [MaterialType.MATERIAL_RENAME_ITEM] = "改名卡",
            [MaterialType.MATERIAL_GCG_EXCHANGE_ITEM] = "七圣召唤-特殊卡",
            [MaterialType.MATERIAL_QUEST_EVENT_BOOK] = "案件记录册",
            [MaterialType.MATERIAL_PROFILE_PICTURE] = "头像道具",
            [MaterialType.MATERIAL_RAINBOW_PRINCE_HAND_BOOK] = "特尔克西的奇幻历险",
            [MaterialType.MATERIAL_PHOTO_DISPLAY_BOOK] = "纪念册",
            [MaterialType.MATERIAL_REMUS_MUSIC_BOX] = "音乐盒",
            [MaterialType.MATERIAL_GREATEFESTIVALV2_INVITE] = "邀请函",
            [MaterialType.MATERIAL_PHOTOGRAPH_POSE] = "照相姿势",
            [MaterialType.MATERIAL_FIRE_MASTER_AVATAR_TALENT_ITEM] = "燧原矿",
            [MaterialType.MATERIAL_PHOTOV5_HAND_BOOK] = "回忆相册",
            [MaterialType.MATERIAL_AVATAR_TRACE] = "游迹",
        };
        private static readonly Dictionary<MaterialType, string> TextMapEN = new Dictionary<MaterialType, string>
        {
            [MaterialType.MATERIAL_NONE]                    = "None",
            [MaterialType.MATERIAL_FOOD]                    = "Food",
            [MaterialType.MATERIAL_QUEST]                   = "Quest",
            [MaterialType.MATERIAL_EXCHANGE]                = "Exchange",
            [MaterialType.MATERIAL_CONSUME]                 = "Consume",
            [MaterialType.MATERIAL_EXP_FRUIT]               = "Exp_fruit",
            [MaterialType.MATERIAL_AVATAR]                  = "Avatar",
            [MaterialType.MATERIAL_ADSORBATE]               = "Adsorbate",
            [MaterialType.MATERIAL_CRICKET]                 = "Cricket",
            [MaterialType.MATERIAL_ELEM_CRYSTAL]            = "Elem_crystal",
            [MaterialType.MATERIAL_WEAPON_EXP_STONE]        = "Weapon_exp_stone",
            [MaterialType.MATERIAL_CHEST]                   = "Chest",
            [MaterialType.MATERIAL_RELIQUARY_MATERIAL]      = "Reliquary_material",
            [MaterialType.MATERIAL_AVATAR_MATERIAL]         = "Avatar_material",
            [MaterialType.MATERIAL_NOTICE_ADD_HP]           = "Notice_add_hp",
            [MaterialType.MATERIAL_SEA_LAMP]                = "Sea_lamp",
            [MaterialType.MATERIAL_SELECTABLE_CHEST]        = "Selectable_chest",
            [MaterialType.MATERIAL_FLYCLOAK]                = "Flycloak",
            [MaterialType.MATERIAL_NAMECARD]                = "Namecard",
            [MaterialType.MATERIAL_TALENT]                  = "Talent",
            [MaterialType.MATERIAL_WIDGET]                  = "Widget",
            [MaterialType.MATERIAL_CHEST_BATCH_USE]         = "Chest_batch_use",
            [MaterialType.MATERIAL_FAKE_ABSORBATE]          = "Fake_absorbate",
            [MaterialType.MATERIAL_CONSUME_BATCH_USE]       = "Consume_batch_use",
            [MaterialType.MATERIAL_WOOD]                    = "Wood",
            [MaterialType.MATERIAL_FURNITURE_FORMULA]       = "Furniture_formula",
            [MaterialType.MATERIAL_CHANNELLER_SLAB_BUFF]    = "Channeller_slab_buff",
            [MaterialType.MATERIAL_FURNITURE_SUITE_FORMULA] = "Furniture_suite_formula",
            [MaterialType.MATERIAL_COSTUME]                 = "Costume",
            [MaterialType.MATERIAL_HOME_SEED]               = "Home_seed",
            [MaterialType.MATERIAL_FISH_BAIT]               = "Fish_bait",
            [MaterialType.MATERIAL_FISH_ROD]                = "Fish_rod",
            [MaterialType.MATERIAL_SUMO_BUFF]               = "Sumo_buff",
            [MaterialType.MATERIAL_FIREWORKS]               = "Fireworks",
            [MaterialType.MATERIAL_BGM]                     = "Bgm",
            [MaterialType.MATERIAL_SPICE_FOOD]              = "Spice_food",
            [MaterialType.MATERIAL_ACTIVITY_ROBOT]          = "Activity_robot",
            [MaterialType.MATERIAL_ACTIVITY_GEAR]           = "Activity_gear",
            [MaterialType.MATERIAL_ACTIVITY_JIGSAW]         = "Activity_jigsaw",
            [MaterialType.MATERIAL_ARANARA]                 = "Aranara",
            [MaterialType.MATERIAL_GCG_CARD]                = "Gcg_card",
            [MaterialType.MATERIAL_GCG_CARD_FACE]           = "Gcg_card_face",
            [MaterialType.MATERIAL_GCG_CARD_BACK]           = "Gcg_card_back",
            [MaterialType.MATERIAL_GCG_FIELD]               = "Gcg_field",
            [MaterialType.MATERIAL_DESHRET_MANUAL]          = "Deshret_manual",
            [MaterialType.MATERIAL_RENAME_ITEM]             = "Rename_item",
            [MaterialType.MATERIAL_GCG_EXCHANGE_ITEM]       = "Gcg_exchange_item",
            [MaterialType.MATERIAL_QUEST_EVENT_BOOK]        = "Quest_event_book",
            [MaterialType.MATERIAL_PROFILE_PICTURE]         = "Profile_picture",
            [MaterialType.MATERIAL_RAINBOW_PRINCE_HAND_BOOK] = "Thelxie's Fantastic Adventures",
            [MaterialType.MATERIAL_PHOTO_DISPLAY_BOOK]      = "Album",
            [MaterialType.MATERIAL_REMUS_MUSIC_BOX]         = "MusicBox",
            [MaterialType.MATERIAL_GREATEFESTIVALV2_INVITE] = "Invitation",
            [MaterialType.MATERIAL_PHOTOGRAPH_POSE]         = "Photograph_pose",
            [MaterialType.MATERIAL_FIRE_MASTER_AVATAR_TALENT_ITEM] = "Fire_master_avatar_talent_item",
            [MaterialType.MATERIAL_PHOTOV5_HAND_BOOK] = "Photov5_hand_book",
            [MaterialType.MATERIAL_AVATAR_TRACE] = "Avatar_trace",
        };

        public static string ToTranslatedString(this MaterialType materialType, string language)
        {
            if (!TextMapCHS.ContainsKey(materialType))
                return materialType.ToString();
            return language.StartsWith("zh") ? TextMapCHS[materialType] : TextMapEN[materialType];
        }
    }
}
