using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMoreResult : MonoBehaviour
{
    //상세결과화면 보기 
    public Transform canvas;
    public void ShowMoreResult()
    {
        
        Transform results2 = canvas.Find("Results2");
        results2.gameObject.SetActive(true);

    }
}
