using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Motocycle Data", menuName = "Motocycle Data", order = 1)]
public class MotocycleData : UpgradeData
{
    [SerializeField] float income;
    [SerializeField] Motocycle prefab;

    [SerializeField] MotocycleData mergeInto;
    [SerializeField] UpgradeData mergeData;

    public float Income { get { return income; } }
    public Motocycle Prefab { get { return prefab;} }
    public MotocycleData MergeInto { get { return mergeInto; } }
    public UpgradeData MergeData { get { return mergeData; } }
}
