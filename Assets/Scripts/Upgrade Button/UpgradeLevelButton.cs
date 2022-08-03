using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeLevelButton : UpgradeButton
{
    [Header("Level UI Elements")]
    [SerializeField] protected Image upgradeImage;
    [SerializeField] protected TMP_Text levelText;

    protected override void Start()
    {
        base.Start();
        levelText.text = $"Level {data.Level}";
        upgradeImage.sprite = data.Icon;
    }

}
