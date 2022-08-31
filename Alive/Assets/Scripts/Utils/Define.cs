using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum State
    {
        Die,
        Moving,
        Idle,
        Attack,
    }

    public enum Layer
    {
        Ground = 8,
        Block = 9,
        Monster = 10,
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum MouseEvent
    {
        PointDown,
        Pressed,
        PointUp,
        Click,
    }

    public enum CameraMode
    {
        QuaterView,
    }
}
