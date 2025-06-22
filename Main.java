import org.json.simple.JSONObject;

public class Main {
    public static void main(String[] args) {
        JSONObject obj = new JSONObject();
        obj.put("name", "John");
        obj.put("age", 30);
        System.out.println(obj.toJSONString());
    }
}