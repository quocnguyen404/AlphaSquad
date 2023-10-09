using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public static class GameConfig
{

    public static void SaveUserData(UserData userData)
    {
        string path = Application.persistentDataPath + "/UserData.json";

        string txt = JsonConvert.SerializeObject(userData);

        //FileStream stream = new FileStream(path, FileMode.Create);

        File.WriteAllText(path, txt);
        Debug.Log("Save success path: " + path);

        //stream.Close();
    }

    public static UserData LoadUserData()
    {
         string path = Application.persistentDataPath + "/UserData.json";

        UserData userData = null;

        if (File.Exists(path))
        {
            Debug.Log("Load user data from: " + path);

            string content = File.ReadAllText(path);
            userData = JsonConvert.DeserializeObject<UserData>(content);
        }
        else if (!File.Exists(path))
        {
            Debug.Log("Not found " + path + " init default user data");
            userData = GetDefaultUserData();
        }

        return userData;
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
