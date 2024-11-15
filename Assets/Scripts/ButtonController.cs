using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // 각 버튼(blue, red, yellow)에 들어가는 스크립트
    private SpriteRenderer theSR;  // 버튼 이미지(sprite)
    public Sprite defaultImage;    // 평소 버튼 이미지
    public Sprite pressedImage;    // 버튼 눌렸을 때 이미지

    public KeyCode keyToPress;     // 각 버튼이 눌러지기 위한 키 (각 버튼마다 다름)
    
    // public string buttonColor; // 버튼 색상 추가

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        // Debug.Log("Button Color Set in ButtonController: " + buttonColor); 
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}
