using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {
    
    
	public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    
}
