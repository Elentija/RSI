import java.rmi.Naming;
import java.rmi.RemoteException;
import java.util.Random;
import java.util.Vector;

public class MyClient {
    public static void main(String[] args) {
        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: // host_address/service_name ");
            return;
        }

        Vector<Vector<Integer>> points = new Vector<>();
        Vector<Integer> point = new Vector<>();
        point.add(0);
        point.add(1);
        points.add(point);
        for (int i=0; i < 10; i++) {
            Vector<Integer> vector = new Vector<>();
            vector.add(new Random().nextInt(15));
            vector.add(new Random().nextInt(15));
            points.add(vector);
        }
        Vector<Integer> point2 = new Vector<>();
        point2.add(0);
        point2.add(0);
        points.add(point2);

        goSearch(points, args[0]);
    }

    private static void goSearch(Vector<Vector<Integer>> points, String address) {
        Vector<Vector<Integer>> pointsVector1 = new Vector<>();
        Vector<Vector<Integer>> pointsVector2 = new Vector<>();
        for (int i=0; i<points.size(); i++) {
            if(i < points.size() / 2) {
                pointsVector1.add(points.get(i));
                System.out.println("Vector1 " + points.get(i));
            }
            else {
                pointsVector2.add(points.get(i));
                System.out.println("Vector2 " + points.get(i));
            }
        }

        InputType inObj1 = null;
        try {
            inObj1 = new InputType();
        } catch (RemoteException e) {
            e.printStackTrace();
        }
        inObj1.a = 3;
        inObj1.b = 4;
        inObj1.c = -4;
        inObj1.points = pointsVector1;

        InputType inObj2 = null;
        try {
            inObj2 = new InputType();
        } catch (RemoteException e) {
            e.printStackTrace();
        }
        inObj2.a = 3;
        inObj2.b = 4;
        inObj2.c = -4;
        inObj2.points = pointsVector2;
        SearchObject obiekt1;
        ResultType wynik1;
        SearchObject obiekt2;
        ResultType wynik2;

        try {
            obiekt1 = (SearchObject) Naming.lookup(address);
        } catch (Exception e) {
            System.out.println("Nie mozna pobrac referencji do " + address);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do " + address + " jest pobrana.");
        try {
            wynik1 = obiekt1.search(inObj1);
        } catch (Exception e) {
            System.out.println("Blad zdalnego wywolania.");
            e.printStackTrace();
            return;
        }
        System.out.println("Result = " + wynik1.result_description + " " + wynik1.result);
        try {
            obiekt2 = (SearchObject) Naming.lookup(address);
        } catch (Exception e) {
            System.out.println("Nie mozna pobrac referencji do " + address);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do " + address + " jest pobrana.");
        try {
            wynik2 = obiekt2.search(inObj2);
        } catch (Exception e) {
            System.out.println("Blad zdalnego wywolania.");
            e.printStackTrace();
            return;
        }
        System.out.println("Result = " + wynik2.result_description + " " + wynik2.result);

        System.out.print("Total result " + (wynik1.result + wynik2.result));

    }
}