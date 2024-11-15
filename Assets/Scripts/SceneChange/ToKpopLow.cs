using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToKpopLow : MonoBehaviour
{
    //Kpop-'하'레벨 
    public void SceneChange()
    {
        SceneManager.LoadScene("KpopLow");
    }
}
