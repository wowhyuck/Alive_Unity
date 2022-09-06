using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main_MpBar : UI_Base
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
        float ratio = _stat.Mp / (float)_stat.MaxMp;
        SetHpRatio(ratio);
        Get<GameObject>((int)GameObjects.Text).GetComponent<Text>().text = $"{(int)_stat.Mp} / {_stat.MaxMp}";
    }

    public void SetHpRatio(float ratio)
    {
        gameObject.GetComponent<Slider>().value = ratio;
    }
}
