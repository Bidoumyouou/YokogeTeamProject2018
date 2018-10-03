using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;//Type入ってる
//特定の型とパラメータを指定してそれを文字に起こすプログラム

//ターゲットの参照と型の情報をもつジェネリッククラス
public class ParamToText<T> {
    public T param;
    public GameObject objRef;


}


public class TextBehavior : MonoBehaviour
{
    public string classname = "GameObject";

    public string membername;
    Type type;
    float member;
    //public ParamToText<int> intparam;
    //intかfloatのみに絞る
    public GameObject obj;

    Text text;

    // Use this for initialization
    void Start()
    {
        
        type = Type.GetType(classname);
        //member = obj.GetComponent<type>
        text = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        //text.text = intparam.param.ToString();
    }
}
