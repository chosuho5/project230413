using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : PoolLabel
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))  // � �ױ׿� �پ�����
        {
            Debug.Log("���׿��� �浹     = >>>> " + collision.gameObject.name);
        }
    }
}
