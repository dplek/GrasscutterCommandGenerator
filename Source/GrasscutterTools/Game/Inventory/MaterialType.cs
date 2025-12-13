
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

using System.Collections.Generic;
using System.Globalization;

namespace GrasscutterTools.Game.Inventory
{
    internal static class MaterialType
    {
        private static readonly Dictionary<string, string> TextMapCHS = new()
        {
            ["MATERIAL_NONE"] = "空",
            ["MATERIAL_FOOD"] = "食物",
            ["MATERIAL_QUEST"] = "任务",
            ["MATERIAL_EXCHANGE"] = "收集物",
            ["MATERIAL_CONSUME"] = "消耗品",
            ["MATERIAL_EXP_FRUIT"] = "经验书",
            ["MATERIAL_AVATAR"] = "角色",
            ["MATERIAL_ADSORBATE"] = "能量球",
            ["MATERIAL_CRICKET"] = "蛐蛐",
            ["MATERIAL_ELEM_CRYSTAL"] = "神瞳",
            ["MATERIAL_WEAPON_EXP_STONE"] = "武器锻造矿",
            ["MATERIAL_CHEST"] = "宝箱",
            ["MATERIAL_RELIQUARY_MATERIAL"] = "圣遗物经验瓶",
            ["MATERIAL_AVATAR_MATERIAL"] = "角色天赋材料",
            ["MATERIAL_NOTICE_ADD_HP"] = "回血食物",
            ["MATERIAL_SEA_LAMP"] = "海灯节",
            ["MATERIAL_SELECTABLE_CHEST"] = "自选礼包",
            ["MATERIAL_FLYCLOAK"] = "风之翼",
            ["MATERIAL_NAMECARD"] = "名片卡",
            ["MATERIAL_TALENT"] = "天赋材料",
            ["MATERIAL_WIDGET"] = "装饰物",
            ["MATERIAL_CHEST_BATCH_USE"] = "礼包",
            ["MATERIAL_FAKE_ABSORBATE"] = "MATERIAL_FAKE_ABSORBATE",
            ["MATERIAL_CONSUME_BATCH_USE"] = "树脂",
            ["MATERIAL_WOOD"] = "树木",
            ["MATERIAL_FURNITURE_FORMULA"] = "尘歌壶室内摆设",
            ["MATERIAL_CHANNELLER_SLAB_BUFF"] = "增益Buff",
            ["MATERIAL_FURNITURE_SUITE_FORMULA"] = "尘歌壶摆设套装",
            ["MATERIAL_COSTUME"] = "皮肤",
            ["MATERIAL_HOME_SEED"] = "种子",
            ["MATERIAL_FISH_BAIT"] = "鱼饵",
            ["MATERIAL_FISH_ROD"] = "鱼竿",
            ["MATERIAL_SUMO_BUFF"] = "MATERIAL_SUMO_BUFF",
            ["MATERIAL_FIREWORKS"] = "烟花",
            ["MATERIAL_BGM"] = "旋曜玉帛",
            ["MATERIAL_SPICE_FOOD"] = "香气四溢的食物",
            ["MATERIAL_ACTIVITY_ROBOT"] = "活动-兑换券",
            ["MATERIAL_ACTIVITY_GEAR"] = "活动-齿轮",
            ["MATERIAL_ACTIVITY_JIGSAW"] = "活动-部件",
            ["MATERIAL_ARANARA"] = "兰纳罗",
            ["MATERIAL_GCG_CARD"] = "七圣召唤-卡片",
            ["MATERIAL_GCG_CARD_FACE"] = "七圣召唤-卡片-正面",
            ["MATERIAL_GCG_CARD_BACK"] = "七圣召唤-卡片-背面",
            ["MATERIAL_GCG_FIELD"] = "七圣召唤-卡片-场地",
            ["MATERIAL_DESHRET_MANUAL"] = "沙漠书",
            ["MATERIAL_RENAME_ITEM"] = "改名卡",
            ["MATERIAL_GCG_EXCHANGE_ITEM"] = "七圣召唤-特殊卡",
            ["MATERIAL_QUEST_EVENT_BOOK"] = "案件记录册",
            ["MATERIAL_PROFILE_PICTURE"] = "头像道具",
            ["MATERIAL_RAINBOW_PRINCE_HAND_BOOK"] = "特尔克西的奇幻历险",
            ["MATERIAL_PHOTO_DISPLAY_BOOK"] = "纪念册",
            ["MATERIAL_REMUS_MUSIC_BOX"] = "音乐盒",
            ["MATERIAL_GREATEFESTIVALV2_INVITE"] = "邀请函",
            ["MATERIAL_PHOTOGRAPH_POSE"] = "照相姿势",
            ["MATERIAL_FIRE_MASTER_AVATAR_TALENT_ITEM"] = "燧原矿",
            ["MATERIAL_PHOTOV5_HAND_BOOK"] = "回忆相册",
            ["MATERIAL_AVATAR_TRACE"] = "游迹",
            ["MATERIAL_CHEST_BATCH_USE_WITH_GROUP"] = "分享包",
            ["MATERIAL_NATLAN_RELATION_A"] = "圣夜旅织A",
            ["MATERIAL_NATLAN_RELATION_B"] = "圣夜旅织B",
            ["MATERIAL_LANV5_PAIMON_GREETING_CARD"] = "祝柬",
            ["MATERIAL_NATLAN_RACE_ALBUM"] = "砥砺之证",
            ["MATERIAL_NATLAN_RACE_ENVELOPE"] = "纪念信件",
            ["MATERIAL_MUSIC_GAME_BOOK_THEME"] = "音乐游戏书主题",
            ["MATERIAL_MIKAWA_FLOWER_INVITE"] = "神子邀请函",
            ["MATERIAL_QUEST_ALBUM"] = "任务相册",
            ["MATERIAL_HOLIDAY_MEMORY_BOOK"] = "悠悠纪念册",
            ["MATERIAL_HOLIDAY_RESORT_INVITE"] = "悠悠度假村邀请函",
            ["MATERIAL_PHOTOV6_HAND_BOOK"] = "提瓦特影册",
            ["MATERIAL_WEAPON_SKIN"] = "武器皮肤",
        };

        public static string ToTranslatedString(string materialType, string language)
        {
            if (language.StartsWith("zh") && TextMapCHS.TryGetValue(materialType, out var text))
                return text;
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                materialType.Substring("MATERIAL_".Length)
                    .Replace('_', ' ')
                    .ToLower());
        }
    }
}
