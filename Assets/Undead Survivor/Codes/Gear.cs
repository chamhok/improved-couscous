using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType type;
    public float rate;

    public void Init(ItemData data)
    {
        //베이직 세팅
        name = "Gear " + data.itemId;
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero;

        //프로퍼티 세팅
        type = data.itemType;
        rate = data.damages[0];
        ApplyGear();
    }

    public void LevelUp (float rate)
    {
        ApplyGear();
        this.rate = rate;
    }
     
    void ApplyGear()
    {
        switch (type)
        {
           
            case ItemData.ItemType.Glove:
                RateUp();
                break;
            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;
            
        }
    }

    void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    float speed = 300 * Character.WaeponSpeed;
                    weapon.speed = speed + (speed * rate);
                    break;
                default:
                     speed = 0.5f * Character.WaeponRate;
                    weapon.speed = speed * (1f - rate);
                    break;
            }
        }
    }

    void SpeedUp()
    {
        float speed = 3 * Character.Speed;
        GameManager.instance.player.speed = speed + speed * rate;
    }
}
