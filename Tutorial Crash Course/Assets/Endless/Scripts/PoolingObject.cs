using System.Collections.Generic;
using UnityEngine;
public class PoolingObject<T> where T : MonoBehaviour
{
    private Stack<T> pool;
    private T prefab;
    private Transform parentTrans;

    public PoolingObject(T prefab, int CoutInit, Transform parent = null)
    {
        this.prefab = prefab;
        this.parentTrans = parent;
        pool = new Stack<T>(CoutInit);
        //  a(CoutInit);
    }

    private void AddGameObject(int cout)
    {
        for (int i = 0; i < cout; i++)
        {
            T obj = Object.Instantiate(prefab, parentTrans);
            obj.gameObject.SetActive(false); // Vô hiệu hóa đối tượng sau khi tạo
            pool.Push(obj); // Đưa đối tượng vào stack
        }
    }


    public T GetObject()
    {
        if (pool.Count > 0)
        {
            T obj = pool.Pop();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T obj = Object.Instantiate(prefab, parentTrans);
            return obj;
        }
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Push(obj);
    }

}
