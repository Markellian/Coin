using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float jumpHeight = 0.2f; // ��������� ������ �������
    public float jumpDuration = 0.8f; // ����������������� ������
    public float rotationSpeed = 60f; // �������� �������� (�������� � �������)

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
        // �������� ������� �������� �������
        Vector3 currentRotation = transform.localRotation.eulerAngles;

        // ����������� �������� y ��������
        currentRotation.y += rotationSpeed * Time.deltaTime;

        // ��������� ����� ��������
        transform.localRotation = Quaternion.Euler(currentRotation);

        if (isJumping)
        {
            currentJumpTime += Time.deltaTime;

            float progress = Mathf.Clamp01(currentJumpTime / jumpDuration);

            // ���������� y �� ������ ���������, ����������� ������� ������
            float targetY = startY + (jumpHeight * Mathf.Sin(progress * Mathf.PI));

            // ������������� ������� �������
            transform.localPosition = new Vector3(transform.localPosition.x, targetY, transform.localPosition.z);

            if (progress >= 1f)
            {
                isJumping = false;
                transform.localPosition = new Vector3(transform.localPosition.x, startY, transform.localPosition.z);
            }
        }
    }
}
