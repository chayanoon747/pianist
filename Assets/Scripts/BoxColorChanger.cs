using UnityEngine;

public class BoxColorChanger : MonoBehaviour
{
    // ตัวแปรสำหรับจับ GameObject ของกล่องต่างๆ
    public GameObject BoxA;
    public GameObject BoxS;
    public GameObject BoxJ;
    public GameObject BoxK;

    // สีที่จะแสดงเมื่อกดปุ่ม
    public Color colorA = Color.red;
    public Color colorS = Color.green;
    public Color colorJ = Color.blue;
    public Color colorK = Color.yellow;

    // สีดั้งเดิมของกล่อง
    private Color originalColorA;
    private Color originalColorS;
    private Color originalColorJ;
    private Color originalColorK;

    void Start()
    {
        // เก็บสีดั้งเดิมของกล่อง
        originalColorA = BoxA.GetComponent<Renderer>().material.color;
        originalColorS = BoxS.GetComponent<Renderer>().material.color;
        originalColorJ = BoxJ.GetComponent<Renderer>().material.color;
        originalColorK = BoxK.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        // ตรวจสอบการกดปุ่ม A
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeBoxColor(BoxA, colorA);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            ResetBoxColor(BoxA, originalColorA);
        }

        // ตรวจสอบการกดปุ่ม S
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeBoxColor(BoxS, colorS);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            ResetBoxColor(BoxS, originalColorS);
        }

        // ตรวจสอบการกดปุ่ม J
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeBoxColor(BoxJ, colorJ);
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            ResetBoxColor(BoxJ, originalColorJ);
        }

        // ตรวจสอบการกดปุ่ม K
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChangeBoxColor(BoxK, colorK);
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            ResetBoxColor(BoxK, originalColorK);
        }
    }

    void ChangeBoxColor(GameObject box, Color color)
    {
        // เปลี่ยนสีของกล่อง
        box.GetComponent<Renderer>().material.color = color;
    }

    void ResetBoxColor(GameObject box, Color originalColor)
    {
        // เปลี่ยนกลับเป็นสีดั้งเดิมของกล่อง
        box.GetComponent<Renderer>().material.color = originalColor;
    }
}
