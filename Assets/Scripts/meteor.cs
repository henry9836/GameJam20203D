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
    public float deathDealy = 0.5f;
    public GameObject particlePrefab;
    public Vector2 StartSizeRange = new Vector2(6.0f, 10.0f);
    private float lifetime = 30.0f;

    public float HP = 100.0f;

    void Start()
    {
        StartCoroutine(grow());
        initsize = Random.Range(StartSizeRange.x, StartSizeRange.y);
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.LookAt(player.transform.position);
    }

    void Update()
    {
        this.transform.localScale = new Vector3(size, size, size);
        this.gameObject.GetComponent<Rigidbody>().mass = 500.0f;

        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void isshot()
    {

        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(GetComponent<Rigidbody>());

        GameObject meteorobj1 = Instantiate(meteorobj, transform.position, transform.rotation);
        meteorobj1.GetComponent<meteor>().isSubDivide = true;
        meteorobj1.GetComponent<meteor>().size = size * 0.45f;
        meteorobj1.GetComponent<meteor>().HP = 100.0f;
        meteorobj1.GetComponent<MeshCollider>().enabled = true;
        meteorobj1.GetComponent<MeshRenderer>().enabled = true;

        GameObject meteorobj2 = Instantiate(meteorobj, transform.position, transform.rotation);
        meteorobj2.GetComponent<meteor>().isSubDivide = true;
        meteorobj2.GetComponent<meteor>().size = size * 0.45f;
        meteorobj2.GetComponent<meteor>().HP = 100.0f;
        meteorobj2.GetComponent<MeshCollider>().enabled = true;
        meteorobj2.GetComponent<MeshRenderer>().enabled = true;

        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (DeathIsInevitable == false)
        {
            Instantiate(particlePrefab, collision.contacts[0].point, Quaternion.identity);

            if (collision.gameObject.tag != gameObject.tag)
            {
                DeathIsInevitable = true;
                RaycastHit[] hits = Physics.SphereCastAll(transform.position, size + additionalexplosionraduis, transform.forward, 1.0f, distructable);
                foreach (var hit in hits)
                {

                    Debug.Log(hit.transform.gameObject.name);

                    //Tree Logic
                    if (hit.collider.tag == "mineableWood")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    //TV Logic
                    if (hit.collider.tag == "TVOBJ")
                    {
                        hit.collider.gameObject.SetActive(false);
                    }
                    else
                    {
                        hit.transform.gameObject.GetComponent<distructableObjs>().HP -= size * 5.0f;
                    }
                }

                hits = Physics.SphereCastAll(transform.position, 60.0f, transform.forward, 1.0f);
                foreach (var hit in hits)
                {

                    if (hit.collider.tag == "Player")
                    {
                        Debug.Log("boom");

                        hit.collider.transform.gameObject.GetComponent<Rigidbody>().AddExplosionForce(470.0f, this.transform.position, 300.0f, 6.0f);
                    }
                }
                StartCoroutine(despawn());
            }
        }
    }


    public IEnumerator grow()
    {
        if (isSubDivide == false)
        {
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * 0.3f)
            {
                size = Mathf.Lerp(0.0f, initsize, t);
                yield return null;
            }
            Vector3 dir = -(this.transform.position - (player.transform.position + new Vector3(Random.Range(8.0f, -8.0f), Random.Range(8.0f, -8.0f), Random.Range(8.0f, -8.0f)))).normalized;
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

    public IEnumerator despawn()
    {
        yield return new WaitForSeconds(deathDealy);
        Destroy(this.gameObject);

        yield return null;
    }

}
