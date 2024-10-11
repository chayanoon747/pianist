using UnityEngine;

public class GameManager : MonoBehaviour
{
    public NoteHandler noteHandlerA; // อ้างอิงถึง NoteHandler สำหรับ A
    public NoteHandler noteHandlerS; // อ้างอิงถึง NoteHandler สำหรับ S
    public NoteHandler noteHandlerJ; // อ้างอิงถึง NoteHandler สำหรับ J
    public NoteHandler noteHandlerK; // อ้างอิงถึง NoteHandler สำหรับ K

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            noteHandlerA.HandleNoteForKey("A");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            noteHandlerS.HandleNoteForKey("S");
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            noteHandlerJ.HandleNoteForKey("J");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            noteHandlerK.HandleNoteForKey("K");
        }
    }
}
