using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, List<Data.Stat>> MonsterDict = new Dictionary<int, List<Data.Stat>>();
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
    public List<Data.Stat> RabbitStatList { get; private set; } = new List<Data.Stat>();
    public List<Data.Stat> WildBoarStatList { get; private set; } = new List<Data.Stat>();
    public List<Data.Stat> WolfStatList { get; private set; } = new List<Data.Stat>();
    public List<Data.Stat> CowStatList { get; private set; } = new List<Data.Stat>();

    public void Init()
    {
        // 플레이어 Dictionary
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();

        // 몬스터 Dictionary
        RabbitStatList = LoadJson<Data.StatData, int, Data.Stat>("RabbitStatData").MakeList();
        MonsterDict.Add(0, RabbitStatList);

        WildBoarStatList = LoadJson<Data.StatData, int, Data.Stat>("WildBoarStatData").MakeList();
        MonsterDict.Add(1, WildBoarStatList);

        WolfStatList = LoadJson<Data.StatData, int, Data.Stat>("WolfStatData").MakeList();
        MonsterDict.Add(2, WolfStatList);

        CowStatList = LoadJson<Data.StatData, int, Data.Stat>("CowStatData").MakeList();
        MonsterDict.Add(3, CowStatList);
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset testAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(testAsset.text);
    }
}
