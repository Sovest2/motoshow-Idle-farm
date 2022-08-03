using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Motocycle Data", menuName = "Motocycle Data", order = 1)]
public class MotocycleData : UpgradeData
{
    [SerializeField] float income;
    [SerializeField] Motocycle prefab;

    public float Income { get { return income; } }
    public Motocycle Prefab { get { return prefab;} }
}
