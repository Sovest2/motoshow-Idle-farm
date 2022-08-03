using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageManager : MonoBehaviour
{
    [SerializeField] Motocycle motoPrefab;

    Queue<Motocycle> motoQueque = new Queue<Motocycle>();


    public void SpawnMoto()
    {
        float yRotation = Random.Range(0f, 360f);
        float zRotation = Random.Range(0f, 90f);
        Motocycle moto = Instantiate(motoPrefab, transform.position, Quaternion.Euler(0, yRotation, zRotation));
        motoQueque.Enqueue(moto);
    }
}
