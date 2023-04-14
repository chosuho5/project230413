using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject poolObj; // 풀에서 관리할 오브젝트 프리펩
    [SerializeField]
    private int allocateCount;  // 풀에 오브젝트를 생성할떄 몇개씩 생성할지

    private Stack<PoolLabel> poolStack = new Stack<PoolLabel>();
    private int objMaxCount;
    private int objActiveCount;

    private void Awake()
    {
        objMaxCount = 0;
        objActiveCount = 0;
        Allocate();
    }

    private int i;
    GameObject allocateObj;

    public void Allocate()
    {
        for(int i = 0; i < allocateCount; i++)
        {
            PoolLabel objLabel;
            allocateObj = Instantiate(poolObj, this.transform);
            if (allocateObj.TryGetComponent<PoolLabel>(out objLabel))
            {
                objLabel.Create(this);
                poolStack.Push(objLabel);
                objMaxCount++;
            }
        }    
    }

    public GameObject Pop()
    {
        if (objActiveCount >= objMaxCount)
            Allocate();

        PoolLabel obj = poolStack.Pop();
        obj.gameObject.SetActive(true);
        obj.InitInfo(); // 오브젝트를 꺼낼때마다 오브젝트 초기화
        objActiveCount++;
        return obj.gameObject;
    }
        public void Push(PoolLabel obj)
        {
        obj.gameObject.SetActive(false);
        poolStack.Push(obj);
        objActiveCount--;
        }
}
