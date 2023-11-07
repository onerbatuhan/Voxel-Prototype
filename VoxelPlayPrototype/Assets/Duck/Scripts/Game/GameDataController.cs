using UnityEngine;
using VoxelPlay;

namespace Duck.Scripts.Game
{
    public class GameDataController : MonoBehaviour
    {
        private void Start()
        {
            VoxelPlayEnvironment.instance.LoadGameBinary(true,true);
        }

        private void OnApplicationQuit()
        {
            VoxelPlayEnvironment.instance.SaveGameBinary();
        }
    }
}
