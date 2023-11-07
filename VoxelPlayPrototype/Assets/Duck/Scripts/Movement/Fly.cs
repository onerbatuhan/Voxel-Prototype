using System;
using System.Collections;
using System.Collections.Generic;
using Duck.Scripts.Game.UI;
using Duck.Scripts.Screen;
using UnityEngine;
using UnityEngine.SceneManagement;
using VoxelPlay;

namespace Duck.Scripts.Movement
{
    public class Fly : MonoBehaviour
    {
        private bool _isTimerActive;
        public float timerDuration = 5f;
        private UIManager m_UIManager;
        private ScreenManager m_ScreenManager;

        private void Start()
        {
            m_UIManager = UIManager.Instance;
            m_ScreenManager = ScreenManager.Instance;
        }

        public void FlyButtonClick()
        {
            m_UIManager.flyTimerText.enabled = true;
            var thirdPersonController = m_ScreenManager.thirdPersonControllerObject.GetComponent<VoxelPlayThirdPersonController>();
            var firstPersonController = m_ScreenManager.firstPersonControllerObject.GetComponent<VoxelPlayFirstPersonController>();

            if (thirdPersonController.isFlying && firstPersonController.isFlying) return;
            thirdPersonController.isFlying = true;
            firstPersonController.isFlying = true;
            StartFlyTimer();
        }

        private void StartFlyTimer()
        {
            _isTimerActive = true;
            StartCoroutine(FlyCountdown());
        }

        private IEnumerator FlyCountdown()
        {
            float timer = timerDuration;

            while (timer > 0f)
            {
                yield return new WaitForSeconds(1f);
                timer -= 1f;
                FlyTimer(timer);
            }

            
            var thirdPersonController = ScreenManager.Instance.thirdPersonControllerObject.GetComponent<VoxelPlayThirdPersonController>();
            var firstPersonController = ScreenManager.Instance.firstPersonControllerObject.GetComponent<VoxelPlayFirstPersonController>();

            thirdPersonController.isFlying = false;
            firstPersonController.isFlying = false;

            _isTimerActive = false;
            m_UIManager.flyTimerText.enabled = false;
        }

        private void FlyTimer(float time)
        {
            if (_isTimerActive)
            {
                UIManager.Instance.flyTimerText.text = "Fly timer: " + time;
            }
            
        }
    }
}
