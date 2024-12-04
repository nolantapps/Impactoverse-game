using UnityEngine;
using TMPro;
using GameAnalyticsSDK;
using System;
using UnityEngine.Analytics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
public class DataReceiver : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Error;
    
    public void Start()
    {
       
        
    }
  
    // This method will be called from JavaScript


    public void ReceiveData(string jsonData )
    {
        string[] strings = jsonData.Split('|');
        string user ="";
        string isChild ="";
        if (strings.Length == 2)
        {
            user = strings[0];
            isChild = strings[1];

            Debug.Log($"user: {user}");
            Debug.Log($"isChild: {isChild}");
        }
        else
        {
            Debug.LogError("Unexpected data format received.");
        }
        Debug.Log($"Received JSON: {user}");
        try
        {
            // Step 1: If jsonData is stringified, attempt to deserialize it
            // The jsonData might be a string with escaped characters.
            // First, let's parse the string to get the raw JSON content.

            // Deserialize the stringified JSON
            if (isChild == "true")
            {
                DataGp.Instance.isChild = true;
                DataGp.Instance.User.characterToUse = CharacterToUse.Child;
                DataGp.Instance.User.Name = "Child";
                DataGp.Instance.User.values.currentShirt =UnityEngine.Random.Range(1,6);
                DataGp.Instance.User.values.currentPant = UnityEngine.Random.Range(1, 6);
                DataGp.Instance.User.values.currentHair = UnityEngine.Random.Range(1, 6);
                DataGp.Instance.User.values.currentCap = UnityEngine.Random.Range(1, 6);
                DataGp.Instance.User.values.currentShoe = UnityEngine.Random.Range(1, 6);
                DataGp.Instance.User.values.skinToneValue = UnityEngine.Random.Range(1, 6);
                DataGp.Instance.User.email = "NoEmail";
                DataGp.Instance.User.password = "NoPassword";
                int test = UnityEngine.Random.Range(0, 2);
                if (test == 0)
                {
                    DataGp.Instance.User.genders = Genders.Male;

                }
                else
                {
                    DataGp.Instance.User.genders = Genders.Female;

                }
                Name.text = "";
                
                Debug.Log("Child Enter");
            }
            else
            {
                    var deserializedJson = JsonConvert.DeserializeObject(user);
                    // Now, get the actual stringified JSON from the object and parse it again.
                    string rawJson = deserializedJson.ToString();
                    // Step 2: Deserialize the actual JSON object into the User class
                    User userData = JsonConvert.DeserializeObject<User>(rawJson);
                    DataGp.Instance.isChild = false;
                    DataGp.Instance.User.Name = userData.publicProfile.displayName;
                    DataGp.Instance.User.characterToUse = CharacterToUse.Adult;
                    DataGp.Instance.User.values.currentShirt = userData.character.shirt;
                    DataGp.Instance.User.values.currentPant = userData.character.pant;
                    DataGp.Instance.User.values.currentHair = userData.character.hair;
                    DataGp.Instance.User.values.currentCap = userData.character.cap;
                    DataGp.Instance.User.values.currentShoe = userData.character.shoes;
                    DataGp.Instance.User.values.skinToneValue = userData.character.skin;
                    DataGp.Instance.User.email = userData.id;
                    DataGp.Instance.User.password = userData.privateProfile.password;
                    if (userData.character.gender == 'M')
                    {
                        DataGp.Instance.User.genders = Genders.Male;
                    }
                    else
                    {
                        DataGp.Instance.User.genders = Genders.Female;

                    }
                Name.text = userData.publicProfile.displayName;
                // Log the user data for verification
                     Debug.Log($"User ID: {userData.id}");
                    Debug.Log($"User Display Name: {userData.publicProfile.displayName}");

                
            }
            


        }
        catch (Exception ex)
        {
            Debug.LogError($"Error deserializing JSON: {ex.Message}");
        }
        GameAnalyticsSDK.GameAnalytics.Initialize();

    }



    [Serializable]
    public class User
    {
        public string id;
        [JsonConverter(typeof(StringEnumConverter))]
        public PlatformType platformType;
        public PublicProfile publicProfile;
        public ProtectedProfile protectedProfile;
        public PrivateProfile privateProfile;
        public Character character;
    }

    [Serializable]
    public class PublicProfile
    {
        public string id;
        public string displayName;
        public string avatarUrl;
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender gender;
        public string dob;
        public string country;
    }

    [Serializable]
    public class ProtectedProfile
    {
        public string sessionToken;
        public bool emailVerified;
        public int impactTokens;
        [JsonConverter(typeof(StringEnumConverter))]
        public MembershipStatus membershipStatus;
    }

    [Serializable]
    public class PrivateProfile
    {
        public string password;
        [JsonConverter(typeof(StringEnumConverter))]
        public LoginType loginType;
        public int otp;
    }

    [Serializable]
    public class Character
    {
        public int shirt;
        public int pant;
        public int shoes;
        public int hair;
        public int cap;
        public int glass;
        public char gender;
        public float skin;
    }
}
