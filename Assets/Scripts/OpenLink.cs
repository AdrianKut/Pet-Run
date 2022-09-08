using UnityEngine;

public class OpenLink : AbstractButton
{
    [SerializeField] private string URL;

    [SerializeField] private Texture2D _cursorTexturePointer;
    [SerializeField] private Texture2D _cursorTextureHand;
    [SerializeField] private CursorMode _cursorMode = CursorMode.Auto;
    [SerializeField] private Vector2 _hotSpot = Vector2.zero;

    public override void Method()
    {
        Application.OpenURL(URL);
    }

    public void OnMouseEnter()
    {
        Cursor.SetCursor(_cursorTextureHand, _hotSpot, _cursorMode);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(_cursorTexturePointer, _hotSpot, _cursorMode);
    }
}
