using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main_HpBar : UI_Base
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
        float ratio = _stat.Hp / (float)_stat.MaxHp;
        SetHpRatio(ratio);
        Get<GameObject>((int)GameObjects.Text).GetComponent<Text>().text = $"{(int)_stat.Hp} / {_stat.MaxHp}";
    }

    public void SetHpRatio(float ratio)
    {
        gameObject.GetComponent<Slider>().value = ratio;
    }
}
