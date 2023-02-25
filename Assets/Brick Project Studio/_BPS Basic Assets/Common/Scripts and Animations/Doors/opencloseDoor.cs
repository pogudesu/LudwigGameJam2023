using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

namespace SojaExiles

{
	public class opencloseDoor : Interactables
	{

		public Animator openandclose;
		public bool open;
		public Transform Player;
		[SerializeField]
		private AudioSource audiosource;
		private GameObject audioSourceObj;
		public AudioClip sfx_open;
		public AudioClip sfx_close;
		public TriggerFinalCutScene triggerFinalCutScene;
		public bool isReadyForCutScene = false;
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
			base.Update();
        }

        public override bool Interact()
        {
			if(distanceToPlayer < interactableDistance)
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
<<<<<<< HEAD
		*/



		public IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			if (audiosource != null)
			{
				audiosource.clip = sfx_open;
				audiosource.Play();
			}
			open = true;
			if (triggerFinalCutScene && isReadyForCutScene)
			{
				triggerFinalCutScene.StartFinalCutscene();
			}
			yield return new WaitForSeconds(.5f);
		}

		public IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
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