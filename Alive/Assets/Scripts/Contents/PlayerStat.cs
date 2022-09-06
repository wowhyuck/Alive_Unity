using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField]
    protected float _mp;
    [SerializeField]
    protected float _maxMp;

    [SerializeField]
    protected int _exp;
    [SerializeField]
    protected int _gold;
    [SerializeField]
    protected int _currentFatigue;
    [SerializeField]
    protected int _maxFatigue;

    public int Exp 
    { 
        get { return _exp; } 
        set 
        { 
            _exp = value;

            // 레벨업 체크
            int level = Level;
            while(true)
            {
                Data.Stat stat;
                if (Managers.Data.StatDict.TryGetValue(level + 1, out stat) == false)
                    break;
                if (_exp < stat.totalExp)
                    break;
                level++;
            }

            if(level != Level)
            {
                Debug.Log("Level Up");
                Level = level;
                SetStat(Level);
            }
        } 
    }

    public float Mp { get { return _mp; } set { _mp = value; } }
    public float MaxMp { get { return _maxMp; } set { _maxMp = value; } }

    public int Gold { get { return _gold; } set { _gold = value; } }
    public int CurrentFatigue { get { return _currentFatigue; } set { _currentFatigue = value; } }
    public int MaxFatigue { get { return _maxFatigue; } set { _maxFatigue = value; } }

    // TODO : 나중에 데이터 시트로 옮기기
    private void Start()
    {
        _level = 1;
        _exp = 0;
        _gold = 0;
        _currentFatigue = 0;
        _maxFatigue = 100;

        SetStat(_level);
    }

    public void SetStat(int level)
    {
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        Data.Stat stat = dict[level];

        _hp = stat.maxHp;
        _maxHp = stat.maxHp;
        _mp = stat.maxMp;
        _maxMp = stat.maxMp;
        _attack = stat.attack;
        _moveSpeed = stat.moveSpeed;
        _defence = stat.defence;
    }

    protected override void OnDead(Stat attackder)
    {
        Debug.Log("Player Dead");
    }
}
