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
            Debug.Log("무기 초기화에 실패 하였습니다.");
        }
    }

    private bool isFiring;

    public bool FIRING
    {
        set // setter, getter
        {
            isFiring = value;
            if (isInit)  // 초기화가 된 무기 이고, isFiring이 true 이면 실행
            {
                if(isFiring)
                {   // 발사
                    StartCoroutine("TryAttack");
                }
                else
                {   // 발사를 멈춤
                    StopCoroutine("TryAttack");
                }
            }
            else
                Debug.Log("weapon 이 초기화가 되지 않은 상태입니다.");
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
