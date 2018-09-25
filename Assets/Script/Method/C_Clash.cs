using UnityEngine;
using System.Collections;

public class C_Clash
{
    //該当キャラのコライダを取得
    BoxCollider2D col;
    //ヒットボックス
    Ray2D ray2d;
    public bool Active = false;//今吹き飛んでいるかどうか
    public bool Trigger = false;//吹っ飛びが発生した瞬間のみtrue
    float tmp_scaler;//実際に吹っ飛ばされた量
    float scaler;//吹っ飛ばされる距離をスカラーで
    Vector2 vector;//吹っ飛ばされる方向をベクトルで
    float speed;
    float time = 0.0f;
    public void Init(BoxCollider2D boxcol)
    {
        col = boxcol;
        Active = false;
        tmp_scaler = 0.0f;
        scaler = 0;
        vector = Vector2.zero;
        speed = 1.0f;
    }
    public void Set(float _scaler, Vector2 _vector, float _speed, bool _Initflag = true)
    {
        if (_Initflag) { Init(col); }
        Active = true;
        tmp_scaler = 0.0f;
        scaler = _scaler;
        vector = _vector;
        speed = _speed;
        Trigger = true;
        time = 0.0f;
    }
    //Updateに入れて常にClashをもつオブジェクトの吹っ飛びを管理
    public bool Action(Transform _transform, ObjectCaller _caller)
    {
        if (time > 0.05f) { Trigger = false; }
        if (!Active) { return false; }
        Vector2 vectorfor2d;
        vectorfor2d.x = _transform.position.x;
        vectorfor2d.y = _transform.position.y;
        float HitBox_x = col.size.x * 0.5f * _transform.localScale.x;//HitBoxのヨコの実長
        float HitBox_y = col.size.y * 0.5f * _transform.localScale.y;//HitBoxのヨコの実長
        Vector2 ColliderRayVector_x= vector.normalized * (HitBox_x / Mathf.Abs(vector.normalized.x));//HitBOx_xを基に長さを調節したRayVector
        Vector2 ColliderRayVector_y = vector.normalized * (HitBox_y / Mathf.Abs(vector.normalized.y)); ;//HitBOx_yを基に長さを調節したRayVector
        Vector2 RayVector;
        if(ColliderRayVector_x.magnitude < ColliderRayVector_y.magnitude) { RayVector = ColliderRayVector_x; } else { RayVector = ColliderRayVector_y; }//↑二つのうち長さが短い方を採用
        ray2d = new Ray2D(vectorfor2d, RayVector);
        Debug.DrawRay(ray2d.origin, ray2d.direction.normalized * RayVector.magnitude,Color.green,1,false);
        if(true)
        {
            //コーラーの壁ヒットフラグがONならTranslateのみ更新を停止
            //if (!_caller.WallHit)
            RaycastHit2D hit = Physics2D.Raycast(ray2d.origin, ray2d.direction.normalized  , 1.0f* RayVector.magnitude);
            if (hit.collider == null || hit.collider.tag != "Wall")
            {
                _transform.Translate(scaler * vector * Time.deltaTime * speed);
            }
            else
            {
                //
            }
        }
        tmp_scaler += scaler * Time.deltaTime * speed;
        if (tmp_scaler >= scaler)
        {
            Active = false;
            _caller.WallHit = false;
        }
        time += Time.deltaTime;
        return true;
    }
}
