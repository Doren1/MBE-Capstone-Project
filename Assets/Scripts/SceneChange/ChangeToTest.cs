using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToTest : MonoBehaviour
{
    // 진단하기 화면으로 이동 

    public void SceneChange()
    {
        SceneManager.LoadScene("Test");
    }
}
