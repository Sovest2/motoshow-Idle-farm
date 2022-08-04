using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageManager : MonoBehaviour
{
    public static CageManager Instance { get; private set; }

    public static Action<int> BikesCountChanged;

    [SerializeField] Transform bikesParent;
    [SerializeField] List<MotocycleData> avalibleMotos;


    public List<Queue<Motocycle>> MotoList { get; private set; } = new List<Queue<Motocycle>>();
    public List<MotocycleData> AvalibleMotos { get { return avalibleMotos; } }

    public int TotalBikes { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void AddMoto(MotocycleData data, int count = 1)
    {
        if (count <= 0) throw new Exception("Incorrect count");

        if (MotoList.Count - 1 < data.Level)
            MotoList.Add(new Queue<Motocycle>());


        for(int i =0; i < count; i++)
        {
            float yRotation = UnityEngine.Random.Range(0f, 360f);
            float zRotation = UnityEngine.Random.Range(0f, 90f);

            Motocycle motocycle = Instantiate(data.Prefab, transform.position, Quaternion.Euler(0, yRotation, zRotation));
            motocycle.transform.parent = bikesParent;
            motocycle.Data = data;
            MotoList[data.Level].Enqueue(motocycle);
        }

        TotalBikes+= count;

        BikesCountChanged?.Invoke(data.Level);
    }

    public void RemoveMoto(MotocycleData data, int count = 1)
    {
        if (count <= 0) throw new Exception("Incorrect count");

        if (MotoList.Count - 1 < data.Level)
            throw new Exception("This level doesn't exists");

        if (MotoList[data.Level].Count < count)
            throw new Exception("There is not enough bikes of that level");

        for (int i = 0; i < count; i++)
        {
            Motocycle motocycle = MotoList[data.Level].Dequeue();
            Destroy(motocycle.gameObject);
        }
        TotalBikes-=count;

        BikesCountChanged?.Invoke(data.Level);
    }
}
