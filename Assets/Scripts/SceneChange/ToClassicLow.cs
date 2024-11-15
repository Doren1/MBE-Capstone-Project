using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToClassicLow : MonoBehaviour
{
    // 클래식 '하'레벨 

    public void SceneChange()
    {
        SceneManager.LoadScene("ClassicLow");
    }
}
