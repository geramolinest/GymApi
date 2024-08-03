namespace GymApi;

public class StringCustomUtils
{
    protected StringCustomUtils(){

    }

    public static String Capitalize(string value)
    {
        if(String.IsNullOrEmpty(value)) return "";

        return value.First().ToString().ToUpper() + value.Substring(1);
    }
}
