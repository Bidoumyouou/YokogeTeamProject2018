using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BidouLib
{
    
    public static class Global
    {
        //bool型を1or-1に変換する
        public static int BoolToSign(bool _b)
        {
            if (_b) {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        //地点Aから地点Bまで一定の速度で動く関数。
        public class MyMove2D {
            public float moveratio = 0;//移動の遂行率
            Vector2 movevec;//移動しなければならないベクトルの和
           public  bool IsFinished = false;
            //(移動する対象、移動元、移動先、速度)
            public static MyMove2D Move(Transform tr ,Vector2 _pos,Vector2 _targetpos, float _speed){
                //
                Vector2 movevec;
                //移動元、移動先から移動すべきベクトルを導出
                movevec = _targetpos - _pos;
                //サイズ1に正規化して速度を賭ける
                Vector2 delta = movevec.normalized * _speed;
                //実際の移動
                tr.Translate(delta);
                //遂行率の導出
                float moveratio;

                Vector2 NowVec = (Vector2)tr.position - _pos;
                moveratio = NowVec.sqrMagnitude / movevec.sqrMagnitude;
                //100%超えてたら100%にする
                bool IsFinished = false;

                if (moveratio >= 1.0f)
                {
                    IsFinished = true;
                    moveratio = 1.0f;tr.position = _targetpos;
                }

                //パラメータの返却
                MyMove2D mymove = new MyMove2D();
                mymove.Set(movevec,moveratio,IsFinished);
                return mymove;
            }



            void Set(Vector2 _movevec,float _movertio, bool _IsFinished)
            {
                movevec = _movevec;
                moveratio = _movertio;
                IsFinished = _IsFinished;
            }
        }

        //ジェネリッククラス
        //Scene上のGameObjectの名前から自動で型判別してGetComponentできる自作クラス
        [System.Serializable]
        public class ClassWithGetter<T> {
            public T Ins;//インスタンス
            public GameObject objRef;//GameObjectの参照

            //セットオブジェクトした際に自動でインスタンスも通す
            public void SetObject(GameObject _obj)
            {
                objRef = _obj;
                SetInstance();
            }

            public void SetInstance()
            {
                Ins = objRef.GetComponent<T>(); 
            }

            //Find関数でオブジェクト内部のインスタンスを返す
            public T GetClassByFind(string _NameOfGameObject = "")
            {
                if(objRef == null)
                {
                    //クラス
                    if (_NameOfGameObject == "" || _NameOfGameObject == null)
                    {
                        objRef = GameObject.Find(typeof(T).Name);
                    }
                    else
                    {
                        objRef = GameObject.Find(_NameOfGameObject);
                    }
                }
                if(objRef != null) {
                    Ins = objRef.GetComponent<T>();
                }
                return Ins;
            }
        }

        //public static FindGameObject
    }

}
