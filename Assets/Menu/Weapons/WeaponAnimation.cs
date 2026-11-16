using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    public float rotationAmount = 10.0f;
    public float rotationSpeed = 1.0f;

    [SerializeField] private Transform _transform;

    void Update()
    {
        float rotation = Mathf.Sin(Time.time * rotationSpeed) * rotationAmount;
        _transform.localRotation = Quaternion.Euler(new Vector3(0, 0, rotation));
    }
}