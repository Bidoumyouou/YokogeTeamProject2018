using UnityEngine;
using System.Collections;

public static class GetEnemyCaller
{
    //_objは必ずプレイヤーのHitBox
    public static ObjectCaller GetObjectCaller(GameObject _obj)
    {
        //HitBox hitbox = _obj.GetComponent<HitBox>();
        //ヒットした側のゲームオブジェクトは保存できないのか
        Collider2D hit_col = _obj.GetComponent<Collider2D>();
        GameObject hitbox = hit_col.gameObject;
        HitBox hitbox_ins = hitbox.GetComponent<HitBox>();
        ObjectCaller caller = hitbox_ins.chara_caller;
        return caller;
    }
}
