using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

namespace UnityChan
{
// 必要なコンポーネントの列記
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Rigidbody))]

	public class UnityChanMove : MonoBehaviour
	{
		public Camera cam;
		public MouseLook mouseLook = new MouseLook();

		public float animSpeed = 1.5f;				
		public float lookSmoother = 3.0f;			// a smoothing setting for camera motion
		public bool useCurves = true;				
		public float useCurvesHeight = 0.5f;		
		public float forwardSpeed = 7.0f;
		public float backwardSpeed = 2.0f;
		public float leftRightSpeed = 3.0f;
		public float jumpPower = 3.0f; 
		private CapsuleCollider col;
		private Rigidbody rb;
		private Vector3 velocity;
		private Vector3 zerontal;
		private float orgColHight;
		private Vector3 orgVectColCenter;

		private bool m_jumping = false;


		private GameObject cameraObject;

		private Animator anim;
		private AnimatorStateInfo currentBaseState;
		static int jumpState = Animator.StringToHash ("Base Layer.Jump");
		void Start ()
		{
			anim = GetComponent<Animator> ();
			col = GetComponent<CapsuleCollider> ();
			rb = GetComponent<Rigidbody> ();
			mouseLook.Init(transform, cam.transform);
			cameraObject = GameObject.FindWithTag ("MainCamera");

			orgColHight = col.height;
			orgVectColCenter = col.center;
		}

		private void Update()
		{
			RotateView();
		}
		void FixedUpdate ()
		{
			float h = Input.GetAxis ("Horizontal");				
			float v = Input.GetAxis ("Vertical");				
			anim.SetFloat ("Speed", v);							
			anim.SetFloat ("RightLeft", h);							
			//anim.SetFloat ("Direction", h); 						
			anim.speed = animSpeed;								
			currentBaseState = anim.GetCurrentAnimatorStateInfo (0);	
			rb.useGravity = true;
		
			velocity = new Vector3 (0, 0, v);
			zerontal = new Vector3(h, 0, 0);
			velocity = transform.TransformDirection (velocity);
			zerontal = transform.TransformDirection(zerontal);
			
			if (v > 0.1) {
				velocity *= forwardSpeed;		
			} else if (v < -0.1) {
				velocity *= backwardSpeed;	
			}
			if (h > 0.1)
			{
				zerontal *= leftRightSpeed;
			}
			else if (h < -0.1)
			{
				zerontal *= leftRightSpeed;
			}

			if (Input.GetButtonDown ("Jump") && m_jumping == false) {
				rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
				anim.SetBool("Jump", true);
				m_jumping = true;
				StartCoroutine(WaitAndPrint(2.5f));
				//m_jumping = false;
			}
		
			transform.localPosition += velocity * Time.fixedDeltaTime;
			transform.localPosition += zerontal * Time.fixedDeltaTime;


			if (currentBaseState.nameHash == jumpState) {
				//cameraObject.SendMessage ("setCameraPositionJumpView");	
				if (!anim.IsInTransition (0)) {
					if (useCurves) {
						float jumpHeight = anim.GetFloat ("JumpHeight");
						float gravityControl = anim.GetFloat ("GravityControl"); 
						if (gravityControl > 0)
							rb.useGravity = false;	

						Ray ray = new Ray (transform.position + Vector3.up, -Vector3.up);
						RaycastHit hitInfo = new RaycastHit ();
						if (Physics.Raycast (ray, out hitInfo)) {
							if (hitInfo.distance > useCurvesHeight) {
								col.height = orgColHight - jumpHeight;			
								float adjCenterY = orgVectColCenter.y + jumpHeight;
								col.center = new Vector3 (0, adjCenterY, 0);	
							} else {			
								resetCollider ();
							}
						}
					}
					if (this.transform.position.y >= 2 || this.transform.rotation.y <= 60) {
						m_jumping = true;
					}
					// Jump bool			
					anim.SetBool ("Jump", false);
					StartCoroutine(WaitAndPrint(4f));
					
				}
			}
		}
		void resetCollider ()
		{
			col.height = orgColHight;
			col.center = orgVectColCenter;
		}

		private void RotateView()
		{
			//avoids the mouse looking if the game is effectively paused
			if (Mathf.Abs(Time.timeScale) < float.Epsilon) return;

			// get the rotation before it's changed
			float oldYRotation = transform.eulerAngles.y;

			mouseLook.LookRotation(transform, cam.transform);

		}

		IEnumerator WaitAndPrint(float waitTime)
		{
			yield return new WaitForSeconds(waitTime);
			m_jumping = false;
		}

	}

}