using UnityEngine;

public class Script_Camera : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 30f;
    [SerializeField]
    public Vector2 panLimitMin;
    public Vector2 panLimitMax;


    public float scrollSpeed = 200f;
    public float minZ = -20f;
    public float maxZ = -5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w")|| Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <=  panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.z += scroll * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, panLimitMin.x, panLimitMax.x);
        pos.z = Mathf.Clamp(pos.z, minZ , maxZ);
        pos.y = Mathf.Clamp(pos.y, panLimitMin.y, panLimitMax.y);

        transform.position = pos;
    }
}
