using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    public enum ResourceType { Sprites, CardsData, MapPath }
    public static ResourceType CurrentLoadingResourceType;
    public static Dictionary<ResourceType, string> PathDictionary;
    public static Dictionary<string, Sprite> SpriteDictionary;
    public static Dictionary<string, Card> CardDictionary;

    public static string ResourceTypeToKey(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Sprites: return "Sprites";
            case ResourceType.CardsData: return "CardsData";
            case ResourceType.MapPath: return "MapPath";
            default: return "MapPath";
        }
    }
    public static ResourceType KeyToResourceType(string resourceKey)
    {
        switch (resourceKey)
        {
            case "Sprites": return ResourceType.Sprites;
            case "CardsData": return ResourceType.CardsData;
            case "MapPath": return ResourceType.MapPath;
            default: return ResourceType.MapPath;
        }
    }
    public static string ResourceTypeToName(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Sprites: return "Sprite图片";
            case ResourceType.CardsData: return "卡片数据";
            case ResourceType.MapPath: return "资源路径";
            default: return "资源路径";
        }
    }
    public static void LoadResources()
    {
        LoadPathMap();
        LoadSprites();
        LoadCardData();
    }
    public static void LoadPathMap()
    {
        CurrentLoadingResourceType = ResourceType.MapPath;
        PathDictionary = new Dictionary<ResourceType, string>();
        JObject PathMap = JsonLoader.LoadJsonFile<JObject>("/Resources/Map/PathMap.json");
        foreach (var prop in PathMap.Properties())
        {
            PathDictionary.Add(KeyToResourceType(prop.Name), (string)prop.Value);
        }
    }
    public static void LoadSprites()
    {
        CurrentLoadingResourceType = ResourceType.Sprites;
        SpriteDictionary = new Dictionary<string, Sprite>();
        JObject SpritesPath = JsonLoader.LoadJsonFile<JObject>(PathDictionary[ResourceType.Sprites]);
        foreach (var prop in SpritesPath.Properties())
        {
            Sprite sprite = ImageLoader.LoadSprite((string)prop.Value);
            SpriteDictionary.Add(prop.Name, sprite);
        }
    }
    public static void LoadCardData()
    {
        CurrentLoadingResourceType = ResourceType.CardsData;
        CardDictionary = new Dictionary<string, Card>();
        JObject cardsData = JsonLoader.LoadJsonFile<JObject>(PathDictionary[ResourceType.CardsData]);
        foreach (var prop in cardsData.Properties())
        {
            Card card = prop.Value.ToObject<Card>();
            CardDictionary.Add(prop.Name, card);
        }
    }
}
