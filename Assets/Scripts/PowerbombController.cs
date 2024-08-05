using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerbombController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float rangeRadius;

    [SerializeField]
    LayerMask rangedMask;

    [SerializeField]
    float damage;

    [SerializeField]
    bool isPercentage;

    Rigidbody2D _rb;

    Vector2 _direction;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb.velocity = _direction * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_rb.position, rangeRadius, rangedMask);
        foreach (Collider2D collider in colliders)
        {
            DamageableController controller = collider.GetComponent<DamageableController>();

            if (controller == null)
                continue;

            controller.TakeDamage(damage, isPercentage);
            
        }
        
        if(!collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }

}
