using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 50f;
    [SerializeField] private Transform[] rotateObjs;

    void Update()
    {
        foreach (Transform obj in rotateObjs)
        {
            obj.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }
}