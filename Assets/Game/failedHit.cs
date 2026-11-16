using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failedHit : MonoBehaviour
{
    public AudioSource failedHitSnd;
    public randomclickgame mRandomclickgame;
    [SerializeField] private Transform hit_hole_prefab, holes_parent;

    private void OnMouseDown()
    {
        if(mRandomclickgame.bullets != 0)
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // получаем координаты клика мыши
            clickPosition.z = 0; // устанавливаем z-координату на 0, чтобы объект не появлялся в глубине сцены
            Instantiate(hit_hole_prefab, clickPosition, Quaternion.identity, holes_parent); // спавним объект в месте клика
            mRandomclickgame.bullets--;
            failedHitSnd.PlayOneShot(failedHitSnd.clip);
            mRandomclickgame.UpdateBulletsText();
        }
    }
}
