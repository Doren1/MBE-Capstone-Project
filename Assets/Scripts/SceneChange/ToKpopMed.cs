using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToKpopMed : MonoBehaviour
{
    //Kpop-'중'레벨 
    public void SceneChange()
    {
        SceneManager.LoadScene("KpopMed");
    }
}
