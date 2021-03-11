import org.apache.xmlrpc.XmlRpcClient;

import java.lang.reflect.Method;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;
import java.util.Vector;

public class klientRPC {
    public static void main(String[] args){
        System.out.println("Daria Hornik, 246700");
        System.out.println("Kamil Graczyk, 246994");
        SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy.MM.dd hh:mm:ss");
        System.out.println(sdf1.format(new Date()));

        Scanner in = new Scanner(System.in);
        System.out.println("Podaj IP lub nazwe DNS:");
        String ipAddr = in.nextLine();

        System.out.println("Podaj port: ");
        Integer port = in.nextInt();

        String path = ipAddr + ":" + port;
        try {
//            XmlRpcClient srv = new XmlRpcClient("http://localhost:5002");

            XmlRpcClient srv = new XmlRpcClient(path);

            Vector<Object> params = new Vector<>();
            Object result = srv.execute("MojSerwer.show", params);
            while (true) {
                System.out.println("Metody: " + result);
                String method = in.next();


                Vector<Object> params2 = new Vector<>();
                params2.addElement(method);
                Object numberOfParam = srv.execute("MojSerwer.methodParamCount", params2);

                Vector<Object> user_param = new Vector<>();
                for(int i=0; i<(int) numberOfParam; i++) {
                    System.out.println("Podaj param: ");
                    Object param = in.next();
                    user_param.addElement((Object) param);
                }
                Object method_result = srv.execute("MojSerwer."+method, user_param);
                System.out.println( method_result.toString());
            }

           /* DF df = new DF();
            Vector<Integer> params2 = new Vector<>();
            params2.addElement(new Integer(3000));
            srv.executeAsync("MojSerwer.execAsy", params2, df);
            System.out.println("Wywolano asynchronicznie");*/
        }
        catch (Exception exception) {
            System.err.println("Serwer XML-RPC: " + exception);
        }
    }
}
