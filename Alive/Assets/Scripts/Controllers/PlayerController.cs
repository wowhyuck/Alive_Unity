using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    PlayerStat _stat;
    Vector3 _destPos;

    Texture2D _baseIcon;
    Texture2D _attackIcon;

    public enum CursorType
    {
        None,
        Base,
        Attack,
    }

    CursorType _cursorType = CursorType.None;

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
        Attack,
    }

    PlayerState _state = PlayerState.Idle;


    void Start()
    {
        _baseIcon = Managers.Resource.Load<Texture2D>("Art/UI/Cursor/Base");
        _attackIcon = Managers.Resource.Load<Texture2D>("Art/UI/Cursor/Attack");

        _stat = gameObject.GetOrAddComponent<PlayerStat>();

        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;
    }

    void UpdateDie()
    {

    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 1.0f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            // TODO
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            float moveDist = Mathf.Clamp(_stat.MoveSpeed * Time.deltaTime, 0, dir.magnitude);
            nma.Move(dir.normalized * moveDist);

            if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, 1.0f, LayerMask.GetMask("Block")))
            {
                if (Input.GetMouseButton(1) == false)
                    _state = PlayerState.Idle;
                return;
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }

        // 애니메이션
        Animator anim = GetComponent<Animator>();

        // 현재 게임 상태에 대한 정보를 넘겨준다.
        anim.SetFloat("speed", _stat.MoveSpeed);
    }

    void OnRunEvent()
    {
        Debug.Log("뚜벅뚜벅~~");

    }

    void UpdateIdle()
    {
        // 애니메이션
        Animator anim = GetComponent<Animator>();

        anim.SetFloat("speed", 0);
    }

    void Update()
    {
        UpdateMouseCursor();

        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;

            case PlayerState.Moving:
                UpdateMoving();
                break;

            case PlayerState.Idle:
                UpdateIdle();
                break;
        }
    }

    void UpdateMouseCursor()
    {
        if (Input.GetMouseButton(1))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, _mask))
        {
            if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
            {
                if (_cursorType != CursorType.Attack)
                {
                    Cursor.SetCursor(_attackIcon, new Vector2(_attackIcon.width * 0.4f, _attackIcon.height * 0.2f), CursorMode.Auto);
                    _cursorType = CursorType.Attack;
                }
            }
            else
            {
                if (_cursorType != CursorType.Base)
                {
                    Cursor.SetCursor(_baseIcon, new Vector2(_baseIcon.width * 0.4f, _baseIcon.height * 0.2f), CursorMode.Auto);
                    _cursorType = CursorType.Base;
                }
            }
        }
    }

    GameObject _lockTarget;
    int _mask = (1 << (int)Define.Layer.Ground | 1 << (int)Define.Layer.Monster);
    void OnMouseEvent(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die)
            return;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool raycastHit = Physics.Raycast(ray, out hit, 100.0f, _mask);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        switch (evt)
        {
            case Define.MouseEvent.PointDown:
                {
                    if (raycastHit)
                    {
                        _destPos = hit.point;
                        _state = PlayerState.Moving;
                    }

                    if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
                        _lockTarget = hit.collider.gameObject;
                    else
                        _lockTarget = null;
                }
                break;
            case Define.MouseEvent.Pressed:
                {
                    if (_lockTarget != null)
                        _destPos = _lockTarget.transform.position;
                    else
                        if (raycastHit)
                        _destPos = hit.point;
                }
                break;
            case Define.MouseEvent.PointUp:
                _lockTarget = null;
                break;
        }
    }
}
