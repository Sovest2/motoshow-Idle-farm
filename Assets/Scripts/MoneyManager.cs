using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] float changingTime;

    float displayValue = 0;
    float DisplayValue 
    {
        get { return displayValue; }
        set 
        { 
            displayValue = value;
            moneyText.text = Utills.FormatNumber(displayValue);
        }
    }

    GameManager gm;
    Coroutine moneyChanging;

    void Start()
    {
        gm = GameManager.Instance;
        GameManager.MoneyChanged += OnMoneyChanged;
    }

    void OnDestroy()
    {
        GameManager.MoneyChanged -= OnMoneyChanged;
    }

    void OnMoneyChanged()
    {
        if (moneyChanging != null) StopCoroutine(moneyChanging);
        moneyChanging = StartCoroutine(ChangeDispalyMoney());
    }

    IEnumerator ChangeDispalyMoney()
    {
        for(float i = 0; i <= changingTime; i+= Time.deltaTime / changingTime)
        {
            DisplayValue = Mathf.Lerp(DisplayValue, gm.Money, i / changingTime);
            yield return null;
        }

        DisplayValue = gm.Money;
    }

    


}
