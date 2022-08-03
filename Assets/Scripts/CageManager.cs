using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageManager : MonoBehaviour
{
    public static CageManager Instance { get; private set; }

    public static Action<int> BikesCountChanged;

    [SerializeField] Transform bikesParent;
    [SerializeField] List<MotocycleData> avilibleMotos;


    public List<Queue<Motocycle>> MotoList { get; private set; } = new List<Queue<Motocycle>>();
    public List<MotocycleData> AvilibleMotos { get { return avilibleMotos; } }

    void Awake()
    {
        Instance = this;
    }

    public void AddMoto(MotocycleData data)
    {
        if (MotoList.Count - 1 < data.Level)
            MotoList.Add(new Queue<Motocycle>());

        float yRotation = UnityEngine.Random.Range(0f, 360f);
        float zRotation = UnityEngine.Random.Range(0f, 90f);

        Motocycle motocycle = Instantiate(data.Prefab, transform.position, Quaternion.Euler(0, yRotation, zRotation));
        motocycle.transform.parent = bikesParent;
        motocycle.Data = data;
        MotoList[data.Level].Enqueue(motocycle);

        BikesCountChanged?.Invoke(data.Level);
    }

    public void RemoveMoto(MotocycleData data)
    {
        if (MotoList.Count - 1 < data.Level)
            throw new Exception("This level doesn't exists");

        if (MotoList[data.Level].Count <= 0)
            throw new Exception("There is no bike of that level");

        Motocycle motocycle = MotoList[data.Level].Dequeue();
        Destroy(motocycle.gameObject);
        BikesCountChanged?.Invoke(data.Level);
    }
}
