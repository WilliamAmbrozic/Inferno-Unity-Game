

using UnityEngine;

public class FOV : MonoBehaviour
{

    public float FieldOfView;
    public Camera Camera2;

    void Start()
    {

        FieldOfView = 50.0f;
    }

    void Update()
    {
        Camera2.fieldOfView = FieldOfView;
    }

    void OnGUI()
    {
        float max, min;
        max = 100.0f;
        min = 20.0f;
        FieldOfView = GUI.HorizontalSlider(new Rect(900, 750, 100, 100), FieldOfView, min, max);
    }
}