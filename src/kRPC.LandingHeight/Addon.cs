using UnityEngine;


namespace kRPC.LandingHeight
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public sealed class Addon : MonoBehaviour
    {
        public void Start()
        {
            LHWrapper.init();
        }
    }
}
