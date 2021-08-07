# SmolTAS
A mod for Smol Ame game which can help make tool assisted speedruns (TAS) for the game, it is still in development. Requires SALT to work

##New in v1.1.1
* Now you can see which mods(from this modpack) are enabled and disabled on the screen
* The coordinates of the player is also visible and can be disabled/enabled by pressing the tilde '~' key

# Mods
This single mod at this moment contains 3 different mods
* [Slow Motion](https://github.com/Sh1r0Yaksha/SmolTAS#slow-motion)
* [Frame advance](https://github.com/Sh1r0Yaksha/SmolTAS#frame-advance)
* [Save and Load Position](https://github.com/Sh1r0Yaksha/SmolTAS#save-and-load-position)

### Slow Motion
This mod pauses the game and makes it run in slow motion.

### Frame Advance
This mod makes the game advance by one game's physics frame (5ms)

### Save and Load Position
This mod saves the players position and time spent in level and then loads it when certain keys are pressed

# How to install

* Download SALT
* Install SALT as given in the instruction
* Download SmolTAS.dll from https://github.com/Sh1r0Yaksha/SmolTAS/releases/tag/1.0.0
* After installing, put the SmolTAS.dll file in the folder "SALT/Mods".

# How to Use

* Pressing 'Left Shift' will pause the game and 'Q' will resume it. If Slow Motion is on, Pressing 'Q' will resume the game at a speed according to the timescale value.

### Slow Motion

* Pressing the alphanumeric key '1' will toggle this mod.
* Pressing function buttons (F2, F3, F4, F5, F6) will change the game's timescale value, so pressing one of those and then holding 'E' makes the game run in slow or fast motion.
* Holding 'E' will resume the game and slow it down according to the timescale value for the time you are holding it.
* 'F2' sets the timescale value to delta time which was before pausing the game, so time will increment in factors of frames of game
* 'F3' sets the timescale value to 0.10, so time will increment in factors of 4-5 ms
* 'F4' sets the timescale value to 1.00, so time will increment normally
* 'F5' decrements the timescale value by 0.1
* 'F6' increments the timescale value by 0.1
* This method is dependent on timescale value so your framerate changes while in slow motion

### Frame Advance

* Pressing the alphanumeric key '2' will toggle this mod.
* 'F' key will advance the game by one frame without changing the timescale value.
* Framerate won't change when 'F' is pressed.

### Save and Load Position

* Pressing the alphanumeric key '3' will toggle this mod.
* Pressing F10 will save player's position
* Pressing F11 will load player's position to the saved place
* If your position is not saved, default load position will be at (0, 0, 0)

# Acknowledgements

* SALT by [MegaPiggy](https://github.com/MegaPiggy/SALT)
* Smol Ame by [KevinCow](https://kevincow.itch.io/smol-ame)
* The Smol Ame speedrunning community [Discord](https://discord.gg/B5SyzgqWjZ)
