using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshLoader : MonoBehaviour
{
    public bool Loaded;

    public int ID = 0;
    GameObject o;

    public float colSizeX = 1.8f;
    public float colSizeY = 1.3f;
    public float colSizeZ = 4.4f;

    public Material mat; //Material for renderer (assign in inspector)

    public WheelCollider[] colliders; //Wheel colliders for driving

    public void Load()
    {
        this.transform.position = new Vector3(0, 10);
        Loaded = true;
        Data dat = SaveData.Load(); //Loading from disk

        //Assigning data for better performance i guess?
        o = new GameObject();
        Vector3 pos;
        GameObject obj;

        while (ID <= 7)
        {
            pos = new Vector3(dat.pointsX[ID], dat.pointsY[ID], dat.pointsZ[ID]); //Setting position 

            obj = Instantiate(o, pos, new Quaternion(), this.transform);  //Spawning the object
            obj.name = "p" + ID; //Renaming it for easy identification

            ID++; //Adding ID
        }

        Render();
    }

    public void Render()
    {
        LineRenderer renderer = this.gameObject.AddComponent<LineRenderer>();

        renderer.positionCount = 17;
        renderer.material = mat;
        renderer.widthMultiplier = 0.1f;

        Transform p0 = transform.GetChild(0);
        Transform p1 = transform.GetChild(1);
        Transform p2 = transform.GetChild(2);
        Transform p3 = transform.GetChild(3);
        Transform p4 = transform.GetChild(4);
        Transform p5 = transform.GetChild(5);
        Transform p6 = transform.GetChild(6);
        Transform p7 = transform.GetChild(7);

        renderer.SetPosition(0, p0.position);
        renderer.SetPosition(1, p1.position);
        renderer.SetPosition(2, p2.position);

        renderer.SetPosition(3, p3.position);
        renderer.SetPosition(4, p0.position);

        renderer.SetPosition(5, p3.position);

        renderer.SetPosition(6, p4.position);
        renderer.SetPosition(7, p5.position);
        renderer.SetPosition(8, p6.position);

        renderer.SetPosition(9, p7.position);
        renderer.SetPosition(10, p4.position);

        renderer.SetPosition(11, p7.position);
        renderer.SetPosition(12, p2.position);

        renderer.SetPosition(13, p1.position);
        renderer.SetPosition(14, p6.position);

        renderer.SetPosition(15, p5.position);
        renderer.SetPosition(16, p0.position);

        AddColliders();
    }

    void AddColliders()
    {
        GameObject p4 = transform.GetChild(4).gameObject;
        GameObject p5 = transform.GetChild(5).gameObject;
        GameObject p6 = transform.GetChild(6).gameObject;
        GameObject p7 = transform.GetChild(7).gameObject;

        this.transform.position = new Vector3(0, 15);
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.mass = 1500f;
        GameObject.FindGameObjectWithTag("Camera").GetComponent<Follow>().Child();

        BoxCollider col = this.gameObject.AddComponent<BoxCollider>();
        col.size = new Vector3(colSizeX, colSizeY, colSizeZ);
        col.center = new Vector3(0f, -10.3f, 0f);

        colliders = new WheelCollider[4];

        colliders[0] = p4.AddComponent<WheelCollider>();
        colliders[1] = p5.AddComponent<WheelCollider>();
        colliders[2] = p6.AddComponent<WheelCollider>();
        colliders[3] = p7.AddComponent<WheelCollider>();

        colliders[0].radius = 0.5f;
        colliders[1].radius = 0.5f;
        colliders[2].radius = 0.5f;
        colliders[3].radius = 0.5f;

        CarController ctrl = this.gameObject.AddComponent<CarController>();
        ctrl.Create(colliders);
    }

    public void Save()
    {
        GameObject obj = GameObject.Find("Model for save");
        SaveData.Save(obj.GetComponent<MeshData>());
    }

    public void Update()
    {
        if (Loaded)
        {
            LineRenderer renderer = this.gameObject.GetComponent<LineRenderer>();

            Transform p0 = transform.GetChild(0);
            Transform p1 = transform.GetChild(1);
            Transform p2 = transform.GetChild(2);
            Transform p3 = transform.GetChild(3);
            Transform p4 = transform.GetChild(4);
            Transform p5 = transform.GetChild(5);
            Transform p6 = transform.GetChild(6);
            Transform p7 = transform.GetChild(7);

            renderer.SetPosition(0, p0.position);
            renderer.SetPosition(1, p1.position);
            renderer.SetPosition(2, p2.position);

            renderer.SetPosition(3, p3.position);
            renderer.SetPosition(4, p0.position);

            renderer.SetPosition(5, p3.position);

            renderer.SetPosition(6, p4.position);
            renderer.SetPosition(7, p5.position);
            renderer.SetPosition(8, p6.position);

            renderer.SetPosition(9, p7.position);
            renderer.SetPosition(10, p4.position);

            renderer.SetPosition(11, p7.position);
            renderer.SetPosition(12, p2.position);

            renderer.SetPosition(13, p1.position);
            renderer.SetPosition(14, p6.position);

            renderer.SetPosition(15, p5.position);
            renderer.SetPosition(16, p0.position);
        }
    }
}
