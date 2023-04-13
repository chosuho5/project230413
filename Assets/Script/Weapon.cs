using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool isInit = false;
    private GameObject projectilePrefab;
    private float attackRate;

    public void Init(GameObject projectile, float rate)
    {
        if (projectile != null && rate > 0.0f)
        {
        projectilePrefab = projectile;
        attackRate = rate;
        isInit = true;
        }
        else
        {
            isInit = false;
            Debug.Log("���� �ʱ�ȭ�� ���� �Ͽ����ϴ�.");
        }
    }

    private bool isFiring;

    public bool FIRING
    {
        set // setter, getter
        {
            isFiring = value;
            if (isInit)  // �ʱ�ȭ�� �� ���� �̰�, isFiring�� true �̸� ����
            {
                if(isFiring)
                {   // �߻�
                    StartCoroutine("TryAttack");
                }
                else
                {   // �߻縦 ����
                    StopCoroutine("TryAttack");
                }
            }
            else
                Debug.Log("weapon �� �ʱ�ȭ�� ���� ���� �����Դϴ�.");
        }
        get
        {
            return isFiring;
        }
    }

    GameObject obj;

    private IEnumerator TryAttack()
    {
        while(true)
        {
            //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            obj = ObjectPoolManager.Inst.pools[(int)objectType.objT_Projectile_01].Pop();
            obj.transform.position = this.transform.position;
            //yield return new WaitForSeconds(attackRate);
            yield return YieldInstructionCache.WaitForSeconds(attackRate);
        }
    }


}
