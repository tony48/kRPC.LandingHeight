using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NET35
using systemAlias = global::KRPC.Client.Compatibility;
using genericCollectionsAlias = global::KRPC.Client.Compatibility;
#else
using systemAlias = global::System;
using genericCollectionsAlias = global::System.Collections.Generic;
#endif

namespace KRPC.Client.Services.LH
{
    /// <summary>
    /// Extension methods for LH service.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Create an instance of the LH service.
        /// </summary>
        public static global::KRPC.Client.Services.LH.Service LH (this global::KRPC.Client.IConnection connection)
        {
            return new global::KRPC.Client.Services.LH.Service (connection);
        }
    }

    /// <summary>
    /// LH service.
    /// </summary>
    public class Service
    {
        global::KRPC.Client.IConnection connection;

        internal Service (global::KRPC.Client.IConnection serverConnection)
        {
            connection = serverConnection;
        }

        [global::KRPC.Client.Attributes.RPCAttribute ("LH", "Height")]
        public double Height ()
        {
            ByteString _data = connection.Invoke ("LH", "Height");
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }
}

