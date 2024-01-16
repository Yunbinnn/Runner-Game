using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] List<GameObject> roadList;

    void Start()
    {
        roadList.Capacity = 10;
    }

    void Update()
    {
        for (int i = 0; i < roadList.Count; i++)
        {
            roadList[i].transform.Translate(speed * Time.deltaTime * Vector3.back);
        }
    }
}