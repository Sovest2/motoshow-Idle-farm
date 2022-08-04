using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cage Data", menuName = "Cage Data", order = 1)]
public class CageData : UpgradeData
{
    [SerializeField] int maxBikes;
    [SerializeField] GameObject gfxPregab;

    public int MaxBikes { get { return maxBikes; } }
    public GameObject GfxPrefab { get { return gfxPregab; } }
}
