using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    Texture2D _baseIcon;
    Texture2D _attackIcon;
    Outline _outline;

    public enum CursorType
    {
        None,
        Base,
        Attack,
    }

    CursorType _cursorType = CursorType.None;

    int _mask = (1 << (int)Define.Layer.Ground | 1 << (int)Define.Layer.Monster);

    void Start()
    {
        _baseIcon = Managers.Resource.Load<Texture2D>("Art/UI/Cursor/Base");
        _attackIcon = Managers.Resource.Load<Texture2D>("Art/UI/Cursor/Attack");
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, _mask))
        {

            if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
            {
                // Outline
                _outline = hit.collider.gameObject.GetComponent<Outline>();
                _outline.OutlineMode = Outline.Mode.OutlineAll;

                // Attack Cursor
                if (_cursorType != CursorType.Attack)
                {
                    Cursor.SetCursor(_attackIcon, new Vector2(_attackIcon.width * 0.4f, _attackIcon.height * 0.2f), CursorMode.Auto);
                    _cursorType = CursorType.Attack;
                }
            }
            else
            {
                if (_outline != null)
                    _outline.OutlineMode = Outline.Mode.OutlineHidden;

                if (_cursorType != CursorType.Base)
                {
                    Cursor.SetCursor(_baseIcon, new Vector2(_baseIcon.width * 0.4f, _baseIcon.height * 0.2f), CursorMode.Auto);
                    _cursorType = CursorType.Base;
                }
            }
        }
    }
}
