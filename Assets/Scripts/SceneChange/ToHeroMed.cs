using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHeroMed : MonoBehaviour
{
    //임영웅 '중' 레벨

    public void SceneChange()
    {
        SceneManager.LoadScene("HeroMed");
    }
}
