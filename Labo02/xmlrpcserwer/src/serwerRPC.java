import org.apache.xmlrpc.WebServer;

import java.lang.reflect.Method;
import java.text.SimpleDateFormat;
import java.util.Date;

public class serwerRPC {

    public double add(double x, double y) {
        return x + y;
    }

    public double sub(double x, double y) {
        return x - y;
    }

    public double mult(double x, double y) {
        return x * y;
    }

    public double div(double x, double y) {
        if (y != 0)
            return x / y;
        else
            throw new ArithmeticException();
    }

    public String getGrade(String name, double grade) {
        try {
            Thread.sleep(3000);
            System.out.println("Wpisywanie oceny studentowi...");
        } catch (InterruptedException e) {
            e.printStackTrace();
            Thread.currentThread().interrupt();
        }
        return "Student: " + name + ". Wstawiona osena: " + String.valueOf(grade);
    }

    public String show() {
        return "\n1. add: dodawanie. Dwa parametry typu rzeczywistego. Metoda dodajaca dwie liczby.\n" +
                "2. sub: odejmowanie. Dwa parametry typu rzeczywistego. Metoda odejmujaca dwie liczby\n" +
                "3. mult: mnozenie. Dwa parametry typu rzeczywistego. Metoda wykonujaca mnozenie dwoch liczb.\n" +
                "4. div: dzielenie. Dwa parametry typu rzeczywistego. Metoda wykonujaca dzielenie dwoch liczb\n" +
                "5. getGrade: wstawienie oceny. Dwa parametry, Lancuch znakow i watosc rzeczywista. " +
                "Metoda wypisuje przywitanie i aktualna date.";
    }

    private Method findMethod(String name) {
        Method[] ms = new Method[0];
        try {
            ms = Class.forName("serwerRPC").getDeclaredMethods();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
        for (Method m : ms) {
            if (name.equals(m.getName())) {
                return m;
            }
        }
        return null;
    }

    public int methodParamCount(String name) {
        return findMethod(name).getParameterCount();
    }

    public String[] methodParamTypes(String name){
        String[] paramTypes = new String[methodParamCount(name)];
        Method method = findMethod(name);
        for (int i=0; i<method.getParameterTypes().length; i++) {
            paramTypes[i] = method.getParameterTypes()[i].getTypeName();
        }
        return paramTypes;
    }

    public static void main(String[] args) throws ClassNotFoundException, NoSuchMethodException {
        System.out.println("Daria Hornik, 246700");
        System.out.println("Kamil Graczyk, 246994");
        SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy.MM.dd hh:mm:ss");
        System.out.println(sdf1.format(new Date()));
        System.out.println("Nazwa komputera: " + System.getProperty("user.name"));

        try {
            System.out.println("Startuje serwer XML-RPC...");
            int port = 5002;
            WebServer server = new WebServer(port);
            server.addHandler("MojSerwer", new serwerRPC());
            server.start();
            System.out.println("Serwer wystartowal pomyslnie.");
            System.out.println("Nasluchuje na porcie: " + port);
            System.out.println("Aby zatrzymac serwer wcisnij crl+c");
        }
        catch (Exception exception) {
            System.err.println("Serwer XMI-RPC: " + exception);
        }
    }
}
