using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Playerモードが持つフラグ
[System.Serializable]
public class ModeFlag : System.Object
{
    [Tooltip("ジャンプできるか")]public bool IsAbleToJump = true;//
    [Tooltip("移動できるか")]public bool IsAbleToMove = true;//
    [Tooltip("数値的にダメージを受けられるか")]public bool IsAbleToBeDameged = true;//
    [Tooltip("吹っ飛べるか")]public bool IsAbleToBeClashed = true;//
    [Tooltip("当たり判定が有効か")]public bool IsAbleToVisible = true;//
    [Tooltip("俗に言う開始フレーム(秒で)")]public float StartTime;//
    [Tooltip("俗に言う終了フレーム(秒で)")]public float EndTime = 100.0f;//
    [Tooltip("コマンド入力受付開始フレーム")]public float StartInputReceptionTime = 0.05f;//
    [Tooltip("コマンド入力受付終了フレーム")]public float EndInputReceptionTime;//
    void Set(bool _move, bool _damege, bool _clash, bool _visible)
    {
        IsAbleToMove = _move;
        IsAbleToBeDameged = _damege;
        IsAbleToBeClashed = _clash;
        IsAbleToVisible = _visible;
    }
}