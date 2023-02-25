using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{

	public class Drawer_Pull_X : Interactables
	{

		public Animator pull_01;
		public bool open;
		public Transform Player;
		public AudioSource audiosource;
		public AudioClip sfx_open;
		public AudioClip sfx_close;

		public override void Start()
		{
			open = false;
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
					if (dist < 10)
					{
						print("object name");
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
			print("you are opening the door");
			pull_01.Play("openpull_01");
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
			print("you are closing the door");
			pull_01.Play("closepush_01");
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