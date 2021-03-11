import org.apache.xmlrpc.AsyncCallback;
import java.net.URL;

public class DF implements AsyncCallback {
    @Override
    public void handleResult(Object o, URL url, String s) {
        System.out.println("Komunikat metody asynchronicznej: " + o.toString());
    }

    @Override
    public void handleError(Exception e, URL url, String s) {
        System.out.println("Error! Nie wiadomo kto jest kim!" + e.toString());
    }
}
