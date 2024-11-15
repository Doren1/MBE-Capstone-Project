using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    // 1초동안 이펙트 효과 후 사라짐 - 각 이펙트(hit, perfect, good, miss) 프리팹에 적용 
    public float lifetime=1;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
