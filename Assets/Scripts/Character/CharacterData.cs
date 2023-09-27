using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character", fileName = "CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] public List<DataConfiguration.Attribute> attributes;

    public CharacterData() { }
}
