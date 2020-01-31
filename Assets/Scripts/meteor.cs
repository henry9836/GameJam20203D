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
    public bool isSubDivide = false;
    public GameObject meteorobj;
    public float hitspred = 0.9f;

    private float lifetime = 30.0f;

    public float HP = 100.0f;

    void Start()
    {
        Debug.Log("hi");
        StartCoroutine(grow());
        initsize = Random.Range(2.0f, 4.0f);
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.LookAt(player.transform.position);
    }

    void Update()
    {
        this.transform.localScale = new Vector3(size, size, size);
        this.gameObject.GetComponent<Rigidbody>().mass = 150.0f;

        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void isshot()
    {

        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(GetComponent<Rigidbody>());

        GameObject meteorobj1 = Instantiate(meteorobj, transform.position, transform.rotation);
        meteorobj1.GetComponent<meteor>().isSubDivide = true;
        meteorobj1.GetComponent<meteor>().size = size * 0.65f;
        meteorobj1.GetComponent<meteor>().HP = 100.0f;
        meteorobj1.GetComponent<SphereCollider>().enabled = true;
        meteorobj1.GetComponent<MeshRenderer>().enabled = true;

        GameObject meteorobj2 = Instantiate(meteorobj, transform.position, transform.rotation);
        meteorobj2.GetComponent<meteor>().isSubDivide = true;
        meteorobj2.GetComponent<meteor>().size = size * 0.65f;
        meteorobj2.GetComponent<meteor>().HP = 100.0f;
        meteorobj2.GetComponent<SphereCollider>().enabled = true;
        meteorobj2.GetComponent<MeshRenderer>().enabled = true;

        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (DeathIsInevitable == false)
        {
            if (collision.gameObject.tag != gameObject.tag)
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
    }


    public IEnumerator grow()
    {
        if (isSubDivide == false)
        {
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 1.0f)
            {
                size = Mathf.Lerp(0.0f, initsize, t);
                yield return null;
            }
            Vector3 dir = -(this.transform.position - player.transform.position).normalized;
            this.gameObject.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
        }
        else 
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            float yrand = Random.Range(hitspred, -hitspred);
            float xrand = Random.Range(Mathf.Sqrt(Mathf.Pow(hitspred, 2) - Mathf.Pow(yrand, 2)), -Mathf.Sqrt(Mathf.Pow(hitspred, 2) - Mathf.Pow(yrand, 2)));
            Vector3 vec3dir = new Vector3(xrand, yrand, 1);
            vec3dir = this.transform.rotation * vec3dir;

            this.gameObject.GetComponent<Rigidbody>().AddForce(vec3dir * speed, ForceMode.Impulse);
        }
    }
}
