using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Data", menuName = "Upgrade Data", order = 1)]
public class UpgradeData : ScriptableObject
{
    public Sprite image;
    public int level;
    public float cost;
}
