using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    /// <summary>
    /// x = ±æÀÌ , y = Æø
    /// </summary>
    [SerializeField] private Vector2 _size = new Vector2(7,3);
    [SerializeField] private LayerMask _enemtLayerMask;
    private float _lifeTime;


    public Transform targetPos;

    private void Start()
    {
        LayerShot();
    }

    public void LayerShot()
    {
        float random = Random.Range(0f,360f);
        transform.rotation = Quaternion.Euler(0,0, random);

        Collider2D[] colliders = Physics2D.OverlapBoxAll(targetPos.position, _size, transform.rotation.z, _enemtLayerMask);

        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject.TryGetComponent<CommonMob>(out CommonMob component))
            {
                component.GetDamage(80);
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
    
}
