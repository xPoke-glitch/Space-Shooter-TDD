using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPool<T> where T : Component
{
    public void SetPrefab(T prefab);
    public T Get();
    public void ReturnToPool(T objectToReturn);

}
