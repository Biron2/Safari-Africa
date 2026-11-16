using UnityEngine;
using UnityEngine.UI;

public class animal_script : MonoBehaviour
{
    public Image[] images;
    public float imageSwitchTime = 1.0f;
    public Image trailImagePrefab;
    public float trailFadeTime = 0.1f;

    // Movement parameters
    public float movementSpeed = 2f;
    public float stopDuration = 2f; // Duration of stop
    public float mapWidth = 10f; // Width of the map


    private int currentIndex = 0;
    private Image currentImage;
    private Image trailImage;

    private float timer = 0f;
    private float stopTimer = 0f; // Timer for the stop duration
    private bool isStopped = false; // Flag to track if the animal is stopped
    public bool facingLeft = true; // Flag to track movement direction

    private int newPosRot = 0;

    [Header("Chances")]
    public float stopChance = 0.05f; // 0.05% chance to stop
    public float chanceToChangeFacingLeft = 0.1f;
    private void Awake()
    {
        if(Random.Range(0, 2) == 0)
        {
            facingLeft = true;
        }
        else
        {
            facingLeft = false;
        }
    }

    void Start()
    {
        currentImage = images[currentIndex];
        currentImage.gameObject.SetActive(true);
    }

    void Update()
    {
        // Movement logic
        if (!isStopped)
        {

            // Check for reaching map boundaries
            if (transform.position.x < -mapWidth / 2 && facingLeft)
            {
                facingLeft = false;
            }
            else if (transform.position.x > mapWidth / 2 && !facingLeft)
            {
                facingLeft = true;
            }

            // Move the animal based on direction
            if (facingLeft)
            {
                transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
                foreach (Image img in images)
                {
                    img.transform.rotation = new Quaternion(0, 180, 0, 0);
                }
                newPosRot = 180;
            }
            else
            {
                foreach(Image img in images)
                {
                    img.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
                newPosRot = 0;
            }

            // Check for stopping chance
            if (Random.value < stopChance)
            {
                isStopped = true;
                stopTimer = 0f;
            }
            if ((transform.position.x < -mapWidth / 2 && facingLeft) || (transform.position.x > mapWidth / 2 && !facingLeft))
            {
                // √енерируем случайное число от 0 до 1
                if (Random.value < chanceToChangeFacingLeft)
                {
                    facingLeft = !facingLeft; // мен€ем значение facingLeft
                }
            }
        }
        else
        {
            // Stop timer
            stopTimer += Time.deltaTime;

            // Resume movement after stop duration
            if (stopTimer >= stopDuration)
            {
                isStopped = false;
            }
        }

        // Image animation logic
        if (!isStopped)
        {
            timer += Time.deltaTime;

            if (timer >= imageSwitchTime)
            {
                if (currentImage != null)
                {
                    if (trailImage != null)
                    {
                        Destroy(trailImage.gameObject, trailFadeTime);
                    }

                    trailImage = Instantiate(trailImagePrefab, currentImage.transform.position, Quaternion.identity, transform);

                    // ƒобавл€ем дергание по оси Y
                    float yOffSet = Mathf.Sin(timer * 5f) * 0.1f; // ѕараметры Sin могут быть изменены под ваши нужды
                    Vector3 newPos = currentImage.transform.position + new Vector3(0, yOffSet, 0);

                    trailImage.transform.position = newPos;
                    trailImage.transform.Rotate(0, newPosRot, 0);
                    trailImage.sprite = currentImage.sprite;
                    trailImage.color = new Color(1f, 1f, 1f, 0.5f);

                    currentImage.gameObject.SetActive(false);

                    currentIndex = (currentIndex + 1) % images.Length;
                    currentImage = images[currentIndex];
                    currentImage.gameObject.SetActive(true);

                    timer = 0f;
                }
            }
        }
        else
        {
            if (trailImage != null)
            {
                Destroy(trailImage.gameObject, trailFadeTime);
            }
        }
    }
}