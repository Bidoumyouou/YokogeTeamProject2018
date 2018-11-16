using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//攻撃のタイプについて
/*
 * 0..射撃(発生した後は独自の法則で動く)
 * 1..打撃(発生した後発生源の子オブジェクトになる)
*/
//Hitboxと両方にMonobが付いてるのは良くないのでは？
public class Damege : MonoBehaviour {

    public GameObject Effect;
    public int type;//攻撃のタイプ
    [Tooltip("攻撃の強靭度")] public int Strength = 1;
    [Tooltip("減少させるHP")]public int value;//減少させるHP
    [Tooltip("ノックバックのパワー")] public float power;//ノックバックのパワー
    public Vector2 vector;//ノックバックのベクトル
    public float speed;//ノックバックのスピード。１が標準
    public void Set(int _type, int _value, float _power, Vector2 _vector, float _speed = 1)
    {
        type = _type;
        value = _value;
        power = _power;
        vector = _vector;
        speed = _speed;
    }
}
