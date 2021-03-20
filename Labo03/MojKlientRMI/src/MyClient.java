import java.rmi.RemoteException;

public class MyClient {
    public static void main(String[] args) {
        double wynik = -1;
        CalcObject zObiekt;
        CalcObject2 z2Obiekt;
        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: // host_address/service_name ");
            return;
        } else if (args.length == 1) {
            String adres = args[0];
// //use this if needed
// if (System.getSecurityManager() == null)
// System.setSecurityManager(new SecurityManager());
            try {
                zObiekt = (CalcObject) java.rmi.Naming.lookup(adres);
            } catch (Exception e) {
                System.out.println("Nie mozna pobrac referencji do " + adres);
                e.printStackTrace();
                return;
            }
            System.out.println("Referencja do " + adres + " jest pobrana.");
            try {
                wynik = zObiekt.calculate(1.1, 2.2);
            } catch (Exception e) {
                System.out.println("Blad zdalnego wywolania.");
                e.printStackTrace();
                return;
            }
            System.out.println("Wynik = "+wynik);
        } else if (args.length == 2) {
            CalcObject2 zObiekt2;
            ResultType wynik2;
            InputType inObj = null;
            try {
                inObj = new InputType();
            } catch (RemoteException e) {
                e.printStackTrace();
            }
            inObj.x1 = 0.1;
            inObj.x2 = 0.2;
            inObj.operation = "add"; //lub "sub"

            String adres = args[0];
            try {
                z2Obiekt = (CalcObject2) java.rmi.Naming.lookup(adres);
            } catch (Exception e) {
                System.out.println("Nie mozna pobrac referencji do " + adres);
                e.printStackTrace();
                return;
            }
            System.out.println("Referencja do " + adres + " jest pobrana.");
            try {
                wynik2 = z2Obiekt.calculate(inObj);
            } catch (Exception e) {
                System.out.println("Blad zdalnego wywolania.");
                e.printStackTrace();
                return;
            }
            System.out.println("Wynik = " + wynik2.result_description + " " + wynik2.result);
        }
        return;
    }
}