using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum objectType
{
    objT_Projectile_01,
    objT_Projectile_02,
    objT_Projectile_03,
    objT_Projectile_04,
    objT_Projectile_05,
    objT_Projectile_06,
    objT_Enemy_01,
    objT_Enemy_02,
    objT_Enemy_03,
    objT_Efeect_01,
    objT_Efeect_02,
};

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager instance;
    public static ObjectPoolManager Inst
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;
    }
    public List<ObjectPool> pools;
}
