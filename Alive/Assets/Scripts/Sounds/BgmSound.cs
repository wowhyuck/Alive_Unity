using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSound : MonoBehaviour
{
    PlayerController _player;
    void Start()
    {

    }

    void Update()
    {
        
    }

    // BGM
    private void OnTriggerEnter(Collider other)
    {
        _player = other.GetComponent<PlayerController>();
        if (_player != null)
            Managers.Sound.Play("BGM/track_coolbreeze_loop", Define.Sound.Bgm);
    }
}
