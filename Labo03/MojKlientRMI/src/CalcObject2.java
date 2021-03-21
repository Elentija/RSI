import java.rmi.Remote;
import java.rmi.RemoteException;

public interface CalcObject2 extends Remote {
    public ResultType calculate2(InputType inputParam)
            throws RemoteException;
}