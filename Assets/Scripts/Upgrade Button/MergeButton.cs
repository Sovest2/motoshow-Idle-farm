using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeButton : UpgradeButton
{
    bool canMerge;
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
            if (cm.AvilibleMotos.Count <= i + 1) continue;
            if (cm.AvilibleMotos[i].MergeInto == null) continue;

            SetData(cm.AvilibleMotos[i].MergeData);
            CanMerge = true;
            break;
        }
    }

    protected override void Upgrade()
    {
        for(int i = cm.MotoList.Count - 1; i >= 0; i--)
        {
            if (cm.MotoList[i].Count < 3) continue;
            if (cm.AvilibleMotos.Count < i + 1) continue;
            if (cm.AvilibleMotos[i].MergeInto == null) continue;

            for (int j = 0; j < 3; j++) cm.RemoveMoto(cm.AvilibleMotos[i]);
            CanMerge = false;
            cm.AddMoto(cm.AvilibleMotos[i + 1]);
            break;
        }
    }
}
