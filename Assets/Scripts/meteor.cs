using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public float size = 1.0f;
    public float additionalexplosionraduis = 1.0f;
    public LayerMask distructable;
    public float initsize = 3.0f;
    public float speed = 1.0f;
    public GameObject player;
    public bool DeathIsInevitable = false;

    void Start()
    {
        StartCoroutine(grow());
        initsize = Random.Range(2.0f, 4.0f);

        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        this.transform.localScale = new Vector3(size, size, size);
        this.gameObject.GetComponent<Rigidbody>().mass = ((4.0f / 3.0f) * Mathf.PI * Mathf.Pow(size, 3.0f));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (DeathIsInevitable == false)
        {
            DeathIsInevitable = true;
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, size + additionalexplosionraduis, transform.forward, 1.0f, distructable);
            foreach (var hit in hits)
            {
                Debug.Log(hit.transform.gameObject.name);
                hit.transform.gameObject.GetComponent<distructableObjs>().HP -= size * 25.0f;
            }
            Destroy(this.gameObject);
        }
    }


    public IEnumerator grow()
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 1.0f)
        {
            size = Mathf.Lerp(0.0f, initsize , t);
            yield return null;
        }
        Vector3 dir = -(this.transform.position - player.transform.position).normalized;
        Debug.Log(dir * speed);
        this.gameObject.GetComponent<Rigidbody>().AddForce(dir * speed , ForceMode.Impulse);
    }

}
