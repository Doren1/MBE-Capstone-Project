using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHeroLow : MonoBehaviour
{
    // 임영웅 '하' 레벨

    public void SceneChange()
    {
        SceneManager.LoadScene("HeroLow");
    }
}
