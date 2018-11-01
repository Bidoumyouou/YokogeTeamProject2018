using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キーの入力を取得する方法。
[System.Serializable]
public class InputRecorder :System.Object{
    List<string> TargetKeyList = new List<string>();//収集するキーの種類リスト
    List<string> KeyList = new List<string>();//実際に収集したキー
    void Init()
    {
        KeyList.Clear();
    }

    public void SetTargetKey(List<string> _targetlist)
    {
        TargetKeyList.Clear();
        TargetKeyList.AddRange(_targetlist);
        Init();
    }

    public void Update()
    {
        if(TargetKeyList.Count == 0) { return; }
        foreach(string s in TargetKeyList)
        {
            //ボタンが入力されたら

            //Axis系の入力に対して偽造工作する
            ConvertAxisToButton(s);

            if (Input.GetButtonDown(s))
            {
                KeyList.Add(s);
            }
        }
    }


    void ConvertAxisToButton(string s)
    {
        //右ジョイスティック
        if(s == "MyHorizontal" && Input.GetAxis(s) > 0)
        {
            KeyList.Add("MyRight");
        }
        //左ジョイスティック
        if (s == "MyHorizontal" && Input.GetAxis(s) < 0)
        {
            KeyList.Add("MyLeft");
        }
        //↑ジョイスティック
        if (s == "MyVertical" && Input.GetAxis(s) < 0)
        {
            KeyList.Add("MyUp");
        }
        //下ジョイスティック
        if (s == "MyVertical" && Input.GetAxis(s) > 0)
        {
            KeyList.Add("MyDown");
        }



    }
    public bool Check(List<string> _targetlist)
    {


        if (_targetlist.Count == 0) { return true; }
        //条件に合うキーが入っているかどうか
        foreach (string s in _targetlist)
        {
            if (!KeyList.Contains(s)) { return false; }
        }
        //入っていたら順序があっているか
        List<string> tmplist = new List<string>();

        tmplist.AddRange(KeyList);
        //targetkeyの中身と合致する
        while(tmplist.Contains(_targetlist[0]))
        {
            var index = tmplist.IndexOf(_targetlist[0]);
            bool flag = true;
            for (int i = 1; i < _targetlist.Count; i++)
            {
                if(tmplist.Count < _targetlist.Count) { return false; }
                if (!(tmplist[index + i] == _targetlist[i]))
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                //順列が一致する配列が見つかった
                return true;
            }
            else
            {
                tmplist.Remove(_targetlist[0]);
            }
        }

        return false;
    }
}
