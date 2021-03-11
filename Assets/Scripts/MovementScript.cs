using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{   
    public GameObject charcter;
    public GameObject cube;
   
    Animator animator;
    Animation anim;
    public bool gotoCube_flag = false;
    public int stages_flag = 0;
    public bool returnedwithCube_flag = false;

   
    // Start is called before the first frame update
    void Start()
    {
     
       charcter = GameObject.Find("Barbarian");
      
        cube = GameObject.Find("ImageTarget_Cube02");

        animator = GetComponent<Animator>();
        anim = charcter.GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        float charcterX = charcter.transform.position.x;
        float charcterY = charcter.transform.position.y;
        float charcterZ = charcter.transform.position.z;

        float cubeX = cube.transform.position.x;
        float cubeY = cube.transform.position.y;
        float cubeZ = cube.transform.position.z;

        float disctance = Mathf.Sqrt(Mathf.Pow(charcterX - cubeX, 2) + Mathf.Pow(charcterY - cubeY, 2) + Mathf.Pow(charcterZ - cubeZ, 2));
       // Debug.Log(string.Format("{0}-{1}-{2}", disctance,gotoCube_flag,stages_flag));







        if (disctance < 12 && disctance > 4 && !gotoCube_flag && stages_flag==0) // in range of cube
        {
            anim.Play("Walk");
            transform.Translate(new Vector3(0, 0, 1.2f) * Time.deltaTime);
        }

        if (disctance < 4 && stages_flag==0) // close to cube
        {

          // Debug.Log("i got the cube");
            anim.Play("Walk");
            
            gotoCube_flag = true;
            stages_flag += 1;
        }

        if (stages_flag == 1) // interact with cube
        {
            transform.Rotate(new Vector3(0, 180, 0));

            stages_flag += 1;

        }

        if (stages_flag == 2)// come back
        {

            transform.Translate(new Vector3(0, 0, 1.2f) * Time.deltaTime);
            
        }

        if( disctance > 12) // far away from cube
        {
            anim.Play("Idle");
            transform.Translate(new Vector3(0, 0, 0));
            
            if (gotoCube_flag) // far way from cube initial position and has cube
            {
                stages_flag += 1; //final stage
            }
        }

    }
}
