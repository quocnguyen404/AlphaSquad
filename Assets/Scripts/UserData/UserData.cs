using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData : ICloneable
{
    public int currentLevel = 1;

    public int maxLevel = 1;

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    //public List<CharacterData> characters;
}
