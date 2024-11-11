using UnityEngine;
using TMPro;
public class DataReceiver : MonoBehaviour
{
    public TextMeshProUGUI Name;

    // This method will be called from JavaScript
    public void ReceiveData (string jsonData)
    {
        // Deserialize the JSON string into a data object
        Data data = JsonUtility.FromJson<Data>(jsonData);

        // Now you can access the email and token
        Name.text = data.displayName.ToUpper(); 

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
