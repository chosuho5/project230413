using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChar : PoolLabel
{
    [SerializeField]
    private int maxHP;
    private int currentHP;

    public override void InitInfo()
    {
        base.InitInfo();
        currentHP = maxHP;
    }

    private Projectile projectile;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))  // 플레이어가 쏜 총알에 맞았을 때
        {
            if(collision.TryGetComponent<Projectile>(out projectile))
            {
                projectile.Push();
                currentHP--;
                if(currentHP <= 0)
                {
                    OnDie();              
                }
            }
            else // 플레이어의 기체에 직접 부딪쳤을때
            {
                OnDie();
            }            
        }
    }


    private GameObject spawnEffectObj;
    public void OnDie()
    {
        //이펙트 
        spawnEffectObj = ObjectPoolManager.Inst.pools[(int)objectType.objT_Efeect_01].Pop();
        spawnEffectObj.transform.position = transform.position; // 이펙트를 자기 자신의 위치로 끌어들임
        Push();
    }


}
