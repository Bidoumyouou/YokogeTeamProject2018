using UnityEngine;
using System.Collections;

public class E002_List 
{
    public E_ModeBase[] ModeList = new E_ModeBase[8];
    public void Set()
    {
        ModeList[0] = new E001_Default();
        ModeList[1] = new E001_Dameged();
        ModeList[2] = new E001_Dead();
        //ここまで固定
        ModeList[3] = new E002_1();
        ModeList[4] = new E002_2();
    }
}
