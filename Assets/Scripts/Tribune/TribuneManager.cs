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

    [SerializeField] List<TribuneData> avalibleTribunes;
    public List<TribuneData> AvalibleTribunes { get { return avalibleTribunes; } }

    public Queue<Tribune> Tribunes { get; private set; } = new Queue<Tribune>();

    [SerializeField] float totalIncomeMultiplier = 1;
    CageManager cm;
    GameManager gm;

    private void Awake()
    {
        Instance = this;

        Tribunes.Enqueue(center);
        Tribunes.Enqueue(left);
        Tribunes.Enqueue(right);
    }
    void Start()
    {
        cm = CageManager.Instance;
        gm = GameManager.Instance;

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
            totalIncomeMultiplier *= Mathf.Pow(motoQueue.Peek().Data.IncomeMultiplier, motoQueue.Count);
        }
    }

    void OnIncomeAcqired(float income)
    {
        gm.Money += income * totalIncomeMultiplier;
    }
}
