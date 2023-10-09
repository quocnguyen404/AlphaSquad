using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ES3Internal;

public static class GameConfig
{
    private const string UserDataKey = "userdata123";

    public static UserData UserData
    {
        get
        {
            if (!ES3.KeyExists(UserDataKey))
            {
                UserData data = GetDefaultUserData();
                return data;
            }

            return ES3.Load<UserData>(UserDataKey);
        }

        set
        {
            SaveUserData(value);
        }
    }

    public static void SaveUserData(UserData userData)
    {
        ES3.Save(UserDataKey, userData);
    }

    private static UserData GetDefaultUserData()
    {
        UserData defaultUserData = new UserData();
        defaultUserData.currentLevel = 1;
        defaultUserData.maxLevel = 1;
        //defaultUserData.characters = new List<CharacterData>();

        return defaultUserData;
    }
}
