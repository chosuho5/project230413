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
            Debug.Log("������Ʈ�� ã�� ���߽��ϴ�. - AletLine.cs - Awke");
        }
    }

    public override void InitInfo()
    {
        base.InitInfo();
        anim.Play();  // �ִϸ��̼� ���
        Invoke("SpawnMeteo", 3.5f);        
    }

    private GameObject obj;
    private Vector3 spawnPos;

    private void SpawnMeteo()
    {// ���׿��� ������Ű�� �ڱ��ڽ�(�����)�� ��ȯ.
        spawnPos = transform.position;
        spawnPos.y = 5.6f;

        obj = ObjectPoolManager.Inst.pools[(int)objectType.objT_Meteorite_02].Pop();
        obj.transform.position = spawnPos;
        Push();
    }

}
