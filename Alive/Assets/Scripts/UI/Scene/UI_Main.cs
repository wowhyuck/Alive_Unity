using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : UI_Scene
{
    enum GameObjects
    {
        UI_Inven,
        UI_Bar
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        // UI_Inven
        GameObject inven = Get<GameObject>((int)GameObjects.UI_Inven);
        foreach (Transform child in inven.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 실제 인벤토리 정보를 참고해서
        for (int i = 0; i < 10; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(inven.transform).gameObject;
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();

            if (i != 9)
                invenItem.SetKey($"{i + 1}");
            else
                invenItem.SetKey("0");
        }

        // UI_Bar
        GameObject bar = Get<GameObject>((int)GameObjects.UI_Bar);
        foreach (Transform child in bar.transform)
            Managers.Resource.Destroy(child.gameObject);

        // UI_Main_HpBar
        GameObject mainHpBar = Managers.UI.MakeSubItem<UI_Main_HpBar>(bar.transform).gameObject;
        UI_Main_HpBar hpBar = mainHpBar.GetOrAddComponent<UI_Main_HpBar>();
        mainHpBar.transform.position = bar.transform.position + new Vector3(80.0f, -20.0f, 0.0f);   // Bar의 위치 조정

        // UI_Main_ExpBar
        GameObject mainExpBar = Managers.UI.MakeSubItem<UI_Main_ExpBar>(bar.transform).gameObject;
        UI_Main_ExpBar expBar = mainExpBar.GetOrAddComponent<UI_Main_ExpBar>();
        mainExpBar.transform.position = bar.transform.position + new Vector3(-210.0f, -50.0f, 0.0f);
    }
}
