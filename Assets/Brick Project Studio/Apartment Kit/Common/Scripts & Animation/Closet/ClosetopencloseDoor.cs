using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class ClosetopencloseDoor : Interactables
	{

		public Animator Closetopenandclose;
		public bool open;
		public Transform PlayerControl;
		public AudioSource audiosource;
		private GameObject audioSourceObj;
		public AudioClip sfx_open;
		public AudioClip sfx_close;
		[SerializeField] float sfx_volume = 0.0f;

		public override void Start()
		{
			open = false;
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
				if (PlayerControl)
				{
					float dist = Vector3.Distance(PlayerControl.position, transform.position);
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
			Closetopenandclose.Play("ClosetOpening");
			if (audiosource != null)
			{
				audiosource.volume = sfx_volume;
				audiosource.clip = sfx_open;
				audiosource.Play();
			}
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			Closetopenandclose.Play("ClosetClosing");
			if (audiosource != null)
			{
				audiosource.volume = sfx_volume;
				audiosource.clip = sfx_close;
				audiosource.Play();
			}
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}