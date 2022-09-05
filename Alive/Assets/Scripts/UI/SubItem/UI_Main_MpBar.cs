using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main_MpBar : UI_Base
{
    GameObject _player;
    PlayerStat _stat;

    public override void Init()
    {
        PlayerController obj = FindObjectOfType<PlayerController>();
        _player = obj.gameObject;
        _stat = _player.GetComponent<PlayerStat>();
    }

    private void Update()
    {
        float ratio = _stat.Mp / (float)_stat.MaxMp;
        SetHpRatio(ratio);
    }

    public void SetHpRatio(float ratio)
    {
        gameObject.GetComponent<Slider>().value = ratio;
    }
}
