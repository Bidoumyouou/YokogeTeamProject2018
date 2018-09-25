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
            if (Input.GetButtonDown(s))
            {
                KeyList.Add(s);
            }
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
