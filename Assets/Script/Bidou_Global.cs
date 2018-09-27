using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BidouLib
{
    public static class Global
    {

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
