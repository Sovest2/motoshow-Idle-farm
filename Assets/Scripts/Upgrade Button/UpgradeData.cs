using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Data", menuName = "Upgrade Data", order = 1)]
public class UpgradeData : ScriptableObject
{
    [SerializeField] Sprite icon;
    [SerializeField] int level;
    [SerializeField] float cost;

    public Sprite Icon { get { return icon; } }
    public int Level { get { return level; } }
    public float Cost { get { return cost; } }
}
