using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public void OnLoadSceneActivity1Clicked(string Activity1)
    {
        SceneManager.LoadScene(Activity1);
    }
}
