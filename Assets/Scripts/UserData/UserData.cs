using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public int currentLevel = 1;

    public int maxLevel = 5;

    public List<CharacterData> characters
    {
        get;
        set;
    }
}
