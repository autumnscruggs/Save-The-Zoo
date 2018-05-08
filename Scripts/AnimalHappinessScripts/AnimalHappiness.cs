using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnimalHappiness : MonoBehaviour {

    private int animalHappiness;

    private StarList starList;
    private List<Sprite> starImages;

    // Use this for initialization
    void Start()
    {
        starList = this.GetComponent<StarList>();
        starImages = starList.stars;
    }

    public void DisplayMainAnimalHappiness(int animalHappiness, Image mainMenuImage, Image subMenuImage, Image phase2MenuImage)
    {
        if (animalHappiness <= 10 && animalHappiness <= 19)
        {
            mainMenuImage.sprite = starImages[0];
            subMenuImage.sprite = starImages[0];
            phase2MenuImage.sprite = starImages[0];
        }

        else if (animalHappiness >= 20 && animalHappiness <= 29)
        {
            mainMenuImage.sprite = starImages[1];
            subMenuImage.sprite = starImages[1];
            phase2MenuImage.sprite = starImages[1];
        }

        else if (animalHappiness >= 30 && animalHappiness <= 39)
        {
            mainMenuImage.sprite = starImages[2];
            subMenuImage.sprite = starImages[2];
            phase2MenuImage.sprite = starImages[2];
        }

        else if (animalHappiness >= 40 && animalHappiness <= 49)
        {
            mainMenuImage.sprite = starImages[3];
            subMenuImage.sprite = starImages[3];
            phase2MenuImage.sprite = starImages[3];
        }

        else if (animalHappiness >= 50 && animalHappiness <= 59)
        {
            mainMenuImage.sprite = starImages[4];
            subMenuImage.sprite = starImages[4];
            phase2MenuImage.sprite = starImages[4];
        }

        else if (animalHappiness >= 60 && animalHappiness <= 69)
        {
            mainMenuImage.sprite = starImages[5];
            subMenuImage.sprite = starImages[5];
            phase2MenuImage.sprite = starImages[5];
        }

        else if (animalHappiness >= 70 && animalHappiness <= 79)
        {
            mainMenuImage.sprite = starImages[6];
            subMenuImage.sprite = starImages[6];
            phase2MenuImage.sprite = starImages[6];
        }

        else if (animalHappiness >= 80 && animalHappiness <= 89)
        {
            mainMenuImage.sprite = starImages[7];
            subMenuImage.sprite = starImages[7];
            phase2MenuImage.sprite = starImages[7];
        }

        else if (animalHappiness >= 90 && animalHappiness <= 99)
        {
            mainMenuImage.sprite = starImages[8];
            subMenuImage.sprite = starImages[8];
            phase2MenuImage.sprite = starImages[8];
        }

        else if (animalHappiness >= 100)
        {
            mainMenuImage.sprite = starImages[9];
            subMenuImage.sprite = starImages[9];
            phase2MenuImage.sprite = starImages[9];
        }
    }

    public void DisplayStatHappiness(float statHappiness, Image mainMenuStatImage, Image subMenuStatImage)
    {
        if (statHappiness <= 10 && statHappiness <= 19)
        {
            mainMenuStatImage.sprite = starImages[0];
            subMenuStatImage.sprite = starImages[0];
        }

        else if (statHappiness >= 20 && statHappiness <= 29)
        {
            mainMenuStatImage.sprite = starImages[1];
            subMenuStatImage.sprite = starImages[1];
        }

        else if (statHappiness >= 30 && statHappiness <= 39)
        {
            mainMenuStatImage.sprite = starImages[2];
        }

        else if (statHappiness >= 40 && statHappiness <= 49)
        {
            mainMenuStatImage.sprite = starImages[3];
            subMenuStatImage.sprite = starImages[3];
        }

        else if (statHappiness >= 50 && statHappiness <= 59)
        {
            mainMenuStatImage.sprite = starImages[4];
            subMenuStatImage.sprite = starImages[4];
        }

        else if (statHappiness >= 60 && statHappiness <= 69)
        {
            mainMenuStatImage.sprite = starImages[5];
            subMenuStatImage.sprite = starImages[5];
        }

        else if (statHappiness >= 70 && statHappiness <= 79)
        {
            mainMenuStatImage.sprite = starImages[6];
            subMenuStatImage.sprite = starImages[6];
        }

        else if (statHappiness >= 80 && statHappiness <= 89)
        {
            mainMenuStatImage.sprite = starImages[7];
            subMenuStatImage.sprite = starImages[7];
        }

        else if (statHappiness >= 90 && statHappiness <= 99)
        {
            mainMenuStatImage.sprite = starImages[8];
            subMenuStatImage.sprite = starImages[8];
        }

        else if (statHappiness >= 100)
        {
            mainMenuStatImage.sprite = starImages[9];
            subMenuStatImage.sprite = starImages[9];
        }
    }
}
