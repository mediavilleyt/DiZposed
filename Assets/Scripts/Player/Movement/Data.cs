using UnityEngine;

public class Data
{
    public PlayerManager Player;

    private static Data instance;
    public static Data Instance
    {
        get
        {
            if (instance == null) instance = new Data();
            return instance;
        }
    }
    private Data() { }

    public void SetPause(bool Paused = false, PauseType TypeOfPause = PauseType.end)
    {
        if (Paused)
        {
            switch (TypeOfPause)
            {
                case PauseType.smallPause: 
                    Player.GetComponent<PlayerMovement>().enabled = false;
                    Player.GetComponent<MouseLook>().enabled = false;
                    break;

                case PauseType.MediumPause:
                    Player.GetComponent<PlayerMovement>().enabled = false;
                    Player.GetComponent<MouseLook>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;

                case PauseType.FullPause:
                    Player.GetComponent<PlayerMovement>().enabled = false;
                    Player.GetComponent<MouseLook>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0f;
                    break;
            }
        }

        else
        {
            Time.timeScale = 1f;
            Player.GetComponent<PlayerMovement>().enabled = true;
            Player.GetComponent<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public enum PauseType
    {
        smallPause,
        MediumPause,
        FullPause,
        end
    }
}
