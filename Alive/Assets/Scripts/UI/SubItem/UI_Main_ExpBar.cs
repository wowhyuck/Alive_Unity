using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main_ExpBar : UI_Base
{
    GameObject _player;
    PlayerStat _stat;
    int currentExp;
    int nextExp;

    public override void Init()
    {
        PlayerController obj = FindObjectOfType<PlayerController>();
        _player = obj.gameObject;
        _stat = _player.GetComponent<PlayerStat>();
    }

    private void Update()
    {
        currentExp = _stat.Exp;
        nextExp = 0;
        Data.Stat nextStat;

        // 만렙일 때
        if (Managers.Data.StatDict.TryGetValue(_stat.Level + 1, out nextStat) == false)
        {
            SetExpRatio(1);
            return;
        }
        // 현재 경험치 / 레벨업 도달 경험치
        else
        {
            currentExp = _stat.Exp - Managers.Data.StatDict[_stat.Level].totalExp;
            nextExp = Managers.Data.StatDict[_stat.Level + 1].totalExp - Managers.Data.StatDict[_stat.Level].totalExp;
            float ratio = currentExp / (float)nextExp;
            SetExpRatio(ratio);
        }
    }

    public void SetExpRatio(float ratio)
    {
        gameObject.GetComponent<Slider>().value = ratio;
    }
}