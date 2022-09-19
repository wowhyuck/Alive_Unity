using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Skill : UI_Base
{
    [Header("Skill_Q")]
    public float _cooltime_Q = 10;
    public bool _isCooltime_Q = false;
    public KeyCode _key_Q;
    Image _skill_Q;

    [Header("Skill_W")]
    public float _cooltime_W = 15;
    public bool _isCooltime_W = false;
    public KeyCode _key_W;
    Image _skill_W;

    [Header("Skill_E")]
    public float _cooltime_E = 5;
    public bool _isCooltime_E = false;
    public KeyCode _key_E;
    Image _skill_E;

    [Header("Skill_R")]
    public float _cooltime_R = 60;
    public bool _isCooltime_R = false;
    public KeyCode _key_R;
    Image _skill_R;

    [Header("Skill_T")]
    public float _cooltime_T = 30;
    public bool _isCooltime_T = false;
    public KeyCode _key_T;
    Image _skill_T;

    [Header("Skill_D")]
    public float _cooltime_D = 30;
    public bool _isCooltime_D = false;
    public KeyCode _key_D;
    Image _skill_D;

    public override void Init()
    {
        _skill_Q = Util.FindChild<Image>(gameObject, "UI_Skill_Q");
        _key_Q = KeyCode.Q;

        _skill_W = Util.FindChild<Image>(gameObject, "UI_Skill_W");
        _key_W = KeyCode.W;

        _skill_E = Util.FindChild<Image>(gameObject, "UI_Skill_E");
        _key_E = KeyCode.E;

        _skill_R = Util.FindChild<Image>(gameObject, "UI_Skill_R");
        _key_R = KeyCode.R;

        _skill_T = Util.FindChild<Image>(gameObject, "UI_Skill_T");
        _key_T = KeyCode.T;

        _skill_D = Util.FindChild<Image>(gameObject, "UI_Skill_D");
        _key_D = KeyCode.D;
    }

    void Update()
    {
        UpdatingSkill_Q(_skill_Q, _key_Q);
        UpdatingSkill_W(_skill_W, _key_W);
        UpdatingSkill_E(_skill_E, _key_E);
        UpdatingSkill_R(_skill_R, _key_R);
        UpdatingSkill_T(_skill_T, _key_T);
        UpdatingSkill_D(_skill_D, _key_D);
    }

    void UpdatingSkill_Q(Image skill, KeyCode key)
    {
        Image cooltime_Q = Util.FindChild<Image>(skill.gameObject, "Cooltime");

        UpdatingCoolTime(key, _cooltime_Q, ref cooltime_Q, ref _isCooltime_Q);
    }

    void UpdatingSkill_W(Image skill, KeyCode key)
    {
        Image cooltime_W = Util.FindChild<Image>(skill.gameObject, "Cooltime");

        UpdatingCoolTime(key, _cooltime_W, ref cooltime_W, ref _isCooltime_W);
    }

    void UpdatingSkill_E(Image skill, KeyCode key)
    {
        Image cooltime_E = Util.FindChild<Image>(skill.gameObject, "Cooltime");

        UpdatingCoolTime(key, _cooltime_E, ref cooltime_E, ref _isCooltime_E);
    }

    void UpdatingSkill_R(Image skill, KeyCode key)
    {
        Image cooltime_R = Util.FindChild<Image>(skill.gameObject, "Cooltime");

        UpdatingCoolTime(key, _cooltime_R, ref cooltime_R, ref _isCooltime_R);
    }

    void UpdatingSkill_T(Image skill, KeyCode key)
    {
        Image cooltime_T = Util.FindChild<Image>(skill.gameObject, "Cooltime");

        UpdatingCoolTime(key, _cooltime_T, ref cooltime_T, ref _isCooltime_T);
    }

    void UpdatingSkill_D(Image skill, KeyCode key)
    {
        Image cooltime_D = Util.FindChild<Image>(skill.gameObject, "Cooltime");

        UpdatingCoolTime(key, _cooltime_D, ref cooltime_D, ref _isCooltime_D);
    }

    void UpdatingCoolTime(KeyCode key, float cooltime, ref Image ct, ref bool isCooltime)
    {
        if (Input.GetKey(key) && isCooltime == false)
        {
            isCooltime = true;
            ct.fillAmount = 1;
        }

        if (isCooltime)
        {            
            ct.fillAmount -= 1 / cooltime * Time.deltaTime;

            if (ct.fillAmount <= 0)
            {
                ct.fillAmount = 0;
                isCooltime = false;
            }
        }
    }
}
