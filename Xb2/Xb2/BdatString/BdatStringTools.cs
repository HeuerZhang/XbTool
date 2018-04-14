﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xb2.Types;

namespace Xb2.BdatString
{
    public static class BdatStringTools
    {
        public static string GetEnhanceCaption(BdatStringValue value)
        {
            BdatStringItem item = value.Parent;
            BdatStringCollection tables = item.Table.Collection;

            int captionId = int.Parse(value.ValueString);
            string caption = tables["btl_enhance_cap"][captionId]?["name"].ValueString;
            if (caption == null) return null;

            var sb = new StringBuilder(caption);

            var tags = ParseTags(caption);

            foreach (var tag in tags.OrderByDescending(x => x.Start))
            {
                if (tag.SubType != "Enhance") continue;
                string replace = string.Empty;

                if (tag.Values.Count <= 0)
                {
                    int effectId = int.Parse(item["EnhanceEffect"].ValueString);
                    replace = tables["BTL_EnhanceEff"][effectId]["Param"].ValueString;
                }
                else if (tag.Values.TryGetValue("kind", out string field))
                {
                    replace = item[field].ValueString;
                }

                sb.Remove(tag.Start, tag.Length);
                sb.Insert(tag.Start, replace);
            }

            return sb.ToString();
        }

        public static string GetItemTable(int id)
        {
            if (id > 61000) return "ITM_EtherCrystal";
            if (id > 60000) return "ITM_HanaAssist";
            if (id > 59000) return "ITM_HanaNArtsSet";
            if (id > 58000) return "ITM_HanaArtsEnh";
            if (id > 57000) return "ITM_HanaAtr";
            if (id > 56000) return "ITM_HanaRole";
            if (id > 50000) return "ITM_BoosterList";
            if (id > 45000) return "ITM_CrystalList";
            if (id > 40000) return "ITM_FavoriteList";
            if (id > 35000) return "ITM_TresureList";
            if (id > 30000) return "ITM_CollectionList";
            if (id > 27000) return "ITM_EventList";
            if (id > 26000) return "ITM_InfoList";
            if (id > 25000) return "ITM_PreciousList";
            if (id > 20000) return "ITM_SalvageList";
            if (id > 17000) return "ITM_OrbEquip";
            if (id > 14000) return "ITM_Orb";
            if (id > 10000) return "ITM_PcWpnChip";
            if (id > 5000) return "ITM_PcWpn";
            return "ITM_PcEquip";
        }

        public static string GetEventTable(int id)
        {
            if (id > 60000) return "EVT_listDeb01";
            if (id > 40000) return "EVT_listTlk01";
            if (id > 30000) return "EVT_listFev01";
            if (id > 20000) return "EVT_listQst01";
            if (id > 19000) return "EVT_listBl";
            return "EVT_listBf";
        }

        public static string GetEventSetupTable(int id)
        {
            if (id > 60000) return "EVT_setupDeb01";
            if (id > 50000) return "EVT_setupTlk01";
            if (id > 40000) return "EVT_setupFev01";
            if (id > 30000) return "EVT_setupQst01";
            if (id > 29000) return "EVT_setupBf70";
            if (id > 20000) return "EVT_setupBf10";
            if (id > 19000) return "EVT_setupBf09";
            if (id > 18000) return "EVT_setupBf08";
            if (id > 17000) return "EVT_setupBf07";
            if (id > 16000) return "EVT_setupBf06";
            if (id > 15000) return "EVT_setupBf05";
            if (id > 14000) return "EVT_setupBf04";
            if (id > 13000) return "EVT_setupBf03";
            if (id > 12000) return "EVT_setupBf02";
            return "EVT_setupBf01";
        }

        public static string GetQuestListTable(int id)
        {
            if (id > 7000) return "FLD_QuestListAchievement";
            if (id > 6000) return "FLD_QuestListMercenaries";
            if (id > 5000) return "FLD_QuestListBlade";
            if (id > 2000) return "FLD_QuestListNormal";
            if (id > 1000) return "FLD_QuestListMini";
            return "FLD_QuestList";
        }

        public static string GetCharacterTable(int id)
        {
            if (id > 2000) return "RSC_NpcList";
            if (id > 1000) return "CHR_Bl";
            return "CHR_Dr";
        }

        public static string GetConditionTable(ConditionType conditionType)
        {
            switch (conditionType)
            {
                case ConditionType.Scenario:
                    return "FLD_ConditionScenario";
                case ConditionType.Quest:
                    return "FLD_ConditionQuest";
                case ConditionType.Environment:
                    return "FLD_ConditionEnv";
                case ConditionType.Flag:
                    return "FLD_ConditionFlag";
                case ConditionType.Item:
                    return "FLD_ConditionItem";
                case ConditionType.Party:
                    return "FLD_ConditionPT";
                case ConditionType.Idea:
                    return "FLD_ConditionIdea";
                case ConditionType.Level:
                    return "FLD_ConditionLevel";
                case ConditionType.Achievement:
                    return "FLD_ConditionAchievement";
                case ConditionType.FieldSkill:
                    return "FLD_ConditionFieldSkiiLevel";
            }

            return null;
        }

        public static string GetTaskTable(TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.Battle:
                    return "FLD_QuestBattle";
                case TaskType.T2:
                    break;
                case TaskType.Collect:
                    return "FLD_QuestCollect";
                case TaskType.UseItem:
                    return "FLD_QuestUse";
                case TaskType.ReachPlace:
                    return "FLD_QuestReach";
                case TaskType.Talk:
                    return "FLD_QuestTalk";
                case TaskType.T7:
                    break;
                case TaskType.Gimmick:
                    return "FLD_QuestGimmick";
                case TaskType.Mercenary:
                    break;
                case TaskType.QuestCondition:
                    return "FLD_QuestCondition";
                case TaskType.UseFieldSkill:
                    return "FLD_QuestFieldSkillCount";
                case TaskType.StatCount:
                    return "FLD_Achievement";
            }

            return null;
        }

        public static string GetShopTable(ShopType shopType)
        {
            switch (shopType)
            {
                case ShopType.Normal:
                    return "MNU_ShopNormal";
                case ShopType.Exchange:
                    return "MNU_ShopChange";
                case ShopType.Inn:
                    return "MNU_ShopInn";
            }

            return null;
        }

        public static string PrintEnumFlags(Type enumType, object value)
        {
            var sb = new StringBuilder();
            bool first = true;

            foreach (var flag in EnumExtensions.GetIndividualFlags(enumType, value))
            {
                if (!first) sb.Append(", ");
                sb.Append(flag);
                first = false;
            }

            return sb.ToString();
        }

        public static string PrintWeatherIdMap(int weather, int mapId, BdatStringCollection tables)
        {
            if (weather == 0xFF) return "All";

            var sb = new StringBuilder();
            bool first = true;

            Weather[] weathers = new Weather[4];
            BdatStringItem map = tables["FLD_maplist"][mapId];
            weathers[0] = (Weather)Enum.Parse(typeof(Weather), map["wa_type"].ValueString);
            weathers[1] = (Weather)Enum.Parse(typeof(Weather), map["wb_type"].ValueString);
            weathers[2] = (Weather)Enum.Parse(typeof(Weather), map["wc_type"].ValueString);
            weathers[3] = (Weather)Enum.Parse(typeof(Weather), map["wd_type"].ValueString);

            for (int i = 0; i < 4; i++)
            {
                if ((weather & (1 << i)) != 0)
                {
                    if (!first) sb.Append(", ");
                    sb.Append(weathers[i]);
                    first = false;
                }
            }

            return sb.ToString();
        }

        public static List<BdatTag> ParseTags(string text)
        {
            int pos = 0;
            var tags = new List<BdatTag>();

            while (true)
            {
                int start = text.IndexOf('[', pos);
                if (start == -1) break;

                if (start > 0 && text[start - 1] == '\\')
                {
                    pos = start + 1;
                    continue;
                }

                int end = text.IndexOf(']', start);
                int length = end - start + 1;
                pos = end + 1;

                var tagText = text.Substring(start + 1, length - 2).Trim(); // Leave out brackets
                var values = tagText.Split(' ');

                if (values.Length == 0) throw new InvalidDataException();

                var tagHead = values[0].Split(':');
                if (tagHead.Length != 2) throw new InvalidDataException();

                var tag = new BdatTag
                {
                    Type = tagHead[0],
                    SubType = tagHead[1],
                    Start = start,
                    Length = length
                };

                for (int i = 1; i < values.Length; i++)
                {
                    string[] keyVal = values[i].Split('=');
                    if (keyVal.Length != 2) throw new InvalidDataException();
                    tag.Values.Add(keyVal[0], keyVal[1]);
                }

                tags.Add(tag);
            }

            return tags;
        }
    }

    public class BdatTag
    {
        public string Type { get; set; }
        public string SubType { get; set; }
        public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
