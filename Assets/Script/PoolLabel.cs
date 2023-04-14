using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolLabel : MonoBehaviour
{
    protected ObjectPool pool;

    public virtual void Create(ObjectPool pool)
    {
        this.pool = pool;
        gameObject.SetActive(false);
    }

    // 오브젝트 풀에 반환될때처리.
    public virtual void Push()
    {
        pool.Push(this);
    }
    // 오브젝트 풀에서 꺼내서 쓸때 초기화.
    public virtual void InitInfo()
    {

    }

}
