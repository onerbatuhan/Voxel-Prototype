using System;
using Duck.Scripts.Game;
using UnityEngine;

namespace Duck.Scripts.Screen
{
    public class ScreenController : MonoBehaviour
    {
        private ScreenManager m_ScreenManager;
        private GameManager m_GameManager;
        public bool canTransitionScreen;

        private void Start()
        {
            m_ScreenManager = ScreenManager.Instance;
            m_GameManager = GameManager.Instance;
        }

        public void ScreenTransitionExecute()
        {
            if (!canTransitionScreen) return;
            ChangeScreen(!m_ScreenManager.firstPersonControllerObject.activeSelf);
        }

        private void ChangeScreen(bool enableFirstPerson)
        {
            m_ScreenManager.thirdPersonScreenCamera.enabled = !enableFirstPerson;

          
            Transform targetTransform = enableFirstPerson
                ? m_ScreenManager.firstPersonControllerObject.transform
                : m_ScreenManager.thirdPersonControllerObject.transform;

            
            Transform sourceTransform = enableFirstPerson
                ? m_ScreenManager.thirdPersonControllerObject.transform
                : m_ScreenManager.firstPersonControllerObject.transform;

            
            targetTransform.position = sourceTransform.position;
            targetTransform.rotation = sourceTransform.rotation;

            m_GameManager.voxelPlayEnvironment.distanceAnchor = targetTransform;

            m_ScreenManager.firstPersonControllerObject.SetActive(enableFirstPerson);
            m_ScreenManager.thirdPersonControllerObject.SetActive(!enableFirstPerson);
        }
    }
}