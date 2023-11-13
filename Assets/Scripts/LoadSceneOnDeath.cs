using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnDeath : MonoBehaviour
{
    bool bossalive = true;
    public string SceneName;
    public GameObject Boss;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Boss.activeInHierarchy == false)
        {
            bossalive = false;
        }
        if (bossalive == false)
        {
            Scenechange(SceneName);
            print("SceneChange");
        }
    }

    public void Scenechange(string name)
    {
        SceneManager.LoadScene(sceneName: name);
    }
}
