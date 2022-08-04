using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tribune : MonoBehaviour
{
    public static Action<float> IncomeAcqired;
    [SerializeField] TribuneData data;

    GameObject gfx;
    Coroutine incomeCoroutine;

    public TribuneData Data
    {
        get { return data; }
        private set { data = value; }
    }

    void Start()
    {
        if(data != null) SetData(data);
    }

    public void SetData(TribuneData data)
    {
        Data = data;
        if (gfx != null) Destroy(gfx);
        gfx = Instantiate(data.GfxPrefab, transform);
        if(incomeCoroutine == null)
        {
            incomeCoroutine = StartCoroutine(MakeIncome());
        }
    }

    IEnumerator MakeIncome()
    {
        while (true)
        {
            yield return new WaitForSeconds(Data.IncomeTime);
            IncomeAcqired?.Invoke(Data.Income);
        }
    }
}
