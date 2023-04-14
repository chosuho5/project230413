using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManeger : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private void OnMouseDown()
    {
        playerController.MoveInput = true;
    }
    private void OnMouseUp()
    {
        playerController.MoveInput = false;
    }
}
