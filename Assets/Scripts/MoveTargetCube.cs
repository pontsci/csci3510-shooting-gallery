using UnityEngine;

public class MoveTargetCube : MonoBehaviour
{
    public float moveAmount = 1f;
    public float xBoundMax = 7f;
    public float xBoundMin = -3f;
    public bool positive = true;

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        if (positive)
        {
            transform.position = new Vector3(x + moveAmount * Time.deltaTime, y, z);
            if (x > xBoundMax)
            {
                positive = false;
            }
        }
        else
        {
            transform.position = new Vector3(x - moveAmount * Time.deltaTime, y, z);
            if(x < xBoundMin)
            {
                positive = true;
            }
        }
    }
}
