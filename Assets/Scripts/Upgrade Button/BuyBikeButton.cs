using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBikeButton : UpgradeButton
{
    protected CageManager cm;
    bool canUpgrade;
    public bool CanUpgrade
    {
        get { return canUpgrade; }
        private set
        {
            canUpgrade = value;
            button.gameObject.SetActive(canUpgrade);
        }
    }

    protected override void Start()
    {
        base.Start();
        cm = CageManager.Instance;
        CageManager.CageUpgraded += CheckCanUpgrade;
        CageManager.BikesCountChanged += OnBikesCountChanged;
    }

    private void OnDestroy()
    {
        CageManager.CageUpgraded -= CheckCanUpgrade;
        CageManager.BikesCountChanged -= OnBikesCountChanged;
    }

    protected override void Upgrade()
    {
        MotocycleData motoData = (MotocycleData) data;
        cm.AddMoto(motoData);
        NotificationManager.Instance.CreateNotificationWithText(1.5f, "New bike added");
    }

    void OnBikesCountChanged(int level) => CheckCanUpgrade();

    void CheckCanUpgrade()
    {
        print($"Max: {cm.Data.MaxBikes}\nTotal: {cm.TotalBikes}");
        CanUpgrade = cm.Data.MaxBikes > cm.TotalBikes;
    }
}
