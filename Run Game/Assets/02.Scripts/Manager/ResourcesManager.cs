using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Create(string path,Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        if (prefab == null)
        {
            Debug.LogError("Faild to load prefab : " + path);
            return null;
        }

        return Instantiate(prefab, parent);
    }

    public void Realese(GameObject prefab)
    {
        if (prefab == null) return;

        Destroy(prefab);
    }
}