using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Duck.Scripts.Scene
{
    public class SceneTransition : MonoBehaviour
    {
        public void GameSceneTransition(String sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
