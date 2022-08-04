using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Motocycle Data", menuName = "Motocycle Data", order = 1)]
public class MotocycleData : UpgradeData
{
    [SerializeField] float incomeMultiplier;
    [SerializeField] Motocycle prefab;

    [SerializeField] MotocycleData mergesFrom;
    [SerializeField] UpgradeData mergeData;

    public float IncomeMultiplier { get { return incomeMultiplier; } }
    public Motocycle Prefab { get { return prefab;} }
    public MotocycleData MergesFrom { get { return mergesFrom; } }
    public UpgradeData MergeData { get { return mergeData; } }
}
