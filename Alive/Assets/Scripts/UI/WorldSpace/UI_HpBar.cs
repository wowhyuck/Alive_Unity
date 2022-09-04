using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HpBar : UI_Base
{
    enum GameObjects
    {
        HpBar
    }

    Stat _stat;

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        _stat = transform.parent.GetComponent<Stat>();
    }

    private void Update()
    {
        Transform parent = transform.parent;

        // 대상 머리 위에 체력바 놓기
        transform.position = parent.position + Vector3.up * (parent.GetComponent<Collider>().bounds.size.y + 0.5f);
        transform.rotation = Camera.main.transform.rotation;

        // 몬스터일 때 체력바를 빨간색으로 변경
        PlayerController go = parent.GetComponent<PlayerController>();
        if (go == null)
        {
            GameObject chlid = Util.FindChild(gameObject, "Fill", true);
            Image image = chlid.GetComponent<Image>();
            image.color = Color.red;
        }

        float ratio = _stat.Hp / (float)_stat.MaxHp;
        SetHpRatio(ratio);
    }

    public void SetHpRatio(float ratio)
    {
        GetObject((int)GameObjects.HpBar).GetComponent<Slider>().value = ratio;
    }
}
