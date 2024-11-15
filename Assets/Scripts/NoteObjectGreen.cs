using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectGreen : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public string buttonColor; // 버튼 색상 추가
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    public void SetButtonColor(string color)
    {
        buttonColor = color;
        Debug.Log("SetButtonColor called with color: " + buttonColor); // 추가된 로그
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){
                gameObject.SetActive(false);
                
                if(Mathf.Abs(transform.position.y) > 2.95f)
                {
                    Debug.Log("Hit");
                    GameManagerHigh.instance.NormalHit("green");
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                } else if(Mathf.Abs(transform.position.y) > 3.6f)
                {
                    Debug.Log("Good");
                    GameManagerHigh.instance.GoodHit("green");
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                } else
                {
                    Debug.Log("Perfect");
                    GameManagerHigh.instance.PerfectHit("green");
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }

            
            }
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

            GameManagerHigh.instance.NoteMissed(buttonColor);

            Vector3 spawnPosition = transform.position; // 현재 위치
            spawnPosition.y += 1.5f; // y 값을 0.5만큼 올림
            Instantiate(missEffect, spawnPosition, missEffect.transform.rotation);
        }
        }
        
    }
}

