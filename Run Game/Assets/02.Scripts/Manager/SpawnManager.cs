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

                // ���� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� �ִ��� Ȯ���մϴ�.
                while (spawnList[random].activeSelf)
                {
                    if (FullVehicle()) // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ �Ǿ��ִ��� Ȯ���մϴ�.
                    {
                        // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ����
                        // vehicle�� ����Ʈ�� �־��ݴϴ�.
                        GameObject vehicle = Instantiate(vehicleObject[Random.Range(0, vehicleObject.Length)]);

                        vehicle.SetActive(false);

                        spawnList.Add(vehicle);
                    }

                    // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� ���� �ʴٸ�
                    // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
                    random = (random + 1) % spawnList.Count;
                }

                // �������� ��ġ�� �����ϴ� ������ �����մϴ�.
                randomPos = Random.Range(0, spawnPos.Length);

                // ���࿡ ���� ������ ����Ǿ� �ִ� ������ �ٽ� ���� randomPos�� ���� 
                // compare������ ��ġ�Ѵٸ� �ߺ��� ���� �ʵ��� ����մϴ�.
                if(compare==randomPos)
                {
                    randomPos = (randomPos + 1) % spawnPos.Length;
                }

                // compare ������ random���� ������ ������ ���� �־��ݴϴ�.
                compare = randomPos;

                // vehicle ������Ʈ�� Ȱ��ȭ �Ǵ� ��ġ�� �������� �����մϴ�.
                spawnList[random].transform.position = spawnPos[randomPos].position;

                // �������� ������ vehicle ������Ʈ�� Ȱ��ȭ �մϴ�.
                spawnList[random].SetActive(true);
            }

            yield return CoroutineCache.waitForSeconds(2.5f);
        }
    }
}