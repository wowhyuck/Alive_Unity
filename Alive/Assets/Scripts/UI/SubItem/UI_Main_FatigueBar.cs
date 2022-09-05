using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main_FatigueBar : UI_Base
{
    enum GameObjects
    {
        Text
    }

    GameObject _player;
    PlayerStat _stat;

    public override void Init()
    {
        PlayerController obj = FindObjectOfType<PlayerController>();
        _player = obj.gameObject;
        _stat = _player.GetComponent<PlayerStat>();
        Bind<GameObject>(typeof(GameObjects));
    }

    private void Update()
    {
        float ratio = _stat.CurrentFatigue / (float)_stat.MaxFatigue;
        SetHpRatio(ratio);
        Get<GameObject>((int)GameObjects.Text).GetComponent<Text>().text = $"{_stat.CurrentFatigue} / {_stat.MaxFatigue}";
    }

    public void SetHpRatio(float ratio)
    {
        gameObject.GetComponent<Slider>().value = ratio;
    }
}
