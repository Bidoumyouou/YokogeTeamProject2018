using System.Linq;
using UnityEngine;
using System.Collections;

public enum E_Tag
{
    Player = 0,
    Enemy = 1
}


public static class GameObjectExtensions
{
    public static T[] GetComponentsInChildrenWithoutSelf<T>(this GameObject self) where T : Component
    {
        return self.GetComponentsInChildren<T>().Where(c => self != c.gameObject).ToArray();
    }

 
}

