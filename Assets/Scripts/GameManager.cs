using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action MoneyChanged;
    public static GameManager Instance { get; private set; }

    [SerializeField] float money = 0;
    public float Money
    {
        get { return money; }
        set 
        {
            money = value;
            MoneyChanged?.Invoke();
        }
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        MoneyChanged?.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Money += 500;
    }


}
