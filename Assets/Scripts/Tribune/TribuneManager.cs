using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribuneManager : MonoBehaviour
{
    public static TribuneManager Instance { get; private set; }

    [Header("Tribunes")]
    [SerializeField] Tribune left;
    [SerializeField] Tribune center;
    [SerializeField] Tribune right;

    Queue<Tribune> tribunes = new Queue<Tribune>();

    float totalIncomeMultiplier = 1;
    CageManager cm;
    GameManager gm;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        cm = CageManager.Instance;
        gm = GameManager.Instance;

        tribunes.Enqueue(center);
        tribunes.Enqueue(left);
        tribunes.Enqueue(right);

        CageManager.BikesCountChanged += OnBikesCountChanged;
        Tribune.IncomeAcqired += OnIncomeAcqired;
    }

    void OnDestroy()
    {
        CageManager.BikesCountChanged -= OnBikesCountChanged;
        Tribune.IncomeAcqired -= OnIncomeAcqired;
    }


    void OnBikesCountChanged(int level)
    {
        totalIncomeMultiplier = 1f;
        foreach(Queue<Motocycle> motoQueue in cm.MotoList)
        {
            if (motoQueue.Count <= 0) continue;
            totalIncomeMultiplier *= motoQueue.Count * motoQueue.Peek().Data.IncomeMultiplier;
        }
    }

    void OnIncomeAcqired(float income)
    {
        gm.Money += income * totalIncomeMultiplier;
    }
}
