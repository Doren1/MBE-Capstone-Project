using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToClassicMed : MonoBehaviour
{
    //클래식 '중' 레벨
    public void SceneChange()
    {
        SceneManager.LoadScene("ClassicMed");
    }
}
