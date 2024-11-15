using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectLow : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public string buttonColor; // 버튼 색상 추가
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    public void SetButtonColor(string color)
    {
        buttonColor = color;
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){

                gameObject.SetActive(false);
                
                if(Mathf.Abs(transform.position.y) > 2.95f)
                {
                    Debug.Log("Hit");
                    GameManagerLow.instance.NormalHit(buttonColor);
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                } else if(Mathf.Abs(transform.position.y) > 3.6f)
                {
                    Debug.Log("Good");
                    GameManagerLow.instance.GoodHit(buttonColor);
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                } else
                {
                    Debug.Log("Perfect");
                    GameManagerLow.instance.PerfectHit(buttonColor);
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }

            
            }
        }

        // 게임 화면 밖으로 나간 노트는 삭제 
        if(transform.position.y < -5.5f)
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
        if (gameObject.activeSelf){
            if(other.tag == "Activator")
        {
            canBePressed = false;

            GameManagerLow.instance.NoteMissed(buttonColor);

            Vector3 spawnPosition = transform.position; // 현재 위치
            spawnPosition.y += 1.5f; // y 값을 0.5만큼 올림
            Instantiate(missEffect, spawnPosition, missEffect.transform.rotation);
        }
        }
        
    }
}
