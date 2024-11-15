using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHeroHigh : MonoBehaviour
{
    // 임영웅 '상' 레벨 
    public void SceneChange()
    {
        SceneManager.LoadScene("HeroHigh");
    }
}
