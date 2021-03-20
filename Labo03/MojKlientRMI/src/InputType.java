import java.io.Serializable;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class InputType extends UnicastRemoteObject implements Serializable, CalcObject2 {
    private static final long serialVersionUID = 101L;
    String operation;
    public double x1;
    public double x2;

    protected InputType() throws RemoteException {
        super();
    }

    public double getx1() {
        return x1;
    }
    public double getx2() {
        return x2;
    }

    @Override
    public ResultType calculate(InputType inputParam) throws RemoteException {
        return null;
    }
}