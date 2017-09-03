using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load the needed scene by name
/// </summary>
public class MenuHandler : MonoBehaviour
{
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
	
}
