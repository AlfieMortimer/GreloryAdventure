using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneName;

    public void Scenechange(string name)
    {
        SceneManager.LoadScene(sceneName: name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            Scenechange(SceneName);

        }
    }
}
