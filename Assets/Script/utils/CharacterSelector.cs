using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private CharacterValues[] characters; 
    private CharacterValues currentCharacter;
    private int currentShirt;
    private int currentPant;
    private int currentShoes;
  
    private void Start()
    {
        LoadCharacter();
        SetShirt();
        SetPant();
        SetShoes();
        SetHair();
        SetCap();
        SetGlasses();
    }
    public void LoadCharacter()
    {
        foreach (var character in characters)
        {
            if (DataGp.Instance.User.genders == character.gender && DataGp.Instance.User.characterToUse == character.type)
            {
              currentCharacter = character;
              currentCharacter.Model.SetActive(true);
            }
        }
    }
    public void SetShirt()
    {
        currentCharacter.shirts[DataGp.Instance.User.values.currentShirt].SetActive(true);
        
    }
    public void SetPant()
    {
        currentCharacter.pants[DataGp.Instance.User.values.currentPant].SetActive(true);

    }
    public void SetShoes()
    {
        currentCharacter.shoes[DataGp.Instance.User.values.currentShoe].SetActive(true);

    }
    public void SetHair()
    {
        currentCharacter.hairs[DataGp.Instance.User.values.currentHair].SetActive(true);

    }
    public void SetCap()
    {
        try
        {
            currentCharacter.caps[DataGp.Instance.User.values.currentCap].SetActive(true);
        }
        catch
        {
            Debug.LogError(DataGp.Instance.User.values.currentCap);
        }
    }
    public void SetGlasses()
    {
        currentCharacter.glasses[DataGp.Instance.User.values.currentGlass].SetActive(true);

    }
   
    void SetSkin()
    {
        Material playerColorMat = currentCharacter.baseMeshRenderer.material;
        Color skinColor = new Color(DataGp.Instance.User.values.skinToneValue, DataGp.Instance.User.values.skinToneValue, DataGp.Instance.User.values.skinToneValue);
        playerColorMat.SetColor("_EmissionColor", skinColor);
        DynamicGI.SetEmissive(currentCharacter.baseMeshRenderer, skinColor);
    }
}
