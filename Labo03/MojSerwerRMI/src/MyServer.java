import java.rmi.Remote;

public class MyServer
{
    public static void main(String[] args)
    {
        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");
            return;
        } else if (args.length == 1){
            if (System.getSecurityManager() == null)
                System.setSecurityManager(new SecurityManager()
                );
            try {
                CalcObjImpl implObiektu = new CalcObjImpl();
                java.rmi.Naming.rebind(args[0], implObiektu);
                System.out.println("Server is registered now :-)");
                System.out.println("Press Crl+C to stop...");
            } catch (Exception e) {
                System.out.println("SERVER CAN'T BE REGISTERED!");
                e.printStackTrace();
                return;
            }
        } else if (args.length == 2){
            if (System.getSecurityManager() == null)
                System.setSecurityManager(new SecurityManager()
                );
            try {
                InputType implObiektu2 = new InputType();
                java.rmi.Naming.rebind(args[0], implObiektu2);
                java.rmi.Naming.rebind(args[1], implObiektu2);
                System.out.println("Server is registered now :-)");
                System.out.println("Press Crl+C to stop...");
            } catch (Exception e) {
                System.out.println("SERVER CAN'T BE REGISTERED!");
                e.printStackTrace();
                return;
            }
        }

    }
}
