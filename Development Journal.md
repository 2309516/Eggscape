# Development Journal
### What sources or references have you identified as relevant to this task?
### Concept
# The Process

## Music
For the music we wanted to create an upbeat horror ambience. We wanted it to be somewhere between horror ambience and the type of music that you can bop your head to as our game isnt a full on horror game and has a fun element to it.

## Scenes 
For the menu, death screen and win screen we used different scenes and coded them to switch between when certain criteria is met. For the canvas background we used an egg texture that was made by Anna on photoshop using the maya UV unwrap. 

The code for the buttons to navigate between the scenes was fairly simple as seen below. It was code we had used before so knew how it worked and how to adapt it.

### RestartScreen.cs
```

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
    
public class RestartGame : MonoBehaviour {
    
    public void Restart() {
        SceneManager.LoadScene(1);
    }
    
} 

```

### PlayGame.cs
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
```
### MainMenu.cs
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }
}
```
### QuitGame.cs
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void doExitGame() {
        Application.Quit();
    }
}

```


- [](itchlink)
- [](gitlink)
- [](youtubelink)

## Reflection

### What Went Well

### What Did Not Go Well

### What would you do differently next time?

## Bibliography


# Documentation

## Declared assets
Kenney (s.d.) Crosshair Pack · Kenney. At: https://kenney.nl/assets/crosshair-pack (Accessed  04/12/2024).

Kitchen Furniture Starterpack | 3D Furniture | Unity Asset Store (s.d.) At: https://assetstore.unity.com/packages/3d/props/furniture/kitchen-furniture-starterpack-209331 (Accessed  04/12/2024).

Floor materials pack v.1 | 2D Floors | Unity Asset Store (s.d.) At: https://assetstore.unity.com/packages/2d/textures-materials/floors/floor-materials-pack-v-1-140435 (Accessed  04/12/2024).

Free 3D Egg Models | TurboSquid (s.d.) At: https://www.turbosquid.com/Search/3D-Models/free/egg (Accessed  04/12/2024).
恐怖 fear | Royalty-free Music (s.d.) At: https://pixabay.com/music/upbeat-fear-14380/ (Accessed  04/12/2024).

microwave ding | Royalty-free Music (s.d.) At: https://pixabay.com/sound-effects/microwave-ding-104123/ (Accessed  04/12/2024).

怖いもの見たさ I’ve seen scary things | Royalty-free Music (s.d.) At: https://pixabay.com/music/beats-ix27ve-seen-scary-things-151751/ (Accessed  04/12/2024).




# Implementation

## What was the process of completing the task? What influenced your decision making?

## What was the process of completing the task at hand? Did you do any initial planning?

## Did you receive any feedback from users, peers or lecturers? How did you react to it?
The feedback we recieved was about the lighting in the game. The game was too dark to where you couldn't see were going because. Because of how dark the game was, when you dropped the egg it was virtually impossible to find without starting over.

We ended up changing elements of the game off of the back of this feedback. The changes we made were adding more lighting and a light to make the egg glow. We did this because if we added more lighting then we already did to the game the world would be too bright, therefore adding the glowing egg meant we didnt need to ruin the darker aspect of the game.

### What creative or technical approaches did you use or try, and how did this contribute to the outcome?

### Did you have any technical difficulties? If so, what were they and did you manage to overcome them?

# Self Evaluation
## Anna
Due to struggles with code and time management on projects before this one I was late to helping with this game. It took me a while to be able to help with this game, but the work I did do further refined the game as a whole and added finishing touches. I also added my own egg texture which I created with the knowledge I gained from 3D, and used this as the cover art, making simplistic and straightforward interactible screens.

I know I could have done more for this project, and regret not sorting my prior assignments out sooner. If I had done I would have been more of an aid for this project. 

## Bradley