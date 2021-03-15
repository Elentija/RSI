import org.apache.xmlrpc.XmlRpcClient;

import java.lang.reflect.Array;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
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
        ipAddr = "25.43.211.64";
        String path = ipAddr + ":" + port;
        try {
            //XmlRpcClient srv = new XmlRpcClient("http://localhost:5002");
            XmlRpcClient srv = new XmlRpcClient(path);

            Vector<Object> params = new Vector<>();
            Object result = srv.execute("MojSerwer.show", params);
            
            while (true) {
                System.out.println("Metody: " + result);
                System.out.println("Wybierz metode:");
                String method = in.next();
                
                Vector<Object> methodName = new Vector<>();
                methodName.addElement(method);
                Object numberOfParam = srv.execute("MojSerwer.methodParamCount", methodName);
                Object paramTypes = srv.execute("MojSerwer.methodParamTypes", methodName);

                Vector<Object> userParams = new Vector<>();
                for(int i=0; i<(int) numberOfParam; i++) {
                    System.out.println("Podaj parametr typu: "+ ((Vector)paramTypes).get(i));
                    String param = in.next();
                    switch((String) ((Vector)paramTypes).get(i)) {
                        case "java.lang.String":
                            userParams.addElement(param);
                            break;
                        case "double":
                            userParams.addElement(new Double( Double.parseDouble(param)));
                            break;
                    }
                }
                Object method_result = srv.execute("MojSerwer."+method, userParams);
                System.out.println("Wynik metody: " + method_result.toString());
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
