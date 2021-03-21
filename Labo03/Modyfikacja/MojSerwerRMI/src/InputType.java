import java.io.Serializable;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.Vector;

public class InputType extends UnicastRemoteObject implements Serializable {
    private static final long serialVersionUID = 101L;

    public double a;
    public double b;
    public double c;
    public Vector<Vector<Integer>> points;

    protected InputType() throws RemoteException {
        super();
    }

    public double getA() {
        return a;
    }
    public double getB() {
        return b;
    }
    public double getC(){
        return c;
    }
    public Vector<Vector<Integer>> getPoints(){
        return points;
    }
}