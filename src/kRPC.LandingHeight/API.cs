using System;
using KRPC.Service;
using KRPC.Service.Attributes;


namespace kRPC.LandingHeight
{
    [KRPCService(Name = "LH", GameScene = GameScene.Flight)]
    public static class Service
    {
        [KRPCProcedure]
        public static double Height()
        {
            if (Available())
            {
                return LHWrapper.LandingHeight();
            }
            throw new Exception("LandingHeight is not available");
        }

        public static bool Available()
        {
            return (bool)LHWrapper.wrapped;
        }
    }
}
