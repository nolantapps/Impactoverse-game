using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArtData", menuName = "ScriptableObjects/ArtDataObject", order = 1)]
public class ArtDataScriptable : ScriptableObject
{
    public ArtType _ArtType;

    public string _ArtName;

    public ArtDetail[] _ArtDetail;
}

[System.Serializable]
public class ArtDetail
{
    public AgeGroup _Agegroup;
    public Sprite _Images;
    public string[] _ArtDetail;
}