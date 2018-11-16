using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ModeParamBase {
    public int test;
}


public class P_ModeBase : ModeBase
{

    protected P_DoudgeParam Modeparam;
    //ChangeMode_Eqition

    [SerializeField] public List<string> targetkeylist;

    public int MP = 0;
    //敵オブジェクトのコーラー(本来ここじゃないかも)
    protected ObjectCaller[] enemy_caller = new ObjectCaller[8];
    //モードフラグ
    

    public override void Mode_Start(Charactor _obj)
    {
        ishitbox = false;
        TestPlayer p = _obj.GetComponent<TestPlayer>();
        //TargetKeyListの形骸化をすべく共通のセッターを入れる
        SetAllKeyToList(p);

        p.recorder.SetTargetKey(targetkeylist);
        base.Mode_Start(_obj);

        //MPの消費
        p.status.MP -= MP;
    }

    void SetAllKeyToList(TestPlayer _obj)
    {
        targetkeylist = _obj.targetkeylist;
    }

    public override void Mode_Update(Charactor _obj)
    {
        //IsRightの更新
        if (_obj.nowflag.IsAbleToMove)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("MyHorizontal") > 0)
            {
                _obj.IsRight = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("MyHorizontal") < 0)
            {
                _obj.IsRight = false;
            }

            
        }
        //IsRightによる向きの調整
        if (true)
        {
            if (_obj.IsRight)
            {
                _obj.transform.localScale = new Vector3(_obj.BaseScale_x, _obj.transform.localScale.y, _obj.transform.localScale.z);
            }
            else
            {
                _obj.transform.localScale = new Vector3(-_obj.BaseScale_x, _obj.transform.localScale.y, _obj.transform.localScale.z);
            }
        }
        //ジャンプ待ち時間の調整
        TestPlayer _p = _obj.GetComponent<TestPlayer>();
        _p.jump_waittime += Time.deltaTime;
        base.Mode_Update(_obj);

        
    }

    
    ///////////////////////////
    //共通の便利関数
    ///////////////////////////
    //もしコマンド入力受付時間内なら
    public override bool IsInputReception(Charactor _obj)
    {
        //両方0ならtrueを返す
        if(_obj.nowflag.StartInputReceptionTime == 0 && _obj.nowflag.EndInputReceptionTime == 0) { return true; }
        if (_obj.nowflag.StartInputReceptionTime <= _obj.modetime && _obj.nowflag.EndInputReceptionTime > _obj.modetime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //もし移動可能なら
    protected void Move(){
       
    }
}