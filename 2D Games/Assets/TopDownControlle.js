 #pragma strict
 
 //Inspector Variables
   var playerSpeed : float = 10; //speed player moves
   
   function Update () 
   {
   
       MoveForward(); // Player Movement 
   }
   
   function MoveForward()
   {
   
       if(Input.GetKey("up"))//Press up arrow key to move forward on the Y AXIS
       {
           transform.Translate(0,playerSpeed * Time.deltaTime,0);
       }
       if(Input.GetKey("down"))//Press up arrow key to move forward on the Y AXIS
       {
           transform.Translate(0,-playerSpeed * Time.deltaTime,0);
       }
       if(Input.GetKey("left"))//Press up arrow key to move forward on the Y AXIS
       {
           transform.Translate(-playerSpeed * Time.deltaTime,0 ,0);
       }
       if(Input.GetKey("right"))//Press up arrow key to move forward on the Y AXIS
       {
           transform.Translate(playerSpeed * Time.deltaTime,0 ,0);
       }
   }