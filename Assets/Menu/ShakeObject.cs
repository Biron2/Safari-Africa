using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    // Параметры тряски
    public float shakeDuration = 1f; // Длительность тряски
    public float shakeAmount = 0.1f; // Интенсивность тряски

    private Vector3 initialPosition; // Начальная позиция объекта
    private float currentShakeDuration; // Текущая длительность тряски

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (currentShakeDuration > 0)
        {
            // Генерация случайного смещения по осям
            Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;

            // Применение смещения к начальной позиции
            transform.localPosition = initialPosition + randomOffset;

            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            // Если тряска закончилась, возвращение объекта в начальную позицию
            transform.localPosition = initialPosition;
        }
    }

    public void Shake()
    {
        currentShakeDuration = shakeDuration;
    }
}