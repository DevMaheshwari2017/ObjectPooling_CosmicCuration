using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private VFXPool vFXPool;
        public VFXService(VFXView vFXView) => vFXPool = new VFXPool(vFXView);

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = vFXPool.GetVFX();
            vfxToPlay.Configure(type, spawnPosition);
        }

        public void ReturnVfxToPool(VFXController vfxToReturn) => vFXPool.ReturnItem(vfxToReturn);
    } 
}