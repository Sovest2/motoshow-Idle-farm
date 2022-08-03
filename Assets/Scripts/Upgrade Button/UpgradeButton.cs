using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] protected Button button;

    [Header("Data")]
    [SerializeField] protected string description;
    [SerializeField] protected UpgradeData data;

    [Header("UI Elements")]
    [SerializeField] protected TMP_Text descriptionText;
    [SerializeField] protected TMP_Text costText;

    protected GameManager gm;
    

    protected virtual void Start()
    {
        gm = GameManager.Instance;
        
    }

    protected virtual void OnEnable()
    {
        descriptionText.text = description;
        SetData(data);
        GameManager.MoneyChanged += OnMoneyChanged;
    }

    protected virtual void OnDisable()
    {
        GameManager.MoneyChanged -= OnMoneyChanged;
    }

    protected virtual void SetData(UpgradeData value)
    {
        data = value;
        costText.text = Utills.FormatNumber(data.Cost);
    }

    protected void OnMoneyChanged()
    {
        button.interactable = gm.Money >= data.Cost;
    }

    public void BuyUpgrade()
    {
        if (gm.Money <= data.Cost) return;
        gm.Money -= data.Cost;
        Upgrade();
    }

    protected virtual void Upgrade()
    {

    }
}
