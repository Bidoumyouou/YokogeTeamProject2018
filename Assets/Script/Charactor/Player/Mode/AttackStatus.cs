using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//攻撃がもつパラメータ
[System.Serializable]
public class AttackStatus : System.Object {
    public bool DeleteToHit;//攻撃が当たったら当たり判定が消えるか
    public bool DeleteToChangeMode = true;//モードが変わったときにあたり判定が消えるか
    public float EndTime = 100.0f;//当たり判定が消えるタイミング

}
