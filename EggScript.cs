using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class EggScript : MonoBehaviour
{
    public static EggScript s_instance;

    public Mesh egg_mesh = null;
    public Material egg_material = null;

    void Awake()
    {
        if (s_instance != null)
        {
            Destroy(this);
        }

        s_instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        if (s_instance == null) { return; }

        egg_mesh = s_instance.gameObject.GetComponent<MeshFilter>().sharedMesh;
        egg_material = s_instance.gameObject.GetComponent<MeshRenderer>().material;
        MonoBehaviour behaviour = (MonoBehaviour)UnityEngine.Object.FindObjectOfType(typeof(MonoBehaviour));
        behaviour.StartCoroutine(Change(egg_mesh, egg_material));
        s_instance.gameObject.GetComponent<MeshFilter>().sharedMesh = null;
    }

    void Update()
    {
       
    }

    IEnumerator Change(Mesh mesh, Material material)
    {
        yield return new WaitForSeconds(1f);


        GameObject notesParent = GameObject.Find("[SongTrack]");

        int count = notesParent.transform.childCount;

        for (int i = 0; i < count; i++)
        {
            Transform note = notesParent.transform.GetChild(i);

            MeshFilter[] mfs = note.GetComponentsInChildren<MeshFilter>(true);
            MeshRenderer[] mrs = note.GetComponentsInChildren<MeshRenderer>(true);

            mfs[0].sharedMesh = mesh;
            mrs[0].material.SetTexture("_MainTex", material.GetTexture("_MainTex"));
        }
    }

    public static void DestroyEggScript()
    {
        if (s_instance == null) { return; }

        Destroy(s_instance);
    }
}
