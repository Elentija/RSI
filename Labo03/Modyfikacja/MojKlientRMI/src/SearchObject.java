import java.rmi.Remote;
import java.rmi.RemoteException;

public interface SearchObject extends Remote {
    public ResultType search(InputType inputParam)
            throws RemoteException;
} 