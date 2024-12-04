using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject LoadingScene;
    public static MainMenuManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
    }
    public  void ChangeScene( string SceneName)
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadYourAsyncScene(SceneName));
        
    }
    
    IEnumerator LoadYourAsyncScene(string SceneName)
    {
        yield return new WaitForSeconds(3f);    

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            SceneManager.LoadScene(SceneName);
            yield return null;
        }
    }

  
}
