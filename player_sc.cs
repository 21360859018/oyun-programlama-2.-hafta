using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
   [SerializeField]
   private float _speed=3.5f;

   [SerializeField] // Değişkenin görünür olması için SerializeField ekleniyor
   private GameObject laserPrefab; // Private olarak değiştirildi

   
   [SerializeField]
   private float _fireRate=0.15f;
   private float _nextFire=0f;

    [SerializeField]
    private int _lives=3;

   Spawn_Maneger_sc spawn_Maneger_sc ;  // değişken tanımladık

    bool isTripleShotActive = false;
    [SerializeField]
    GameObject tripleShotPrefab;


       void Start()
    {
       // transform.position=new Vector3(-2,0,0);
       // transform.Translate(new Vector3(1,0,0));
       // transform.Translate(new Vector3(-1,0,0));

          spawn_Maneger_sc = GameObject.Find("Spawn_Maneger").GetComponent<Spawn_Maneger_sc>();
          if(spawn_Maneger_sc == null)
          {  
            Debug.LogError("spawn_Maneger_sc bileşeni bulunamadi!");
          }



    }

    // Update is called once per frame
    void Update()
    {
           Calculate_Movement(); 

        if(Input.GetKeyDown(KeyCode.Space) && Time.time>_nextFire)  // atış yapılan yer
        {
           FireLaser();          

        }
      // Damage();

    }

   void FireLaser()
   {
        if(!isTripleShotActive)
        {

           Instantiate(laserPrefab, transform.position + new Vector3(0,1.05f, 0), Quaternion.identity);
        
        }
        else
         {
        Instantiate(tripleShotPrefab,transform.position + new Vector3(-0.5f, 1.05f, 0), Quaternion.identity);
        

        }      

         _nextFire = Time.time + _fireRate; // Son ateş zamanını güncelle
 
   }

    void Calculate_Movement()
    {

         float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction= new Vector3(horizontalInput,verticalInput,0);
        transform.Translate(direction*_speed*Time.deltaTime);
        
        transform.position= new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-3.8f,0),0);
        
         transform.position= new Vector3(Mathf.Clamp(transform.position.x,-7.5f,10.0f),transform.position.y,0);
        
    }



    public void Damage()
    {
        _lives--;
         Debug.Log("Current Lives: " + _lives); // Mevcut canı konsola yazdır
        if(_lives<0)
        {
            if(spawn_Maneger_sc != null)
             spawn_Maneger_sc.OnPlayerDeath();
            
            Destroy(this.gameObject);
        }

    }

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Enemy")) // "Enemy" etiketi ile çarpışmayı kontrol eder
    {
        Damage(); // Çarpışma gerçekleştiğinde canı azaltan Damage metodunu çağırır
    }
}


public void ActivateTripleShot()
{
   isTripleShotActive = true;
   // 5 saniye sonra
   

   StartCoroutine(TripleShotBonusDisableRoutine());  

}

IEnumerator TripleShotBonusDisableRoutine()
{

yield return new WaitForSeconds(5.0f);
isTripleShotActive = false;

}


}
