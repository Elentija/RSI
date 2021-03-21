import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.Vector;

public class SearchObjectImpl extends UnicastRemoteObject implements SearchObject
{
    private double a;
    private double b;
    private double c;

    public SearchObjectImpl() throws RemoteException {
        super();
    }

    public ResultType search(InputType inParam) throws RemoteException {
        Vector<Vector<Integer>> points;
        ResultType wynik = new ResultType();
        a = inParam.getA();
        b = inParam.getB();
        c = inParam.getC();
        points = inParam.getPoints();
        wynik.result_description = "On the straight line "+ inParam.a + "x+" + inParam.b +"y+" + inParam.c + "=0 lies ";
        wynik.result = checkPoints(points);
        return wynik;
    }

    private int checkPoints(Vector<Vector<Integer>> points){
        int numberPoint = 0;
        for (Vector<Integer> pointVector: points) {
            if (checkPoint(pointVector)) numberPoint++;
        }
        return numberPoint;
    }

    private boolean checkPoint(Vector<Integer> pointVector) {
        double d = Math.abs(a * pointVector.get(0) + b * pointVector.get(1) + c) / Math.sqrt(Math.pow(a, 2) + Math.pow(b, 2));
        return d == 0;
    }
}