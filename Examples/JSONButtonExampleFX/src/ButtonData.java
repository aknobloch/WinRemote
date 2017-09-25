import com.google.gson.annotations.Expose;

import java.util.List;

public class ButtonData
{
    @Expose
    private List<WinButton> buttonData;

    public ButtonData(List<WinButton> buttons)
    {
        buttonData = buttons;
    }

    public List<WinButton> getList()
    {
        return this.buttonData;
    }
}
