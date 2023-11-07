using System;
using System.Collections.Generic;
using UnityEngine;
using VoxelPlay;

namespace Duck.Scripts.Voxel
{
    public class VoxelController : MonoBehaviour
    {
        public List<VoxelDefinition> canBeCollectedVoxelDefinitions;
        public List<VoxelDefinition> canNotBeCollectedVoxelDefinitions;

        private void Start()
        {
            VoxelsCollectPropertyInıt();
        }

        private void VoxelsCollectPropertyInıt()
        {
            foreach (var voxel in canBeCollectedVoxelDefinitions)
            {
                MakeVoxelCollectable(voxel);
            }
            foreach (var voxel in canNotBeCollectedVoxelDefinitions)
            {
                MakeVoxelUnCollectable(voxel);
            }
        }
        private void MakeVoxelCollectable(VoxelDefinition voxelDefinition)
        {
            voxelDefinition.canBeCollected = true;
        }
        
        private void MakeVoxelUnCollectable(VoxelDefinition voxelDefinition)
        {
            voxelDefinition.canBeCollected = false;
        }
    }
}
