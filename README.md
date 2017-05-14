# Scrolling-and-offsetting-Background-Tile-in-MonoGame
XNA Game Studio Express: Developing Games for Windows and the Xbox 360 by Joseph Hall (Mixed media product, 2007)

Measure the passage of time in Update method
Track elapsed time since last frame, That records the time that has elapsed since the last call to the update 
Records the time since the game started that tracks the total time that the game has been running.


Create a grid of tiles side by side. Until the screen is filled.
Update the position of the first cell in the background tile grid over time therefore, since other tiles are aligned to the first they will be animated.

The background will scroll to the left at 50 pixels per second. 

It will oscillate up and down, varying its vertical position between 200 pixels up and 200 down in a cycle that repeats roughly every 11 seconds (33 degrees per second). 

The vertical offset is calculated using the sine trigonometric function that takes an angle and returns a value between -1, and +1.

To animate the grid, we simply multiply the maximum vertical distance that we wanted the tiles to move in a given direction (200 pixels) by the value of the sine function.

The result is a number lies between -200 (200 pixels up), +200 (200 pixels down)

