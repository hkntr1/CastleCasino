using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float expForce, radius;

    private void Start()
    {
        Timer.countDown?.Invoke();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }
   public void knockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearyby in colliders)
        {
            Rigidbody rigg = nearyby.GetComponent<Rigidbody>();
            if (rigg != null)
            {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }
}