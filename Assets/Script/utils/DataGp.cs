using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGp : MonoBehaviour
{
    public static DataGp Instance;
    public  User User;
   
  
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }

    }
 
}
