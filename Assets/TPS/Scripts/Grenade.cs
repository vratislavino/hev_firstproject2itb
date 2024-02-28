using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float timeToDestroy = 4;

    [SerializeField]
    private float range = 6;

    [SerializeField]
    private float dmgMultiplier = 5;

    [SerializeField]
    public ParticleSystem ExplosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedExplode());
    }

    private IEnumerator DelayedExplode()
    {
        yield return new WaitForSeconds(timeToDestroy);
        var colliders = Physics.OverlapSphere(transform.position, range);

        foreach(var col in colliders) {
            var dmg = col.GetComponent<IDamagable>();
            if (dmg != null) {
                var dmgBasedOnDistance = range- Vector3.Distance(col.transform.position, transform.position);
                dmg.DoDmg((int)(dmgBasedOnDistance * dmgMultiplier));
            }
        }
        ExplosionParticles.transform.SetParent(null);
        ExplosionParticles.transform.rotation = Quaternion.identity;
        ExplosionParticles.Emit(500);
        Destroy(gameObject);
    }
}
