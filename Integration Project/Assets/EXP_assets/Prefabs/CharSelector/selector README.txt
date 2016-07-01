HeroMenuManager:
menu manager (script)
	menu parent [grid] (child of MenuCanvas)
	menu item prefab [MenuItem]
	menu canvas [MenuCanvas]

==----==

MenuItem:
rect transform
MenuItem (script)
	all items are in children
layout element
	all false

==----==

MenuCanvas:
rect transform
canvas
canvas scaler
	ui scale mode [scale w/ screen size]

graphic raycaster

==----==

Hero:
mesh filter
mesh renderer
capsule collider
hero stats (script)
nav mesh agent
	agent size
		radius [0.5]
		height [2]
		base offset [1]

	steering
		autobraking [x]

	obstacle avoidance
		quality [high]

player control (script)
	move surface layermask
		default [x]
		transparentfx [x]
		ignore raycast [ ]
		water [x]
		ui [x]
		resource [x]

	move speed [5]
	nav mesh agent [Hero]

player resources (script)
	mine rate [0.2]
	max mine dist [2]
	resource layer mask [Resource]

==----==

Grid (child of MenuCanvas):
rect transform
grid layout group
	padding
		left [0]
		right [0]
		top [40]
		bottom [0]
	
	cell size [270 | 100]
	start corner [upper left]
	start axis [horizontal]
	child alignment [middle center]
	constraint [flexible]