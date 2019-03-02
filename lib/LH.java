package krpc.client.services;

import com.google.protobuf.ByteString;

import krpc.client.Connection;
import krpc.client.Encoder;
import krpc.client.RemoteEnum;
import krpc.client.RemoteObject;
import krpc.client.RPCInfo;
import krpc.client.RPCException;
import krpc.client.Types;

public class LH {

    public static LH newInstance(Connection connection) {
        return new LH(connection);
    }

    private Connection connection;

    private LH(Connection connection) {
        this.connection = connection;
    }

    private void addExceptionTypes(Connection connection) {
    }

    @SuppressWarnings({ "unchecked" })
    @RPCInfo(service = "LH", procedure = "Height", types = _Types.class)
    public double height() throws RPCException {
        ByteString _data = this.connection.invoke("LH", "Height");
        return (double) Encoder.decode(_data, krpc.client.Types.createValue(krpc.schema.KRPC.Type.TypeCode.DOUBLE), this.connection);
    }

    public static class _Types {
        public static krpc.schema.KRPC.Type getReturnType(String procedure) {
            switch (procedure) {
            case "Height":
                return krpc.client.Types.createValue(krpc.schema.KRPC.Type.TypeCode.DOUBLE);
            }
            throw new IllegalArgumentException("Procedure '" + procedure +"' not found");
        }

        public static krpc.schema.KRPC.Type[] getParameterTypes(String procedure) {
            switch (procedure) {
            case "Height":
                return new krpc.schema.KRPC.Type[] {
                };
            }
            throw new IllegalArgumentException("Procedure '" + procedure +"' not found");
        }
    }
}
