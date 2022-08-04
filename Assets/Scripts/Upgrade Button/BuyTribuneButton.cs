using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTribuneButton : UpgradeLevelButton
{
    TribuneManager tm;

    bool canUpgrade;
    public bool CanUpgrade 
    { 
        get { return canUpgrade;}
        private set 
        {
            canUpgrade = value;
            button.gameObject.SetActive(value);
        }
    }

    protected override void Start()
    {
        base.Start();
        tm = TribuneManager.Instance;
        CheckCanUpgrade();
    }

    protected override void Upgrade()
    {
        Tribune tribune = tm.Tribunes.Dequeue();
        tribune.SetData((TribuneData)data);
        tm.Tribunes.Enqueue(tribune);
        NotificationManager.Instance.CreateNotificationWithText(2f, "Tribune upgraded");
        CheckCanUpgrade();
    }

    void CheckCanUpgrade()
    {
        Tribune tribune = tm.Tribunes.Peek();
        if(tribune.Data == null)
        {
            CanUpgrade = true;
            SetData(tm.AvalibleTribunes[0]);
            return;
        }

        CanUpgrade = tribune.Data.Level < tm.AvalibleTribunes.Count - 1;
        if(CanUpgrade) SetData(tm.AvalibleTribunes[tribune.Data.Level + 1]);
    }
}
