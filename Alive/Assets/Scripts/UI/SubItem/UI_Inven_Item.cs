using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    enum GameObjects
    {
        Icon,
        Key,
        Number,
    }

    string _key;

    void Start()
    {
        Init();   
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.Key).GetComponent<Text>().text = _key;

        Get<GameObject>((int)GameObjects.Icon).BindEvent((PointerEventData) => { Debug.Log($"아이템 클릭!"); });
    }

    public void SetKey(string key)
    {
        _key = key;
    }
    
}
