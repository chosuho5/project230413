using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private bool isMove;

    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float attackRate;

    public Weapon playerWeapon;
    public bool MoveInput
    {
        set
        {
            isMove = value;
            if (isMove)
                playerWeapon.FIRING = true;
            else
                playerWeapon.FIRING = false;
        }
    }

    private void Awake()
    {
        isMove = false;

        if (!TryGetComponent<Weapon>(out playerWeapon))
        {
            Debug.Log("Weapon 컴포넌트를 찾아오는데 실패 했습니다.");
        }
        else
        {
            playerWeapon.Init(projectilePrefab, attackRate);  // 총알을 발사하는 속도
        }
    }

    private Vector3 pos;
    [SerializeField]
    private Vector2 clampMin;// x랑 y좌표만 취급
    [SerializeField]
    private Vector2 clampMax;

    private void Update()
    {
        if(isMove)
        {
            // 캐릭터 이동
            //Debug.Log("이동중...");
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.x = Mathf.Clamp(pos.x, clampMin.x, clampMax.x);
            pos.y = Mathf.Clamp(pos.y, clampMin.y, clampMax.y);
            pos.z = transform.position.z;   // 캐릭터 z좌표를 그대로 유지한다
            transform.position = pos;
        }
    }
}
