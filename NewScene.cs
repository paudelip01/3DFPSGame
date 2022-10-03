using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void MpScene()
    {
        SceneManager.LoadScene(6);
    }

    public void MainScene()
    {
        SceneManager.LoadScene(4);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
