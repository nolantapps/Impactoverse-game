using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
    private void Start()
    {
        
    }
    public  void CharacterSelectionButton()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadYourAsyncScene());
        
    }
    IEnumerator LoadYourAsyncScene()
    {
        

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            SceneManager.LoadScene(1);
            yield return null;
        }
    }

  
}
