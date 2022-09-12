using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.Lock;

    [SerializeField]
    Vector3 _delta = new Vector3(-6, 10, -6);

    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    float _camSpeed = 20.0f;

    private Vector3 _vertical = new Vector3(1, 0, 1);
    private Vector3 _horizontal = new Vector3(1, 0, -1);

    public void SetPlayer(GameObject player) { _player = player; }

    void Start()
    {
        transform.position = _player.transform.position + _delta;
        transform.LookAt(_player.transform);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _mode = Define.CameraMode.Lock;
        else if(Input.GetKeyUp(KeyCode.Space))
            _mode = Define.CameraMode.Unlock;

        if (_mode == Define.CameraMode.Lock)
            SetLockView();
        else
            SetUnlockView();
    }

    // Camera Lock Mode
    public void SetLockView()
    {
        if (_player.IsValid() == false)
            return;
        transform.position = _player.transform.position + _delta;
        transform.LookAt(_player.transform);
    }

    // Camera Unlock Mode
    public void SetUnlockView()
    {
        // Up
        if (Input.mousePosition.y >= Screen.height)
            transform.position += _vertical * _camSpeed * Time.deltaTime;

        // Down
        if (Input.mousePosition.y <= 0)
            transform.position -= _vertical * _camSpeed * Time.deltaTime;

        // Right
        if (Input.mousePosition.x >= Screen.width)
            transform.position += _horizontal * _camSpeed * Time.deltaTime;

        // Left
        if (Input.mousePosition.x <= 0)
            transform.position -= _horizontal * _camSpeed * Time.deltaTime;
    }
}
