using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManeger : MonoBehaviour
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
            Debug.Log("�÷��̾� ��Ʈ�ѷ��� ã�� ���߽��ϴ�.");
    }

    private void OnMouseDown()
    {
        playerController.MoveInput = true;
    }
    private void OnMouseUp()
    {
        playerController.MoveInput = false;
    }
}
