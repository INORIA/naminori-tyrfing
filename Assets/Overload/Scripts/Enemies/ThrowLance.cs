using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Overland.Scripts.Enemies
{
    public class ThrowLance : MonoBehaviour
    {
        public GameObject LancePrefab;
        public GameObject LanceHold;

        private GameObject player;
        private bool attacked = false;
        private float attackOffset = 10f;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (this.player == null)
            {
                this.player = GameObject.FindGameObjectWithTag("Player");
            }
            else if (this.player.transform.position.x >= (transform.position.x - attackOffset))
            {
                if (!attacked)
                {
                    attacked = true;
                    Fire();
                }
            }
        }

        void Fire()
        {
            var lance = Instantiate(LancePrefab, transform.position, Quaternion.identity);
            LanceHold.SetActive(false);
            lance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, -200));
            Destroy(lance, 2f);
        }
    }
}
