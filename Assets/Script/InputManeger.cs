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
            Debug.Log("플레이어 컨트롤러를 찾지 못했습니다.");
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
