using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : PoolLabel
{
    private Rigidbody2D rig;

    private void Awake()
    {
        if( !TryGetComponent<Rigidbody2D>(out rig))
        {
            Debug.Log("������Ʈ ���� ���� - DropItem - Awake()");
        }
    }

    private Vector2 dropDir;

    public override void InitInfo()
    {
        base.InitInfo();
        dropDir.x = Random.Range(-1, 1f);
        dropDir.y = Random.Range(3f, 4f);
        rig.velocity = dropDir; // �������� �ӵ� ���ϱ�� ���� ����
    }
}
