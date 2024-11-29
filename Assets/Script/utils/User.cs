using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User 
{
    public string Name { get; set; }
    public Character values;
    public  CharacterToUse characterToUse;
    public Genders genders;
    public string password;
    public string email;
}

public struct Character
{
    public int currentShirt;
    public int currentPant;
    public int currentShoe;
    public int currentHair;
    public int currentCap;
    public int currentGlass;
    public float skinToneValue;
}