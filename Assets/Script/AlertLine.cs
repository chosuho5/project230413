using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertLine : PoolLabel
{
    private Animation anim;

    private void Awake()
    {
        if( !TryGetComponent<Animation>(out anim))
        {
            Debug.Log("컴포넌트를 찾지 못했습니다. - AletLine.cs - Awke");
        }
    }

    public override void InitInfo()
    {
        base.InitInfo();
        anim.Play();  // 애니메이션 재생
        Invoke("SpawnMeteo", 3.5f);        
    }

    private GameObject obj;
    private Vector3 spawnPos;

    private void SpawnMeteo()
    {// 메테오를 생성시키고 자기자신(경고줄)은 반환.
        spawnPos = transform.position;
        spawnPos.y = 5.6f;

        obj = ObjectPoolManager.Inst.pools[(int)objectType.objT_Meteorite_02].Pop();
        obj.transform.position = spawnPos;
        Push();
    }

}
