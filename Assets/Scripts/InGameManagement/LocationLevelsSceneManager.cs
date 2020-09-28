using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationLevelsSceneManager : MonoBehaviour
{
   

    public delegate void EndLocationLevelHandler();
    public static event EndLocationLevelHandler OnEndLocationLevel;

    public static int NumberOfRemainingResources = 0;

    public static void ResourceTaked()
    {
        NumberOfRemainingResources--;
        if (NumberOfRemainingResources <= 0)
        {
            LoadingNextLevel();
        }
    }

    public static void LoadingNextLevel()
    {
        OnEndLocationLevel?.Invoke();
        SceneManager.LoadScene(0);
    }

}
