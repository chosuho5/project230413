using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : PoolLabel
{
    private ParticleSystem ps;

    private void Awake()
    {
        if ( !TryGetComponent<ParticleSystem>(out ps))
        {
            Debug.Log("파티클 시스템을 찾지 못했습니다.");
        }
    }
    public override void InitInfo()
    {
        base.InitInfo();
        ps.Play();
    }


    private void Update()
    {
        if (ps.isPlaying == false)
        {
            Push();
        }
    }
}
