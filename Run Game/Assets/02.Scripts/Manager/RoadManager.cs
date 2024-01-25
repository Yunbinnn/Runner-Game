using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] float offset = 25.0f;
    [SerializeField] List<GameObject> roadList;

    void Start()
    {
        roadList.Capacity = 10;
    }

    void Update()
    {
        if (!GameManager.Instance.state) return;

        for (int i = 0; i < roadList.Count; i++)
        {
            roadList[i].transform.Translate(GameManager.Instance.speed * Time.deltaTime * Vector3.back);
        }
    }

    public void NewPosition()
    {
        GameObject newRoad = roadList[0];

        roadList.Remove(newRoad);

        float newZ = roadList[^1].transform.position.z + offset;

        newRoad.transform.position = new Vector3(0, 0, newZ);

        roadList.Add(newRoad);
    }
}