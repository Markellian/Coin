using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float jumpHeight = 0.2f; // Насколько высоко прыгать
    public float jumpDuration = 0.8f; // Продолжительность прыжка
    public float rotationSpeed = 60f; // Скорость вращения (градусов в секунду)

    private float currentJumpTime = 0f;
    private float startY;
    private bool isJumping = false;

    void Start()
    {
        startY = transform.localPosition.y;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            currentJumpTime = 0f;
        }
        
    }
    void Update()
    {
        // Получаем текущее вращение объекта
        Vector3 currentRotation = transform.localRotation.eulerAngles;

        // Увеличиваем значение y вращения
        currentRotation.y += rotationSpeed * Time.deltaTime;

        // Применяем новое вращение
        transform.localRotation = Quaternion.Euler(currentRotation);

        if (isJumping)
        {
            currentJumpTime += Time.deltaTime;

            float progress = Mathf.Clamp01(currentJumpTime / jumpDuration);

            // Вычисление y на основе синусоиды, обеспечивая плавный прыжок
            float targetY = startY + (jumpHeight * Mathf.Sin(progress * Mathf.PI));

            // Устанавливаем позицию объекта
            transform.localPosition = new Vector3(transform.localPosition.x, targetY, transform.localPosition.z);

            if (progress >= 1f)
            {
                isJumping = false;
                transform.localPosition = new Vector3(transform.localPosition.x, startY, transform.localPosition.z);
            }
        }
    }
}
