using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
   
    public int levelCoinMultiplier = 2;

    private void OnEnable()
    {
        EventManager.OnGameOver.AddListener(GameOver);
    }

    private void OnDisable()
    {
        EventManager.OnGameOver.RemoveListener(GameOver);
    }

    public void GameOver()
    {
        StartCoroutine(LoadNextSceneCo());
    }

    private IEnumerator LoadNextSceneCo()
    {   
        //Cach next level build index
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        //Get how many scenes are loaded
        int sceneCount = SceneManager.sceneCount;
        //Create list for scenes to be unloaded
        List<Scene> scenesToUnLoaded = new List<Scene>();
        //Add scenes to be unloaded tothe list
        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name.Contains("Level"))
            {
                scenesToUnLoaded.Add(scene);
            }
        }
        //Unload all scenes that needs to be unloaded
        foreach (var s in scenesToUnLoaded)
        {
            yield return SceneManager.UnloadSceneAsync(s);
        }
        //Check if we can load  this scene
        if (!Application.CanStreamedLevelBeLoaded(buildIndex))
        {   
            // Set it back to default
            buildIndex = 1;
        }
        //Load the scene
        yield return SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        Scene levelScene = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(levelScene);
        PlayerPrefs.SetString("LastLevel",levelScene.name);
    }
}

