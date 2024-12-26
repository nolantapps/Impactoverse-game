using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Winz;
using TMPro;
using Invector.vCharacterController;

public class AvatarCustomizer : MonoBehaviour
{
    public static AvatarCustomizer instance;
    public Slider skinToneColorSlider;
    public List<CharacterValues> CharacterSetup;
    [SerializeField] private bool isAllReset;
    [SerializeField] private CharacterToUse characterToUse;
    [SerializeField] private Genders genders;
    bool isMale;
    private CharacterValues currentCharacter;
    public int[] currentIndices = new int[6]; // Stores indices for shirts, pants, shoes, hairs, caps, glasses
    public GameObject LoadingScreen;
    public TMP_Dropdown dropdown;

    // Store the last used hair index
    private int lastUsedHairIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitializeCharacter();
        InitializeAppearance();
        UpdateAppearance();
    }

    public void UpdateShirt()
    {
        currentIndices[0]++;
        if (currentIndices[0] >= currentCharacter.shirts.Length)
        {
            currentIndices[0] = 1; // Skip base index 0
        }
        SetActiveItems(currentCharacter.shirts, currentIndices[0]);
    }

    public void UpdatePant()
    {
        currentIndices[1]++;
        if (currentIndices[1] >= currentCharacter.pants.Length)
        {
            currentIndices[1] = 1; // Skip base index 0
        }
        SetActiveItems(currentCharacter.pants, currentIndices[1]);
    }

    public void UpdateShoes()
    {
        currentIndices[2]++;
        if (currentIndices[2] >= currentCharacter.shoes.Length)
        {
            currentIndices[2] = 1; // Skip base index 0
        }
        SetActiveItems(currentCharacter.shoes, currentIndices[2]);
    }

    public void UpdateHair()
    {
        // If cap is equipped (not 0), prevent hair update visually but store the new index
        if (currentIndices[4] != 0) // Cap is equipped
        {
            lastUsedHairIndex++;
            if (lastUsedHairIndex >= currentCharacter.hairs.Length)
            {
                lastUsedHairIndex = 1; // Skip base index 0
            }
            return;
        }

        // If no cap is equipped, update hair normally
        currentIndices[3]++;
        if (currentIndices[3] >= currentCharacter.hairs.Length)
        {
            currentIndices[3] = 1; // Skip base index 0
        }
        SetActiveItems(currentCharacter.hairs, currentIndices[3]);
    }

    public void UpdateCap()
    {
        currentIndices[4]++;
        if (currentIndices[4] >= currentCharacter.caps.Length)
        {
            currentIndices[4] = 1; // Skip base index 0
        }
        SetActiveItems(currentCharacter.caps, currentIndices[4]);

        // If a cap is equipped, set hair to base index (0)
        if (currentIndices[4] != 0) // Cap is equipped
        {
            currentIndices[3] = 0; // Force hair to base
            SetActiveItems(currentCharacter.hairs, currentIndices[3]);
        }
        else
        {
            // If cap is unequipped, revert to the last used hair index
            currentIndices[3] = lastUsedHairIndex;
            SetActiveItems(currentCharacter.hairs, currentIndices[3]);
        }
    }

    public void UpdateGlasses()
    {
        currentIndices[5]++;
        if (currentIndices[5] >= currentCharacter.glasses.Length)
        {
            currentIndices[5] = 1; // Skip base index 0
        }
        SetActiveItems(currentCharacter.glasses, currentIndices[5]);
    }

    public void UpdatePlayerSkin()
    {
        PlayerSkinColor();
    }

    private void InitializeCharacter()
    {
        characterToUse = DataGp.Instance.User.characterToUse;
        genders = DataGp.Instance.User.genders;
        if (genders == Genders.Male)
        {
            dropdown.value = 0;
        }
        else
        {
            dropdown.value = 1;

        }
        currentCharacter = CharacterSetup.Find(cv => cv.gender == genders && cv.type == characterToUse);
        currentCharacter.Model.SetActive(true);

        currentIndices[0] = DataGp.Instance.User.values.currentShirt;
        
        currentIndices[1] = DataGp.Instance.User.values.currentPant;
        currentIndices[2] = DataGp.Instance.User.values.currentShoe;
        currentIndices[3] = DataGp.Instance.User.values.currentHair;
        currentIndices[4] = DataGp.Instance.User.values.currentCap;
        currentIndices[5] = DataGp.Instance.User.values.currentGlass;

        skinToneColorSlider.value = DataGp.Instance.User.values.skinToneValue;
    }

    private void InitializeAppearance()
    {
        if (currentIndices[0] == 0)
        {
            currentIndices[0] = 1;
        }
        if (currentIndices[1] == 0)
        {
            currentIndices[1] = 1;

        }
        if (currentIndices[3] == 0)
        {
            currentIndices[3] = 1;

        }
        SetActiveItems(currentCharacter.shirts, currentIndices[0]);
        SetActiveItems(currentCharacter.pants, currentIndices[1]);
        SetActiveItems(currentCharacter.shoes, currentIndices[2]);
        SetActiveItems(currentCharacter.glasses, currentIndices[5]);
        PlayerSkinColor();
    }

    private void UpdateAppearance()
    {
        SetActiveItems(currentCharacter.shirts, currentIndices[0]);
        SetActiveItems(currentCharacter.pants, currentIndices[1]);
        SetActiveItems(currentCharacter.shoes, currentIndices[2]);
        SetActiveItems(currentCharacter.hairs, currentIndices[3]);
        //SetActiveItems(currentCharacter.caps, currentIndices[4]);
        SetActiveItems(currentCharacter.glasses, currentIndices[5]);
        PlayerSkinColor();
    }

    private int SetActiveItems(GameObject[] items, int activeIndex)
    {
        if (items == null) return -1;

        if (activeIndex >= items.Length)
        {
            activeIndex = 0; // Loop back to the first item if the index exceeds the array length
        }

        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(i == activeIndex || i == 0); // Ensure 0th index is always active
        }

        return activeIndex;
    }

    public void SaveData()
    {

        DataGp.Instance.User.values.currentShirt = currentIndices[0];
        DataGp.Instance.User.values.currentPant = currentIndices[1];
        DataGp.Instance.User.values.currentShoe = currentIndices[2];
        DataGp.Instance.User.values.currentHair = currentIndices[3];
        DataGp.Instance.User.values.currentCap = currentIndices[4];
        DataGp.Instance.User.values.currentGlass = currentIndices[5];
        DataGp.Instance.User.values.skinToneValue = skinToneColorSlider.value;
        DataGp.Instance.User.genders = genders;
        if (!DataGp.Instance.isChild)
        {
            APIManager.Instance.UpdateCharacter();

        }

        Debug.Log("Shirt: " + currentIndices[0]);
        Debug.Log("Pant: " + currentIndices[1]);
        Debug.Log("Shoe: " + currentIndices[2]);
        Debug.Log("Hair: " + currentIndices[3]);
        Debug.Log("Cap: " + currentIndices[4]);
        Debug.Log("Glasses: " + currentIndices[5]);
        Debug.Log("SkinToneValueis: " + skinToneColorSlider.value);
        Debug.Log("genders: " +genders);
        LoadingScreen.SetActive(true);
        Invoke(nameof(ChangeScene), 3);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    private void PlayerSkinColor()
    {
        if (!currentCharacter.baseMeshRenderer) return;

        Material playerColorMat = currentCharacter.baseMeshRenderer.material;
        Color skinColor = new Color(skinToneColorSlider.value, skinToneColorSlider.value, skinToneColorSlider.value);
        playerColorMat.SetColor("_EmissionColor", skinColor);
        DynamicGI.SetEmissive(currentCharacter.baseMeshRenderer, skinColor);
    }
    public void GenderChange()
    {
        foreach (var item in CharacterSetup)
        {
            item.Model.SetActive(false);
        }
        DataGp.Instance.User.values.currentShirt = currentIndices[0];
        DataGp.Instance.User.values.currentPant = currentIndices[1];
        DataGp.Instance.User.values.currentShoe = currentIndices[2];
        DataGp.Instance.User.values.currentHair = currentIndices[3];
        DataGp.Instance.User.values.currentCap = currentIndices[4];
        DataGp.Instance.User.values.currentGlass = currentIndices[5];
        DataGp.Instance.User.values.skinToneValue = skinToneColorSlider.value;
        if (genders == Genders.Male)
        {
            
            DataGp.Instance.User.genders = Genders.Female;
        }
        else
        {
            DataGp.Instance.User.genders = Genders.Male;
        }
        InitializeCharacter();
        InitializeAppearance();
        UpdateAppearance();

    }
}

[System.Serializable]
public struct CharacterValues
{
    public CharacterToUse type;
    public Genders gender;
    public GameObject Model;
    public GameObject[] shirts, pants, shoes, hairs, caps, glasses, allMesh;
    public Renderer baseMeshRenderer;
    public vThirdPersonController controller;

}

public enum Genders { Male, Female }
public enum CharacterToUse { Child, Adult }
