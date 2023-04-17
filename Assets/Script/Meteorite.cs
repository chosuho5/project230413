using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : PoolLabel
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))  // 어떤 테그와 다았을때
        {
            Debug.Log("메테오와 충돌     = >>>> " + collision.gameObject.name);
        }
    }
}
