using Newtonsoft.Json;
using potg.RiotGames.Types;

namespace potg.Data.Converters;

public class EventTypeConverter : JsonConverter<EventType>
{
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, EventType value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override EventType ReadJson(JsonReader reader, Type objectType, EventType existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return EventType.Unkown;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "BUILDING_KILL":
                return EventType.BuildingKill;
            case "CHAMPION_KILL":
                return EventType.ChampionKill;
            case "CHAMPION_SPECIAL_KILL":
                return EventType.ChampionSpecialKill;
            case "ELITE_MONSTER_KILL":
                return EventType.EliteMonsterKill;
            case "GAME_END":
                return EventType.GameEnd;
            case "ITEM_DESTROYED":
                return EventType.ItemDestroyed;
            case "ITEM_PURCHASED":
                return EventType.ItemPurchased;
            case "ITEM_SOLD":
                return EventType.ItemSold;
            case "ITEM_UNDO":
                return EventType.ItemUndo;
            case "LEVEL_UP":
                return EventType.LevelUp;
            case "OBJECTIVE_BOUNTY_PRESTART":
                return EventType.ObjectiveBountyPreStart;
            case "OBJECTIVE_BOUNTY_FINISH":
                return EventType.ObjectiveBountyFinish;
            case "PAUSE_END":
                return EventType.PauseEnd;
            case "SKILL_LEVEL_UP":
                return EventType.SkillLevelUp;
            case "TURRET_PLATE_DESTROYED":
                return EventType.TurretPlateDestroyed;
            case "WARD_KILL":
                return EventType.WardKill;
            case "WARD_PLACED":
                return EventType.WardPlaced;
            case "CHAMPION_TRANSFORM":
                return EventType.ChampionTransform;
            case "DRAGON_SOUL_GIVEN":
                return EventType.DragonSoulGiven;
            default:
                throw new Exception($"Cannot unmarshal type EventType: {value}");
        }
    }
}