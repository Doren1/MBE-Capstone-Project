using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    // NoteHolder오브젝트에 들어가는 스크립트
    
    public float beatTempo;    // 화살표가 떨어지는 속도(게임의 bpm을 inspector창에서 입력하기)
    public bool hasStarted;    // 게임 시작 여부

    void Start()
    {
        beatTempo = beatTempo / 60f;  // 떨어지는 템포 조정
    }

    void Update()
    {
        if(hasStarted)  // 게임 시작되었다면 beatTempo속도에 따라 노트 떨어지게 만들기
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        } 
    }
}
