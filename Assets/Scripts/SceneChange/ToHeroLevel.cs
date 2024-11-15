using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHeroLevel : MonoBehaviour
{
    // 임영웅 노래 레벨 화면

    public void SceneChange()
    {
        SceneManager.LoadScene("HeroLevel");
    }
}
