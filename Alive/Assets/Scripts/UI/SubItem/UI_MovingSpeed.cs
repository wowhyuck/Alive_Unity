using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MovingSpeed : UI_Base
{
    public enum GameObjects
    {
        UI_Stat,
        UI_Inven_Item,
        UI_Image
    }

    GameObject _player;
    Stat _stat;

    public override void Init()
    {
        PlayerController obj = FindObjectOfType<PlayerController>();
        _player = obj.gameObject;
        _stat = _player.GetComponent<PlayerStat>();
        Bind<GameObject>(typeof(GameObjects));
    }

    void Update()
    {
        Get<GameObject>((int)GameObjects.UI_Stat).GetComponent<Text>().text = $"{_stat.MoveSpeed}";
    }
}
