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
            Debug.Log("Weapon ������Ʈ�� ã�ƿ��µ� ���� �߽��ϴ�.");
        }
        else
        {
            playerWeapon.Init(projectilePrefab, attackRate);  // �Ѿ��� �߻��ϴ� �ӵ�
        }
    }

    private Vector3 pos;
    [SerializeField]
    private Vector2 clampMin;// x�� y��ǥ�� ���
    [SerializeField]
    private Vector2 clampMax;

    private void Update()
    {
        if(isMove)
        {
            // ĳ���� �̵�
            //Debug.Log("�̵���...");
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.x = Mathf.Clamp(pos.x, clampMin.x, clampMax.x);
            pos.y = Mathf.Clamp(pos.y, clampMin.y, clampMax.y);
            pos.z = transform.position.z;   // ĳ���� z��ǥ�� �״�� �����Ѵ�
            transform.position = pos;
        }
    }
}
