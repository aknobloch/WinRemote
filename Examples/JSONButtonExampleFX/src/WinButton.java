import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class WinButton
{
    @Expose
    public int ID;
    @SerializedName("Name")
    public String displayName;
}
