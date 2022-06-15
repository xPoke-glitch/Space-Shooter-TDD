using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : Singleton<GenericObjectPool<T>>, IObjectPool<T> where T : Component
{
    [SerializeField] 
    private T prefab;

    private Queue<T> objects = new Queue<T>();

    public void SetPrefab(T prefab)
    {
        this.prefab = prefab;
    }

    public T Get()
    {
        if (objects.Count == 0)
        {
            AddObject(1);
        }
        return objects.Dequeue();
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }

    private void AddObject(int count)
    {
        var newObject = GameObject.Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        objects.Enqueue(newObject);
    }
}
