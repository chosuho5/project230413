using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private bool isMove;

    public bool MoveInput
    {
        set
        {
            isMove = value;
            if (isMove)
                StartCoroutine("TryAttack");
            else
                StopCoroutine("TryAttack");
        }
    }

    private void Awake()
    {
        isMove = false;
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
            Debug.Log("�̵���...");
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.x = Mathf.Clamp(pos.x, clampMin.x, clampMax.x);
            pos.y = Mathf.Clamp(pos.y, clampMin.y, clampMax.y);
            pos.z = transform.position.z;   // ĳ���� z��ǥ�� �״�� �����Ѵ�
            transform.position = pos;
        }
    }

    [SerializeField]
    private GameObject projectilePrefab;
    private IEnumerator TryAttack()
    {
        while(true)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
