using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameObject testObject;
    int _currSceneIndex;

    int _mainMenu = 1;
    int _optionsMenu = 2;
    int _levelSelect = 3;
    int _mainGame = 4;

    private void Start()
    {
        _currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(_currSceneIndex == 0)
        {
            StartCoroutine(LoadFromSplashScreen());
        }
    }

    private IEnumerator LoadFromSplashScreen()
    {
        yield return new WaitForSeconds(FindObjectOfType<AudioSource>().clip.length);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene(_optionsMenu);
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene(_levelSelect);
    }

    public void LoadLevel(int levelNum)
    {
        SceneManager.LoadScene(_mainGame);
        MapLoader.SetMapNum(levelNum);
    }
}
