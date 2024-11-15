using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStartScene : MonoBehaviour
{
    // home button 누를 시 게임 첫 화면(start scene)으로 이동
    public void SceneChange()
    {
        SceneManager.LoadScene("Start");
    }
}
