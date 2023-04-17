using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorLiteSpawnManager : MonoBehaviour
{
    [SerializeField]
    private float meteoSpawnRate;

    private void Awake()
    {
        StartCoroutine("SpawnAlerLine");
    }

    private GameObject obj;
    private Vector3 pos;

    IEnumerator SpawnAlerLine()
    {
        while(true)
        {
            yield return YieldInstructionCache.WaitForSeconds(meteoSpawnRate);

            obj = ObjectPoolManager.Inst.pools[(int)objectType.objT_Meteorite_01].Pop();
            pos.x = Random.Range(-2.65f, 2.65f);
            pos.y = 0f;
            pos.z = 0f;


            obj.transform.position = pos;
        }
    }
}
