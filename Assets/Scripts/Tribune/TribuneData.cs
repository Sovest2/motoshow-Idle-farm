using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tribune Data", menuName = "Tribune Data", order = 1)]
public class TribuneData : UpgradeData
{
    [SerializeField] float incomeTime;
    [SerializeField] float income;
    [SerializeField] GameObject gfxPregab;

    public float IncomeTime { get { return incomeTime; } }
    public float Income { get { return income; } }
    public GameObject GfxPrefab { get { return gfxPregab; } }
}
