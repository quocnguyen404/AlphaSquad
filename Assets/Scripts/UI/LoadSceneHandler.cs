using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHandler : MonoBehaviour
{
    public void LoadGamePlayeScene()
    {
        SceneManager.LoadScene(1);
    }
}
