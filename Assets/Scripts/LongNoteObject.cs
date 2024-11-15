using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteObject : MonoBehaviour
{
    //검지, 중지, 약지 구부리는 동작에 해당하는 노트 (secondbend, thirdbend, fourthbend)
    public bool canBePressed;
    public KeyCode keyToPress;
    // 긴 노트 홀딩 상태 
    private bool isHolding = false;

    private bool isNormalHit = false;
    private bool isGoodHit = false;
    private bool isPerfectHit = false;

    // 키 눌렀다가 중간에 빨리 떼어버려서 미스 난 경우
    private bool isMissedInTheMiddle = false;

    public string buttonColor; // 버튼 색상 추가


    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    private SpriteRenderer noteSprite;

    public void SetButtonColor(string color)
    {
        buttonColor = color;
        // Debug.Log("SetButtonColor called with color: " + buttonColor); // 추가된 로그
    }

    void Start()
    {
        noteSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){
                isHolding = true;
                
                //투명도 낮추기
                Color color = noteSprite.color;
                color.a = 0.5f;
                noteSprite.color = color;

                // 키 누른 순간 (판정 범위)
                if(Mathf.Abs(transform.position.y) > 2.15f)
                {
                    Debug.Log("Hit");
                    // GameManager.instance.NormalHit(buttonColor);
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    isNormalHit = true;
                } else if(Mathf.Abs(transform.position.y) > 2.7f)
                {
                    Debug.Log("Good");
                    // GameManager.instance.GoodHit(buttonColor);
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    isGoodHit = true;
                } else
                {
                    Debug.Log("Perfect");
                    // GameManager.instance.PerfectHit(buttonColor);
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    isPerfectHit = true;
                }
            }
        }

        // ***********여기 잠시 주석처리***************
        // 키 누르고 있는 동안 노트 놓침

        // if (isHolding && canBePressed){
        //     if(Input.GetKeyUp(keyToPress))
        //     {
        //         isHolding = false;
        //         isMissedInTheMiddle = true;

        //         GameManagerHigh.instance.NoteMissed(buttonColor);

        //         Vector3 spawnPosition = transform.position; // 현재 위치
        //         spawnPosition.y += 1.5f; // y 값을 0.5만큼 올림
        //         Instantiate(missEffect, spawnPosition, missEffect.transform.rotation);
        //         print("키 누르는 도중에 놓침");
        //     }
        // }

        // *******여기까지 ********8

        // y좌표가 -5.3 보다 아래일 때(마지막 판정)
        if(transform.position.y<-5f){
            if(isHolding)
            {
                isHolding=false;

                Vector3 spawnPosition = transform.position; // 현재 위치
                spawnPosition.y += 1.5f; 

                if (isNormalHit){
                    GameManagerHigh.instance.NormalHit(buttonColor);
                    Instantiate(hitEffect, spawnPosition, hitEffect.transform.rotation);
                }
                else if (isGoodHit){
                    GameManagerHigh.instance.GoodHit(buttonColor);
                    Instantiate(goodEffect, spawnPosition, goodEffect.transform.rotation);
                }
                else if (isPerfectHit){
                    GameManagerHigh.instance.PerfectHit(buttonColor);
                    Instantiate(perfectEffect, spawnPosition, perfectEffect.transform.rotation);
                }
                gameObject.SetActive(false);
            }
        }

        if(transform.position.y < -6.4f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeSelf && !isMissedInTheMiddle){
            if(other.tag == "Activator")
            {
                canBePressed = false;
                // 키 누르지도 않고 놓친 경우
                if(!isHolding){
                    GameManagerHigh.instance.NoteMissed(buttonColor);

                    Vector3 spawnPosition = transform.position; // 현재 위치
                    spawnPosition.y += 3; // y 값을 3만큼 올림
                    Instantiate(missEffect, spawnPosition, missEffect.transform.rotation);
                    print("키 누르지도 않고 놓침");
                }
            }
        }
        
    }
}
