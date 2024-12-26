using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject LoadingScene;
    [SerializeField] private TextMeshProUGUI NameText;
    public static MainMenuManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        NameText.text = DataGp.Instance.User.Name;
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
