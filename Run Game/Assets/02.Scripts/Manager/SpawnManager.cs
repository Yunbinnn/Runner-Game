using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnList;

    [SerializeField] Transform[] spawnPos;
    [SerializeField] GameObject[] vehicleObject;
    private GameObject[] childObject = new GameObject[2];

    [SerializeField] int count;
    [SerializeField] int random;
    [SerializeField] int randomPos;
    int disableCount;
    int a = 0;

    void Start()
    {
        spawnList.Capacity = 56;

        randomPos = Random.Range(0, spawnPos.Length);

        Create();

        StartCoroutine(ActiceVehicle());
    }

    public void Create()
    {
        for (int i = 0; i < vehicleObject.Length; i++)
        {
            // vehicle 오브젝트가 활성화 되는 위치를 랜덤으로 설정합니다.
            GameObject vehicle = Instantiate(vehicleObject[i], spawnPos[randomPos]);

            // 랜덤으로 위치를 설정하는 변수를 선언합니다.
            randomPos = Random.Range(0, spawnPos.Length);

            vehicle.SetActive(false);

            spawnList.Add(vehicle);
        }
    }

    IEnumerator ActiceVehicle()
    {
        while (true)
        {
            for (int a = 0; a < vehicleObject.Length - 53; a++)
            {
                random = Random.Range(0, vehicleObject.Length);

                while (spawnList[random].activeSelf)
                {
                    if (count++ >= vehicleObject.Length)
                    {
                        CheckDisableVehicle();

                        if(count >= vehicleObject.Length)
                            yield break;
                    }

                    random = (random + 1) % vehicleObject.Length;
                }

                childObject[a] = spawnList[random];
            }

            if (childObject[a].transform.parent != childObject[a + 1].transform.parent)
            {
                for (int i = 0; i < childObject.Length; i++)
                {
                    // 랜덤으로 설정된 vehicle 오브젝트를 활성화 합니다.
                    childObject[i].SetActive(true);
                }
            }
            else childObject[Random.Range(0, childObject.Length)].SetActive(true);

            yield return new WaitForSeconds(2f);
        }
    }

    private void CheckDisableVehicle()
    {
        for (int j = 0; j < vehicleObject.Length; j++)
        {
            if (!vehicleObject[j].activeSelf)
            {
                disableCount++;
            }
        }

        count -= disableCount;

        StartCoroutine(ActiceVehicle());
    }
}