using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToClassicHigh : MonoBehaviour
{
    // 클래식 '상'레벨 
    public void SceneChange()
    {
        SceneManager.LoadScene("ClassicHigh");
    }
}
