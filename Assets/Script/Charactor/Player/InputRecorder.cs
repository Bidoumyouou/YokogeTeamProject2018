using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キーの入力を取得する方法。
[System.Serializable]
public class InputRecorder :System.Object{
    List<string> TargetKeyList = new List<string>();//収集するキーの種類リスト
    public List<string> KeyList = new List<string>();//実際に収集したキー
    public bool keySuccess = false;
    List<string> RemoveKeyList = new List<string>();

    bool Pre_Axis_Up = false;
    bool Pre_Axis_Down = false;
    bool Pre_Axis_Left = false;
    bool Pre_Axis_Right = false;
    public bool now_Axis_Up = false;
    public bool now_Axis_Down = false;
    public bool now_Axis_Left = false;
    public bool now_Axis_Right = false;
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
        //右ジョイスティック
        if (Input.GetAxis("MyHorizontal") > 0)
        {
            now_Axis_Right = true;
        }
        else
        {
            now_Axis_Right = false;
        }
        //左ジョイスティック
        if (Input.GetAxis("MyHorizontal") < 0)
        {
            now_Axis_Left = true;
        }
        else
        {
            now_Axis_Left = false;
        }
        //↑ジョイスティック
        if (Input.GetAxis("MyVertical") < 0)
        {
            now_Axis_Up = true;
        }
        else
        {
            now_Axis_Up = false;
        }

        //下ジョイスティック
        if (Input.GetAxis("MyVertical") > 0)
        {
            now_Axis_Down = true;
        }
        else
        {
            now_Axis_Down = false;
        }



        if (TargetKeyList.Count == 0) { return; }
        //同時押しを考慮するために「一回追加したらそれ以外のキーをもう一周捜査」を入れてみる


        foreach(string s in TargetKeyList)
        {
            //ボタンが入力されたら


            //Axis系の入力に対して偽造工作する
            ConvertAxisToButton(s);
            //回避系の入力に対して偽造工作する
            //ConvertDoudgeButton(s);

            if (Input.GetButtonDown(s))
            {
                KeyList.Add(s);
            }
        }

        Pre_Axis_Up = now_Axis_Up;
        Pre_Axis_Down = now_Axis_Down;
        Pre_Axis_Left = now_Axis_Left;
        Pre_Axis_Right = now_Axis_Right;

    }
    void ConvertDoudgeButton(string s)
    {
        if(s == "MyC")
        {
            if (Input.GetButton(s))
            {
                if(!KeyList.Contains("MyC"))
                    KeyList.Add(s);
            }
        }
    }

    void ConvertAxisToButton(string s)
    {

        //ジョイスティックにIsDownを疑似的に追加


        if(s == "MyHorizontal" && now_Axis_Up && !Pre_Axis_Up)
        {
            KeyList.Add("MyUp");
        }
        if (s == "MyHorizontal" && now_Axis_Down && !Pre_Axis_Down)
        {
            KeyList.Add("MyDown");
        }
        if (s == "MyVertical" && now_Axis_Left && !Pre_Axis_Left)
        {
            KeyList.Add("MyLeft");
        }
        if (s == "MyVertical" && now_Axis_Right && !Pre_Axis_Right)
        {
            KeyList.Add("MyRight");
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
        /*
        while(tmplist.Contains(_targetlist[0]))
        {
            var index = tmplist.IndexOf(_targetlist[0]);
            bool flag = true;
            for (int i = 0; i < _targetlist.Count; i++)
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
        */

        //いったんRemoveリストに参照渡しして実際にChangeModeするときに消す
        RemoveKeyList = tmplist;
        //キー入力成立通知をプレイヤーに送る
        keySuccess = true;
        /*
        foreach(string s in _targetlist){
            tmplist.Remove(s);
            
        }
        */
        return true;
    }

    public void RemoveKey()
    {
        //AxisDOwn用の変数のリセット
        now_Axis_Up = Pre_Axis_Up = false;
        now_Axis_Down = Pre_Axis_Down = false;
        now_Axis_Left = Pre_Axis_Left = false;
        now_Axis_Right = Pre_Axis_Right = false;

        keySuccess = false;

        if (RemoveKeyList == null)
        {
            return;
        }
        if (RemoveKeyList.Count == 0)
            return;
        RemoveKeyList.RemoveRange(0, RemoveKeyList.Count);

    }

    //特定のモード(主にRun)で最新以外の左右キーを排除する
    public void DeleteOldAllowStack()
    {
        List<string> oldkeylist = new List<string>();


        for(int i = 0; i< KeyList.Count - 1;i++)
        {
           if( KeyList[i] == "MyRight" || KeyList[i] == "MyLeft")
            {
                KeyList.Remove(KeyList[i]);
            }
        }

    }
}
