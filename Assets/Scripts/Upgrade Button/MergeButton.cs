using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeButton : UpgradeButton
{
    bool canMerge;
    MotocycleData mergeInto;
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
        for (int i = level; i >= 0; i--)
        {
            if (cm.MotoList[i].Count < 3) continue;
            if (cm.AvalibleMotos.Count <= i + 1) continue;
            if (cm.AvalibleMotos[i].MergeInto == null) continue;

            SetData(cm.AvalibleMotos[i].MergeData);
            mergeInto = cm.AvalibleMotos[i].MergeInto;
            CanMerge = true;
            break;
        }
    }

    protected override void Upgrade()
    {
        cm.RemoveMoto(cm.AvalibleMotos[mergeInto.Level - 1], 3);
        CanMerge = false;
        cm.AddMoto(mergeInto);
    }
}
