using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnList;

    [SerializeField] GameObject[] spawnPos;
    [SerializeField] GameObject[] vehicleObject;

    [SerializeField] int count;
    [SerializeField] int random;
    [SerializeField] int randomPos;

    void Start()
    {
        spawnList.Capacity = 56;

        Create();
        StartCoroutine(ActiceVehicle());
    }

    public void Create()
    {
        for (int i = 0; i < vehicleObject.Length; i++)
        {
            GameObject vehicle = Instantiate(vehicleObject[i], spawnPos[Random.Range(0, 3)].transform);
            
            vehicle.SetActive(false);

            spawnList.Add(vehicle);
        }
    }

    IEnumerator ActiceVehicle()
    {
        while (true)
        {
            random = Random.Range(0, vehicleObject.Length);

            while (spawnList[random].activeSelf)
            {
                count++;

                if (count >= vehicleObject.Length)
                {
                    yield break;
                }

                random = (random + 1) % vehicleObject.Length;
            }
            
            spawnList[random].SetActive(true);

            yield return new WaitForSeconds(2.5f);
        }
    }
}