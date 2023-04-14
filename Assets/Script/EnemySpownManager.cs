using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpownManager : MonoBehaviour
{
    private GameObject spawnObj;

    [SerializeField]
    private List<Transform> spawnTrans;

    private void Awake()
    {
        StartCoroutine(SpawnEvent());
    }

    int i;

    IEnumerator SpawnEvent()
    {
        while(true)
        {
            yield return YieldInstructionCache.WaitForSeconds(2.0f);

            for(i = 0; i < 5; i++)
            {
                spawnObj = ObjectPoolManager.Inst.pools[(int)objectType.objT_Enemy_01].Pop();
                spawnObj.transform.position = spawnTrans[i].position;
                spawnObj.transform.rotation = spawnTrans[i].rotation;
            }

        }
    }
}
