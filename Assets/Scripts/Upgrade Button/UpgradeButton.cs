using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] Image upgradeImage;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text costText;

    [SerializeField] string description;
    [SerializeField] UpgradeData upgradeData;

    GameManager gm;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        gm = GameManager.Instance;

        descriptionText.text = description;
        upgradeImage.sprite = upgradeData.image;
        levelText.text = $"Level {upgradeData.level}";
        costText.text = Utills.FormatNumber(upgradeData.cost);

        GameManager.MoneyChanged += OnMoneyChanged;
    }

    void OnDestroy()
    {
        GameManager.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged()
    {
        button.interactable = gm.Money >= upgradeData.cost;
    }

    public void BuyUpgrade()
    {
        if (gm.Money <= upgradeData.cost) return;
        gm.Money -= upgradeData.cost;
        Upgrade();
    }

    protected virtual void Upgrade()
    {

    }
}
