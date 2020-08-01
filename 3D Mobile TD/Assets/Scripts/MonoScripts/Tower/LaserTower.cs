using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : Tower
{
    [Header("Laser Settings")]
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private ParticleSystem _laserImpactParticle;
    [SerializeField] private Light _laserLight;

    protected override void Start()
    {
        base.Start();

        _bulletPrefab = null;
        if (_lineRenderer != null)
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }
        else
        {
            print("Laser is not found!");
        }
    }

    protected override void Update()
    {
        base.Update();

        if (target == null)
        {
            if (_lineRenderer.enabled)
            {
                _lineRenderer.enabled = false;
                _laserImpactParticle.Stop();
                _laserLight.enabled = false;
            }
            return;
        }

        if (targetEnemy != null)
        {
            Laser();
        }
    }

    private void Laser()
    {
        if (target != null)
        {
            target.gameObject.GetComponent<Enemy>().TakeDamage(towerData.laserDamageOverTime * Time.deltaTime);

            if (!_lineRenderer.enabled)
            {
                _lineRenderer.enabled = true;
                _laserImpactParticle.Play();
                _laserLight.enabled = true;
            }
            _lineRenderer.SetPosition(0, _firePoint.position);
            _lineRenderer.SetPosition(1, target.position);

            Vector3 dir = _firePoint.transform.position - target.position;

            _laserImpactParticle.transform.position = target.position + dir.normalized * .5f;

            _laserImpactParticle.transform.rotation = Quaternion.LookRotation(dir);
        }
        else
        {
            Debug.LogWarning("Laser target is null");
        }
    }
}
