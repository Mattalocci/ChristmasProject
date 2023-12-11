using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    [Header("Settings")]
    public weaponShoot currentWeapon;


    public void UpdateWeapon(GameObject hitbox_prefab, GameObject weapon_graphic, Vector2 position, float rotation)
    {
        currentWeapon.projectileInstance = hitbox_prefab;
        currentWeapon.weaponMesh = weapon_graphic;
        currentWeapon.weaponMesh.transform.localPosition = position;
        currentWeapon.weaponMesh.transform.localRotation = Quaternion.Euler(0f, 0f, rotation);
    }
}
