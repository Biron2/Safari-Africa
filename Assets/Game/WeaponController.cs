using System.Collections;
using UnityEngine;
using YG;

public class WeaponController : MonoBehaviour
{
    public AudioSource weapons_sound;
    public AudioClip hunt_xbow, mosin_sound, karyak, noBullets, succes_hit;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public randomclickgame _Randomclickgame;
    [SerializeField] private GameObject scope_canvas, bulletPrefab;
    [SerializeField] private Transform bulletParent, bulletsSpawner;
    [SerializeField] private Camera mCamera;
    public bool isFiring = false;
    public float padding = 1f;
    private float speed = 3.5f;
    [SerializeField] private Collider2D colliderBorders;
    [SerializeField] private GameObject[] objToOffOn;
    private bool allowShoot = false;
    private void Start()
    {
        if (YandexGame.savesData.choosenWeapon == 1)
        {
            fireRate = 0.25f; 
        }
        else if (YandexGame.savesData.choosenWeapon == 2)
        {
            fireRate = 1.00f;
        }
        else if (YandexGame.savesData.choosenWeapon == 3)
        {
            fireRate = 1.75f;
        }
        StartCoroutine(allowShotInSec());
    }
    private IEnumerator allowShotInSec()
    {
        yield return new WaitForSeconds(1);
        allowShoot = true;
    }
    void MoveCamera()
    {
        Vector3 mousePos = mCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // Проверяем столкновения с фоном
        Collider2D backgroundCollider = Physics2D.OverlapPoint(mousePos);
        if (backgroundCollider != null && backgroundCollider.CompareTag("Background"))
        {
            Bounds bounds = backgroundCollider.bounds;

            float cameraWidth = mCamera.orthographicSize * mCamera.aspect;
            float cameraHeight = mCamera.orthographicSize;

            float minX = bounds.min.x + cameraWidth;  
            float maxX = bounds.max.x - cameraWidth;

            float minY = bounds.min.y + cameraHeight;
            float maxY = bounds.max.y - cameraHeight;

            Vector3 clampedPosition = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX),
                                                  Mathf.Clamp(mousePos.y, minY, maxY),
                                                  mCamera.transform.position.z);

            mCamera.transform.position = Vector3.MoveTowards(mCamera.transform.position, clampedPosition, speed * Time.deltaTime);
        }
    }

    void Update()
    {
        if(allowShoot == true)
        {
            if (_Randomclickgame.bullets > 0)
            {
                if (Input.GetMouseButton(0) && Time.time > nextFireTime && colliderBorders.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    scope_canvas.SetActive(true);
                    mCamera.orthographicSize = 1.5f;
                    foreach (GameObject obj in objToOffOn)
                    {
                        obj.SetActive(false);
                    }

                    if (!isFiring)
                    {
                        isFiring = true;
                    }
                }
                else if (Input.GetMouseButtonUp(0) && Time.time > nextFireTime && colliderBorders.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    _Randomclickgame.bullets -= 1;
                    _Randomclickgame.UpdateBulletsText();

                    Vector3 spawnPosition = bulletsSpawner.position;
                    Instantiate(bulletPrefab, spawnPosition, Quaternion.identity, bulletParent);

                    if (YandexGame.savesData.choosenWeapon == 1)
                    {
                        weapons_sound.PlayOneShot(hunt_xbow);
                    }
                    else if (YandexGame.savesData.choosenWeapon == 2)
                    {
                        weapons_sound.PlayOneShot(karyak);
                    }
                    else if (YandexGame.savesData.choosenWeapon == 3)
                    {
                        weapons_sound.PlayOneShot(mosin_sound);
                    }

                    mCamera.transform.position = new Vector3(0, 0, 0);
                    isFiring = false;
                    mCamera.orthographicSize = 5f;
                    foreach (GameObject obj in objToOffOn)
                    {
                        obj.SetActive(true);
                    }
                    scope_canvas.SetActive(false);
                    nextFireTime = Time.time + 1f / fireRate;
                }
                else if (Input.GetMouseButtonDown(0) && colliderBorders.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    weapons_sound.PlayOneShot(noBullets);
                }
                if (isFiring)
                {
                    MoveCamera();
                }
            }
        }
    }

}