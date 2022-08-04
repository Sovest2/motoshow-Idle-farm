using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeButton : UpgradeButton
{
    bool canMerge;

    MotocycleData mergeInto;
    MotocycleData mergesFrom;

    bool CanMerge 
    {
        get { return canMerge; }
        set
        {
            canMerge = value;
            button.gameObject.SetActive(canMerge);
        }
    }
    CageManager cm;

    protected override void Start()
    {
        base.Start();
        cm = CageManager.Instance;
        button.gameObject.SetActive(false);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        CageManager.BikesCountChanged += OnBikeAdded;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        CageManager.BikesCountChanged -= OnBikeAdded;
    }

    void OnBikeAdded(int level)
    {
        for (int i = level + 1; i >= 0; i--)
        {
            if (cm.AvalibleMotos.Count <= i) continue;
            MotocycleData motoData = cm.AvalibleMotos[i];
            if (motoData.MergesFrom == null) continue;
            if (cm.MotoList[motoData.MergesFrom.Level].Count < 3) continue;

            SetData(motoData.MergeData);
            mergeInto = motoData;
            mergesFrom = motoData.MergesFrom;
            CanMerge = true;
            break;
        }
    }

    protected override void Upgrade()
    {
        cm.RemoveMoto(mergesFrom, 3);

        NotificationManager.Instance.CreateNotificationWithText(1.5f, $"3x bikes of Level {mergesFrom.Level} merged into 1x Level {mergeInto.Level}");
        CanMerge = false;

        cm.AddMoto(mergeInto);
    }
}
