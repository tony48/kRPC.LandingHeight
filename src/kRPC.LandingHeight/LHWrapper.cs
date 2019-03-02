using System;
using System.Reflection;
using UnityEngine;


namespace kRPC.LandingHeight
{
    public class LHWrapper
    {
        public static bool? wrapped = null;
        private static System.Type LHAPIType = null;
        private static MethodInfo lhHeightToLand = null;

        private static Type GetType(string name)
        {
            Type type = null;
            AssemblyLoader.loadedAssemblies.TypeOperation(t =>
            {
                if (t.FullName == name)
                    type = t;
            });
            return type;
        }

        public static void init()
        {
            LHAPIType = GetType("LandingHeight.LHFlight");
            if (LHAPIType == null)
            {
                Debug.LogError("[kRPC.LH] Cannot find Landing Height");
                wrapped = false;
                return;
            }
            Debug.Log("[kRPC.LH] Landing Height found");

            lhHeightToLand = LHAPIType.GetMethod("heightToLand");
            if (lhHeightToLand == null)
            {
                wrapped = false;
                return;
            }

            wrapped = true;
        }

        public static double LandingHeight()
        {
            var inst = Activator.CreateInstance(LHAPIType);
            return (double)lhHeightToLand.Invoke(inst, new object[] { });
        }

        public static bool Wrapped()
        {
            if (wrapped != null)
            {
                return (bool)wrapped;
            }
            else
            {
                init();
                return (bool)wrapped;
            }
        }
    }
}
