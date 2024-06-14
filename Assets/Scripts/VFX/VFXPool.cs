using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CosmicCuration.Utilities;

namespace CosmicCuration.VFX {
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView vfxView;

        public VFXPool(VFXView vFXView) 
        {
            vfxView = vFXView;
        }

        public VFXController GetVFX() => GetItem<VFXController>();
        protected override VFXController CreateItem<T>() => new VFXController(vfxView);
        
    }
}
