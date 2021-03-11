import org.apache.xmlrpc.WebServer;

import javax.xml.crypto.Data;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.LinkedList;
import java.util.List;

public class serwerRPC {
    public Integer echo(int x, int y) {
        return new Integer(x+y);
    }

    public int execAsy(int x) {
        System.out.println("... wywolano asy - odliczam");
        try {
            Thread.sleep(x);
        } catch (InterruptedException e) {
            e.printStackTrace();
            Thread.currentThread().interrupt();
        }
        System.out.println("...asy - koniec odliczania");
        return (123);
    }

    public double add(double x, double y){
        return x+y;
    }

    public double sub(double x, double y){
        return x-y;
    }

    public double mult(double x, double y){
        return x*y;
    }

    public double div(double x, double y){
        if(y != 0)
            return x/y;
        else
            throw new ArithmeticException();
    }

    public String introduce(String name1, String name2, Date date) {
        SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy.MM.dd hh:mm:ss");
        try {
            Thread.sleep(3000);
        } catch (InterruptedException e) {
            e.printStackTrace();
            Thread.currentThread().interrupt();
        }
        return "Student 1: " + name1 + "Student 2: " + name2 + ". Today is " + sdf1.format(date);
    }

    public String show() {
      String allMethods ="\n1. add: dodawanie. Dwa parametry typu rzeczywistego. Metoda dodajaca dwie liczby.\n"+
         "2. sub: odejmowanie. Dwa parametry typu rzeczywistego. Metoda odejmujaca dwie liczby\n"+
         "3. mult: mnozenie. Dwa parametry typu rzeczywistego. Metoda wykonujaca mnozenie dwoch liczb.\n"+
         "4. div: dzielenie. Dwa parametry typu rzeczywistego. Metoda wykonujaca dzielenie dwoch liczb\n"+
         "5. introduce: przedstaweinie sie. Trzy parametry, dwa sa typu lancuchow znakow, jeden to data. "+
                "Metoda wypisuje przywitanie i aktualna date.";
        return  allMethods;
    }

    public int methodParamCount(String name) {
        try {
            Method[] ms = Class.forName("serwerRPC").getDeclaredMethods();
            for ( Method m: ms) {
                if(name.equals(m.getName()))
                    return m.getParameterCount();
                System.out.println( m.getName());
                System.out.println( m.getParameterCount());
            }
            return Class.forName("serwerRPC").getDeclaredMethod(name).getParameterCount();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (NoSuchMethodException e) {
            e.printStackTrace();
        }
        return -1;
    }


    public static void main(String[] args) throws ParseException {
        System.out.println("Daria Hornik, 246700");
        System.out.println("Kamil Graczyk, 246994");
        SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy.MM.dd hh:mm:ss");
        System.out.println(sdf1.format(new Date()));

        System.out.println(System.getProperty("user.name"));
        System.out.println();
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
