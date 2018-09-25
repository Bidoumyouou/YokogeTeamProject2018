using UnityEngine;
using System.Collections;

//壁クラス

public class Wall : MonoBehaviour
{

    // Use this forC:\Users\Bidoumyouou\Documents\Git\YokoGe\Assets\Script\Charactor\Player\Mode\P_Zyaku3.cs initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //敵か味方の場合
        if(col.tag == "Enemy" || col.tag == "Player")
        {
            //壁の少し外側で当たったことをオブジェクトに通知する
            GameObject objcol = col.gameObject;
            ObjectCaller caller = objcol.GetComponent<ObjectCaller>();
            Charactor chara_ins = objcol.GetComponent<Charactor>();
            if (chara_ins != null)
            {
                C_Clash clash = chara_ins.clash;
            }
            if (caller != null)
            {
                caller.WallHit = true;
            }

            //if(clash.Active)
        }
        else
        {

        }
    }
}
