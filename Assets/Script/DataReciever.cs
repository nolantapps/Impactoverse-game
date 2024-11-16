using UnityEngine;
using TMPro;
using GameAnalyticsSDK;
public class DataReceiver : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Error;
    public void Start()
    {
        try
        {
            GameAnalyticsSDK.GameAnalytics.Initialize();
        }
        catch
        {
            //Error.text = "Some Issue With the GameAnalytics";
        }
        
        //InvokeRepeating(nameof(SendEvent), 4f, 1f);
    }
    void SendEvent()
    {
        try
        {
            if (GameAnalytics.Initialized)
            {
                GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(GameAnalyticsSDK.GAProgressionStatus.Start, "Bravo Entered The Space");
                GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(GameAnalyticsSDK.GAProgressionStatus.Start, "Shaheer Entered The Space");
                Error.text = "Analytics Send";

            }
            else
            {
                try
                {
                    GameAnalytics.Initialize();

                }
                catch
                {
                    Error.text = "Some Issue With the GameAnalytics in the Invoke";
                }
                Error.text = "Analytics Not Initilized Send";

            }
        }
        catch
        {
            Error.text = "Serious Issue With the Analytics";
        }
    }
    // This method will be called from JavaScript
    public void ReceiveData (string jsonData)
    {
        // Deserialize the JSON string into a data object
        Data data = JsonUtility.FromJson<Data>(jsonData);

        // Now you can access the email and token
        Name.text = data.displayName.ToUpper();
        GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(GameAnalyticsSDK.GAProgressionStatus.Start,data.displayName.ToUpper()+ " Entered The Space");
        // Handle the received data as needed
        // For example, you might want to store it or use it in your game
    }

    // Define a class to match the JSON structure
    [System.Serializable]
    public class Data
    {
        public string displayName;
        public string token;
    }
}
