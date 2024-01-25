using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnList;

    [SerializeField] Transform[] spawnPos;
    [SerializeField] GameObject[] vehicleObject;

    [SerializeField] int count;
    [SerializeField] int random;
    [SerializeField] int randomPos;
    int compare = -1;
    int disableCount;

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
            GameObject vehicle = Instantiate(vehicleObject[i]);

            vehicle.SetActive(false);

            spawnList.Add(vehicle);
        }
    }

    public bool FullVehicle()
    {
        for(int i = 0;i < spawnList.Count; i++)
        {
            if (!spawnList[i].activeSelf) return false;
        }

        return true;
    }

    IEnumerator ActiceVehicle()
    {
        while (GameManager.Instance.state)
        {
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                random = Random.Range(0, vehicleObject.Length);

                // 현재 게임 오브젝트가 활성화 되어 있는지 확인합니다.
                while (spawnList[random].activeSelf)
                {
                    if (FullVehicle()) // 현재 리스트에 있는 모든 게임 오브젝트가 활성화 되어있는지 확인합니다.
                    {
                        // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                        // vehicle을 리스트에 넣어줍니다.
                        GameObject vehicle = Instantiate(vehicleObject[Random.Range(0, vehicleObject.Length)]);

                        vehicle.SetActive(false);

                        spawnList.Add(vehicle);
                    }

                    // 현재 리스트에 있는 모든 게임 오브젝트가 활성화 되어 있지 않다면
                    // random 변수의 값을 +1을 해서 다시 검색합니다.
                    random = (random + 1) % spawnList.Count;
                }

                // 랜덤으로 위치를 설정하는 변수를 선언합니다.
                randomPos = Random.Range(0, spawnPos.Length);

                // 만약에 내가 이전에 저장되어 있던 변수와 다시 뽑은 randomPos의 값이 
                // compare변수와 일치한다면 중복이 되지 않도록 계산합니다.
                if(compare==randomPos)
                {
                    randomPos = (randomPos + 1) % spawnPos.Length;
                }

                // compare 변수와 random으로 설정된 변수의 값을 넣어줍니다.
                compare = randomPos;

                // vehicle 오브젝트가 활성화 되는 위치를 랜덤으로 설정합니다.
                spawnList[random].transform.position = spawnPos[randomPos].position;

                // 랜덤으로 설정된 vehicle 오브젝트를 활성화 합니다.
                spawnList[random].SetActive(true);
            }

            yield return CoroutineCache.waitForSeconds(2.5f);
        }
    }
}