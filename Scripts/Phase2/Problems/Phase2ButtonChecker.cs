using UnityEngine;
using System.Collections;

public class Phase2ButtonChecker : MonoBehaviour 
{
    [SerializeField]
    private PhaseTwoProblemSolver phaseTwoProblemSolver;
    [SerializeField]
    private PhaseTwoProblemGenerator phase2gen;
	[SerializeField] 
	private AudioSource ClickSound;


    public void PenguKeeperButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.KeeperProblemSolver("penguin", 0, 3, true);

    }

    public void PenguVetButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.VetProblemSolver("penguin", 4, 7, true);
    }

    public void PandaKeeperButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.KeeperProblemSolver("panda", 8, 11, true);
    }

    public void PandaVetButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.VetProblemSolver("panda", 12, 15, true);
    }

    public void GorillaKeeperButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.KeeperProblemSolver("gorilla", 16, 19, true);
    }

    public void GorillaVetButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.VetProblemSolver("gorilla", 20, 23, true);
    }


    public void ZebraKeeperButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.KeeperProblemSolver("zebra", 24, 27, true);
    }

    public void ZebraVetButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.VetProblemSolver("zebra", 28, 31, true);
    }

    public void KangarooKeeperButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.VetProblemSolver("kangaroo", 32, 35, true);
    }

    public void KangarooVetButton()
    {
		ClickSound.Play ();
        phaseTwoProblemSolver.VetProblemSolver("kangaroo", 36, 39, true);
    }

    public void GeneralCuratorButton()
    {
        ClickSound.Play();
        phaseTwoProblemSolver.GeneralCuratorProblemSolver("curator", 40, 43, true);
    }

    public void GeneralServicesButton()
    {
        ClickSound.Play();
        phaseTwoProblemSolver.GeneralServicesProblemSolver("services", 44, 47, true);
    }
}
