using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        UI_Inven_Background
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        GameObject background = Get<GameObject>((int)GameObjects.UI_Inven_Background);
        foreach (Transform child in background.transform)
            Managers.Resource.Destroy(child.gameObject);

        // 실제 인벤토리 정보를 참고해서
        for (int i = 0; i < 10; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(background.transform).gameObject;
            UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetKey($"{i}");
        }
    }
}
