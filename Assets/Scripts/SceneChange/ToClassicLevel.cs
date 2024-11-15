using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToClassicLevel : MonoBehaviour
{
    // 클래식 레벨 선택 화면 
    public void SceneChange()
    {
        SceneManager.LoadScene("ClassicLevel");
    }
}
