public class Singleton {

    private Singleton() {
      
    }

    private string currentString = "";
    private static Singleton instance = null;

    public static Singleton getInstance() {
        if (Singleton.instance == null) {Singleton.instance = new Singleton();}
        return Singleton.instance;
    }

    public string getValue() {
        return Singleton.instance.currentString;
    }

    public void setValue(string value){
        Singleton.instance.currentString = value;
    }
}
