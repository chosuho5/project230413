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
        if(collision.CompareTag("Player"))  // �÷��̾ �� �Ѿ˿� �¾��� ��
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
            else // �÷��̾��� ��ü�� ���� �ε�������
            {
                OnDie();
            }            
        }
    }


    private GameObject spawnEffectObj;
    public void OnDie()
    {
        //����Ʈ 
        spawnEffectObj = ObjectPoolManager.Inst.pools[(int)objectType.objT_Efeect_01].Pop();
        spawnEffectObj.transform.position = transform.position; // ����Ʈ�� �ڱ� �ڽ��� ��ġ�� �������
        Push();
    }


}
