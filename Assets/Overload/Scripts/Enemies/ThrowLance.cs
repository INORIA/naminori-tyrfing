using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Overland.Scripts.Enemies
{
    public class ThrowLance : MonoBehaviour
    {
        public GameObject LancePrefab;

        // Use this for initialization
        void Start()
        {
            Fire();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void Fire()
        {
            var lance = Instantiate(LancePrefab, transform.position, Quaternion.identity);
            lance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, -200));
            Destroy(lance, 2f);
        }
    }
}
