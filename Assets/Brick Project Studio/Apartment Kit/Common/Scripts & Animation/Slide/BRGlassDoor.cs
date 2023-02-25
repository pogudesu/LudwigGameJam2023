using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class BRGlassDoor : Interactables
	{

		public Animator openandclose;
		public bool open;
		public Transform Player;
		public AudioSource audiosource;
		public AudioClip sfx_open;
		public AudioClip sfx_close;

		public override void Start()
		{
			open = false;
			//if (PlayerController.Instance.transform != null)
			//{
			//	Player = PlayerController.Instance.transform;
			//}
			base.Start();
		}

		public override void Update()
		{
			base.Update();
		}

		public override bool Interact()
		{
			if (distanceToPlayer < interactableDistance)
			{
				if (open == false)
				{
					StartCoroutine(opening());
				}
				else
				{
					StartCoroutine(closing());
				}
			}
			return false;
		}
		/*
		void OnMouseOver()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 15)
					{
						if (open == false)
						{
							if (Input.GetMouseButtonDown(0))
							{
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetMouseButtonDown(0))
								{
									StartCoroutine(closing());
								}
							}

						}

					}
				}

			}

		}
		*/
		IEnumerator opening()
		{
			print("you are opening");
			openandclose.Play("BRGlassDoorOpen");
			if (audiosource != null)
			{
				audiosource.clip = sfx_open;
				audiosource.Play();
			}
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing");
			openandclose.Play("BRGlassDoorClose");
			if (audiosource != null)
			{
				audiosource.clip = sfx_close;
				audiosource.Play();
			}
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}