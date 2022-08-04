using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBikeButton : UpgradeButton
{
    protected CageManager cm;

    protected override void Start()
    {
        base.Start();
        cm = CageManager.Instance;
    }

    protected override void Upgrade()
    {
        MotocycleData motoData = (MotocycleData) data;
        cm.AddMoto(motoData);
        NotificationManager.Instance.CreateNotificationWithText(1.5f, "New bike added");
    }
}
