using UnityEngine;
using UnityEngine.UI;
using TanksBattle.Core.Interface;

namespace TanksBattle.Tank.MVC
{
    public class TankView : MonoBehaviour, IDamageable
    {
        protected TankController m_controller;


        [Header("Explosion")]
        public ParticleSystem explosion;
        public AudioSource explosionAudio;

        [Header("Health")]
        public Image healthBar;

        [Header("Componenets")]
        public Rigidbody rb;
        public MeshRenderer[] meshs;

        [Header("Firing")]
        public Transform firePoint;

        //Setter
        public void SetTankController(TankController controller) => m_controller = controller;
        public void SetHealthBar(float value) => healthBar.fillAmount = value;
        public void SetMaterial(Material mat)
        {
            for (int i = 0; i < meshs.Length; i++)
            {
                meshs[i].material = mat;
            }
        }

        //Getter
        public Rigidbody GetRigidbody() => rb;

        // Interface
        public void TakeDamage(float value) => m_controller.TakeDamage(value);

        public void PlayerDead()
        {
            explosion.transform.SetParent(null);
            explosion.Play();
            explosionAudio.Play();
            Destroy(explosion.gameObject, Mathf.Max(explosion.main.duration, explosionAudio.clip.length));
            Destroy(gameObject);
        }
    }
}