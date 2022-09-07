using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : Stat
{
    Define.Monster _type;
    [SerializeField]
    int _key;
    [SerializeField]
    int _exp;

    void Start()
    {
        // Monster Type
        _type = SetMonsterType(gameObject.name);
        _key = 0;
        SetMonsterStat(_type, _key);
    }

    public Define.Monster SetMonsterType(string name)
    {
        if (name == "Rabbit")
            return Define.Monster.Rabbit;
        else if (name == "WildBoar")
            return Define.Monster.WildBoar;
        else if (name == "Wolf")
            return Define.Monster.Wolf;
        else
            return Define.Monster.Cow;
    }


    public void SetMonsterStat(Define.Monster type, int key)
    {
        Dictionary<int, List<Data.Stat>> monsterDict = Managers.Data.MonsterDict;
        List<Data.Stat> list = monsterDict[(int)type];
        Data.Stat stat = list[key];

        _level = stat.level;
        _hp = stat.maxHp;
        _maxHp = stat.maxHp;
        _attack = stat.attack;
        _moveSpeed = stat.moveSpeed;
        _defence = stat.defence;
        _exp = stat.exp;
    }

    protected override void OnDead(Stat attacker)
    {
        PlayerStat playerStat = attacker as PlayerStat;
        if (playerStat != null)
        {
            playerStat.Exp += _exp;

            if(_key < 3)
                _key++;
        }
        Managers.Game.Despawn(gameObject);
    }
}
