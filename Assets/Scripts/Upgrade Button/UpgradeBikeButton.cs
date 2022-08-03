using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBikeButton : UpgradeButton
{
    protected CageManager cm;

    protected override void Start()
    {
        base.Start();
        cm = CageManager.Instance;
    }

    protected override void OnEnable()
    {
        //upgradeData = cm.AvilibleMotos[0];
        base.OnEnable();
    }

    protected override void Upgrade()
    {
        MotocycleData motoData = (MotocycleData) data;
        cm.AddMoto(motoData);
    }
}
