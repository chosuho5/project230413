using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    private PoolLabel triggerOther;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PoolLabel>(out triggerOther))
        {
            triggerOther.Push();
        }
    }
}
