#pragma strict
 @script RequireComponent(Rigidbody2D)
 
 var Speed : float = 5;
 var RotationSpeed : float = 3;
 
 function Awake(){
     GetComponent.<Rigidbody2D>().angularDrag = 1;
     GetComponent.<Rigidbody2D>().drag = 1;
     GetComponent.<Rigidbody2D>().mass = 1;
     GetComponent.<Rigidbody2D>().gravityScale = 0;
 }
 
 function FixedUpdate() {
     var ZRotation : int = Input.GetAxis("Horizontal") * RotationSpeed;
     var YSpeed : int = Input.GetAxis("Vertical") * Speed;
     GetComponent.<Rigidbody2D>().AddTorque(-ZRotation, 0);
     GetComponent.<Rigidbody2D>().AddForce(transform.up * YSpeed);
     
 }