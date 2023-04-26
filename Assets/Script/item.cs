using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Item",fileName ="NewItem")]
public class item : ScriptableObject
{
    public string itemName;
    public string itemDes;
    public Sprite itemSprite;
    public Ty tye;
    public int value;

    public enum Ty
    {
        hp,
        mp
    }
}
