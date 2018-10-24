using UnityEngine;
using UnityEditor;

public class Eq_MP : EqitionBase
{
    

    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if (_obj.tag.ToString() == "Player")
        {
            TestPlayer _player = _obj.GetComponent<TestPlayer>();
            //MPが足りているか
            P_ModeBase pmode = (P_ModeBase)targetmode;
                if (_player.status.MP >= pmode.MP)
                {
                        return true;
                }
            
        }
        //もし不足していたら効果音を鳴らす

        return false;
    }


}