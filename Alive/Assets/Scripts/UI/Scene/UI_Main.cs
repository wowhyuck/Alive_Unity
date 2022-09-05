using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        MakeMainUI<UI_Main_HpBar>(bar, new Vector3(80.0f, -20.0f, 0.0f));       // Hp Bar
        MakeMainUI<UI_Main_MpBar>(bar, new Vector3(80.0f, -35.0f, 0.0f));       // Mp Bar
        MakeMainUI<UI_Main_FatigueBar>(bar, new Vector3(80.0f, -50.0f, 0.0f));  // Fatigue Bar
        MakeMainUI<UI_Main_ExpBar>(bar, new Vector3(-210.0f, -50.0f, 0.0f));    // Exp Bar
        MakeMainUI<UI_Profile>(bar, new Vector3(-210.0f, 14.0f, 0.0f));         // Profile

    }

    public void MakeMainUI<T>(GameObject parent, Vector3 pos) where T : UI_Base
    {
        GameObject main = Managers.UI.MakeSubItem<T>(parent.transform).gameObject;
        T child = main.GetOrAddComponent<T>();
        main.transform.position = parent.transform.position + pos;   // Bar의 위치 조정
    }
}
