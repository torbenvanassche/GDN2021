using Utilities;

public class Controls : Singleton<Controls>
{
    public InputSettings Input;

    public void Enable()
    {
        if (Input == null) Input = new InputSettings();
        Input.Enable();
    }

    public void Disable()
    {
        Input.Disable();
    }
}