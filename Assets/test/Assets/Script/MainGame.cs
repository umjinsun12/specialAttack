using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour
{

    #region ���� Photon ������ ����!
    //public GameObject Player1;
    //public GameObject enemy;
    #endregion

    private Vector3[] GenPoint = new Vector3[]{
        new Vector3(-4.5f, 10f, 0f), 
        new Vector3(-3f, 10f, 0f), 
        new Vector3(-1.5f, 10f, 0f),
        new Vector3(0f, 10f, 0f),
        new Vector3(1.5f, 10f, 0f),
        new Vector3(3f, 10f, 0f),
        new Vector3(4.5f, 10f, 0f)};

    private float GenStart = 0f;
    private float GenTerm = 3f;
    private float DropSpeed = 5f;



	// Use this for initialization
	void Start () {
        GenStart = Time.time;
        //���� Photon���� ���� ���� 
        //Instantiate(Player1, new Vector3(0f, 0f, 0f), Quaternion.Euler(new Vector3(0f,0f,180f)));
	}
	
	// Update is called once per frame
	void Update () {
        //���� Photon���� ���� ��ȭ
        if (PhotonNetwork.isMasterClient == true ) EnemyGen();
	}

    void EnemyGen()
    {
        if (GenStart + GenTerm > Time.time) return;
        
        //GenTerm -= 0.01f;
        DropSpeed += 0.02f;
        StartCoroutine("EnemyDrop");
        GenStart = Time.time;

    }

    IEnumerator EnemyDrop()
    {
        foreach (Vector3 genposition in GenPoint)
        {
            //���� Photon���� ���� ��ȭ
           GameObject gobj = PhotonNetwork.InstantiateSceneObject("enemy", genposition, Quaternion.identity, 9, null) as GameObject;
           if (gobj.GetComponent<Enemy>() != null) gobj.GetComponent<Enemy>().Set_Speed(DropSpeed);
        }
        return null;
    }
}
