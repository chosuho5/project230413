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
            Debug.Log("컴포넌트 참조 실패 - DropItem - Awake()");
        }
    }

    private Vector2 dropDir;

    public override void InitInfo()
    {
        base.InitInfo();
        dropDir.x = Random.Range(-1, 1f);
        dropDir.y = Random.Range(3f, 4f);
        rig.velocity = dropDir; // 떨어지는 속도 곱하기로 조절 가능
    }
}
