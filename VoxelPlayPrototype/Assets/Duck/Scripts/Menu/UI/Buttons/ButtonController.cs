using System;
using Duck.Scripts.Scene;
using UnityEngine;

namespace Duck.Scripts.Menu.UI.Buttons
{
    public class ButtonController : MonoBehaviour
    {
        private SceneTransition m_SceneTransition;

        private void Start()
        {
            m_SceneTransition = new SceneTransition();
        }

        //Unity Event - play-btn
        public void PlayButtonClick()
        {
            m_SceneTransition.GameSceneTransition("World_Scene");
        }
    }
}
