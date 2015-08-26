using UnityEngine;

public class MusicCredits : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void OnMusicCreditsClick()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=XYrQC-jWMFM");
    }
    
    public void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
