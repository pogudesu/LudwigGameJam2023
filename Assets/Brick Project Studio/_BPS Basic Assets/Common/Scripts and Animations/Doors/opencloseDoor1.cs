using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor1 : Interactables
	{

		public Animator openandclose1;
		public bool open;
		public Transform Player;
		public AudioSource audiosource;
		private GameObject audioSourceObj;
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
			if (audiosource == null)
			{
				audioSourceObj = Instantiate(AudioManager.Instance.audioSourcePrefab);
				audioSourceObj.transform.position = gameObject.transform.position;
				audiosource = audioSourceObj.GetComponent<AudioSource>();
			}
			if (sfx_open == null)
			{
				sfx_open = AudioManager.Instance.sfx_defaultopen;
				sfx_close = AudioManager.Instance.sfx_defaultclose;
			}
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
			print("you are opening the door");
			openandclose1.Play("Opening 1");
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
			openandclose1.Play("Closing 1");
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