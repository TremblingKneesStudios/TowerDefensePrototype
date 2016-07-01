Components:

Mesh filter
mesh renderer
box collider

resource(script)
nav mesh obstacle
	shape [box]
	carve [x]
		move threshold [0.1]
		time to stationary [0.5]
		carve only stationary [x]